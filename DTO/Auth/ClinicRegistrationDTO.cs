using System.ComponentModel.DataAnnotations;
using Tooth_Booth_API.Common;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.Helper.CustomValidationAttribute;

namespace Tooth_Booth_API.DTO.Auth
{
    public class ClinicRegistrationDTO : RegistrationDTO
    {

        [Required]
        [MinLength(3,ErrorMessage =Error.enterValidClinicName)]       
        public string ClinicName { get; set; }
        [Required]
        [MinWords(4,ErrorMessage =Error.minWordInDescription)]
        public string Description { get; set; }
        [Required]
        [MinLength(3,ErrorMessage =Error.minLengthForCity)]
        [RegularExpression(RegularExpressions.hasOnlyAlphabet)]
        public string ClinicCity { get; set; }

    }
}
