using PizzaFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Helpers
{
    public class FactoryConfigSection : ConfigurationSection, IFactoryConfigSection
    {
        
        [ConfigurationProperty("GeneralSettings", IsRequired = true)]
        public GeneralSettings GeneralSettings
        {
            get => (GeneralSettings) this["GeneralSettings"]; set => this["GeneralSettings"] = value;
        }

        [ConfigurationProperty("PizzaBaseCollection")]
        [ConfigurationCollection(typeof(PizzaBaseCollection), AddItemName = "Base")]
        public PizzaBaseCollection PizzaBaseCollection
        {
            get => (PizzaBaseCollection)this["PizzaBaseCollection"]; set => this["PizzaBaseCollection"] = value;
        }

        [ConfigurationProperty("PizzaTopCollection")]
        [ConfigurationCollection(typeof(PizzaTopCollection), AddItemName ="Top")]
        public PizzaTopCollection PizzaTopCollection
        {
            get => (PizzaTopCollection) this["PizzaTopCollection"]; set => this["PizzaTopCollection"] = value;
        }

        
    }

    public class GeneralSettings : ConfigurationElement, IGeneralSettings
    {
        [ConfigurationProperty("CookingTimeBase", IsRequired = true)]
        public int CookingTimeBase
        {
            get => (int)this["CookingTimeBase"]; set => this["CookingTimeBase"] = value;
        }

        [ConfigurationProperty("NumTargetPizzas", IsRequired = true)]
        public int NumTargetPizzas
        {
            get => (int)this["NumTargetPizzas"]; set => this["NumTargetPizzas"] = value;
        }
        [ConfigurationProperty("MaxNumTops", IsRequired = true)]
        public int MaxNumTops
        {
            get => (int)this["MaxNumTops"]; set => this["MaxNumTops"] = value;
        }
    }

    public class PizzaBaseCollection : ConfigurationElementCollection, IEnumerable<PizzaBaseElement>
    {
        private List<PizzaBaseElement> elements;

        public PizzaBaseCollection()
        {
            elements = new List<PizzaBaseElement>();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            var element = new PizzaBaseElement();
            elements.Add(element);
            return element;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PizzaBaseElement)element).Name;
        }

        public new IEnumerator<PizzaBaseElement> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        public void SetPizzaBaseList(List<PizzaBaseElement> pizzas)
        {
            elements = pizzas;
        }
    }

    public class PizzaBaseElement : ConfigurationElement, IPizzaBaseElement
    {
        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get => (string)this["Name"]; set => this["Name"] = value;
        }

        [ConfigurationProperty("Description", IsRequired = true)]
        public string Description
        {
            get => (string)this["Description"]; set => this["Description"] = value;
        }

        [ConfigurationProperty("CookingTimeMultiplier", IsRequired = true)]
        public double CookingTimeMultiplier
        {
            get => (double)this["CookingTimeMultiplier"]; set => this["CookingTimeMultiplier"] = value;
        }

        [ConfigurationProperty("Price", IsRequired = true)]
        public double Price
        {
            get => (double)this["Price"]; set => this["Price"] = value;
        }

    }

    public class PizzaTopCollection : ConfigurationElementCollection, IEnumerable<PizzaTopElement>
    {
        private List<PizzaTopElement> elements;

        public PizzaTopCollection()
        {
            this.elements = new List<PizzaTopElement>();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            var element = new PizzaTopElement();
            this.elements.Add(element);
            return element;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PizzaTopElement)element).Top;
        }

        public new IEnumerator<PizzaTopElement> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        public void SetPizzaTopList(List<PizzaTopElement> tops)
        {
            elements = tops;
        }
    }

    public class PizzaTopElement : ConfigurationElement, IPizzaTopElement
    {
        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Top
        {
            get => (string)this["Name"]; set => this["Name"] = value;
        }

        [ConfigurationProperty("Description", IsRequired = true)]
        public string Description
        {
            get => (string)this["Description"]; set => this["Description"] = value;
        }

        [ConfigurationProperty("CookingTime", IsRequired = true)]
        public int CookingTime
        {
            get => (int)this["CookingTime"]; set => this["CookingTime"] = value;
        }

        [ConfigurationProperty("Price", IsRequired = true)]
        public double Price
        {
            get => (double)this["Price"]; set => this["Price"] = value;
        }

    }

}
