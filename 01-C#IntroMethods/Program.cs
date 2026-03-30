//1 - ci Task

//using System;
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Birinci ededi daxil edin:");
//        double a = Convert.ToDouble(Console.ReadLine());
//        Console.WriteLine("Ikinci ededi daxil edin:");
//        double b = Convert.ToDouble(Console.ReadLine());
//        RiyaziEmel(a, b);
//    }
//    static void RiyaziEmel(double a, double b)
//    {
//        Console.WriteLine("Toplama: " + (a + b));
//        Console.WriteLine("Cixma: " + (a - b));
//        Console.WriteLine("Vurma: " + (a * b));
//        if (b != 0)
//            Console.WriteLine("Bolme: " + (a / b));
//        else
//            Console.WriteLine("0-a bolmek olmaz");
//    }
//}

//--------------------------------------------------------------------------------------------------------------------------

//2 - ci Task

//using System;
//class Program
//{
//    static void Main()
//    {
//        int[] arr = { 14, 20, 35, 40, 57, 60, 100 };
//        Eded(arr);
//    }

//    static void Eded(int[] arr)
//    {
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] % 2 == 0)
//                Console.WriteLine(arr[i] + " Cut Ededdir");
//            else
//                Console.WriteLine(arr[i] + " Tek Ededdir");
//        }
//    }
//}

//-----------------------------------------------------------------------------------------------------------------------

//3 - cu Task

//using System;
//class Program
//{
//    static void Main()
//    {
//        int[] arr = { 14, 20, 35, 40, 57, 60, 100 };
//        int netice = CemTap(arr);
//        Console.WriteLine("Cem: " + netice);
//    }
//    static int CemTap(int[] arr)
//    {
//        int cem = 0;
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] % 4 == 0 && arr[i] % 5 == 0)
//            {
//                cem += arr[i];
//            }
//        }
//        return cem;
//    }
//}

//-------------------------------------------------------------------------------------------------------------------------

//4 - cu Task

//using System;
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Cumleni Daxil Edin: ");
//        string cumle = Console.ReadLine();
//        Console.Write("Simvolu Daxil Edin: ");
//        char simvol = Convert.ToChar(Console.ReadLine());
//        int say = 0;
//        for (int i = 0; i < cumle.Length; i++)
//        {
//            if (Char.ToLower(cumle[i]) == Char.ToLower(simvol))
//            {
//                say++;
//            }
//        }
//        Console.WriteLine("Simvolun Sayi: " + say);
//    }
//}

//-----------------------------------------------------------------------------------------------------------------------