using CalculatorClassLibrary.Exceptions;

namespace CalculatorClassLibrary
{


    // calculator should find the sum of two non-zero, non-negative, non-odd
    // ints and return the result else throw exeption
    public class Calculator
    {
        public int Sum(int a, int b)
        {
            // non zero
            if (a == 0 || b == 0)
                throw new ZeroInputException("Provide Non-Zero Input");

            // non-negative
            if (a < 0 || b < 0) throw new NegativeInputException("Provide Non-Negative Input");

            // non-odd
            if (a % 2 != 0 || b % 2 != 0) throw new OddInputException("Provide Non-Odd Input");

            return a + b;
        }
    }
}
