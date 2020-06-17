using PlanRza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanRza.Models
{
    public class Substation:BaseEntity
    {
    
        public VoltLevel VoltageLevel { get; set; }

        public string Area { get; set; }

        public List<Equipment> Equipments { get; set; }
    }
}
