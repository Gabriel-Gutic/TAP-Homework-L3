using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Tema2Console.FileReader;
using Tema2Console.Logger;
using Tema2Console.Models;
using Tema2Console.Factory;
using Tema2Console.Orders;
using Tema2Console.Serializer;

namespace Tema2Console
{
    public class HotelReception
    {
        private ILogger _logger;
        private IFileReader _fileReader;
        private IOrderSerializer _orderSerializer;
        private IOrderFactory _orderFactory;

        public decimal FinalPrice { get; set; }

        public HotelReception(ILogger logger, IFileReader fileReader, IOrderSerializer orderSerializer, IOrderFactory orderFactory)
        {
            _logger = logger;
            _fileReader = fileReader;
            _orderSerializer = orderSerializer;
            _orderFactory = orderFactory;
        }

        public void ProcessOrder()
        {
            Console.WriteLine("Start processing...");

            string dataJson = _fileReader.Read();

            var orderData = _orderSerializer.DeserializeOrder(dataJson);

            Order order = _orderFactory.Create(orderData);

            FinalPrice = order.Process(orderData);

            _logger.Log("Rating completed.");
        }
    }
}
