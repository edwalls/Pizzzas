using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaFactory.Helpers;
using PizzaFactory.Implementation;
using PizzaFactory.Interfaces;
using System.Collections.Generic;

namespace PizzaFactory.Tests
{
    [TestClass]
    public class PizzaKingStoreTests
    {
        protected IFactoryConfigSection _settings;
        protected IPizzaFactory _pizzaFactory;
        protected IPizzaTopFactory _pizzaTopFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            _settings = TestHelpers.GetPizzaFactoryConfig();
            _pizzaFactory = new PizzaKingFactory(_settings);
            _pizzaTopFactory = new PizzaTopFactory(_settings);
        }

        [TestMethod]        
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Null_Settings_Fail()
        {
            var pizzaStore = new PizzaKingStore(null, _pizzaFactory, _pizzaTopFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Null_PizzaFactory_Fail()
        {
            var pizzaStore = new PizzaKingStore(_settings, null, _pizzaTopFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Null_PizzaTopFactory_Fail()
        {
            var pizzaStore = new PizzaKingStore(_settings, _pizzaFactory, null);
        }

        [TestMethod]        
        public void StartProcess_Success()
        {
            var pizzaStore = new PizzaKingStore(_settings, _pizzaFactory, _pizzaTopFactory);
            Assert.IsNotNull(pizzaStore);
        }


    }
}
