using System;
using System.Collections.Generic;
using HealthcareSystem.Models;
using HealthcareSystem.Repositories;

namespace HealthcareSystem
{
    public class HealthSystemApp
    {
        private readonly Repository<Patient> _patientRepo = new();
        private readonly Repository<Prescription> _prescriptionRepo = new();
        private readonly Dictionary<int, List<Prescription>> _prescriptionMap = new();

        public void SeedData()
        {
            // Add patients
            _patientRepo.Add(new Patient(1, "Ama Boateng", 28, "Female"));
            _patientRepo.Add(new Patient(2, "Kojo Mensah", 35, "Male"));
            _patientRepo.Add(new Patient(3, "Efua Asante", 42, "Female"));

            // Add prescriptions (PatientIds must match above)
            _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Today.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Today.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Paracetamol", DateTime.Today.AddDays(-2)));
            _prescriptionRepo.Add(new Prescription(4, 3, "Metformin", DateTime.Today.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(5, 3, "Vitamin D", DateTime.Today));
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap.Clear();
            foreach (var prescription in _prescriptionRepo.GetAll())
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("Patients:");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine($"  ID: {patient.Id} | {patient.Name} ({patient.Age} yrs, {patient.Gender})");
            }
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            return _prescriptionMap.ContainsKey(patientId)
                ? _prescriptionMap[patientId]
                : new List<Prescription>();
        }

        public void PrintPrescriptionsForPatient(int id)
        {
            var prescriptions = GetPrescriptionsByPatientId(id);
            if (prescriptions.Count == 0)
            {
                Console.WriteLine($"No prescriptions found for patient ID {id}");
                return;
            }

            Console.WriteLine($"Prescriptions for Patient {id}:");
            foreach (var p in prescriptions)
            {
                Console.WriteLine($"  #{p.Id} {p.MedicationName} (Issued: {p.DateIssued:yyyy-MM-dd})");
            }
        }
    }
}
