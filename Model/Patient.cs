namespace YourMauiProject.Models
{
    public class Patient
    {
        public string Name { get; }
        public int Workload { get; }

        public Patient(string name, string vitals, string accucheck, bool incontinent, int needyFactor)
        {
            Name = name;
            Workload = (vitals == "Q4" ? 2 : 1) + (accucheck == "None" ? 1 : 2) + (incontinent ? 2 : 1) + needyFactor;
        }

        public override string ToString() => $"{Name} (Workload: {Workload})";
    }
}
