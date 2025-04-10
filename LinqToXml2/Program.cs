using System.Xml.Linq;

namespace LinqToXml2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load XML Document 

            XDocument xml = XDocument.Load("XMLFile1.xml");
            // get all book titles and display

            var titles = from book in xml.Descendants("book")
                         where book.Element("genre").Value == "Computer"
                         select book.Element("title").Value;



            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            // get all titles and authors then display

            var titlesAndAuthors = from book in xml.Descendants("book")
                                   select new
                                   {
                                       Title = book.Element("title").Value,
                                       Author = book.Element("author").Value
                                   };


            // find the total worth of all books

            var totalWorth = xml.Descendants("price")
                .Sum(x => double.Parse(x.Value));

            var totalWorth2 = (from price in xml.Descendants("price")
                               select double.Parse(price.Value)).Sum();

            Console.WriteLine(totalWorth);

            // get the costliest book title

            var costliest = (from book in xml.Descendants("book")
                             orderby double.Parse(book.Element("price").Value) descending
                             select book.Element("title").Value).FirstOrDefault();

            Console.WriteLine(costliest);
        }
    }

    //class AuthorAndTitle
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //}
}
