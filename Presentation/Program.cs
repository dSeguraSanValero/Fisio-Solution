using FisioSolution.Business;
using FisioSolution.Data;
using FisioSolution.Presentation;


IPhysioRepository physioRepository = new PhysioRepository();
IPatientRepository patientRepository = new PatientRepository();

IPatientService patientService = new PatientService(patientRepository);
IPhysioService physioService = new PhysioService(physioRepository);

MainMenu mainMenu = new (physioService, patientService);
mainMenu.MenuPrincipal();