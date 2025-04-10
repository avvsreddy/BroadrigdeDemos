using System.Xml.Linq;

namespace LinqToXml1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" }

            // get words with 3 or less charectors

            //var shortWords1 = from w in words
            //                  where w.Length <= 3
            //                  select w;


            // Load the XML document
            XDocument xml = XDocument.Load("XMLFile1.xml");

            var shortWords1 = from w in xml.Descendants("word")
                              where w.Value.Length <= 3
                              select w.Value;
        }
    }
}
