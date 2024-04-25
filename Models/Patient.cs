namespace FisioSolution.Models;

public class Patient
{
   public int Id { get; set; }
   public string? Name { get; set; }
   public string? Password { get; set; }
   public DateTime BirthDate { get; set; }
   public decimal Weight { get; set; }
   public decimal Height { get; set; }
   public bool Insurance { get; set; }
   public static int PatientIdSeed { get; set; }

   public Patient(string name, string password, DateTime birthDate, decimal weight, decimal height, bool insurance) 
   {
      Id = PatientIdSeed++;
      Name = name;
      Password = password;
      BirthDate = birthDate;
      Weight = weight;
      Height = height;
      Insurance = insurance;
   }

}