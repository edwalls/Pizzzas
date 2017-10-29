using Pizzzas.Interfaces;
using System;

namespace Pizzzas.Implementation
{

    /// <summary>
    /// Obtract class for pizza tops that implement the ITop interface
    /// </summary>
    public class AbstractTop : ITop
    {
        protected string _topName;
        protected string _description;
        protected int _cookingTime;
        protected double _price;
        
        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="topName"></param>
        /// <param name="description"></param>
        /// <param name="cookingTime"></param>
        /// <param name="price"></param>
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

        /// <summary>
        /// Get the details for this top for report propouse
        /// </summary>
        /// <returns></returns>
        public virtual string GetDetails()
        {
            return $"{_description} ";
        }

        /// <summary>
        /// Get the cooking time for this top
        /// </summary>
        /// <returns></returns>
        public int GetCookTime()
        {
            return _cookingTime;
        }

        /// <summary>
        /// GEt the price for this top
        /// </summary>
        /// <returns></returns>
        public double GetPrice()
        {
            return _price;
        }

        /// <summary>
        /// Get the TopName 
        /// </summary>
        /// <returns></returns>
        public string GetTopName()
        {
            return _topName;
        }
    }
}
