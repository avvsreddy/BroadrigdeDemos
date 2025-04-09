namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept two numbers, find the sum then dislay and repeat

            while (true)
            {
                try
                {
                    int fno;
                    int sno;
                    int sum;
                    Console.WriteLine("Enter First Number");
                    fno = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Second Number");
                    sno = int.Parse(Console.ReadLine());

                    //sum = fno + sno;
                    Calculator calc = new Calculator();
                    sum = calc.Sum(fno, sno);

                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");


                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter only numbers");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Please enter smaller numbers");
                }
                catch (Exception ex)// when (ex is FormatException) // Cath All Block
                {
                    Console.WriteLine(ex.Message);

                    //if (ex is FormatException) 
                    //{

                    //}
                    //else if (ex is OverflowException) 
                    //{

                    //}
                }
                finally
                {
                    Console.WriteLine("In finally block");
                }
            }
        }
    }


    /// <summary>
    /// Will do a basic mathematical calculations
    /// </summary>
    public class Calculator
    {

        /* this is multiline comment
         * sdfsdfasdf
         * sdfsdfasdf
         * sdfsdfasdf
         * sdfasdfasdf
         */



        // should find sum of two non zero non negative and non odd numbers only then store in a file


        /// <summary>
        /// should find sum of two non zero non negative and non odd numbers only
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>sum of two numbers</returns>
        /// <exception cref="ValueZeroInputException"></exception>
        /// <exception cref="NegativeInputException"></exception>
        /// <exception cref="OddNumberInputException"></exception>
        public int Sum(int a, int b) // BLL
        {
            // non zero
            if (a == 0 || b == 0)
            {
                throw new ValueZeroInputException("Please enter non zero numbers only");
            }
            if (a < 0 || b < 0)
            {
                throw new NegativeInputException("Please enter non negative numbers only");
            }
            if (a % 2 != 0 || b % 2 != 0)
            {
                throw new OddNumberInputException("Please enter non odd numbers only");
            }
            string result = $"{a} + {b} = {a + b}";
            ResultRepository repo = new ResultRepository();
            try
            {
                repo.Save(result);
            }
            catch (Exception ex)
            {
                // log the exp using some frameworks like serilog or n log
                UnableToSaveException unableToSaveException = new UnableToSaveException("Unable to save result, try again later", ex);
                throw unableToSaveException;

            }
            return a + b;
        }
    }

    class ResultRepository // DAL
    {
        public void Save(string result)
        {
            File.WriteAllText("d://test//results.txt", result);
        }
    }

    public class UnableToSaveException : ApplicationException
    {
        public UnableToSaveException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }

    public class ValueZeroInputException : ApplicationException
    {
        public ValueZeroInputException(string msg = null) : base(msg)
        {
            //this.Message = msg;
        }
    }

    public class NegativeInputException : ApplicationException
    {
        public NegativeInputException(string msg = null) : base(msg)
        {

        }
    }

    public class OddNumberInputException : ApplicationException
    {
        public OddNumberInputException(string msg = null) : base(msg)
        {

        }
    }
}
