namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organization organization = new Organization();
            organization.Name = "ABC Organization";

            Trainer trainer = new Trainer();

            trainer.Org = organization;

            Training training = new Training();

            training.Trainer = trainer;

            string orgName = training.GetTrainingOrgName();
            Console.WriteLine($"The Training Organization Name : {orgName}");

            Trainee t1 = new Trainee();
            Trainee t2 = new();
            Trainee t3 = new();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);


            Console.WriteLine($"Trainees Count:  {training.GetTraineesCount()}");


            Unit u1 = new Unit { Duration = 2 };
            Unit u2 = new Unit { Duration = 1 };
            Unit u3 = new Unit { Duration = 4 };
            Unit u4 = new Unit { Duration = 2 };
            Unit u5 = new Unit { Duration = 3 };

            Module m1 = new Module();
            Module m2 = new Module();

            m1.Units.Add(u1);
            m1.Units.Add(u2);
            m1.Units.Add(u3);

            m2.Units.Add(u4);
            m2.Units.Add(u5);

            Cource cource = new Cource();
            cource.Modules.Add(m1);
            cource.Modules.Add(m2);

            training.Cource = cource;







            Console.WriteLine($"Duration: {training.GetTrainingDurationInHrs()}");

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

        public int GetTraineesCount()
        {
            return Trainees.Count();
        }
        public string GetTrainingOrgName()
        {
            return Trainer.Org.Name;
        }
        public int GetTrainingDurationInHrs()
        {
            int totDuration = 0;
            // for each module in a course
            foreach (var module in Cource.Modules)
            {
                // for each unit in a module
                foreach (var unit in module.Units)
                {
                    totDuration += unit.Duration;
                }
            }
            return totDuration;
        }
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
