namespace EnginesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hybrid hybrid = new Hybrid();
            Diesel d = new Diesel();
            hybrid.Engines.Add(d);
            hybrid.Start();
        }
    }

    interface IEngine
    {
        void Start();
        void Stop();
    }

    class Diesel : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Starting Diesel Engine");
        }

        public void Stop()
        {
            Console.WriteLine("Stoping Diesel Engine");
        }
    }
    class Petrol : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Starting Petrol Engine");
        }

        public void Stop()
        {
            Console.WriteLine("Stoping Petrol Engine");
        }
    }

    class Hybrid : IEngine
    {
        //Petrol petrol = new Petrol();
        //Diesel diesel = new Diesel();
        public List<IEngine> Engines { get; set; } = new List<IEngine>();
        public void Start()
        {
            foreach (var item in Engines)
            {
                item.Start();
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
