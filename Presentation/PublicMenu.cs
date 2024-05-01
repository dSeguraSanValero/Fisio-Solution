using FisioSolution.Business;
using FisioSolution.Models;


namespace FisioSolution.Presentation;

public class PublicMenu
{
    public readonly IPhysioService _physioService;
    public readonly IPatientService _patientService;

    public PublicMenu(IPhysioService physioService, IPatientService patientService)
    {
        _physioService = physioService;
        _patientService = _patientService;
    }

    public void MenuPublico()
    {
        
        Console.WriteLine($"-----------------------------------------");
        Console.WriteLine("Por favor introduce el número de colegiado de tu fisio:");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int registrationNumber))
        {
            Physio physio = _physioService.GetPhysioByRegistrationNumber(registrationNumber);

            if (physio != null)
            {
                Console.WriteLine("¡¡Fisioterapeuta encontrado!!:");
                Console.WriteLine($"Nombre: {physio.Name}");
                Console.WriteLine($"Hora de apertura: {physio.OpeningTime} - Hora de cierre: {physio.ClosingTime}");
                Console.WriteLine($"Precio por sesión: {physio.Price} euros");
                
                MainMenu mainMenu = new (_physioService, _patientService);
                mainMenu.MenuPrincipal();
            }
            else
            {
                Console.WriteLine("No se encontró ningún fisioterapeuta con ese número de colegiado.");
                MenuPublico();
            }
        }
        else
        {
            Console.WriteLine("Por favor, introduce un número válido.");
            MenuPublico();
        }
    }
}