namespace CalculatorClassLibrary.Exceptions
{
    public class ZeroInputException : ApplicationException
    {
        public ZeroInputException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }
}
