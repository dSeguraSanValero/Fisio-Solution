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

    public void RegisterPhysio(string name, int registrationNumber, string password, bool availeable, TimeSpan horaApertura, TimeSpan horaCierre, decimal price)
    {
        try 
        {
            Physio physio = new(name, registrationNumber, password, availeable, horaApertura, horaCierre, price);
            _repository.AddPhysio(physio);
            _repository.SaveChanges();
        } 
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al registrar el usuario", e);
        }
    }

    public bool CheckPhysioExist(int registrationNumber)
    {
        try
        {
            foreach (var physio in _repository.GetAllPhysios().Values)
            {
                if (physio.RegistrationNumber.Equals(registrationNumber))
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

    public Physio GetPhysioByRegistrationNumber(int registrationNumber)
    {
        try
        {
            foreach (var physio in _repository.GetAllPhysios().Values)
            {
                if (physio.RegistrationNumber.Equals(registrationNumber))
                {
                    return physio;
                }
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al obtener el usuario", e);
        }
    }
}
