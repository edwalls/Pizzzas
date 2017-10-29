using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizzzas.Interfaces;
using Pizzzas.Implementation;
using System;

namespace Pizzzas.Tests
{
    [TestClass]
    public class PizzaTopObjectsTests
    {
        protected IPizzaFactorySettings _settings;

        [TestInitialize]
        public void TestInitialize()
        {
            _settings = TestHelpers.GetPizzaSettings();
        }      

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePizzaTop_Description_Empty_Fail()
        {
            var top = new HamAndMushroomsTop(string.Empty, 100, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePizzaTop_CookingTime_Invalid_Fail()
        {
            var top = new HamAndMushroomsTop("Ham and Mushrooms", 0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePizzaTop_Price_Invalid_Fail()
        {
            var top = new HamAndMushroomsTop("Ham and Mushrooms", 100, 0);
        }

        [TestMethod]
        public void Create_HamAndMushroomsTop_Success()
        {
            var top = new HamAndMushroomsTop("Ham and Mushrooms", 100, 2);
            Assert.IsNotNull(top);
            Assert.AreEqual(Constants.TOP_HAM_AND_MUSHROOMS, top.GetTopName());
            Assert.AreEqual(2, top.GetPrice());

        }
    }

}
