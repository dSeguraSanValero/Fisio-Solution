namespace FisioSolution.Business;

public interface IPhysioService
{
    public void RegisterPhysio(string name, string password, bool availeable, TimeSpan horaApertura, TimeSpan horaCierre, decimal price);
}