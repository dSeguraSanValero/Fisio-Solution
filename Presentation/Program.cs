using FisioSolution.Business;
using FisioSolution.MainMenu;
using FisioSolution.Data;


IPhysioRepository physioRepository = new PhysioRepository();
IPhysioService physioService = new PhysioService(physioRepository);
MainMenu mainMenu = new MainMenu(physioService);
mainMenu.MenuPrincipal();