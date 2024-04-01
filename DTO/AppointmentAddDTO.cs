using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Tooth_Booth_API.Enum;
using System.Text.Json.Serialization;
using serverless_dotnet.Models;

namespace Tooth_Booth_API.DTO
{
    public class AppointmentAddDTO
    {


        [Required]
        public string DoctorUserName { get; set; }
        
        [Required]
        public string DoctorId { get; set; }
      

   
        public string Prescription { get; set; }
        [Required]

        public PaymentType PaymentType { get; set; }
    }
}
