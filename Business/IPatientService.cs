namespace FisioSolution.Business;

public interface IPatientService
{
    public void RegisterPatient(string name, string password, DateTime birthDate, decimal weight, decimal height, bool insurance);
}