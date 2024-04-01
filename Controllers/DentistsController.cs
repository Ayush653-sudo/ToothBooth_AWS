
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using serverless_dotnet.Models;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Common.Message;
using Tooth_Booth_API.Helper;
using Tooth_Booth_API.Helper.LogManager1;

namespace Tooth_Booth_API.Controllers
{
    [Route("[controller]")]
  //  [ApiController]
    public class DentistsController:ControllerBase
    {
        IDentistBusiness _dentistBusiness {  get; set; }
        private  ILoggerManager _logger;
        public DentistsController(IDentistBusiness dentistBusiness) 
        {
            this._dentistBusiness = dentistBusiness;
            
        }

       [HttpGet]
        public async Task<IActionResult> Get(int? ClinicId)
        {
            try
            {
                var listOfDentistDTO = await _dentistBusiness.GetDentistByClinicId(ClinicId);
                return Ok(listOfDentistDTO);
            }
            catch(ApiError ex)
            {
                return StatusCode(ex.statusCode,ex.message);
            }

            
        
        }
        [HttpPatch("{userId}")]
      
       // [Authorize(Roles = Roles.dentist)]
        public async Task<IActionResult> Patch( string userId,[FromBody] Dentist updateDentist)
        {
            try
            {
                
                
                await _dentistBusiness.UpdateDentist(userId, updateDentist);
                return Ok(SuccessMessage.dentistAddedSucessFully);
               
            }
            catch (ApiError ex)
            {
                return StatusCode(ex.statusCode, ex.Message);
            }
            

        }

        [HttpDelete("{id}")]
        /*[Authorize(Roles = Roles.clinicAdmin)]*/
        public async Task<IActionResult> Delete(string id) 
        {

            try
            {
               // var userId = User.Identity.GetUserId();
                await _dentistBusiness.DeleteDentist(id, "eef");
                    return StatusCode(StatusCodes.Status200OK, SuccessMessage.dentistDeletedSucessFully);
               
            }
            catch(ApiError ex)
            {
                return StatusCode(ex.statusCode,ex.Message);
            }
            
        }


    }
}
