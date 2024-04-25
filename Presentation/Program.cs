using FisioSolution.Business;
using FisioSolution.MainMenu;
using FisioSolution.Data;


IPhysioRepository physioRepository = new PhysioRepository();
IPhysioService physioService = new PhysioService(physioRepository);
IPatientRepository patientRepository = new PatientRepository();
IPatientService patientService = new PatientService(patientRepository);
MainMenu mainMenu = new(physioService, patientService);
mainMenu.MenuPrincipal();