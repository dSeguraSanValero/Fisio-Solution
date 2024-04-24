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

    public string CheckNull()
    {
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("¡Error! Debes completar el campo");
        }
    }

    public string CheckAvaileable()
    {
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && (input == "y" || input == "n"))
            {
                return input;
            }
            Console.WriteLine("¡Error! Debes indicar si estás disponible o no");
        }
    }

    public TimeSpan CheckTimeSpan()
    {
        string input = Console.ReadLine();

        try
        {
            TimeSpan hora = TimeSpan.Parse(input);
            return hora;
        }
        catch (FormatException)
        {
            Console.WriteLine("Introduce un formato de hora válido por favor");
            return CheckTimeSpan();
        }
    }

    public decimal CheckDecimal()
    {
        decimal price;

        while (true)
        {
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out price))
            {
                return price;
            }
            Console.WriteLine("Introduce un formato de precio válido");
            return CheckDecimal();
        }
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
