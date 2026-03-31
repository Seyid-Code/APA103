using System;
class Currency
{
    public double Amount { get; set; }
    public Currency(double amount)
    {
        Amount = amount;
    }
    public void Show()
    {
        Console.WriteLine("Amount: " + Amount);
    }
}
class Dollar : Currency
{
    public Dollar(double amount) : base(amount) { }
    public void ShowDollar()
    {
        Console.WriteLine("Dollar: $" + Amount);
    }
}
class Manat : Currency
{
    public Manat(double amount) : base(amount) { }
    public void ShowManat()
    {
        Console.WriteLine("Manat: " + Amount + " AZN");
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("UPCASTING");
        Currency c1 = new Dollar(100);
        Currency c2 = new Manat(170);
        c1.Show();
        c2.Show();
        Console.WriteLine();
        Console.WriteLine("DOWNCASTING");
        Dollar d = (Dollar)c1;
        Manat m = (Manat)c2;
        d.ShowDollar();
        m.ShowManat();
        Console.WriteLine();
        Console.WriteLine("SAFE CASTING");
        if (c1 is Dollar)
        {
            Dollar d2 = (Dollar)c1;
            d2.ShowDollar();
        }
        Manat m2 = c2 as Manat;
        if (m2 != null)
        {
            m2.ShowManat();
        }
        Console.WriteLine();
        Console.WriteLine("CURRENCY CONVERSION");
        double dollarAmount = 50;
        double manatAmount = dollarAmount * 1.7;
        Console.WriteLine(dollarAmount + " $ = " + manatAmount + " AZN");
        double bigValue = 123.75;
        int rounded = (int)bigValue;
        Console.WriteLine("Explicit casting (double -> int): " + rounded);
        Console.WriteLine();
        Console.WriteLine("ARRAY + LOOP");
        Currency[] list = new Currency[3];
        list[0] = new Dollar(20);
        list[1] = new Manat(34);
        list[2] = new Dollar(75);
        foreach (Currency item in list)
        {
            if (item is Dollar)
            {
                Dollar dd = (Dollar)item;
                dd.ShowDollar();
            }
            else if (item is Manat)
            {
                Manat mm = (Manat)item;
                mm.ShowManat();
            }
        }
    }
}