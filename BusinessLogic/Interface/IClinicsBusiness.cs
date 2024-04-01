using Microsoft.AspNetCore.JsonPatch;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.BusinessLogic.Interface
{
    public interface IClinicsBusiness
    {
        Task<IEnumerable<ClinicDTO>> GetAllClinic(string clinicAdminId,int? clinicId,string clinicName,string clinicCity, bool? isVerified);
        Task UpdateClinic(int id,Clinic updateClinic);
        Task DeleteClinic(string city, int id);
    }
}
