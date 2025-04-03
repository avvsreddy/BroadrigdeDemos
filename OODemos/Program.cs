namespace OODemos
{
    internal class Program : Object
    {
        //Employee e = new Employee(); // HAS-A
        public static void Main(string[] args)
        {
            var a = 10;
            //a = "a";
            var str = "hello";


            Employee employee = new Employee(); // Uses
                                                //employee.name = "Ravi";

            employee.EmpId = 123;
            employee.Name = "Test";
            employee.Salary = 1000;

            //Object Initialization Syntax

            //Employee e2 = new Employee { EmpId=222, Name="aaaa", Salary=78000 };
            var e2 = new { EmpId = 222, Name = "aaaa", Salary = 78000 };
            // Anoymous Objects

            Employee e3 = new Employee { EmpId = 333 };

            Employee e4 = new Employee { EmpId = 444, Name = "abcd" };

            Employee e5 = new Employee { Name = "sdfsdfsdf" };

            //employee.SetEmpId(123);
            //int id = employee.GetEmpId();
            int id = employee.EmpId;
            //employee.salary = 75000;
            Console.WriteLine("Hello, World!");
        }
    }

    class Employee //: Program  // IS-A
    {
        //private int empid;
        //private string name;
        //private int salary;

        //private int backingfieldfsdfsdfsdf83r332434;
        //public void SetEmpId(int id)
        //{
        //    empid = id;
        //}
        //public int GetEmpId() 
        //{
        //    return empid;
        //}


        public int EmpId // Property
        {
            get;// { return empid; }
            set;// { empid = value; }
        }
        public string Name { get; set; }
        public int Salary { get; set; }

        //public Employee(int id)
        //{
        //    EmpId = id;
        //}

        //public Employee(int id, string name):this(id)
        //{
        //    //EmpId = id;
        //    Name = name;
        //}
        //public Employee(int id=0, string name=null, int salary=0) 
        //{
        //    this.EmpId = id;
        //    Name = name;
        //    Salary = salary;
        //}
    }

    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}
