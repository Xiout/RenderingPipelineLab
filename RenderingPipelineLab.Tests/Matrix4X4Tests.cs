using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderingPipelineLab.Tests
{
    [TestFixture]
    public class Matrix4X4Tests
    {
        [TestCase(
            new float[] { 1.0f, -2.0f, 3.0f, 4.5f }, new float[] { 2.0f, 3.0f, -1.0f, 0.0f }, new float[] { 5.0f, -1.0f, 7.0f, 1.0f }, new float[] { 0.0f, 0.0f, -4.0f, 8.0f },
            new float[] { -1.0f, 2.0f, -3.0f, 4.0f }, new float[] { 4.0f, -2.0f, 1.0f, 0.0f }, new float[] { -5.0f, 0.0f, 2.0f, -1.0f }, new float[] { 3.0f, 1.0f, 0.0f, -3.0f },
            new float[] { 0.0f, 0.0f, 0.0f, 8.5f }, new float[] { 6.0f, 1.0f, 0.0f, 0.0f }, new float[] { 0.0f, -1.0f, 9.0f, 0.0f }, new float[] { 3.0f, 1.0f, -4.0f, 5.0f }
        )]
        public void Test_Add(float[] MatARow0,float[] MatARow1, float[] MatARow2, float[] MatARow3,
                             float[] MatBRow0, float[] MatBRow1, float[] MatBRow2, float[] MatBRow3,
                             float[] expRow0 , float[] expRow1 , float[] expRow2 , float[] expRow3)
        {
            // Arrange
            Matrix4X4 matA = new Matrix4X4(MatARow0, MatARow1, MatARow2, MatARow3);
            Matrix4X4 matB = new Matrix4X4(MatBRow0, MatBRow1, MatBRow2, MatBRow3);
            Matrix4X4 expectedResult = new Matrix4X4(expRow0, expRow1, expRow2, expRow3);

            // Act
            Matrix4X4 result = Matrix4X4.Add(matA, matB);

            // Assert
            StringBuilder sb = new StringBuilder();
            bool isEqual = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (result.GetElement(i, j) != expectedResult.GetElement(i, j))
                    {
                        sb.Append($"row {i} column {j}, expected: {expectedResult.GetElement(i, j)} but was: {result.GetElement(i,j)}\n");
                        isEqual = false;
                    }
                }
            }

            Assert.IsTrue( isEqual , sb.ToString());
        }

        [TestCase(
            new float[] { 2.0f, 1.0f, 1.0f, 0.0f }, new float[] { 0.0f, 3.0f, 1.0f, 0.0f }, new float[] { 1.0f, 0.0f, 2.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 1.0f },
            new float[] { 3.0f, 2.0f, 1.0f, 0.0f }, new float[] { 1.0f, 2.0f, 3.0f, 0.0f }, new float[] { 2.0f, 1.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 1.0f },
            new float[] { 9.0f, 7.0f, 5.0f, 0.0f }, new float[] { 5.0f, 7.0f, 9.0f, 0.0f }, new float[] { 7.0f, 4.0f, 1.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 1.0f }
            )]
        [TestCase(
            new float[] { 1.0f, -2.0f, 3.0f, 4.5f }, new float[] { 2.0f, 3.0f, -1.0f, 0.0f }, new float[] { 5.0f, -1.0f, 7.0f, 1.0f }, new float[] { 0.0f, 0.0f, -4.0f, 8.0f },
            new float[] { -1.0f, 2.0f, -3.0f, 4.0f }, new float[] { 4.0f, -2.0f, 1.0f, 0.0f }, new float[] { -5.0f, 0.0f, 2.0f, -1.0f }, new float[] { 3.0f, 1.0f, 0.0f, -3.0f },
            new float[] { -10.5f, 10.5f, 1.0f, -12.5f }, new float[] { 15.0f, -2.0f, -5.0f, 9.0f }, new float[] { -41.0f, 13.0f, -2.0f, 10.0f }, new float[] { 44.0f, 8.0f, -8.0f, -20.0f }
        )]
        [TestCase(
            new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f },
            new float[] { 1.0f, 2.0f, 3.0f, 4.0f }, new float[] { 5.0f, 6.0f, 7.0f, 8.0f }, new float[] { 9.0f, 10.0f, 11.0f, 12.0f }, new float[] { 13.0f, 14.0f, 15.0f, 16.0f },
            new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }
        )]//With Zero Matrix
        [TestCase(
            new float[] { 1.0f, 2.0f, 3.0f, 4.0f }, new float[] { 5.0f, 6.0f, 7.0f, 8.0f }, new float[] { 9.0f, 10.0f, 11.0f, 12.0f }, new float[] { 13.0f, 14.0f, 15.0f, 16.0f },
            new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 0.0f }
        )]//With Zero Matrix
        [TestCase(
            new float[] { 1.0f, 2.0f, 3.0f, 4.0f }, new float[] { 5.0f, 6.0f, 7.0f, 8.0f }, new float[] { 9.0f, 10.0f, 11.0f, 12.0f }, new float[] { 13.0f, 14.0f, 15.0f, 16.0f },
            new float[] { 1.0f, 0.0f, 0.0f, 0.0f }, new float[] { 0.0f, 1.0f, 0.0f, 0.0f }, new float[] { 0.0f, 0.0f, 1.0f, 0.0f }, new float[] { 0.0f, 0.0f, 0.0f, 1.0f },
            new float[] { 1.0f, 2.0f, 3.0f, 4.0f }, new float[] { 5.0f, 6.0f, 7.0f, 8.0f }, new float[] { 9.0f, 10.0f, 11.0f, 12.0f }, new float[] { 13.0f, 14.0f, 15.0f, 16.0f }
        )]//Identity

        public void Test_Multiply(float[] MatARow0, float[] MatARow1, float[] MatARow2, float[] MatARow3,
                                  float[] MatBRow0, float[] MatBRow1, float[] MatBRow2, float[] MatBRow3,
                                  float[] expRow0 , float[] expRow1 , float[] expRow2 , float[] expRow3)
        {
            // Arrange
            Matrix4X4 matA = new Matrix4X4(MatARow0, MatARow1, MatARow2, MatARow3);
            Matrix4X4 matB = new Matrix4X4(MatBRow0, MatBRow1, MatBRow2, MatBRow3);
            Matrix4X4 expectedResult = new Matrix4X4(expRow0, expRow1, expRow2, expRow3);

            // Act
            Matrix4X4 result = Matrix4X4.Multiply(matA, matB);

            // Assert
            StringBuilder sb = new StringBuilder();
            bool isEqual = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (result.GetElement(i, j) != expectedResult.GetElement(i, j))
                    {
                        sb.Append($"row {i} column {j}, expected: {expectedResult.GetElement(i, j)} but was: {result.GetElement(i, j)}\n");
                        isEqual = false;
                    }
                }
            }

            Assert.IsTrue(isEqual, sb.ToString());
        }

        [TestCase(1.0f, 2.0f, 3.0f, 5.0f, -3.0f, 2.0f, 6.0f, -1.0f, 5.0f)]
        [TestCase(-4.0f, 7.0f, 1.0f, 0.0f, 0.0f, 0.0f, -4.0f, 7.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 10.0f, 20.0f, 30.0f, 10.0f, 20.0f, 30.0f)]
        [TestCase(3.0f, -5.0f, 8.0f, -3.0f, 3.0f, -8.0f, 0.0f, -2.0f, 0.0f)]
        [TestCase(-1.0f, -1.0f, -1.0f, 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(10.0f, 5.0f, -3.0f, -10.0f, -5.0f, 3.0f, 0.0f, 0.0f, 0.0f)]
        public void Test_Translation(float vecAx, float vecAy, float vecAz,
                                  float tx, float ty, float tz,
                                  float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecT = new Vector3D(tx, ty, tz);
            Matrix4X4 matT = Matrix4X4.GetTranslateMatrix(vecT);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act 
            Vector3D result = Matrix4X4.ApplyTransformMatrix(matT, vecA);

            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(1.0f, 2.0f, 3.0f, 2.0f, -3.0f, 0.5f, 2.0f, -6.0f, 1.5f)]
        [TestCase(0.0f, 0.0f, 0.0f, 10.0f, 20.0f, 30.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(-1.0f, -1.0f, -1.0f, -2.0f, 3.0f, 4.0f, 2.0f, -3.0f, -4.0f)]
        [TestCase(10.0f, -5.0f, 2.0f, 0.1f, 2.0f, -3.0f, 1.0f, -10.0f, -6.0f)]
        [TestCase(3.0f, 7.0f, -9.0f, 1.0f, 0.0f, -1.0f, 3.0f, 0.0f, 9.0f)]
        [TestCase(4.5f, 6.2f, -3.1f, 0.0f, 1.0f, -0.5f, 0.0f, 6.2f, 1.55f)]
        public void Test_Scaling(float vecAx, float vecAy, float vecAz,
                                  float sx, float sy, float sz,
                                  float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecS = new Vector3D(sx, sy, sz);
            Matrix4X4 matS = Matrix4X4.GetScalingMatrix(vecS);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act 
            Vector3D result = Matrix4X4.ApplyTransformMatrix(matS, vecA);

            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(0.0f, 1.0f, 0.0f, MathF.PI/2.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 2.0f, 3.0f, MathF.PI/4.0f, 1.0f, 0.7071f, 3.5355f)]
        public void Test_RotationX(float vecAx, float vecAy, float vecAz, float angle, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Matrix4X4 matRx = Matrix4X4.GetRotationMatrix_XAxis(angle);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act 
            Vector3D result = Matrix4X4.ApplyTransformMatrix(matRx, vecA);

            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(1.0f, 0.0f, 0.0f, MathF.PI/2.0f, 0.0f, 0.0f, -1.0f)]
        [TestCase(3.0f, 2.0f, 1.0f, MathF.PI/6.0f, 2.5981f, 2.0f, -0.2321f)]
        public void Test_RotationY(float vecAx, float vecAy, float vecAz, float angle, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Matrix4X4 matRy = Matrix4X4.GetRotationMatrix_YAxis(angle);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act 
            Vector3D result = Matrix4X4.ApplyTransformMatrix(matRy, vecA);

            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(1.0f, 0.0f, 0.0f, MathF.PI/2.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(1.0f, 2.0f, 3.0f, MathF.PI/3.0f, -0.7321f, 2.5981f, 3.0f)]
        public void Test_RotationZ(float vecAx, float vecAy, float vecAz, float angle, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Matrix4X4 matRz = Matrix4X4.GetRotationMatrix_ZAxis(angle);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act 
            Vector3D result = Matrix4X4.ApplyTransformMatrix(matRz, vecA);

            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

    }
}
