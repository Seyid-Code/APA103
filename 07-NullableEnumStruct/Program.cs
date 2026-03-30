using System;

namespace CafeOrderSystem
{
    enum DrinkType
    {
        Coffee = 0,
        Tea = 1,
        Juice = 2,
        Water = 3
    }

    enum DrinkSize
    {
        Small = 0,
        Medium = 1,
        Large = 2
    }

    enum OrderStatus
    {
        New = 0,
        Preparing = 1,
        Ready = 2,
        Delivered = 3
    }
    class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }
        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
            Status = OrderStatus.New;
            Price = CalculatePrice();
        }
        public decimal CalculatePrice()
        {
            switch (Drink)
            {
                case DrinkType.Coffee:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 3;
                        case DrinkSize.Medium: return 4;
                        case DrinkSize.Large: return 5;
                    }
                    break;
                case DrinkType.Tea:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 2;
                        case DrinkSize.Medium: return 3;
                        case DrinkSize.Large: return 4;
                    }
                    break;
                case DrinkType.Juice:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 4;
                        case DrinkSize.Medium: return 5;
                        case DrinkSize.Large: return 6;
                    }
                    break;
                case DrinkType.Water:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 1;
                        case DrinkSize.Medium: return 1.5m;
                        case DrinkSize.Large: return 2;
                    }
                    break;
            }
            return 0;
        }
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifaris #{OrderNumber} Statusu: {Status}");
        }
        public void DisplayOrder()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("       Sifariş Detalları");
            Console.WriteLine($"Sifaris Nomresi: {OrderNumber}");
            Console.WriteLine($"Musteri: {CustomerName}");
            Console.WriteLine($"İcki: {Drink}");
            Console.WriteLine($"Olçu: {Size}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Qiymet: {Price} AZN");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DrinkOrder order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Preparing);
            order1.UpdateStatus(OrderStatus.Ready);
            order1.UpdateStatus(OrderStatus.Delivered);
            DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            order2.DisplayOrder();
            order2.UpdateStatus(OrderStatus.Ready);
            DrinkOrder order3 = new DrinkOrder(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
            order3.DisplayOrder();
            Console.WriteLine("-------------------------------\n");
            Console.WriteLine("Butun DrinkType Deyerleri:");
            foreach (var dt in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine(dt);
            }
            Console.WriteLine();
            Console.WriteLine("Butun DrinkSize Deyerleri:");
            foreach (var ds in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine(ds);
            }
            Console.WriteLine();
            Console.WriteLine("Butun OrderStatus Deyerleri:");
            foreach (var os in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine(os);
            }
            Console.WriteLine();
            Console.WriteLine($"DrinkType.Coffee.ToString() {DrinkType.Coffee.ToString()}");
            Console.WriteLine($"DrinkSize.Large.ToString() {DrinkSize.Large.ToString()}\n");
            DrinkType parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
            DrinkSize parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");
            Console.WriteLine($"Parsed DrinkType: {parsedDrink}");
            Console.WriteLine($"Parsed DrinkSize: {parsedSize}\n");
            int totalOrders = 3;
            decimal totalAmount = order1.Price + order2.Price + order3.Price;
            Console.WriteLine($"Umumi sifaris sayi: {totalOrders}");
            Console.WriteLine($"1-ci sifaris qiymeti: {order1.Price} AZN");
            Console.WriteLine($"2-ci sifaris qiymeti: {order2.Price} AZN");
            Console.WriteLine($"3-cu sifaris qiymeti: {order3.Price} AZN");
            Console.WriteLine($"Umumi mebleg: {totalAmount} AZN");
        }
    }
}