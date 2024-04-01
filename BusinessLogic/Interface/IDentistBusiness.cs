using Microsoft.AspNetCore.JsonPatch;
using serverless_dotnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO;

namespace Tooth_Booth_API.BusinessLogic.Interface
{
    public interface IDentistBusiness
    {
        Task<IEnumerable<DentistDTO>> GetDentistByClinicId(int? ClinicID);
        Task UpdateDentist(string id,Dentist updateDentint);
        Task DeleteDentist(string id,string userID);



    }
}