using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Logger;
using Tema2Console.Models;

namespace Tema2Console.Orders
{
    public class ProductOrder : Order
    {
        public ProductOrder(ILogger logger) 
            :base(logger)
        {
        }

        public override decimal Process(OrderData orderData)
        {
            _logger.Log("Processing Product order...");

            _logger.Log("Validating order parameters...");

            if (!ValidateName(orderData))
            {
                return 0;
            }

            if (!ValidateQuantity(orderData))
            {
                return 0;
            }

            if (!ValidatePrice(orderData))
            {
                return 0;
            }

            var price = orderData.Quantity * orderData.Price;
            if (orderData.Name == "Fanta")
            {
                price *= 0.75m;
            }

            return price;
        }

        protected override string GetStringType()
        {
            return "Product";
        }
    }
}
