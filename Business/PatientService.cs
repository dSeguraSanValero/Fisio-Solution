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

    public void RegisterPatient(string name, string password, DateTime birthDate, decimal weight, decimal height, bool insurance)
    {
        try 
        {
            Patient patient = new(name, password, birthDate, weight, height, insurance);
            _repository.AddPatient(patient);
        } 
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al registrar el usuario", e);
        }
    }
}