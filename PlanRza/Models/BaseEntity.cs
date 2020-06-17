using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanRza.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }

    }
}
