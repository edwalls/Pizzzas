using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Helpers
{
    public class FactoryConfigSection : ConfigurationSection
    {
        
        [ConfigurationProperty("GeneralSettings", IsRequired = true)]
        public GeneralSettingsElement GeneralSettings
        {
            get => (GeneralSettingsElement) this["GeneralSettings"]; set => this["GeneralSettings"] = value;
        }

        [ConfigurationProperty("PizzaBaseCollection", IsRequired = true)]        
        public PizzaBaseCollection PizzaBaseCollection
        {
            get => (PizzaBaseCollection)this["PizzaBaseCollection"]; set => this["PizzaBaseCollection"] = value;
        }

        [ConfigurationProperty("PizzaTopCollection", IsRequired = true)]        
        public PizzaTopCollection PizzaTopCollection
        {
            get => (PizzaTopCollection) this["PizzaTopCollection"]; set => this["PizzaTopCollection"] = value;
        }        
    }

    public class PizzaBaseCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PizzaBaseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PizzaBaseElement)element).Name;
        }
    }

    public class PizzaTopCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PizzaTopElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PizzaTopElement)element).Name;
        }
    }

    public class GeneralSettingsElement : ConfigurationElement, IGeneralSettings
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
        [ConfigurationProperty("NumPizzaBases", IsRequired = true)]
        public int NumPizzaBases
        {
            get => (int)this["NumPizzaBases"]; set => this["NumPizzaBases"] = value;
        }
        [ConfigurationProperty("NumPizzaTops", IsRequired = true)]
        public int NumPizzaTops
        {
            get => (int)this["NumPizzaTops"]; set => this["NumPizzaTops"] = value;
        }
    }

    

    public class PizzaBaseElement : ConfigurationElement, IPizzaSettings
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

    public class PizzaTopElement : ConfigurationElement, IPizzaTopSettings
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
