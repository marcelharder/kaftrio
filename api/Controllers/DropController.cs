using System.Collections.Generic;
using api.DAL.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cardiohelp.Controllers
{
    [ApiController]
    [Authorize]
    public class DropController : ControllerBase
    {
        private Dropdownlists _drops;
        public DropController(Dropdownlists drops)
        {
            _drops = drops;
        }
        [Route("api/dropdownlist/{id}")]
        public List<Class_Item> Get(int id)
        {

            var ret = new List<Class_Item>();
            if (id == 61) { ret = _drops.getReasonForUse(); }
            if (id == 62) { ret = _drops.getTypeSupport(); }
            if (id == 63) { ret = _drops.getCannulationSite(); }
            if (id == 64) { ret = _drops.getGender(); }
            if (id == 65) { ret = _drops.getReasonDeadOnECLS(); }
            if (id == 66) { ret = _drops.getReasonDiscontinuing(); }
            if (id == 68) { ret = _drops.getYN(); }
            if (id == 69) { ret = _drops.getCannulaSiteRepair(); }
            if (id == 70) { ret = _drops.getVenousSizes(); }
            if (id == 71) { ret = _drops.getVVSizes(); }
            if (id == 72) { ret = _drops.getArterialSizes(); }
            if (id == 73) { ret = _drops.getArterialLength(); }
            if (id == 74) { ret = _drops.getVenousLength(); }
            if (id == 75) { ret = _drops.getDischargeLocation(); }
            if (id == 76) { ret = _drops.getLLDPDiameter(); }
            if (id == 77) { ret = _drops.getLLDPLength(); }
            if (id == 78) { ret = _drops.getAge(); }
            if (id == 79) { ret = _drops.getHeight(); }
            if (id == 80) { ret = _drops.getWeight(); }
            if (id == 81) { ret = _drops.getHours(); }
            if (id == 82) { ret = _drops.getMinutes(); }
            return ret;
        }


    }






}
