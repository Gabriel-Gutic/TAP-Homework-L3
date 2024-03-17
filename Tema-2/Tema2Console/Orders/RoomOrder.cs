using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Logger;
using Tema2Console.Models;

namespace Tema2Console.Orders
{
    public class RoomOrder : Order
    {
        public RoomOrder(ILogger logger) 
            :base(logger)
        {

        }

        public override decimal Process(OrderData orderData)
        {
            _logger.Log("Processing Room order...");

            _logger.Log("Validating order parameters...");

            if (!ValidateQuantity(orderData))
            {
                return 0;
            }

            if (!ValidatePrice(orderData))
            {
                return 0;
            }

            if (!ValidateReservationDate(orderData, out DateTime pasedReservationDate))
            {
                return 0;
            }


            decimal pricePerQuantity = orderData.Quantity * orderData.Price;
            if (pasedReservationDate < DateTime.Now.AddMonths(1))
            {
                return pricePerQuantity * 0.9m;
            }
            else if (pasedReservationDate < DateTime.Now.AddMonths(2))
            {
                return pricePerQuantity * 0.8m;
            }
               
            return pricePerQuantity;
        }

        protected override string GetStringType()
        {
            return "Room";
        }
    }
}
