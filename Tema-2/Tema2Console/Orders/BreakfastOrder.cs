using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Logger;
using Tema2Console.Models;

namespace Tema2Console.Orders
{
    public class BreakfastOrder : Order
    {
        public BreakfastOrder(ILogger logger) 
            :base(logger)
        {
        }

        public override decimal Process(OrderData orderData)
        {
            _logger.Log("Processing Breakfast order...");

            _logger.Log("Validating order parameters...");

            if (!ValidateQuantity(orderData))
            {
                return 0;
            }

            if (!ValidatePrice(orderData))
            {
                return 0;
            }

            if (!ValidateServingDate(orderData, out DateTime pasedServingDate))
            {
                return 0;
            }

            decimal pricePerQuantity = orderData.Quantity * orderData.Price;
            
            if (pasedServingDate >= DateTime.Now.AddDays(7))
            {
                return pricePerQuantity * 0.5m;
            }

            return pricePerQuantity;
        }

        protected override string GetStringType()
        {
            return "Breakfast";
        }
    }
}
