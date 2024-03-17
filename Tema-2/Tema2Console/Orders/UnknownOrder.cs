using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Logger;
using Tema2Console.Models;

namespace Tema2Console.Orders
{
    public class UnknownOrder : Order
    {
        public UnknownOrder(ILogger logger) 
            :base(logger)
        {
        }

        public override decimal Process(OrderData orderData)
        {
            return 0;
        }

        protected override string GetStringType()
        {
            return "Unknown";
        }
    }
}
