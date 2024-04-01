/*using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Helper;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.UOW.Interface;
namespace Tooth_Booth_API.BusinessLogic
{
    public class AppointmentBusiness : IAppointmentBusiness
    {

         
        IMapper _mapper;
        public AppointmentBusiness(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;

        }

        public async Task AddAppointment(AppointmentAddDTO appointmentInput,string userName)
        {

            var dentist = _unitOfWork.DentistRepository.GetAll().FirstOrDefault((obj) => obj.Id.Equals(appointmentInput.DoctorId));
            if (dentist == null)
                throw new ApiError(404, Error.noDentistFound);
            else if (!dentist.Availability||dentist.MaxAppointment==0)
            {
                throw new ApiError(404, Error.dentistIsNotFree);
            }
            var appointment = _mapper.Map<Appointment>(appointmentInput);
            appointment.AppointmentDate = DateTime.Today;
            appointment.PatientUserName = userName;
            var clinicId = dentist.ClinicID;       
            appointment.ClinicId = clinicId;
            dentist.MaxAppointment -= 1;
          _unitOfWork.DentistRepository.Update(dentist);
           await _unitOfWork.AppointmentRepository.AddAsync(appointment);
            await _unitOfWork.SaveAsync();            
           
        }
        public  async Task UpdateAppointment(int id, string dentistId,JsonPatchDocument<Appointment> updateAppointment)
        {
          
            Appointment appoint= _unitOfWork.AppointmentRepository.GetAll().FirstOrDefault((a)=>a.AppointmentId.Equals(id)&&a.DoctorId.Equals(dentistId));
            if (appoint == null)
            {
                throw new ApiError(404, Error.noAppointmentFound);
            }
            updateAppointment.ApplyTo(appoint);
            _unitOfWork.AppointmentRepository.Update(appoint);
            await _unitOfWork.SaveAsync();
            
          
        }

        public IEnumerable<AppointmentDTO> GetAppointmentFilter(DateTime? dateTime,int? appointmentId,string patientUserName,string doctorId,int? clinicId) 
        {

            IEnumerable<Appointment> appointments = _unitOfWork.AppointmentRepository.GetAll();
            var appointmentsDTO=_mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
            if (dateTime.HasValue)
            {
             appointmentsDTO=  appointmentsDTO.Where((obj)=>obj.AppointmentDate.Equals(dateTime.Value)).ToList();
            }
            if (appointmentId.HasValue)
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.AppointmentId.Equals(appointmentId)).ToList();
            }
            if(!string.IsNullOrEmpty(patientUserName))
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.PatientUserName.Equals(patientUserName)).ToList();
            }
            if (!string.IsNullOrEmpty(doctorId))
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.DoctorId.Equals(doctorId)).ToList();
            }
            if(clinicId.HasValue) 
            {
                appointmentsDTO = appointmentsDTO.Where((obj) => obj.ClinicId.Equals(clinicId)).ToList();  
            }

            return appointmentsDTO;
        }
       
        public  async Task DeleteAppointById(int id,string userName) 
        {
         
            
            Appointment appointment = _unitOfWork.AppointmentRepository.GetAll().FirstOrDefault(obj => obj.PatientUserName.Equals(userName) &&
            obj.AppointmentId.Equals(id)&&
            obj.AppointmentDate.Equals(DateTime.Today)&&
            obj.Prescription.Length==0);
            if(appointment == null)
            {
                throw new ApiError(404,Error.noAppointmentFound);
            }
            else
            {
                var dentist = _unitOfWork.DentistRepository.GetAll().FirstOrDefault((obj) => obj.Id.Equals(appointment.DoctorId));

                dentist.MaxAppointment += 1;
                _unitOfWork.DentistRepository.Update(dentist);
              await _unitOfWork.AppointmentRepository.DeleteAsync(appointment.AppointmentId);
              await _unitOfWork.SaveAsync();                 

            }
            
        }


    }
}*/
