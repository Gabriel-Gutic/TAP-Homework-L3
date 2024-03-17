using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Logger;
using Tema2Console.Models;

namespace Tema2Console.Orders
{
    public abstract class Order
    {
        protected ILogger _logger;

        protected Order(ILogger logger) 
        { 
            _logger = logger;
        }

        public abstract decimal Process(OrderData orderData);

        protected abstract string GetStringType();

        public bool ValidateName(OrderData orderData)
        {
            if (string.IsNullOrEmpty(orderData.Name))
            {
                _logger.Log("-" + GetStringType() + " order must specify Name");
                return false;
            }
            return true;
        }

        public bool ValidateQuantity(OrderData orderData)
        {
            if (orderData.Quantity == 0) 
            {
                _logger.Log("-" + GetStringType() + " order must specify Quantity");
                return false;
            }
            return true;
        }

        public bool ValidatePrice(OrderData orderData)
        {
            if (orderData.Price == 0)
            {
                _logger.Log("-" + GetStringType() + " order must specify Price");
                return false;
            }
            return true;
        }

        public bool ValidateReservationDate(OrderData orderData, out DateTime result)
        {
            result = DateTime.MinValue;
            if (string.IsNullOrEmpty(orderData.ReservationDate))
            {
                _logger.Log("-" + GetStringType() + " order must specify Reservation Date");
                return false;
            }

            if (!DateTime.TryParseExact(orderData.ReservationDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out result))
            {
                _logger.Log("-Reservation Date must be a valid date");
                return false;
            }

            return true;
        }

        public bool ValidateServingDate(OrderData orderData, out DateTime result)
        {
            result = DateTime.MinValue;
            if (string.IsNullOrEmpty(orderData.ServingDate))
            {
                _logger.Log("-" + GetStringType() + " order must specify Serving Date");
                return false;
            }

            if (!DateTime.TryParseExact(orderData.ServingDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out result))
            {
                _logger.Log("-Serving Date must be a valid date");
                return false;
            }

            return true;
        }
    }
}
