namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linq to Objects - in-memory collections

            List<int> numbers = new List<int>() { 23, 56, 34, 23, 6, 7, 234, 75, 76, 2325, 5, 234, 6, 2 };

            // extract all even numbers

            // SQL - Table: Numbers, Column: number
            // select number from numbers where number mod 2 = 0

            var result = from number in numbers where number % 2 == 0 select number;

            Func<int, bool> filterDelegate = new Func<int, bool>(IsEven);

            var result2 = numbers.Where(filterDelegate);

            var result3 = numbers.Where(IsEven);


            // Anoymous Delegates

            var result4 = numbers.Where(
                delegate (int number)
                {
                    return number % 2 == 0;
                });

            // Using Labda Statement

            var result5 = numbers.Where(
                (int number) =>
               {
                   return number % 2 == 0;
               });

            // Lambda Expressions- Light Weight Syntax for Anonymous Delegates

            var result6 = numbers.Where(
               (int number) =>

                    number % 2 == 0
               );

            var result7 = numbers.Where(number => number % 2 == 0);

            // Lambda Statements
            // Lambda Expressions

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
