using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizzzas.Helpers;
using Pizzzas.Implementation;
using Pizzzas.Interfaces;
using System.Collections.Generic;

namespace Pizzzas.Tests
{
    [TestClass]
    public class PizzaStoreTests
    {
        protected IPizzaFactorySettings _settings;
        protected IPizzaFactory _pizzaFactory;
        protected IPizzaTopFactory _pizzaTopFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            _settings = TestHelpers.GetPizzaSettings();
            _pizzaFactory = new PizzaFactory(_settings.GeneralSettings, _settings.PizzaBases);
            _pizzaTopFactory = new PizzaTopFactory(_settings.PizzaTops);
        }

        [TestMethod]        
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Null_Settings_Fail()
        {
            var pizzaStore = new PizzzasStore(null, _pizzaFactory, _pizzaTopFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Null_PizzaFactory_Fail()
        {
            var pizzaStore = new PizzzasStore(_settings, null, _pizzaTopFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Null_PizzaTopFactory_Fail()
        {
            var pizzaStore = new PizzzasStore(_settings, _pizzaFactory, null);
        }

        [TestMethod]        
        public void StartProcess_Success()
        {
            var pizzaStore = new PizzzasStore(_settings, _pizzaFactory, _pizzaTopFactory);
            Assert.IsNotNull(pizzaStore);
        }


    }
}
