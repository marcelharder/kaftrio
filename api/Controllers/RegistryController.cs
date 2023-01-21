using System.Collections.Generic;
using System.Threading.Tasks;
using api.DAL.code;
using api.DAL.data;
using api.DAL.dtos;
using api.DAL.helpers;
using Cardiohelp.data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cardiohelp.Controllers
{
    [ApiController]
    [Authorize]
    public class RegistryController : ControllerBase
    {
        private IRegistryRepository _reg;
        private SpecialMaps _spm;

        public RegistryController(IRegistryRepository reg, SpecialMaps spm)
        {
            _reg = reg;
            _spm = spm;

        }

         [HttpGet]
        [Route("api/getListOfRegistries")]
        public async Task<IActionResult> Get([FromQuery] UserParams userParams)
        {
            var l = new List<RegistryForReturnDto>();
            var values = await _reg.getListOfRegistries(userParams);
            foreach (patientData us in values)
            {
                l.Add(await _spm.mapToRegistryForDto(us));
            }

            Response.AddPagination(values.Currentpage, values.PageSize, values.TotalCount, values.TotalPages);
            return Ok(l);
        }


        /*
        -------- CRUD Stuff ----------
        */

        [HttpGet]
        [Route("api/getRegistry/{id}", Name = "GetRegistry")]
        public async Task<RegistryForReturnDto> GetAsync(int id)
        {
            return await _reg.getRegistry(id);
        }
       
        [HttpPost]
        [Route("api/addRegistry")]
        public async Task<IActionResult> addReg()
        {
            var recordToAdd = new patientData();
            _reg.Add(recordToAdd);
            if(await _reg.SaveAll()){
            return CreatedAtRoute("GetRegistry", new { id = recordToAdd.Id }, recordToAdd);
            }
            return BadRequest("Adding record failed");
        }

        [HttpPut]
        [Route("api/updateRegistry")]
        public async Task<IActionResult> updateReg([FromBody]RegistryForUpdateDTO dt)
        {
            var currentRecord = await _reg.getFullPatientData(dt.Id);
            var update_record = _spm.mapToPatientData(dt,currentRecord);
            _reg.Update(update_record);
            if(await _reg.SaveAll()){return Ok("record updated");}
            return BadRequest("Updating record failed");
        }
     
        [HttpDelete]
        [Route("api/deleteRegistry/{id}")]
        public async Task<IActionResult> deleteReg(int id)
        {
            var currentRecord = await _reg.getFullPatientData(id);
            _reg.Delete(currentRecord);
            if(await _reg.SaveAll()){return Ok("record removed");}
            return BadRequest("record could not be removed");
        }



    }
}