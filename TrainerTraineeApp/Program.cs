namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Organization
    {
        public string Name { get; set; }
    }
    public class Trainer
    {
        //Organization org = new Organization();
        public Organization Org { get; set; }

        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();
    }
    public class Trainee
    {
        public Trainer Trainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
    }

    public class Training
    {
        public Trainer Trainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public Cource Cource { get; set; }

        public int GetTraineesCount() { return 0; }
        public string GetTrainingOrgName() { return null; }
        public int GetTrainingDurationInHrs() { return 0; }
    }
    public class Cource
    {
        public List<Module> Modules { get; set; } = new List<Module>();
    }
    public class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
    public class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
    public class Topic
    {
        public string Name { get; set; }
    }

}
