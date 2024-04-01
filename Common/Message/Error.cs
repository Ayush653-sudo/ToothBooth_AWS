using Microsoft.AspNetCore.Http;


namespace Tooth_Booth_API.Common.Message
{
    public static class Error
    {
        public static string someThingWrong = "Something Went Wrong";
        public static string noAppointmentFound="Not able to find any apppointment";
        public static string noClinicFound = "Not able to find any Clinic";
        public static string notAbleToRegister = "Not able to Register User";
        public static string notAbleToLogin = "Not able to LogIn";
        public static string noDentistFound = "Not able to find Any Dentist";
        public static string modelNotValid = "Please enter valid details";
        public static string dentistIsNotFree = "Sorry Dentist is not Free To Book Appointment";
        public const string minWordInDescription = "Desciption Must Contain word greater than and equals 4";
        public const string minLengthForCity = "Minimum Length For City is 3";
        public const string userNameAlphaNumeric = "UserName is only allowed to be alphaNumeric";
        public const string enterValidEmail = "Please Enter A Valid Email Address";
        public const string enterValidPhoneNumber = "Please Enter A Valid PhoneNumber";
        public const string enterValidClinicName = "Clinic Name Should Be Grater Than 3 in length";

    }
}
