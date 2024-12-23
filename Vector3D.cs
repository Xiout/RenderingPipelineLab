using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderingPipelineLab
{
    public class Vector3D
    {
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

        public float Magnitude { get { return MathF.Sqrt(X*X + Y*Y + Z*Z); } }

        public Vector3D Normalized { get { return new Vector3D(X / Magnitude, Y / Magnitude, Z / Magnitude); } }

        public static readonly Vector3D Zero = new Vector3D(0, 0, 0);

        public Vector3D(float[] coord)
        {
            _coord = new float[3];
            Array.Copy(coord, _coord, 3);
        }

        public Vector3D(float x, float y, float z)
        {
            _coord = new float[3] { x, y, z };
        }

        public void Add(Vector3D vec)
        {
            X += vec.X;
            Y += vec.Y;
            Z += vec.Z;
        }

        public void Substract(Vector3D vec)
        {
            X -= vec.X;
            Y -= vec.Y;
            Z -= vec.Z;
        }

        public void MultiplyScalar (float k)
        {
            X *= k; 
            Y *= k; 
            Z *= k;
        }

        public bool isOrthogonal(Vector3D vec)
        {
            return DotProduct(this, vec) == 0;
        }

        public bool isColinear(Vector3D vec)
        {
            return CrossProduct(this, vec).Equals(Vector3D.Zero);
        }

        public static float DotProduct(Vector3D vecA, Vector3D vecB)
        {
            return vecA.X*vecB.X + vecA.Y*vecB.Y + vecA.Z*vecB.Z;
        }

        public static Vector3D CrossProduct(Vector3D vecA, Vector3D vecB)
        {
            return new Vector3D(
                    vecA.Y*vecB.Z - vecA.Z*vecB.Y,
                    vecA.Z*vecB.X - vecA.X*vecB.Z,
                    vecA.X*vecB.Y - vecA.Y*vecB.X
                );
        }

        public override bool Equals(object? obj)
        {
            Vector3D other = obj as Vector3D;
            if(other == null) return false;

            return this.X==other.X && this.Y==other.Y && this.Z==other.Z;
        }
    }
}
