using NUnit.Framework;
using RenderingPipelineLab;
using System;

namespace RenderingPipelineLab.Tests
{
    [TestFixture]
    public class Vector3DTests
    {
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

    }
}