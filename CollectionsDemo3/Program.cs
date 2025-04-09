namespace CollectionsDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Queue and Stack


            // Stack
            // Declare
            Stack<int> numbers = new Stack<int>();

            // add
            numbers.Push(1);
            // read
            int x = numbers.Peek();
            // read and remove
            x = numbers.Pop();

            // Queue
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(x);
            // add

            // read
            x = queue.Dequeue(); // extract and delete
            x = numbers.Pop(); // extract

            // Dictionaries
            Dictionary<int, string> results = new Dictionary<int, string>();
            // add
            results.Add(111, "Pass");

            // read

            string resultof111 = results[111];

            // store days number and day name in dictionary
            Dictionary<int, string> days = new Dictionary<int, string>();
            days.Add(1, "Sunday");
            days.Add(2, "Monday");
            days.Add(3, "Tuesday");
            days.Add(4, "Wednesday");
            days.Add(5, "Thrusday");
            days.Add(6, "Friday");
            days.Add(7, "Saturday");

            int dayNumber = 3;
            string dayname = days[dayNumber];


            // Hashset - unique data
            HashSet<int> uniqueNumbers = new HashSet<int>();

            uniqueNumbers.Add(1);
            uniqueNumbers.Add(1);
            Console.WriteLine(uniqueNumbers.Count);

            // store 100 unique random numbers
            List<int> list = new List<int>();
            list = Enumerable.Range(1, 100).ToList();

            Random rnd = new Random();


            while (uniqueNumbers.Count <= 100)
            {
                int randomNumber = rnd.Next(1, 1000);
                uniqueNumbers.Add(randomNumber);
            }

        }
    }
}
