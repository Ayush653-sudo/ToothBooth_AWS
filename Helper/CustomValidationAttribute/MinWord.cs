using System.ComponentModel.DataAnnotations;
using System;

namespace Tooth_Booth_API.Helper.CustomValidationAttribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MinWords : ValidationAttribute
    {
        private readonly int _minWords;

        public MinWords(int minWords) : base("{0} must have at least {1} words.")
        {
            _minWords = minWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                string[] words = stringValue.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length < _minWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName, _minWords);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }

        private string FormatErrorMessage(string name, int minWords)
        {
            return string.Format(ErrorMessageString, name, minWords);
        }
    }
}
