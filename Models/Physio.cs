namespace FisioSolution.Models;
public class Physio
{
   public int Id { get; set; }
   public string? Name { get; set; }
   public string? Password { get; set; }
   public bool Availeable { get; set; }
   public TimeSpan OpeningTime { get; set; }
   public TimeSpan ClosingTime { get; set; }
   public decimal Price { get; set; }
   public static int PhysioIdSeed { get; set; }


   public Physio(string name, string password, bool availeable, TimeSpan openingTime, TimeSpan closingTime, decimal price) 
   {
      Id = PhysioIdSeed++;
      Name = name;
      Password = password;
      Availeable = availeable;
      OpeningTime = openingTime;
      ClosingTime = closingTime;
      Price = price;
   }

}
