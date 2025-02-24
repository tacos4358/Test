using System.Collections.Generic;
using System.Linq;

namespace YourMauiProject.Models
{
    public class Tech
    {
        public string Name { get; }
        public List<Patient> AssignedPatients { get; } = new List<Patient>();
        public int TotalWorkload => AssignedPatients.Sum(p => p.Workload);

        public Tech(string name) => Name = name;

        public void AssignPatient(Patient patient) => AssignedPatients.Add(patient);

        public override string ToString()
        {
            return $"{Name} - Total Workload: {TotalWorkload}\n  Patients: {string.Join(", ", AssignedPatients)}";
        }
    }
}
