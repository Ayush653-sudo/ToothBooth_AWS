using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Helper;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.Repository;


namespace Tooth_Booth_API.BusinessLogic
{
    public class ClinicsBusinesscs:IClinicsBusiness
    {
       
        private readonly IMapper _mapper;
        private readonly IRepository<Clinic,int> _clinicRepository;
        public ClinicsBusinesscs(IMapper mapper, IRepository<Clinic, int> clinicRepository)
        {

           
            _mapper = mapper;
            _clinicRepository = clinicRepository;
        }

        public async Task<IEnumerable<ClinicDTO>> GetAllClinic(string clinicAdminId, int? clinicId,string clinicName,string clinicCity,bool? isVerified)
        {
            
            var Allclinics= await _clinicRepository.GetAll(clinicCity);
            var clinics = _mapper.Map<IEnumerable<ClinicDTO>>(Allclinics);


            if (!string.IsNullOrEmpty(clinicAdminId))
            {
                return clinics.Where((obj) => obj.ClinicAdminId == clinicAdminId);
            }
            if (clinicId.HasValue)
            {
                return clinics.Where((obj) => obj.ClinicId == clinicId);
            }
                   
            if(!string.IsNullOrEmpty(clinicName))
            {
              clinics=clinics.Where((obj) => obj.ClinicName == clinicName);
            }
           
            if (isVerified.HasValue)
            {
                clinics = clinics.Where((obj) => obj.Isverified==isVerified);
            }
            return clinics;
        }
            

        
        public async Task UpdateClinic(int id,Clinic updateClinic)
        {



            var clinics = await _clinicRepository.GetAll(updateClinic.ClinicCity);
          var  clinic = clinics.FirstOrDefault((a) => a.ClinicId.Equals(id));
            if (clinic == null)
            {
                throw new ApiError(404, Error.noClinicFound);
            }
          
          await _clinicRepository.Update(updateClinic);
          

        }
        public async Task DeleteClinic(string city ,int id)
        {
            var clinics = await _clinicRepository.GetAll(city);
            var clinic = clinics.FirstOrDefault((a) => a.ClinicId.Equals(id));
            if (clinic == null)
            {
                throw new ApiError(404, Error.noClinicFound);
            }
            else
            {
                await _clinicRepository.DeleteAsync(city ,clinic.ClinicId);

               /* IdentityUser clinicAdmin = await _unitOfWork.AuthRepository.Find(clinic.ClinicAdminId);
                var result = await _unitOfWork.AuthRepository.Delete(clinicAdmin);
                if (result.Succeeded)
                {
                    await _unitOfWork.SaveAsync();
                }
                else
                    throw new ApiError(500, Error.someThingWrong);*/

            }

        }

    }
}
