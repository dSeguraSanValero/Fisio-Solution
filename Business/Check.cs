namespace FisioSolution.Business;

public class Check
{
    public string CheckNull()
    {
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("¡Error! Debes completar el campo");
        }
    }

    public TimeSpan CheckTimeSpan()
    {
        string input = Console.ReadLine();

        try
        {
            TimeSpan hora = TimeSpan.Parse(input);
            return hora;
        }
        catch (FormatException)
        {
            Console.WriteLine("Introduce un formato de hora válido por favor");
            return CheckTimeSpan();
        }
    }

    public DateTime CheckDateTime()
    {
        string input = Console.ReadLine();

        try
        {
            DateTime fecha = DateTime.Parse(input);
            return fecha;
        }
        catch (FormatException)
        {
            Console.WriteLine("Introduce un formato de hora válido por favor");
            return CheckDateTime();
        }
    }

    public decimal CheckDecimal()
    {
        decimal price;

        while (true)
        {
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out price))
            {
                return price;
            }
            Console.WriteLine("Introduce un formato de precio válido");
            return CheckDecimal();
        }
    }

        public string CheckBoolean()
    {
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && (input == "y" || input == "n"))
            {
                return input;
            }
            Console.WriteLine("¡Error! Debes indicar si estás disponible o no");
        }
    }
} 