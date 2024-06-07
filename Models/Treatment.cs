using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FisioSolution.Models;
public class Treatment
{
    public int Id { get; set; }
    public string? PhysioName { get; set; }
    public string? Dni { get; set; }
    public string? TreatmentCause { get; set; }
    
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly TreatmentDate { get; set; }
    
    public static int TreatmentIdSeed { get; set; }
    public bool MoreSessionsNeeded { get; set; }

    public Treatment(string dni, string physioName, string treatmentCause, DateOnly treatmentDate, bool moreSessionsNeeded ) 
   {
      Id = TreatmentIdSeed++;
      PhysioName = physioName;
      Dni = dni;
      TreatmentCause = treatmentCause;
      TreatmentDate = treatmentDate;
      MoreSessionsNeeded = moreSessionsNeeded; 
   }
}