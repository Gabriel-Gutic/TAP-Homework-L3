namespace Tema2Console.Models
{
    public class OrderData
    {
        public OrderType Type { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string ReservationDate { get; set; }

        public string Name { get; set; }

        public string ServingDate { get; set; }
    }
}
