namespace FisioSolution.Models;
public class Treatment
{
    public int Id { get; set; }
    public string? PhysioName { get; set; }
    public string? Dni { get; set; }
    public string? TreatmentCause { get; set; }
    public DateTime TreatmentDate { get; set; }
    public static int TreatmentIdSeed { get; set; }
    public bool MoreSessionsNeeded { get; set; }

    public Treatment(string dni, string physioName, string treatmentCause, DateTime treatmentDate, bool moreSessionsNeeded ) 
   {
      Id = TreatmentIdSeed++;
      PhysioName = physioName;
      Dni = dni;
      TreatmentCause = treatmentCause;
      TreatmentDate = treatmentDate;
      MoreSessionsNeeded = moreSessionsNeeded; 
   }
}