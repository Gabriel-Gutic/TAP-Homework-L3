using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Logger;
using Tema2Console.Models;


namespace Tema2Console.Serializer
{
    public class OrderSerializer : IOrderSerializer
    {
        ILogger _logger;
        public OrderSerializer(ILogger logger) 
        { 
            _logger = logger;
        }

        public OrderData DeserializeOrder(string orderJson)
        {
            _logger.Log("Deserializing Order object from json data...");
            OrderData orderData = JsonConvert.DeserializeObject<OrderData>(orderJson, new StringEnumConverter());
            
            if (orderData == null) 
            { 
                orderData = new OrderData();
                orderData.Type = OrderType.Unknown;
            }
            
            return orderData;
        }
    }
}
