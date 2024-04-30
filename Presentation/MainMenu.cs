using System.Collections;
using FisioSolution.Business;
using FisioSolution.Presentation;

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
    Console.WriteLine("3: Buscar un fisioterapeuta");
    Console.WriteLine("4: Cerrar sesión");
    
    string userInput = Console.ReadLine() ?? "";
    
    switch(userInput)
        {
            case "1":
                SingUp();
            break;
            case "2":
                SignIn();
            break;
            case "3":
                PublicMenu publicMenu = new(_physioService);
                publicMenu.MenuPublico();
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

            Console.WriteLine("Introduce tu número de colegiado:");
            string Input = Console.ReadLine();
            int registrationNumber = Convert.ToInt32(Input);
            
            Console.WriteLine("Introduce tu contraseña:");
            string physioPassword = check.CheckNull();

            Console.WriteLine("¿Te encuentras en activo y listo para tratar pacientes?: y/n");
            string boolInput = check.CheckBoolean();
            bool availeable = (boolInput == "y");

            Console.WriteLine("Introduce tu horario de apertura (Por ejemplo 8:00):");
            TimeSpan horaApertura = check.CheckTimeSpan();

            Console.WriteLine("Introduce tu horario de cierre (Por ejemplo 16:00):");
            TimeSpan horaCierre = check.CheckTimeSpan();

            Console.WriteLine("Introduce tu precio por sesión (Por ejemplo 40,00):");
            decimal price = check.CheckDecimal();

            if (_physioService.CheckPhysioExist(registrationNumber))
            {
                Console.WriteLine("Error, ya existe una cuenta asociada a ese número de colegiado.");
                SingUp();
            }
            else
            {
                _physioService.RegisterPhysio(physioName, registrationNumber, physioPassword, availeable, horaApertura, horaCierre, price);
                Console.WriteLine("¡Fisioterapeuta añadido con éxito!");
                MenuPrincipal();
            }
            break;


            case "2":
            Console.WriteLine("Introduce tu nombre:");
            string patientName = check.CheckNull();

            Console.WriteLine("Introduce tu DNI:");
            string dni = check.CheckNull();
            
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

            if (_patientService.CheckPatientExist(dni))
            {
                Console.WriteLine("Error, ya existe una cuenta asociada a ese DNI.");
                SingUp();
            }
            else
            {
                _patientService.RegisterPatient(patientName, dni, patientPassword, fechaNacimiento, weight, height, insurance);
                Console.WriteLine("¡Paciente añadido con éxito!");
                MenuPrincipal();
            }
            break;


            case "3":
            MenuPrincipal();
            break;

            default:
            Console.WriteLine("¡Opción no válida!");
            return;
        }
    }


    private void SignIn()
    {
        Console.Write("Pulsa 1 si eres paciente, o 2 si eres fisioterapeuta:");
        string option = check.CheckNull();

        switch (option)
        {
        case "1":
            Console.Write("Introduce tu DNI: ");
            string dni = check.CheckNull();
            Console.Write("Contraseña: ");
            string password = check.CheckNull();
            if (_patientService.CheckLoginPatient(dni, password))
            {
                UserMenu userMenu = new(_patientService, _physioService);
                userMenu.MainUserMenu(dni);
            } 
            else
            {
                Console.WriteLine("El correo o la contraseña introducida es incorrecta.");
                MenuPrincipal();
            }
        break;


        case "2":
        break;


        default:
        
        return;
        }
    }
}
