using Tema2Console.Serializer;
using Tema2Console.Factory;

namespace Tema2Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Client...");

            Logger.ILogger logger = new Logger.ConsoleLogger();

            var hotelReception = new HotelReception(logger, new FileReader.FileReader(logger), new OrderSerializer(logger), new OrderFactory(logger));
            hotelReception.ProcessOrder();

            if (hotelReception.FinalPrice == 0)
            {
                Console.WriteLine("No order was processed.");
            }
            else
            {
                Console.WriteLine($"Final price for you order: {hotelReception.FinalPrice} RON");
            }
        }
    }
}
