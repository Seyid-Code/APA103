using System;
interface ICalculation
{
    double? Calculate(double a, double b, string op);
}
class Calculation : ICalculation
{
    public double? Calculate(double a, double b, string op)
    {
        switch (op)
        {
            case "+": return a + b;
            case "-": return a - b;
            case "*": return a * b;
            case "/":
                if (b == 0)
                {
                    Console.WriteLine("0-a Bolmek Olmaz!");
                    return null;
                }
                return a / b;
            default:
                Console.WriteLine("Yanlis Emeliyyat!");
                return null;
        }
    }
}
class Program
{
    static void Main()
    {
        Calculation calc = new Calculation();

        Console.Write("Ilk Ededi Daxil Edin: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Emeliyyati Secin (+ - * /): ");
        string op = Console.ReadLine();

        Console.Write("Ikinci Ededi Daxil Edin: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double? result = calc.Calculate(a, b, op);

        if (result != null)
            Console.WriteLine("Netice: " + result);
    }
}