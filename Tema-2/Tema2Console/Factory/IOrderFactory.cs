using Tema2Console.Models;
using Tema2Console.Orders;


namespace Tema2Console.Factory
{
    public interface IOrderFactory
    {
        public Order Create(OrderData orderData);
    }
}
