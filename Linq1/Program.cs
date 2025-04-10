namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Extension Methods
            string str = "This is very sensitive data";

            string str1 = str.ToUpper();

            str1 = str.Encrypt();
            str1 = Util.Encrypt(str1);
            //Enumerable
        }
    }


    static class Util
    {
        public static string Encrypt(this string str)
        {
            return "SDFSDR@#$@#$@#$%!@%R$%!@$REWF#$%!#$%#$%$";
        }
    }


    //class ExtendedUtil : Util
    //{

    //}
}
