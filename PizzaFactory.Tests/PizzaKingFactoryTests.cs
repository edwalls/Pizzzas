using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaFactory.Helpers;
using PizzaFactory.Implementation;

namespace PizzaFactory.Tests
{
    [TestClass]
    public class PizzaKingFactoryTests
    {
        private FactoryConfigSection _settings;

        [TestInitialize]
        public void TestInitialize()
        {
            _settings = TestHelpers.GetPizzaFactoryConfig();
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Settings_Null_Fail()
        {
            var factory = new PizzaKingFactory(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Settings_PizzaBaseCollection_Null_Fail()
        {
            _settings.PizzaBaseCollection = null;
            var factory = new PizzaKingFactory(_settings);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Settings_PizzaBaseCollection_Empty_Fail()
        {
            _settings.PizzaBaseCollection = new PizzaBaseCollection();
            var factory = new PizzaKingFactory(_settings);
        }
    }
}
