using FisioSolution.Business;

namespace FisioSolution.MainMenu;

public class MainMenu
{
    public readonly IPhysioService _physioService;

    public readonly IPatientService _patientService;

    public MainMenu(IPhysioService physioService, IPatientService patientService)
    {
        _physioService = physioService;
        _patientService = patientService;
    }

    public Check check = new Check();

    public void MenuPrincipal()
    {
    Console.WriteLine("BIENVENIDO A FISIO SOLUTION");
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
            string physioName = check.CheckNull();
            
            Console.WriteLine("Introduce tu contraseña:");
            string physioPassword = check.CheckNull();

            Console.WriteLine("¿Te encuentras en activo y listo para tratar pacientes?: y/n");
            string physioInput = check.CheckBoolean();
            bool availeable = (physioInput == "y");

            Console.WriteLine("Introduce tu horario de apertura (Por ejemplo 8:00):");
            TimeSpan horaApertura = check.CheckTimeSpan();

            Console.WriteLine("Introduce tu horario de cierre (Por ejemplo 16:00):");
            TimeSpan horaCierre = check.CheckTimeSpan();

            Console.WriteLine("Introduce tu precio por sesión (Por ejemplo 40,00):");
            decimal price = check.CheckDecimal();
            


            // Programar lógica para verificar si ya existe fisioterapeuta con esos datos


            _physioService.RegisterPhysio(physioName, physioPassword, availeable, horaApertura, horaCierre, price);
            MenuPrincipal();
            break;


            case "2":
            Console.WriteLine("Introduce tu nombre:");
            string patientName = check.CheckNull();
            
            Console.WriteLine("Introduce tu contraseña:");
            string patientPassword = check.CheckNull();

            Console.WriteLine("Introduce tu fecha de nacimiento:");
            DateTime fechaNacimiento = check.CheckDateTime();

            Console.WriteLine("Introduce tu peso (por ejemplo 75,43):");
            decimal weight = check.CheckDecimal();

            Console.WriteLine("Introduce tu altura (por ejemplo 1,74):");
            decimal height = check.CheckDecimal();

            Console.WriteLine("¿Tienes seguro médico?: y/n");
            string patientInput = check.CheckBoolean();
            bool insurance = (patientInput == "y");


            // programar lógica para verificar existencia de paciente con esos datos


            _patientService.RegisterPatient(patientName, patientPassword, fechaNacimiento, weight, height, insurance);
            MenuPrincipal();
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
