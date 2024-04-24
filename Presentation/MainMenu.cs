using FisioSolution.Business;

namespace FisioSolution.MainMenu;

public class MainMenu
{
    public readonly IPhysioService _physioService;

    public MainMenu(IPhysioService physioService)
    {
        _physioService = physioService;
    }


    public void MenuPrincipal()
    {
    Console.WriteLine("~~~~~~~~~~~~~~~~ BIENVENIDO A FISIO SOLUTION ~~~~~~~~~~~~~~~~");
    Console.WriteLine("1: Registrar nuevo usuario");
    Console.WriteLine("2: Iniciar sesión");
    Console.WriteLine("3: Zona pública");
    Console.WriteLine("4: Cerrar sesión");
    
    string userInput = Console.ReadLine() ?? "";
    
    switch(userInput)
        {
            case "1":
                SingUp();
            break;
            case "2":
            Console.WriteLine("2: Registrarse como paciente");
            break;
            case "3":
            Console.WriteLine("Queda por programar");
            break;            
            case "4":
            Console.WriteLine("¡Buenas noches!");
            break;
            default:
            Console.WriteLine("¡Opción no válida!");
            MenuPrincipal();
            return;
        }
    }

    private void SingUp() 
    {
        Console.WriteLine("1: Registrarse como fisioterapeuta");
        Console.WriteLine("2: Registrarse como paciente");
        Console.WriteLine("3: Volver al menú principal");

        string userInput = Console.ReadLine() ?? "";

        switch(userInput)
        {
            case "1":
            Console.WriteLine("Introduce tu nombre:");
            string name = _physioService.CheckNull();
            
            Console.WriteLine("Introduce tu contraseña:");
            string password = _physioService.CheckNull();

            Console.WriteLine("¿Te encuentras en activo y listo para tratar pacientes?: y/n");
            string yes_No = _physioService.CheckAvaileable();
            bool availeable = (yes_No == "y");

            Console.WriteLine("Introduce tu horario de apertura (Por ejemplo 8:00):");
            TimeSpan horaApertura = _physioService.CheckTimeSpan();

            Console.WriteLine("Introduce tu horario de cierre (Por ejemplo 16:00):");
            TimeSpan horaCierre = _physioService.CheckTimeSpan();

            Console.WriteLine("Introduce tu precio por sesión (Por ejemplo 40,00):");
            decimal price = _physioService.CheckDecimal();
            
            // if (checkPhysio logic)
            _physioService.RegisterPhysio(name, password, availeable, horaApertura, horaCierre, price);

            break;
            case "2":
            Console.WriteLine("2: Por programar");
            break;
            case "3":
            MenuPrincipal();
            break;            
            default:
            Console.WriteLine("¡Opción no válida!");
            MenuPrincipal();
            return;
        }
    }
}
