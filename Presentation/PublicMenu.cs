using FisioSolution.Business;
using FisioSolution.Models;


namespace FisioSolution.Presentation;

public class PublicMenu
{
    public readonly IPhysioService _physioService;
    public readonly IPatientService _patientService;

    public Check check = new Check();

    public PublicMenu(IPhysioService physioService, IPatientService patientService)
    {
        _physioService = physioService;
        _patientService = _patientService;
    }

    public void MenuPublico()
    {
        bool continuar = true;
        while (continuar)
        {

        Console.WriteLine($"-----------------------------------------");
        Console.WriteLine("Pulsa 1 para buscar a un fisioterapeuta:");
        Console.WriteLine("Pulsa 2 para ver a todos los fisioterapeutas:");
        Console.WriteLine("Pulsa 3 para volver al menú principal:");

        string userInput = check.CheckNull();

        switch(userInput)
        {
            case "1":
                Console.WriteLine($"-----------------------------------------");
                Console.WriteLine("Por favor introduce el número de colegiado de tu fisio:");
                
                int registrationNumber = check.CheckInt();
                
                Physio physio = _physioService.GetPhysioByRegistrationNumber(registrationNumber);

                if (physio != null)
                {
                    Console.WriteLine("¡¡Fisioterapeuta encontrado!!:");
                    Console.WriteLine($"Nombre: {physio.Name}");
                    Console.WriteLine($"Hora de apertura: {physio.OpeningTime} - Hora de cierre: {physio.ClosingTime}");
                    Console.WriteLine($"Precio por sesión: {physio.Price} euros");
                    

                }
                else
                {
                    Console.WriteLine("No se encontró ningún fisioterapeuta con ese número de colegiado.");
                    MenuPublico();
                }
            break;

            case "2":
            
                _physioService.PrintPhysioTreatments();
            break;

            case "3":
                continuar = false;

                MainMenu mainMenu = new (_physioService, _patientService);
                mainMenu.MenuPrincipal();
            break;    
        }
        }
    }
}