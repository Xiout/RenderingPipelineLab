using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderingPipelineLab
{
    public class Vector3D
    {
        //---Static properties

        /// <summary>
        /// Vector wich all coordinates are equal to zero
        /// </summary>
        public static readonly Vector3D Zero = new Vector3D(0.0f, 0.0f, 0.0f);

        //---Members & Properties---
        private float[] _coord;

        public float X
        {
            get { return _coord[0]; }
            private set { _coord[0] = value; }
        }

        public float Y
        {
            get { return _coord[1]; }
            private set { _coord[1] = value; }
        }

        public float Z
        { 
            get { return _coord[2]; }
            private set { _coord[2] = value; }
        }

        /// <summary>
        /// Lenght of the vector
        /// </summary>
        public float Magnitude { get { return MathF.Sqrt(X*X + Y*Y + Z*Z); } }

        /// <summary>
        /// Vector of same direction with magnitude of 1
        /// </summary>
        public Vector3D Normalized { 
            get 
            {
                if (this.Equals(Zero))
                {
                    return null;
                }
                return new Vector3D(X / Magnitude, Y / Magnitude, Z / Magnitude); 
            } 
        }

        //---Constructors---

        public Vector3D(float[] coord)
        {
            _coord = new float[3];
            Array.Copy(coord, _coord, 3);
        }

        public Vector3D(float x, float y, float z)
        {
            _coord = new float[3] { x, y, z };
        }

        public Vector3D(Vector3D vec)
        {
            _coord = new float[3] { vec.X, vec.Y, vec.Z };
        }

        //---Methods---

        /// <summary>
        /// Verify the orthogonality between this vector and another in parameter
        /// </summary>
        public bool isOrthogonal(Vector3D vec)
        {
            return DotProduct(this, vec) == 0;
        }

        /// <summary>
        /// Verify the colinearity between this vector and another in parameter
        /// </summary>
        public bool isColinear(Vector3D vec)
        {
            return CrossProduct(this, vec).Equals(Vector3D.Zero);
        }

        //---Static Methods---

        /// <summary>
        /// Return vector which result of the addition of the two vectors in parameter
        /// </summary>
        public static Vector3D Add(Vector3D vecA, Vector3D vecB)
        {
            return new Vector3D(vecA.X+vecB.X, vecA.Y+vecB.Y, vecA.Z+vecB.Z);
        }

        /// <summary>
        /// Return vector which result of the substraction of the two vectors in parameter
        /// </summary>
        public static Vector3D Substract(Vector3D vecA, Vector3D vecB)
        {
            return new Vector3D(vecA.X - vecB.X, vecA.Y - vecB.Y, vecA.Z - vecB.Z);
        }

        /// <summary>
        /// Return vector which result of the multiplication of the vector and a scalar in parameter
        /// </summary>
        public static Vector3D MultiplyScalar (Vector3D vec, float k)
        {
            return new Vector3D(vec.X*k, vec.Y*k, vec.Z*k);
        }

        /// <summary>
        /// Calculate result of the scalar product between two vectors
        /// </summary>
        public static float DotProduct(Vector3D vecA, Vector3D vecB)
        {
            return vecA.X*vecB.X + vecA.Y*vecB.Y + vecA.Z*vecB.Z;
        }

        /// <summary>
        /// Return vector resulting of the vector product between two vectors
        /// </summary>
        public static Vector3D CrossProduct(Vector3D vecA, Vector3D vecB)
        {
            return new Vector3D(
                    vecA.Y*vecB.Z - vecA.Z*vecB.Y,
                    vecA.Z*vecB.X - vecA.X*vecB.Z,
                    vecA.X*vecB.Y - vecA.Y*vecB.X
                );
        }

        //---Overrides---

        public override bool Equals(object? obj)
        {
            Vector3D other = obj as Vector3D;
            if(other == null) return false;

            return this.X==other.X && this.Y==other.Y && this.Z==other.Z;
        }
    }
}
