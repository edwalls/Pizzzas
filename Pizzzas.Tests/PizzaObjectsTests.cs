using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizzzas.Helpers;
using Pizzzas.Implementation;
using System.Collections.Generic;
using Pizzzas.Interfaces;

namespace Pizzzas.Tests
{
    [TestClass]
    public class PizzaObjectsTests
    {
        protected IPizzaFactorySettings _settings;

        [TestInitialize]
        public void TestInitialize()
        {
            _settings = TestHelpers.GetPizzaSettings();            
        }   

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePizza_CookTime_Invalid_Fail()
        {
            var pizza = new ThinAndCrispyPizza(0,"Very crispy", 1.5,10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePizza_Description_Empty_Fail()
        {
            var pizza = new ThinAndCrispyPizza(3000, string.Empty, 1.5, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePizza_CookingTime_Invalid_Fail()
        {
            var pizza = new ThinAndCrispyPizza(3000, "Very crispy", 0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePizza_Price_Invalid_Fail()
        {
            var pizza = new ThinAndCrispyPizza(3000, "Very crispy", 1.5, 0);
        }

        [TestMethod]
        public void Create_ThinAndCrispy_Success()
        {
            var pizza = new ThinAndCrispyPizza(3000, "Very crispy", 1.5, 10);
            Assert.IsNotNull(pizza);
            Assert.AreEqual(Constants.BASE_THIN_AND_CRISPY, pizza.GetPizzaBaseName());
            Assert.AreEqual(10, pizza.GetPrice());

        }
    }
}
