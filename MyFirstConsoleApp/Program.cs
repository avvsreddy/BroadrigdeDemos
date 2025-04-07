
using SimpleCalculatorLibrary;


namespace MyFirstConsoleApp
{
    internal class Program //UI
    {
        public static void swapinmem()
        {
            int a, b;
            Console.Write("Enter 1st No.: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd No.: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Before: num1 = " + a + ", num2 = " + b);
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine("After: num1 = " + a + ", num2 = " + b);
        }
        static void Main(string[] args) // UI
        {
            //SwapNumbers();
            swapinmem();
            // accept two numbers, find the sum then display the result
            // Step 1: 
            int fno;
            int sno;
            int sum;

            // Step 2:
            Console.WriteLine("Please enter first number");
            fno = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number");
            sno = int.Parse(Console.ReadLine());

            // Step3:
            //sum = fno + sno; // BLL
            sum = Calculator.FindSum(fno, sno);
            // Step 4:
            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
        }
        public static void SwapNumbers()
        {
            int a, b;
            Console.Write("Enter first number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Before swap: a = " + a + ", b = " + b);
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("After swap: a = " + a + ", b = " + b);
        }

    }


}
