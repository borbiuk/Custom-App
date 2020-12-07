using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomBL.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomBL.Controller.Tests
{
    [TestClass()]
    public class CarControllerTests
    {
        [TestMethod()]
        public void CarControllerTest()
        {   
            // Arrange
            

            // Act
            

            // Assert
            Assert.Fail();
        }
        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var mark = Guid.NewGuid().ToString();
            var model = Guid.NewGuid().ToString();
            var price = 8000;
            var year = Convert.ToDateTime("25.12.2012");
            var volume = 3000;
            var typeEngine = 1;

            // Act
            var controller = new CarController(mark, model, price, year, volume, typeEngine);

            // Assert
            Assert.AreEqual(mark, controller.Car.Mark);
            Assert.AreEqual(model, controller.Car.Model);
            Assert.AreEqual(price, controller.Car.Price);
            Assert.AreEqual(year, controller.Car.Year);
            Assert.AreEqual(volume, controller.Car.Volume);
            Assert.AreEqual(typeEngine, controller.Car.TypeEngine);

        }
        [TestMethod()]
        public void ImportDutyTest()
        {   
            // Arrange


            // Act


            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void ExciseTaxTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void MethodVATTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void EndResultTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Fail();
        }
    }
}