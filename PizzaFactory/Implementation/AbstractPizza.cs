using PizzaFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Implementation
{
    public abstract class AbstractPizza : IPizza
    {
        protected int _baseCookTime;
        protected string _baseName;
        protected string _description;
        protected double _cookingTimeMultiplier;
        protected double _price;
        protected int _totalCookTime;
        protected double _totalPrice;
        protected List<ITop> _tops;        

        public AbstractPizza(int baseCookTime, string baseName, string description, double cookingTimeMultiplier, double price)
        {
            if(baseCookTime <= 0)
            {
                throw new ArgumentException(string.Format($"{nameof(baseCookTime)} must be greater than 0"));
            }
            _baseCookTime = baseCookTime;

            if(string.IsNullOrEmpty(baseName))
            {
                throw new ArgumentException(string.Format($"{nameof(baseName)} is null or empty"));
            }
            _baseName = baseName;

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException(string.Format($"{nameof(description)} is null or empty"));
            }
            _description = description;

            if (cookingTimeMultiplier <= 0)
            {
                throw new ArgumentException(string.Format($"{nameof(cookingTimeMultiplier)} must be greater than 0"));
            }
            _cookingTimeMultiplier = cookingTimeMultiplier;

            if (price <= 0)
            {
                throw new ArgumentException(string.Format($"{nameof(price)} must be greater than 0"));
            }
            _price = price;

            _tops = new List<ITop>();
        }       

        public void AddTop(ITop newTop)
        {
            if (newTop == null)
            {
                throw new ArgumentException($"{nameof(newTop)} is null");
            }
            _tops.Add(newTop);

            _totalCookTime = _baseCookTime;
            _totalPrice = _price;
            foreach (var top in _tops)
            {
                _totalCookTime += top.GetCookTime();
                _price += top.GetPrice();
            }
            _totalCookTime = (int)(_totalCookTime * _cookingTimeMultiplier);
            
        }

        public virtual string GetDetails()
        {
            string resume = $"Pizza: {_description}";
            double totalPrice = _price;
            foreach (var top in _tops)
            {
                resume += $", {top.GetDetails()}";
                
            }
            resume += Environment.NewLine;
            resume += $"Time spended: {_totalCookTime} ms." + Environment.NewLine;
            resume += $"Price: £{totalPrice}.";

            return resume;
        }

        public int GetCookTime()
        {
            return _totalCookTime;
        }

        public double GetPrice()
        {
            return _totalPrice;
        }
        
    }
}
