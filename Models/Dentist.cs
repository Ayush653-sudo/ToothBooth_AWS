using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Tooth_Booth_API.Enum;

namespace serverless_dotnet.Models
{
    public class Dentist
    {

        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
       
        public int ClinicID { get; set; }
        [Required]
        
        public DentistCategory Category { get; set; }
        [Required]
        
        public bool Availability { get; set; }
        [Required]
    
        public int MaxAppointment { get; set; }



    }
}
