
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.Helper;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Controllers
{

   [Route("[controller]")]
   // [ApiController]
    public class ClinicsController : ControllerBase
    {
          IClinicsBusiness _clinicsBusiness;
        
        public ClinicsController(IClinicsBusiness clinicBusiness)
        { 
            this._clinicsBusiness = clinicBusiness;
           
        }

       
     


        [HttpGet]
 public async Task<IActionResult> Get(string clinicAdminId,string clinicCity)
 {
     

         var listOfClinic = await _clinicsBusiness.GetAllClinic(clinicAdminId,clinicCity);
         return Ok(listOfClinic);
     
     

 }

        

        [HttpPut("{id:int}")]
       // [Authorize(Roles = Roles.admin)]
        public async Task<IActionResult> Put(int id,[FromBody] Clinic updateClinic)
        {

            try
            {
                await _clinicsBusiness.UpdateClinic(id, updateClinic);
                return StatusCode(StatusCodes.Status200OK, SuccessMessage.clinicUpdatedSucessfully);
            }
            catch(ApiError ex)
            {
                return StatusCode(ex.statusCode, ex.message);
            }
            
          

        }
        [HttpDelete("{city}/{id}")]
        public async Task<IActionResult> Delete(string city ,int id)
        {

            try
            {
                await _clinicsBusiness.DeleteClinic(city,id);
                return StatusCode(StatusCodes.Status200OK, SuccessMessage.clinicDeletedSucessFully);
            }
            catch (ApiError ex)
            {
                return StatusCode(ex.statusCode,ex.message);
            }
            
            
        }

    }
}
