using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanRza.Models;
using PlanRza.Models.Data;
using PlanRza.Models.Enums;
using PlanRza.Extensions;
using System.Reflection.Metadata;

namespace PlanRza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjaxController : Controller
    {
        private readonly IRepository<Branch> _repoBranch;
        private readonly IRepository<Substation> _repoSubstation;
        
        public AjaxController(IRepository<Branch> repoBranch, IRepository<Substation> repoSubstation)
        {
            _repoBranch = repoBranch;
            _repoSubstation = repoSubstation;
        }
        
        [HttpGet("[action]/branch/{branchId}")] //api/ajax/VoltLevels/branch/1
        public async Task<IActionResult> VoltLevels(int branchId)
        {
            List<dynamic> listVariants = await _repoBranch.DeepFindVariantsAsync(branchId, nameof(Substation.VoltageLevel));
            var toReturn = listVariants.OfType<VoltLevel>()
                .Select(x => new IndexViewModel
                {
                    Params = "branch/" + branchId + "/voltageLevel/" + (int)x,
                    Name = x.GetDescription(),
                    IsFolder = true,
                    Method = nameof(this.Substations)
                });
            if (toReturn == null)
                return NotFound();    
            return Ok(toReturn);
        }
        

        [HttpGet("[action]/branch/{branchId}/voltageLevel/{voltageLevel}")] //api/ajax/substations/branch/1/voltageLevel/1
        public async Task<IActionResult> Substations(int branchId, int voltageLevel)
        {
            Branch branch = await _repoBranch.DeepFindAsync(branchId);
            var toReturn = branch.Substations
                .Where(x=>x.VoltageLevel ==(VoltLevel)voltageLevel)
                .Select(x => new IndexViewModel 
                { Params = "substation/"+x.Id.ToString(), Name = x.Name, IsFolder = true, Method = nameof(this.Equipments) });
            if (toReturn == null)
                return NotFound();
            return Ok(toReturn);
        }

        [HttpGet("[action]/substation/{substationId}")] //api/ajax/Equipments/substation/1
        public async Task<IActionResult> Equipments(int substationId)
        {
            Substation substation = await _repoSubstation.DeepFindAsync(substationId);
            var toReturn = substation.Equipments.Select(x => new IndexViewModel  { Name = x.Name,IsFolder=false });
            if (toReturn == null)
                return NotFound();
            return Ok(toReturn);
        }
    }
}