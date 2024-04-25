using FisioSolution.Models;
using System.Text.Json;

namespace FisioSolution.Data;

public class PatientRepository : IPatientRepository
{
    private Dictionary<string, Patient> _patients = new Dictionary<string, Patient>();
    private readonly string _filePath = "patients.json";

    public void AddPatient(Patient patient)
    {
        _patients[patient.Id.ToString()] = patient;

        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_patients.Values, options);
            File.WriteAllText(_filePath, jsonString);
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al guardar cambios en el archivo de usuarios", e);
        }
    }
}