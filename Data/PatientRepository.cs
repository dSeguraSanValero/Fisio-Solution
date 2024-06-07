using FisioSolution.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FisioSolution.Data
{
    public class PatientRepository : IPatientRepository
    {
        private Dictionary<string, Patient> _patients = new Dictionary<string, Patient>();
        private readonly string _filePath;

        public PatientRepository()
        {
            _filePath = Environment.GetEnvironmentVariable("JSON_FILE_PATH");

            if (string.IsNullOrEmpty(_filePath))
            {
                _filePath = "../../../../Data/patients.json";
            }

            if (File.Exists(_filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(_filePath);
                    var patients = JsonSerializer.Deserialize<IEnumerable<Patient>>(jsonString);
                    _patients = patients.ToDictionary(p => p.Id.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception("Ha ocurrido un error al leer el archivo de pacientes", e);
                }
            }

            if (_patients.Count == 0)
            {
                Patient.PatientIdSeed = 1;
            }
            else
            {
                Patient.PatientIdSeed = _patients.Count + 1; 
            }
        }

        public void AddPatient(Patient patient)
        {
            _patients[patient.Id.ToString()] = patient;
            SaveChanges();
        }

        public Patient GetPatient(string dni)
        {
            foreach (var patient in _patients.Values)
            {
                if (patient.Dni.Equals(dni))
                {
                    return patient;
                }
            }
            return null;
        }

        public Dictionary<string, Patient> GetAllPatients()
        {
            return new Dictionary<string, Patient>(_patients);
        }

        public void SaveChanges()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(_patients.Values, options);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error al guardar cambios en el archivo de pacientes", e);
            }
        }

        public void RemovePatient(Patient patient)
        {
            _patients.Remove(patient.Id.ToString());
            SaveChanges();
        }
    }
}
