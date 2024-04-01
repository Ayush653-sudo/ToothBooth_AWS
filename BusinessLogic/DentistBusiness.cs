
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using serverless_dotnet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Helper;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.Repository;


namespace Tooth_Booth_API.BusinessLogic
{
    public class DentistBusiness : IDentistBusiness
    {
        private readonly IRepository<Dentist, string> _dentistRepository;
        private readonly IRepository<Clinic, int> _clinicRepository;
        private readonly IMapper _mapper;
        public DentistBusiness(IRepository<Dentist, string> dentistRepository, IMapper mapper, IRepository<Clinic, int> clinicRepository)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
            _clinicRepository = clinicRepository;
        }

        public async  Task<IEnumerable<DentistDTO>> GetDentistByClinicId(int? ClinicId)
        {
           var listOfDentist=await _dentistRepository.GetAll(ClinicId.ToString());
            //if (!ClinicId.HasValue)
           // {
               var listOfDentistDTO = _mapper.Map<IEnumerable<DentistDTO>>(listOfDentist);
            return listOfDentistDTO;
          //  }
         //return _mapper.Map<IEnumerable<DentistDTO>>(listOfDentist.Where((obj)=>obj.ClinicID.Equals(ClinicId)));
            
        }
        public async Task UpdateDentist(string id,Dentist updateDentist)
        {

            var listOfDentists = await _dentistRepository.GetAll("");
               var dentist = listOfDentists.FirstOrDefault((a) => a.Id.Equals(id));
            if (dentist == null)
            {
                throw new ApiError(404, Error.noDentistFound);
            }
            
          await _dentistRepository.Update(updateDentist);
          
            
        }

        public async Task DeleteDentist(string id, string userID)
        {

            var listOfClinics = await _clinicRepository.GetAll(userID);
                var clinicId= listOfClinics.FirstOrDefault((obj)=>obj.ClinicAdminId.Equals(userID))!.ClinicId;
            var listOfDentists = await _dentistRepository.GetAll(clinicId.ToString());
            Dentist dentist = listOfDentists.FirstOrDefault(obj => obj.ClinicID == clinicId && obj.Id == id)!;


            if (dentist == null)
                throw new ApiError(404,Error.noDentistFound);
            else
            {
                /* IdentityUser identityUser = await _unitOfWork.AuthRepository.Find(dentist.Id);

                 var result = await _unitOfWork.AuthRepository.Delete(identityUser);
                 if (result.Succeeded)

                 {*/

                await _dentistRepository.DeleteAsync("", dentist.Id);
                                           
              //  }
              /*  else
                {
                    throw new ApiError(500, Error.someThingWrong);
                }*/
            }
           

        }

    }
}
