using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag06.AnimalDemo.Test
{
    [TestClass]
    public class AnimalTest
    {
        //[TestMethod]
        //public void WeightTest()
        //{
        //    // Act
        //    Animal a = new Animal(4.5);
        //    double result = a.Weight;

        //    // Assert
        //    Assert.AreEqual(4.5, result, Double.Epsilon);
        //}

        [TestMethod]
        public void BirdTest()
        {
            // Arrange
            Animal a = new Bird();

            // Act
            double result = a.Weight;

            // Assert
            Assert.AreEqual(0.1, result);
        }

        //[TestMethod]
        //public void DefaultWeightTest()
        //{
        //    // Act
        //    Animal a = new Animal();
        //    double result = a.Weight;

        //    // Assert
        //    Assert.AreEqual(1.0, result, Double.Epsilon);
        //}

        [TestMethod]
        public void MakeNoiseTest()
        {
            Animal bird = new Bird();

            string result = bird.MakeNoise();

            Assert.AreEqual("tjilp tjilp", result);
        }

        [TestMethod]
        public void MakeNoiseElephantTest()
        {
            Animal elephant = new Elephant();

            string result = elephant.MakeNoise();

            Assert.AreEqual("tetterdetet", result);
        }
    }
}
