using FisioSolution.Models;

namespace FisioSolution.Business;


public interface IPhysioService
{
    public void RegisterPhysio(string name, int registrationNumber, string password, bool availeable, TimeSpan horaApertura, TimeSpan horaCierre, decimal price);
    public bool CheckPhysioExist(int registrationNumber);
    public Physio GetPhysioByRegistrationNumber(int registrationNumber);
}