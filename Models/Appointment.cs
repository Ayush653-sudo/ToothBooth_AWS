using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using serverless_dotnet.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tooth_Booth_API.Common;
using Tooth_Booth_API.Enum;

namespace Tooth_Booth_API.Models
{
    public class Appointment
    {
        
        public int AppointmentId { get; set; }
        [Required]
        [RegularExpression(RegularExpressions.alphaNumericRegex)]
      
        public string PatientUserName { get; set; }

        [Required]
       
        public string DoctorUserName {  get; set; }

        [Required]
        public string DoctorId { get; set; }
       

        [Required]
        [DataType(DataType.Date)]
        
        public DateTime AppointmentDate { get; set; }
        [Required]
        
        public int ClinicId { get; set; }
        [Required]
        public string Prescription { get; set; }
        [Required]
        

        public PaymentType PaymentType { get; set; }
    }
}
