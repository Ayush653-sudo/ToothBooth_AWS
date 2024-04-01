using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.BusinessLogic.Interface
{
    public interface IAppointmentBusiness
    {
        Task AddAppointment(AppointmentAddDTO appointment,string userName);
        Task UpdateAppointment(int  id,string dentistId, JsonPatchDocument<Appointment>updateAppointment);
        IEnumerable<AppointmentDTO> GetAppointmentFilter(DateTime? dateTime,int? appointmentId,string patientUserName,string DoctorId,int? clinicId);

        Task DeleteAppointById(int id,string userName);
    }
}