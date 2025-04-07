/*
 * Design and Program the classes based on the following requirements.

An IDE supports different types of Programming Languages like C#, C and Java. All the programming languages have the following methods used by the IDE to support adding elements:
1. getUnit() which returns a string
2. getParadigm() which returns a string
3. getName() which returns a string
The getUnit() methods returns the string "Class" or "Function" depending on whether the language is Object Oriented or Procedural.
The getParadigm() methods returns the string "ObjectOriented" or "Procedural" depending on whether the language is Object Oriented or Procedural.
The getName() method returns the name of the language. These methods are used to design the support for the languages in an IDE.

Note: Avoid code duplication
*/

namespace IDECasestudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new();
            ILanguage cSharp = new CSharpLang();
            ILanguage java = new JavaLang();
            ILanguage c = new CLang();

            //ide.CSharp = cSharp;
            //ide.Java = java;
            //ide.C = c;
            ide.Languages.Add(cSharp);
            ide.Languages.Add(java);
            ide.Languages.Add(c);

            ide.DoWork();
        }
    }

    class IDE  //OCP
    {
        //public CSharpLang CSharp { get; set; }
        //public JavaLang Java { get; set; }
        //public CLang C { get; set; }

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();
        public void DoWork()
        {
            foreach (var language in Languages)
            {
                Console.WriteLine(language.GetName());
                Console.WriteLine(language.GetUnit());
                Console.WriteLine(language.GetParadigm());
                Console.WriteLine("--------------------");
            }
            //Console.WriteLine(Java.GetName());
            //Console.WriteLine(Java.GetUnit());
            //Console.WriteLine(Java.GetParadigm());
            //Console.WriteLine("--------------------");
            //Console.WriteLine(C.GetName());
            //Console.WriteLine(C.GetUnit());
            //Console.WriteLine(C.GetParadigm());

        }
    }


    public interface ILanguage
    {
        string GetName();
        string GetUnit();
        string GetParadigm();
    }


    public abstract class ObjectOriented : ILanguage
    {
        public string GetUnit() { return "Class"; }
        public string GetParadigm() { return "Object Oriented"; }

        public abstract string GetName();
        //{
        //    throw new NotImplementedException();
        //}
    }

    public abstract class ProcedureOriented : ILanguage
    {
        public string GetUnit() { return "Function"; }
        public string GetParadigm() { return "Procedural"; }
        public abstract string GetName();
    }

    public class CSharpLang : ObjectOriented
    {
        public override string GetName() { return "C Sharp"; }
    }
    public class JavaLang : ObjectOriented
    {

        public override string GetName() { return "Java"; }
    }
    public class CLang : ProcedureOriented
    {
        public override string GetName() { return "C Language"; }
    }
}
