using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Tooth_Booth_API.Common;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.Enum;

namespace Tooth_Booth_API.DTO.Auth
{
    public class RegistrationDTO
    {


        [Required]
        [RegularExpression(RegularExpressions.alphaNumericRegex,ErrorMessage =Error.userNameAlphaNumeric)]
        public string UserName { get; set; }
        [Required]
          
        public string Password { get; set; }

        [RegularExpression(RegularExpressions.EmailRegex,ErrorMessage =Error.enterValidEmail)]
        public string EmailAddress { get; set; }
        [Required]
        [RegularExpression(RegularExpressions.phoneNumberRegex,ErrorMessage =Error.enterValidPhoneNumber)]
        public string PhoneNumber { get; set; }



    }
}