using FisioSolution.Data;
using FisioSolution.Models;

namespace FisioSolution.Business;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public void RegisterPatient(string name, string dni, string password, DateTime birthDate, decimal weight, decimal height, bool insurance)
    {
        try 
        {
            Patient patient = new(name, dni, password, birthDate, weight, height, insurance);
            _repository.AddPatient(patient);
            _repository.SaveChanges();
        } 
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al registrar el usuario", e);
        }
    }

    public bool CheckPatientExist(string dni)
    {
        try
        {
            foreach (var patient in _repository.GetAllPatients().Values)
            {
                if (patient.Dni.Equals(dni))
                {
                    return true;
                }
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al comprobar el usuario", e);
        }
    }

    public bool CheckLoginPatient(string dni, string pasword)
    {
        try
        {
            foreach (var patient in _repository.GetAllPatients().Values)
            {
                if (patient.Dni.Equals(dni, StringComparison.OrdinalIgnoreCase) &&
                    patient.Password.Equals(pasword))
                {
                    return true;
                }
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al comprobar el usuario", e);
        }
    }

    public Patient GetPatientByDni(string dni)
    {
        try
        {
            foreach (var patient in _repository.GetAllPatients().Values)
            {
                if (patient.Dni.Equals(dni))
                {
                    return patient;
                }
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al obtener el usuario", e);
        }
    }

    public void UpdatePatientTreatments(string dni, List<Treatment> treatments)
    {
        try
        {
            // Obtener el paciente por su DNI
            Patient patient = GetPatientByDni(dni); // Asignar el resultado de GetPatientByDni a la variable patient

            if (patient != null)
            {
                // Asignar la nueva lista de tratamientos al paciente
                patient.MyTreatments = treatments;

                // Guardar los cambios en el repositorio
                _repository.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró ningún paciente con el DNI proporcionado.");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al actualizar los tratamientos del paciente.", e);
        }
    }


}