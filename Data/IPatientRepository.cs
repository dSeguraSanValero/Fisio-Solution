using FisioSolution.Models;

namespace FisioSolution.Data;
public interface IPatientRepository
{
    void AddPatient(Patient patient);
}