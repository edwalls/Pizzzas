using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizzzas.Interfaces;
using Pizzzas.Implementation;

namespace Pizzzas.Tests
{
    [TestClass]
    public class PizzaTopFactoryTests
    {
        protected IPizzaFactorySettings _settings;

        [TestInitialize]
        public void TestInitialize()
        {
            _settings = TestHelpers.GetPizzaSettings();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_PizzaTops_Null_Fail()
        {
            var factory = new PizzaTopFactory(null);
        }
    }
}
