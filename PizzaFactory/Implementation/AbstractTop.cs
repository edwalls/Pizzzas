using PizzaFactory.Interfaces;
using System;

namespace PizzaFactory.Implementation
{
    public class AbstractTop : ITop
    {
        protected string _topName;
        protected string _description;
        protected int _cookingTime;
        protected double _price;
        

        public AbstractTop(string topName, string description, int cookingTime, double price)
        {
            if (string.IsNullOrEmpty(topName))
            {
                throw new ArgumentException(string.Format($"{nameof(topName)} is null or empty"));
            }
            _topName = topName;

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException(string.Format($"{nameof(description)} is null or empty"));
            }
            _description = description;

            if (cookingTime <= 0)
            {
                throw new ArgumentException(string.Format($"{nameof(cookingTime)} must be greater than 0"));
            }
            _cookingTime = cookingTime;

            if (price <= 0)
            {
                throw new ArgumentException(string.Format($"{nameof(price)} must be greater than 0"));
            }
            _price = price;
        }

        public virtual string GetDetails()
        {
            return $"{_description} ";
        }

        public int GetCookTime()
        {
            return _cookingTime;
        }

        public double GetPrice()
        {
            return _price;
        }
    }
}
