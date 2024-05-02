using FisioSolution.Business;
using FisioSolution.Models;

namespace FisioSolution.Presentation;

public class PrivateMenu
{
    
    private readonly IPatientService _patientService;
    private readonly IPhysioService _physioService;
    public Check check = new Check();

    public PrivateMenu(IPatientService patientService, IPhysioService physioService)
    {
        _patientService = patientService;
        _physioService = physioService;
    }
    

    public void PrivatePatientMenu(string dni)
    {
        MainMenu mainMenu = new (_physioService, _patientService);
        Patient patient = _patientService.GetPatientByDni(dni);

        bool continuar = true;

        while (continuar)
        {

        Console.WriteLine($"-----------------------------------------");
        Console.WriteLine($"¡Bienvenido {patient.Name}!");
        Console.WriteLine("Pulsa 1 para ver tus datos.");
        Console.WriteLine("Pulsa 2 para ver tus tratamientos pasados.");
        Console.WriteLine("Pulsa 3 para eliminar tu cuenta.");
        Console.WriteLine("Pulsa 4 para actualizar tus datos.");
        Console.WriteLine("Pulsa 5 para cerrar la sesión.");

        string userInput = check.CheckNull();

        switch(userInput)
        {
            case "1":

            Console.WriteLine($"Nombre: {patient.Name}");
            Console.WriteLine($"DNI: {patient.Dni}");
            Console.WriteLine($"Contraseña: {patient.Password}");
            Console.WriteLine($"Fecha de nacimiento: {patient.BirthDate}");
            Console.WriteLine($"Altura: {patient.Height}");
            Console.WriteLine($"Peso: {patient.Weight}");
            Console.WriteLine($"{(patient.Insurance ? "Tienes seguro activo." : "No tienes seguro actualmente.")}");
            break;


            case "2":

            foreach (var treatment in patient.MyTreatments)
            {
                Console.WriteLine($"Fecha del tratamiento: {treatment.TreatmentDate}");
                Console.WriteLine($"Causa del tratamiento: {treatment.TreatmentCause}");
                Console.WriteLine($"Nombre del fisioterapeuta: {treatment.PhysioName}");
                Console.WriteLine($"¿Más sesiones necesarias?: {(treatment.MoreSessionsNeeded ? "Sí" : "No")}");
                Console.WriteLine($"-----------------------------------------");
            }

            break;

            case "3":
            continuar = false;
            _patientService.DeletePatient(patient);

            mainMenu.MenuPrincipal();
            break;

            case "4":
            
            Console.WriteLine("Introduce tu nuevo nombre:");
            string newName = check.CheckNull();

            Console.WriteLine("Introduce tu nueva contraseña:");
            string newPassword = check.CheckNull();

            Console.WriteLine("Introduce tu nuevo peso:");
            decimal newWeight = check.CheckDecimal();

            Console.WriteLine("Introduce tu nueva altura:");
            decimal newHeight = check.CheckDecimal();

            Console.WriteLine("¿Tienes seguro?: y/n");
            string boolInput = check.CheckBoolean();
            bool newInsurance = (boolInput == "y");

            _patientService.UpdatePatientData(patient, newName, newPassword, newWeight, newHeight, newInsurance);
            
            Console.WriteLine("¡Datos actualizados!");
            break;

            case "5":

            continuar = false;
            
            mainMenu.MenuPrincipal();
            break;


            default:

            Console.WriteLine("¡Opción no válida!");
            return;
        }

        } 
    }


    public void PrivatePhysioMenu(int registrationNumber)
    {
        MainMenu mainMenu = new (_physioService, _patientService);
        Physio physio = _physioService.GetPhysioByRegistrationNumber(registrationNumber);

        bool continuar = true;

        while (continuar)
        {

            Console.WriteLine($"-----------------------------------------");
            Console.WriteLine($"¡Bienvenido {physio.Name}!");
            Console.WriteLine("Pulsa 1 para ver tus datos.");
            Console.WriteLine("Pulsa 2 para añadir un nuevo tratamiento");
            Console.WriteLine("Pulsa 3 para ver tus tratamientos");
            Console.WriteLine("Pulsa 4 para cerrar la sesión");


            string userInput = check.CheckNull();

            switch(userInput)
            {
                case "1":

                Console.WriteLine($"Nombre: {physio.Name}");
                Console.WriteLine($"Número de colegiado: {physio.RegistrationNumber}");
                Console.WriteLine($"Contraseña: {physio.Password}");
                Console.WriteLine($"{(physio.Availeable ? "Te encuentras en activo." : "No te encuentras en activo")}");
                Console.WriteLine($"Hora de apertura: {physio.OpeningTime}");
                Console.WriteLine($"Hora de cierre: {physio.ClosingTime}");
                Console.WriteLine($"Precio por sesión: {physio.Price}");
                break;


                case "2":

                Console.WriteLine("Introduce el DNI del paciente tratado: ");
                string dni = check.CheckNull();

                if (_patientService.CheckPatientExist(dni))
                {
                    Console.WriteLine("Ingrese la causa del tratamiento: ");
                    string treatmentCause = check.CheckNull();

                    Console.WriteLine("¿Necesita más sesiones el paciente?: y/n");
                    string moreSession = check.CheckBoolean();
                    bool moreSessionsNeeded = (moreSession == "y");
                
                    Console.WriteLine("Ingrese la fecha del tratamiento: ");
                    
                    DateTime treatmentDate = check.CheckDateTime();
                    try
                    {
                        var patientExistingTreatments = _patientService.GetPatientByDni(dni).MyTreatments;
                        var physioExistingTreatments = physio.MyTreatments;
                        
                        Treatment newTreatment = new Treatment(dni, physio.Name, treatmentCause, treatmentDate, moreSessionsNeeded);

                        patientExistingTreatments.Add(newTreatment);
                        physioExistingTreatments.Add(newTreatment);

                        _patientService.UpdatePatientTreatments(dni, patientExistingTreatments);
                        _physioService.UpdatePhysioTreatments(physio, physioExistingTreatments);
                        
                        Console.WriteLine("Tratamiento asignado correctamente.");

                    }
                    catch
                    {
                        Console.WriteLine("Error al asignar tratamiento");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró ningún paciente con el DNI proporcionado.");
                    PrivatePhysioMenu(registrationNumber);
                }
                break;


                case "3":

                foreach (var treatment in physio.MyTreatments)
                {
                    Console.WriteLine($"DNI del paciente: {treatment.Dni}");
                    Console.WriteLine($"Fecha del tratamiento: {treatment.TreatmentDate}");
                    Console.WriteLine($"Causa del tratamiento: {treatment.TreatmentCause}");
                    Console.WriteLine($"Nombre del fisioterapeuta: {treatment.PhysioName}");
                    Console.WriteLine($"¿Más sesiones necesarias?: {(treatment.MoreSessionsNeeded ? "Sí" : "No")}");
                    Console.WriteLine($"-----------------------------------------");
                }
                break;

                case "4":

                continuar = false;
                mainMenu.MenuPrincipal();

                break;

                default:
                    Console.WriteLine("Error, por favor introduce un número válido");
                return;
            }    
        }
    }
}