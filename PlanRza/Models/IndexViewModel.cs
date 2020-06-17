using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanRza.Models
{
    public class IndexViewModel
    {
        public string Params { get; set; }
        public string Name { get; set; }

        public bool IsFolder { get; set; }

        public string Method { get; set; }
    }
}
