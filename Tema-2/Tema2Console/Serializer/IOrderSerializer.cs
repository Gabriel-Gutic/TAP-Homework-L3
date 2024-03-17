using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2Console.Models;


namespace Tema2Console.Serializer
{
    public interface IOrderSerializer
    {
        public OrderData DeserializeOrder(string orderJson);
    }
}
