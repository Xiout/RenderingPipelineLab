using NUnit.Framework;
using RenderingPipelineLab;
using System;

namespace RenderingPipelineLab.Tests
{
    [TestFixture]
    public class Vector3DTests
    {
        public const float EPSILON = 1e-6f;

        [TestCase(1.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 1.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 1.0f)]
        [TestCase(3.0f, 4.0f, 0.0f, 5.0f)]
        [TestCase(1.0f, 1.0f, 1.0f, 1.7320508f)]
        [TestCase(2.0f, 3.0f, 6.0f, 7.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(2.0f, 1.0f, 2.0f, 3.0f)]
        [TestCase(-1.0f, -1.0f, -1.0f, 1.7320508f)]
        [TestCase(-1.0f, -2.0f, -2.0f, 3.0f)]
        [TestCase(1.0f, 2.0f, 3.0f, 3.7416575f)]
        public void Test_Magnitude(float vecAx, float vecAy, float vecAz, float expectedResult)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);

            // Assert
            Assert.AreEqual(expectedResult, vecA.Magnitude);
        }

        [TestCase(1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f)]   
        [TestCase(1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f)] 
        [TestCase(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 32.0f)]  
        [TestCase(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 3.0f)]   
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 0.0f)]  //with zero vector 
        [TestCase(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 32.0f)]  
        [TestCase(1.0f, 2.0f, 3.0f, -1.0f, -2.0f, -3.0f, -14.0f)]
        [TestCase(2.0f, 3.0f, 4.0f, 1.0f, 1.0f, 1.0f, 9.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f, 0.0f, -1.0f, -1.0f)] 
        [TestCase(2.0f, 3.0f, 4.0f, 4.0f, 3.0f, 2.0f, 25.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f)] //orthogonal (unit vectors)
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f)] //orthogonal (unit vectors)
        [TestCase(1.0f, 2.0f, 3.0f, -2.0f, 1.0f, 0.0f, 0.0f)] //orthogonal
        public void Test_DotProduct(float vecAx, float vecAy, float vecAz, float vecBx, float vecBy, float vecBz, float expectedResult)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecB = new Vector3D(vecBx, vecBy, vecBz);

            // Assert
            Assert.AreEqual(expectedResult, Vector3D.DotProduct(vecA, vecB));
        }

        [TestCase(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f)]  
        [TestCase(2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, -3.0f, 6.0f, -3.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f)]  //with zero vector
        [TestCase(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, -3.0f, 6.0f, -3.0f)]
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 0.0f, 0.0f)]  
        [TestCase(1.0f, -2.0f, 6.0f, 1.0f, -2.0f, 6.0f, 0.0f, 0.0f, 0.0f)] //Same vectors
        [TestCase(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, -3.0f, 6.0f, -3.0f)]
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f)]  //with zero vector
        [TestCase(1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(1.0f, 2.0f, 3.0f, 2.0f, 4.0f, 6.0f, 0.0f, 0.0f, 0.0f)]  // Colinear
        [TestCase(1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, 0.0f, 0.0f, 0.0f)] // Colinear
        public void Test_CrossProduct(float vecAx, float vecAy, float vecAz, float vecBx, float vecBy, float vecBz, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecB = new Vector3D(vecBx, vecBy, vecBz);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act
            Vector3D result = Vector3D.CrossProduct(vecA, vecB);

            // Assert
            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, true)] 
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, true)] 
        [TestCase(1.0f, 2.0f, 3.0f, -3.0f, 2.0f, 1.0f, false)]
        [TestCase(1.0f, 1.0f, 1.0f, -1.0f, -1.0f, 1.0f, false)] 
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, true)] //zero vector
        [TestCase(3.0f, -2.0f, 1.0f, 4.0f, 3.0f, -2.0f, false)] 
        [TestCase(2.0f, -1.0f, 3.0f, 1.0f, 2.0f, 4.0f, false)]
        [TestCase(5.0f, 0.0f, 0.0f, 0.0f, 5.0f, 0.0f, true)]

        [TestCase(1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, false)] //colinear
        [TestCase(3.0f, 5.0f, 7.0f, 6.0f, 10.0f, 14.0f, false)] //colinear
        [TestCase(2.0f, 3.0f, 4.0f, 4.0f, 6.0f, 8.0f, false)]  //colinear
        public void Test_IsOrthogonal(float vecAx, float vecAy, float vecAz, float vecBx, float vecBy, float vecBz, bool expectedResult)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecB = new Vector3D(vecBx, vecBy, vecBz);

            Assert.AreEqual(expectedResult, vecA.isOrthogonal(vecB));
        }

        [TestCase(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, false)] //orthogonal
        [TestCase(0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, false)] //orthogonal
        [TestCase(5.0f, 0.0f, 0.0f, 0.0f, 5.0f, 0.0f, false)] //orthogonal
        [TestCase(1.0f, 2.0f, 3.0f, 2.0f, 4.0f, 6.0f, true)]  
        [TestCase(1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, true)]
        [TestCase(3.0f, 5.0f, 7.0f, 6.0f, 10.0f, 14.0f, true)] 
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, true)] //zero vector
        [TestCase(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, false)]
        [TestCase(2.0f, 3.0f, 4.0f, -4.0f, 3.0f, 2.0f, false)] 
        [TestCase(2.0f, 3.0f, 4.0f, 4.0f, 6.0f, 8.0f, true)]
        public void Test_IsColinear(float vecAx, float vecAy, float vecAz, float vecBx, float vecBy, float vecBz, bool expectedResult)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecB = new Vector3D(vecBx, vecBy, vecBz);

            Assert.AreEqual(expectedResult, vecA.isColinear(vecB));
        }

        [TestCase(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 5.0f, 7.0f, 9.0f)] 
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f, 2.0f, 3.0f, 1.0f, 2.0f, 3.0f)]  // Adding zero vector
        [TestCase(-1.0f, -2.0f, -3.0f, 1.0f, 2.0f, 3.0f, 0.0f, 0.0f, 0.0f)]  // Opposite vectors
        [TestCase(2.5f, 3.5f, 4.5f, 1.5f, 2.5f, 3.5f, 4.0f, 6.0f, 8.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 0.0f)]
        [TestCase(5.0f, 7.0f, 9.0f, -2.0f, -3.0f, -4.0f, 3.0f, 4.0f, 5.0f)]  // Adding negative and positive vectors
        [TestCase(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f)]  // Adding two zero vectors
        public void Test_Add(float vecAx, float vecAy, float vecAz, float vecBx, float vecBy, float vecBz, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecB = new Vector3D(vecBx, vecBy, vecBz);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act
            Vector3D result = Vector3D.Add(vecA, vecB);

            // Assert
            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(4.0f, 5.0f, 6.0f, 1.0f, 2.0f, 3.0f, 3.0f, 3.0f, 3.0f)]
        [TestCase(1.0f, 2.0f, 3.0f, 1.0f, 2.0f, 3.0f, 0.0f, 0.0f, 0.0f)]  // Subtracting identical vectors
        [TestCase(0.0f, 0.0f, 0.0f, 1.0f, 2.0f, 3.0f, -1.0f, -2.0f, -3.0f)]  // Subtracting a vector from zero vector
        [TestCase(1.0f, 2.0f, 3.0f, 0.0f, 0.0f, 0.0f, 1.0f, 2.0f, 3.0f)]  // Subtracting zero vector from a vector
        [TestCase(2.5f, 3.5f, 4.5f, 1.5f, 2.5f, 3.5f, 1.0f, 1.0f, 1.0f)]
        [TestCase(5.0f, 7.0f, 9.0f, -2.0f, -3.0f, -4.0f, 7.0f, 10.0f, 13.0f)]  // Subtracting a negative vector
        [TestCase(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f)]  // Subtracting two zero vectors
        public void Test_Substract(float vecAx, float vecAy, float vecAz, float vecBx, float vecBy, float vecBz, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D vecB = new Vector3D(vecBx, vecBy, vecBz);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act
            Vector3D result = Vector3D.Substract(vecA, vecB);

            // Assert
            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(1.0f, 2.0f, 3.0f, 2.0f, 2.0f, 4.0f, 6.0f)] 
        [TestCase(1.0f, 2.0f, 3.0f, -1.0f, -1.0f, -2.0f, -3.0f)]
        [TestCase(1.0f, 2.0f, 3.0f, 0.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(2.5f, 3.5f, 4.5f, 2.0f, 5.0f, 7.0f, 9.0f)]
        [TestCase(1.0f, 0.0f, 0.0f, 3.0f, 3.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f)]
        [TestCase(-1.0f, -2.0f, -3.0f, 3.0f, -3.0f, -6.0f, -9.0f)]
        public void Test_MultiplyScalar(float vecAx, float vecAy, float vecAz, float k, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act
            Vector3D result = Vector3D.MultiplyScalar(vecA, k);

            // Assert
            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [TestCase(3.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f)]
        [TestCase(0.0f, 4.0f, 0.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 1.0f)]
        [TestCase(1.0f, 2.0f, 2.0f, 0.33333334f, 0.6666667f, 0.6666667f)] 
        [TestCase(-1.0f, -1.0f, -1.0f, -0.57735026f, -0.57735026f, -0.57735026f)] 
        [TestCase(1.0f, 1.0f, 1.0f, 0.57735026f, 0.57735026f, 0.57735026f)] 
        public void Test_Normalized(float vecAx, float vecAy, float vecAz, float expX, float expY, float expZ)
        {
            // Arrange
            Vector3D vecA = new Vector3D(vecAx, vecAy, vecAz);
            Vector3D expectedResult = new Vector3D(expX, expY, expZ);

            // Act
            Vector3D result = vecA.Normalized;
            float magnitude = result.Magnitude;

            // Assert
            Assert.IsTrue((1.0 - magnitude < EPSILON), $"Magnitude of Normalized vector should be 1 but was {magnitude}");
            Assert.AreEqual(expectedResult, result, $"Expected: ({expX},{expY},{expZ}) But was: ({result.X},{result.Y},{result.Z})");
        }

        [Test]
        public void Test_Normalized_VectorZero() { 
            // Arrange
            Vector3D vecZero = Vector3D.Zero;

            // Act
            Vector3D result = vecZero.Normalized;

            // Assert
            Assert.IsNull(result, "Vector Zero cannot be normalized");
        }

    }
}