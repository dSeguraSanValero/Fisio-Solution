using FisioSolution.Data;
using FisioSolution.Models;


namespace FisioSolution.Business;
public class PhysioService : IPhysioService
{

    private readonly IPhysioRepository _repository;

    public PhysioService(IPhysioRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public void RegisterPhysio(string name, string password, bool availeable, TimeSpan horaApertura, TimeSpan horaCierre, decimal price)
    {
        try 
        {
            Physio physio = new(name, password, availeable, horaApertura, horaCierre, price);
            _repository.AddPhysio(physio);
        } 
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al registrar el usuario", e);
        }
    }
}
