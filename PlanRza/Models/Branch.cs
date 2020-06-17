using PlanRza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanRza.Models
{
    public class Branch:BaseEntity
    {
        public BranchDirection Direction { get; set; }
        public List<Substation> Substations { get; set; }
    }
}
