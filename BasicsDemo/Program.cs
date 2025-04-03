namespace BasicsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arrays
            // store 10 int numbers and process

            int[] numbers = { 1, 2, 3, 4, 5, 6, 45, 34, 76 };

            // find sum of all

            //int sum = 0;
            //foreach (int number in numbers) 
            //{
            //    sum += number;
            //}
            //Console.WriteLine(sum);

            int sum = numbers.Sum();
            double avg = numbers.Average();
            int max = numbers.Max();
            int min = numbers.Min();
            int count = numbers.Count();

            // table: numbers
            // column: number

            // sql: get all even numbers
            // select number from numbers where number mod 2 = 0;

            var evens = from n in numbers where n % 2 == 0 orderby n descending select n; // LINQ

            Array.Sort(numbers);
        }
    }
}
