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


   public Physio() {}


   public Physio(string name, string password, bool availeable, TimeSpan openingTime, TimeSpan closingTime, decimal price) 
   {
    Name = name;
    Password = password;
    Availeable = availeable;
    OpeningTime = openingTime;
    ClosingTime = closingTime;
    Price = price;
   }

}
