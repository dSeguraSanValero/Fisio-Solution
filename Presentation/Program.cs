using FisioSolution.Business;
using FisioSolution.MainMenu;
using FisioSolution.Data;


IPhysioRepository physioRepository = new PhysioRepository();
IPatientRepository patientRepository = new PatientRepository();

IPatientService patientService = new PatientService(patientRepository);
IPhysioService physioService = new PhysioService(physioRepository);

MainMenu mainMenu = new (physioService, patientService);
mainMenu.MenuPrincipal();