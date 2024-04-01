namespace Tooth_Booth_API.Common
{
    public static class RegularExpressions
    {
        public const string EmailRegex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
        public const string phoneNumberRegex = @"^([0]|\+91)?[789]\d{9}$";
        public const string alphaNumericRegex = @"^[a-zA-Z][a-zA-Z0-9]*$";
        public const string hasOnlyAlphabet = @"^[a-zA-Z]+$";
    }
}
