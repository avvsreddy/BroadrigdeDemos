
using SimpleCalculatorLibrary;


namespace MyFirstConsoleApp
{
    internal class Program //UI
    {
        static void Main(string[] args) // UI
        {
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


    }


}
