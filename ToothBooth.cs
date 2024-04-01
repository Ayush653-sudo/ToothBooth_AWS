using Amazon.DynamoDBv2.DataModel;
using System;

namespace dynamodb_sample
{
    public class ToothBoothDB
    {

        [DynamoDBHashKey]
        public string Key {  get; set; }
        [DynamoDBRangeKey]
        public string sort {  get; set; }
        [DynamoDBProperty]
        public string ClinicAdminId { get; set; }
        [DynamoDBProperty]
        public string ClinicCity { get; set; }
        [DynamoDBProperty]
        public int ClinicId { get; set; }
        [DynamoDBProperty]
        public string ClinicName { get; set; }
        [DynamoDBProperty]
        public string Description {  get; set; }
        [DynamoDBProperty]
        public bool Isverified {  get; set; }
        [DynamoDBProperty]
        public string Id {  get; set; }
        [DynamoDBProperty]
        public bool Availability {  get; set; }
        [DynamoDBProperty]
        public int MaxAppointment { get; set; }
        [DynamoDBProperty]

        public string UserName { get; set; }
        [DynamoDBProperty]
        public int Category { get; set; }
        [DynamoDBProperty]

        public string DoctorUserName {  get; set; }
        [DynamoDBProperty]

        public string PatientUserName { get; set; }
        [DynamoDBProperty]

        public int AppintmentId { get; set; }
        [DynamoDBProperty]
        public string DoctorId { get; set; }
        [DynamoDBProperty]

        public DateTime AppointmentDate { get; set; }
        [DynamoDBProperty]

        public string Prescription { get; set; }
        [DynamoDBProperty]
        public int PaymentType { get; set; }




    }
}
