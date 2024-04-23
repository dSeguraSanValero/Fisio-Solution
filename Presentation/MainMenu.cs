namespace FisioSolution.MainMenu;

public class MainMenu
{
    public void MenuPrincipal()
    {
    Console.WriteLine("~~~~~~~~~~~~~~~~ BIENVENIDO A FISIO SOLUTION ~~~~~~~~~~~~~~~~");
    Console.WriteLine("1: Registrarte como fisioterapeuta");
    Console.WriteLine("2: Iniciar sesión como fisioterapeuta");
    Console.WriteLine("3: Registrarte como paciente");
    Console.WriteLine("4: Iniciar sesión como paciente");
    Console.WriteLine("5: Zona pública");
    
    string userInput = Console.ReadLine() ?? "Campo vacío!!";
    SelectOption(userInput);
    }

    public void SelectOption(string userInput)
    {
        switch(userInput)
        {
            case "1":
            Console.WriteLine("funciona!!");
            break;
            default:
            Console.WriteLine("Default!!");
            return;
        }
    }
}
