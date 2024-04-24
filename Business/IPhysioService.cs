namespace FisioSolution.Business;

public interface IPhysioService
{
    string CheckNull();

    string CheckAvaileable();
    TimeSpan CheckTimeSpan();
    decimal CheckDecimal();

    public void RegisterPhysio(string name, string password, bool availeable, TimeSpan horaApertura, TimeSpan horaCierre, decimal price);
}