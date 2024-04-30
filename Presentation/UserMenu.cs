using FisioSolution.Business;
using FisioSolution.Models;

namespace FisioSolution.Presentation;

public class UserMenu
{
    public readonly IPatientService _patientService;
    public readonly IPhysioService _physioService;

    public UserMenu(IPatientService patientService, IPhysioService physioService)
    {
        _patientService = patientService;
        _physioService = physioService;
    }

    public void MainUserMenu(string dni)
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

                // Verificar si el paciente existe
                if (_patientService.CheckPatientExist(dni))
                {
                    Console.WriteLine("Ingrese el nombre del fisioterapeuta:");
                    string physioName = Console.ReadLine();

                    Console.WriteLine("Ingrese la causa del tratamiento:");
                    string treatmentCause = Console.ReadLine();

                    Console.WriteLine("Ingrese la fecha del tratamiento (yyyy-MM-dd):");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime treatmentDate))
                    {
                        try
                        {
                            // Obtener lista de tratamientos existente del paciente
                            var existingTreatments = _patientService.GetPatientByDni(dni).MyTreatments;

                            // Crear nuevo tratamiento
                            Treatment newTreatment = new Treatment(dni, physioName, treatmentCause, treatmentDate);

                            // Agregar el nuevo tratamiento a la lista existente
                            existingTreatments.Add(newTreatment);

                            // Actualizar la lista de tratamientos del paciente en el repositorio
                            _patientService.UpdatePatientTreatments(dni, existingTreatments);

                            Console.WriteLine("Tratamiento asignado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al asignar tratamiento: {ex.Message}");
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
                }

                















            
            break;


            default:
            Console.WriteLine("¡Opción no válida!");
            return;
        }
    }

}