namespace IDNF6R_Homework
{
    public class Work
    {
        // Automatic Properties
        public string NameOfWork { get; set; }
        public int RequiredTimeInMinutes { get; set; }
        public int MaterialCosts { get; set; }

        // Constructor
        public Work(string nameOfWork, int requiredTimeInMinutes, int materialCosts)
        {
            NameOfWork = nameOfWork;
            RequiredTimeInMinutes = requiredTimeInMinutes;
            MaterialCosts = materialCosts;
        }

        // Properties to calculate Hour and Minute of service time
        public int Hours => RequiredTimeInMinutes / 60;
        public int Minutes => RequiredTimeInMinutes % 60;
    }
}
