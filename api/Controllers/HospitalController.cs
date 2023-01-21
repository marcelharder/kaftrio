using System.Collections.Generic;
using System.Security.Claims;
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
    public class HospitalController : ControllerBase
    {
        private IHospitalRepository _hos;
        private SpecialMaps _special;
        public HospitalController(IHospitalRepository hos, SpecialMaps special)
        {
            _hos = hos;
            _special = special;
        }

        [Route("api/getHospital/{id}", Name = "GetHospital")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _hos.getHospitalDetails(id));
        }

        [HttpDelete]
        [Route("api/deleteHospital/{id}/{center_id}")]
        public async Task<IActionResult> removeHospital(int id, int center_id){
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id) return Unauthorized();

            // remove the correct hospital
            var selectedHospital = await _hos.getHospitalDetails(center_id);
            _hos.Delete(selectedHospital);
            if (await _hos.SaveAll()) { return Ok("Hospital deleted ..."); }
           return BadRequest("Could not delete the hospital ...");
        }


        [HttpGet]
        [Route("api/addHospital/{id}")]
        public async Task<IActionResult> addHospital(int id)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id) return Unauthorized();
            var newHospital = new hospital();
            _hos.Add(newHospital);
            if (await _hos.SaveAll())
            {
                return CreatedAtRoute("GetHospital", new { id = newHospital.center_id }, newHospital);
            }
            return BadRequest("Could not add the hospital ...");
        }

        [HttpGet]
        [Route("api/getListOfHospitals")]
        public async Task<IActionResult> Get([FromQuery] HospitalParams h)
        {
            var values = await _hos.getHospitals(h);
            var l = new List<hospital>();
            foreach (hospital us in values)
            {
                l.Add(us);
            }
            Response.AddPagination(values.Currentpage, values.PageSize, values.TotalCount, values.TotalPages);
            return Ok(l);
        }

        [HttpGet]
        [Route("api/getListOfHospitalsPerCountry")]
        public async Task<IActionResult> GetPerCountry([FromQuery] HospitalParams h)
        {
            var values = await _hos.getHospitalsCountry(h);
            var l = new List<hospital>();
            foreach (hospital us in values)
            {
                l.Add(us);
            }
            Response.AddPagination(values.Currentpage, values.PageSize, values.TotalCount, values.TotalPages);
            return Ok(l);
        }

        [HttpPut]
        [Route("api/updateHospital/{id}")]
        public async Task<IActionResult> PutAsync(int id, hospitalForUpdateDTO td)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id) return Unauthorized();

            var hospital_before = await _hos.getHospitalDetails(td.Id);
            _hos.Update(_special.mapToHospitalAsync(td, hospital_before));
            if (await _hos.SaveAll()) { return Ok("updated ..."); } else { return BadRequest(); }
        }


    }

}