using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RenderingPipelineLab
{
    public class Matrix4X4
    {
        public static readonly Matrix4X4 Identity = new Matrix4X4(1.0f, 0.0f, 0.0f, 0.0f,
                                                                  0.0f, 1.0f, 0.0f, 0.0f,
                                                                  0.0f, 0.0f, 1.0f, 0.0f,
                                                                  0.0f, 0.0f, 0.0f, 1.0f);

        private float[] _coord;

        //---Contructors---
        public Matrix4X4(float[] row0, float[] row1, float[] row2, float[] row3)
        {
            if (row0 == null || row0.Length != 4) { throw new ArgumentException($"Parameter row0 should has a lenght of 4 but was {(row0 == null ? "null" : row0.Length.ToString())}"); }
            if (row1 == null || row1.Length != 4) { throw new ArgumentException($"Parameter row1 should has a lenght of 4 but was {(row1 == null ? "null" : row1.Length.ToString())}"); }
            if (row2 == null || row2.Length != 4) { throw new ArgumentException($"Parameter row2 should has a lenght of 4 but was {(row2 == null ? "null" : row2.Length.ToString())}"); }
            if (row3 == null || row3.Length != 4) { throw new ArgumentException($"Parameter row3 should has a lenght of 4 but was {(row3 == null ? "null" : row3.Length.ToString())}"); }

            List<float> coord = new List<float>();
            coord.AddRange(row0);
            coord.AddRange(row1);
            coord.AddRange(row2);
            coord.AddRange(row3);

            _coord = coord.ToArray();
        }

        public Matrix4X4(float[] coord) 
        { 
            if(coord == null || coord.Length != 16) { throw new ArgumentException($"Parameter coord should has a lenght of 16 but was {(coord == null ? "null" : coord.Length.ToString())}"); }
            _coord = coord;
        }

        private Matrix4X4(float el00, float el01, float el02, float el03,
                         float el10, float el11, float el12, float el13,
                         float el20, float el21, float el22, float el23,
                         float el30, float el31, float el32, float el33)
        {
            _coord = new float[16] { el00, el01, el02, el03, el10, el11, el12, el13, el20, el21, el22, el23, el30, el31, el32, el33 };
        }

        public float GetElement(int row, int column)
        {
            if(row < 0 || row >= 4)
            {
                throw new ArgumentException($"row parameter {row} was out of bound");
            }

            if (column < 0 || column >= 4)
            {
                throw new ArgumentException($"column parameter {column} was out of bound");
            }


            return _coord[row*4+column];
        }

        public static Matrix4X4 Add(Matrix4X4 MatA, Matrix4X4 MatB)
        {
            float[] coord = new float[16];

            for(int i_row = 0; i_row < 4; ++i_row)
            {
                for (int i_col = 0; i_col < 4; ++i_col)
                {
                    coord[i_row*4+i_col] = MatA.GetElement(i_row, i_col) + MatB.GetElement(i_row, i_col);
                }
            }

            return new Matrix4X4(coord);
        }

        public static Matrix4X4 Multiply(Matrix4X4 MatA, Matrix4X4 MatB)
        {
            float[] coord = new float[16];

            for(int row = 0; row < 4; ++row)
            {
                for (int col = 0; col < 4; ++col)
                {
                    float element = 0.0f;
                    for(int i = 0; i < 4; ++i)
                    {
                        element += (float)MatA.GetElement(row, i) * (float)MatB.GetElement(i, col);
                    }
                    coord[row*4+col] = element;
                }
            }

            return new Matrix4X4(coord);
        }

        public static Vector3D ApplyTransformMatrix(Matrix4X4 matTransf, Vector3D vec)
        {
            float[] homogeneousCoord = new float[4] { vec.X, vec.Y, vec.Z, 1.0f };
            float[] result = new float[4];

            for(int row = 0; row < 4; row++)
            {
                float element = 0.0f;
                for (int i = 0; i < 4; i++)
                {
                    element += matTransf.GetElement(row, i) * homogeneousCoord[i];
                }

                result[row] = element;
            }

            return new Vector3D(result[0] / result[3], result[1] / result[3], result[2] / result[3]);
        }

        public static Matrix4X4 GetScalingMatrix(Vector3D scalingVector)
        {
            return new Matrix4X4( scalingVector.X, 0.0f, 0.0f, 0.0f,
                              0.0f, scalingVector.Y, 0.0f, 0.0f,
                              0.0f, 0.0f, scalingVector.Z, 0.0f,
                              0.0f, 0.0f, 0.0f, 1.0f);
        }

        public static Matrix4X4 GetTranslateMatrix(Vector3D translateVector)
        {
            return new Matrix4X4(1.0f, 0.0f, 0.0f, translateVector.X,
                                 0.0f, 1.0f, 0.0f, translateVector.Y,
                                 0.0f, 0.0f, 1.0f, translateVector.Z,
                                 0.0f, 0.0f, 0.0f, 1.0f);
        }

        public static Matrix4X4 GetRotationMatrix_XAxis(float theta)
        {
            return new Matrix4X4(1.0f, 0.0f, 0.0f, 0.0f,
                                 0.0f, MathF.Cos(theta), -MathF.Sin(theta), 0.0f,
                                 0.0f, MathF.Sin(theta), MathF.Cos(theta), 0.0f,
                                 0.0f, 0.0f, 0.0f, 1.0f);
        }

        public static Matrix4X4 GetRotationMatrix_YAxis(float theta)
        {
            return new Matrix4X4(MathF.Cos(theta), 0.0f, MathF.Sin(theta), 0.0f,
                                 0.0f, 1.0f, 0.0f, 0.0f,
                                 -MathF.Sin(theta), 0.0f, MathF.Cos(theta), 0.0f,
                                 0.0f, 0.0f, 0.0f, 1.0f);
        }

        public static Matrix4X4 GetRotationMatrix_ZAxis(float theta)
        {
            return new Matrix4X4(MathF.Cos(theta), -MathF.Sin(theta), 0.0f, 0.0f,
                                 MathF.Sin(theta), MathF.Cos(theta), 0.0f, 0.0f,
                                 0.0f, 0.0f, 1.0f, 0.0f,
                                 0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}
