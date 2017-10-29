using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizzzas.Helpers;
using Pizzzas.Implementation;
using System.Collections.Generic;
using Pizzzas.Interfaces;

namespace Pizzzas.Tests
{
    [TestClass]
    public class PizzaFactoryTests
    {
        protected IPizzaFactorySettings _settings;

        [TestInitialize]
        public void TestInitialize()
        {
            _settings = TestHelpers.GetPizzaSettings();            
        }   

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Settings_Null_Fail()
        {
            var factory = new PizzaFactory(null, _settings.PizzaBases);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Settings_PizzaBaseCollection_Null_Fail()
        {
            _settings.PizzaBases = null;
            var factory = new PizzaFactory(_settings.GeneralSettings, _settings.PizzaBases);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Settings_PizzaBaseCollection_Empty_Fail()
        {
            _settings.PizzaBases = new List<IPizzaSettings>();
            var factory = new PizzaFactory(_settings.GeneralSettings, _settings.PizzaBases);
        }
    }
}
