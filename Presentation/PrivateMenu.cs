using FisioSolution.Business;
using FisioSolution.Models;

namespace FisioSolution.Presentation;

public class PrivateMenu
{
    public readonly IPatientService _patientService;
    public readonly IPhysioService _physioService;

    public PrivateMenu(IPatientService patientService, IPhysioService physioService)
    {
        _patientService = patientService;
        _physioService = physioService;
    }

    public void PrivatePatientMenu(string dni)
    {
        Patient patient = _patientService.GetPatientByDni(dni);

        Console.WriteLine($"¡Bienvenido {patient.Name}!");
        Console.WriteLine("Pulsa 1 para ver tus datos.");
        Console.WriteLine("Pulsa 2 para ver tus tratamientos pasados.");

        string userInput = Console.ReadLine() ?? "";

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

            break;


            default:
            Console.WriteLine("¡Opción no válida!");
            return;
        }
    }


    public void PrivatePhysioMenu(int registrationNumber)
    {
        Physio physio = _physioService.GetPhysioByRegistrationNumber(registrationNumber);

        Console.WriteLine($"¡Bienvenido {physio.Name}!");
        Console.WriteLine("Pulsa 1 para ver tus datos.");
        Console.WriteLine("Pulsa 2 para añadir un nuevo tratamiento");
        Console.WriteLine("Pulsa 3 para ver tus tratamientos");

        string userInput = Console.ReadLine() ?? "";

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
            string dni = Console.ReadLine() ?? "";

                if (_patientService.CheckPatientExist(dni))
                {
                    Console.WriteLine("Ingrese el nombre del fisioterapeuta: ");
                    string physioName = Console.ReadLine();

                    Console.WriteLine("Ingrese la causa del tratamiento: ");
                    string treatmentCause = Console.ReadLine();

                    Console.WriteLine("Ingrese la fecha del tratamiento: ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime treatmentDate))
                    {
                        try
                        {
                            var existingTreatments = _patientService.GetPatientByDni(dni).MyTreatments;
                            
                            Treatment newTreatment = new Treatment(dni, physioName, treatmentCause, treatmentDate);

                            existingTreatments.Add(newTreatment);

                            _patientService.UpdatePatientTreatments(dni, existingTreatments);

                            Console.WriteLine("Tratamiento asignado correctamente.");
                        }
                        catch
                        {
                            Console.WriteLine("Error al asignar tratamiento");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fecha inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró ningún paciente con el DNI proporcionado.");
                    PrivatePhysioMenu(registrationNumber);
                }
            break;


            case "3":
            break;


            default: 
            return;
        }    
    }

}