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
    public class GraphController : ControllerBase
    {
        
        private IElementaryStatistics _st;
        public GraphController(IElementaryStatistics st)
        {
            _st = st;
        }

        [Route("api/ageGraph")]
        public async Task<IActionResult> GetAsyncAge()
        {
            return Ok(await _st.getAgeDistributionPerHospital());
        }

    }
}
