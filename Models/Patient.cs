using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FisioSolution.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Dni { get; set; }
        public string? Password { get; set; }
        
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BirthDate { get; set; }
        
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public bool Insurance { get; set; }
        public List<Treatment> MyTreatments { get; set; }
        public static int PatientIdSeed { get; set; }

        public Patient(string name, string dni, string password, DateOnly birthDate, decimal weight, decimal height, bool insurance)
        {
            Id = PatientIdSeed++;
            Name = name;
            Dni = dni;
            Password = password;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
            Insurance = insurance;
            MyTreatments = new List<Treatment>();
        }
    }
}
