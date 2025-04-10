namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 23, 56, 34, 23, 6, 7, 234, 75, 76, 2325, 5, 234, 6, 2 };

            // get all single digit numbers in assending order

            // linq expression

            var result1 = from n in numbers
                          where n <= 9 && n >= 0
                          orderby n
                          select n;

            // Lambda Expressions
            var result2 = numbers.Where(n => n >= 0 && n <= 9).OrderBy(x => x);

        }
    }
}
