using Tema2Console.Logger;
using Tema2Console.Models;
using Tema2Console.Orders;


namespace Tema2Console.Factory
{
    public class OrderFactory : IOrderFactory
    {
        private ILogger _logger;

        public OrderFactory(ILogger logger)
        {
            _logger = logger;
        }

        public Order Create(OrderData orderData)
        {
            switch (orderData.Type)
            {
                case OrderType.Room:
                    return new RoomOrder(_logger);
                case OrderType.Product:
                    return new ProductOrder(_logger);
                case OrderType.Breakfast:
                    return new BreakfastOrder(_logger);
            }

            return new UnknownOrder(_logger);
        }
    }
}
