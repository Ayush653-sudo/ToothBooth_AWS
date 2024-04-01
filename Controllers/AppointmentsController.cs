/*

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.Helper;
using Tooth_Booth_API.Helper.LogManager1;
using Microsoft.AspNetCore.Http;

namespace Tooth_Booth_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        IAppointmentBusiness _appointmentBusiness { get; set; }

        public AppointmentsController(IAppointmentBusiness appointmentBusiness)
        {
            this._appointmentBusiness = appointmentBusiness;

        }

      *//*  [HttpPost]
        [Authorize(Roles = Roles.patient)]
        public async Task<IActionResult> Post([FromBody] AppointmentAddDTO model)

        {
            try
            {
                var userName = User.Identity.GetUserName();

                await _appointmentBusiness.AddAppointment(model, userName);

                return StatusCode(StatusCodes.Status200OK, SuccessMessage.appointmentAddedSucessFully);

            }
            catch (ApiError error)
            {

                return StatusCode(error.statusCode, error.message);
            }


        }*//*




        [HttpGet]
     //   [Authorize(Roles = Roles.dentist + "," + Roles.patient)]

        public IActionResult Get(DateTime? date, int? appointmentId, string patientUserName, string DoctorId, int? clinicId)
        {

            if (User.IsInRole(Roles.dentist))
            {
                DoctorId = User.Identity.GetUserId();
            }
            if (User.IsInRole(Roles.patient))
            {
                patientUserName = User.Identity.GetUserName();
            }


            IEnumerable<AppointmentDTO> appointments = _appointmentBusiness.GetAppointmentFilter(date, appointmentId, patientUserName, DoctorId, clinicId);
            return Ok(appointments);




        }



        [HttpPatch("{id}")]
        [Authorize(Roles = Roles.dentist)]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Appointment> updateAppointment)
        {

            try
            {
                var dentistId = User.Identity.GetUserId();

                await _appointmentBusiness.UpdateAppointment(id, dentistId, updateAppointment);
                // return Ok(SuccessMessage.appointmentUpdateSucessFully);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (ApiError ex)
            {
                return StatusCode(ex.statusCode, ex.Message);
            }


        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Roles.patient)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userName = User.Identity.GetUserName();
                await _appointmentBusiness.DeleteAppointById(id, userName);
                return Ok(SuccessMessage.appointmentDeletedSucessFully);

            }
            catch (ApiError ex)
            {
                return StatusCode(ex.statusCode, ex.Message);
            }


        }

    }
}
*/