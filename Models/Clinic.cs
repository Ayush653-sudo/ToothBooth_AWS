using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tooth_Booth_API.Helper.CustomValidationAttribute;
using Tooth_Booth_API.Common;
using serverless_dotnet.Models;
using Amazon.DynamoDBv2.DataModel;

namespace Tooth_Booth_API.Models
{
    public class Clinic
    {


        [Required]
        public int ClinicId { get; set; }

        [Required]
        public string ClinicAdminId {  get; set; }
        [Required]      
        public string ClinicName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ClinicCity {  get; set; }
        [Required] 
        public bool Isverified {  get; set; }
    }
}
