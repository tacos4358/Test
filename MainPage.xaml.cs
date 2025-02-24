using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace YourMauiProject
{
    public partial class MainPage : ContentPage
    {
        private List<Tech> techs = new List<Tech>
        {
            new Tech("Alice"),
            new Tech("Bob"),
            new Tech("Charlie")
        };
        private List<Patient> patients = new List<Patient>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void AddPatient(object sender, EventArgs e)
        {
            string name = patientNameEntry.Text;
            string vitals = vitalsPicker.SelectedItem?.ToString();
            string accucheck = accucheckPicker.SelectedItem?.ToString();
            bool incontinent = incontinentSwitch.IsToggled;
            int needyFactor = (int)needyFactorStepper.Value;

            if (!string.IsNullOrEmpty(name) && vitals != null && accucheck != null)
            {
                patients.Add(new Patient(name, vitals, accucheck, incontinent, needyFactor));
                patientListView.ItemsSource = null;
                patientListView.ItemsSource = patients;
            }
        }

        private void AssignPatients(object sender, EventArgs e)
        {
            foreach (var patient in patients.OrderByDescending(p => p.Workload))
            {
                techs.OrderBy(n => n.TotalWorkload).First().AssignPatient(patient);
            }
            techListView.ItemsSource = null;
            techListView.ItemsSource = techs;
        }
    }
}
