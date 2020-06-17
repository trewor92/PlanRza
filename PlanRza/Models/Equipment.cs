using PlanRza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanRza.Models
{
    public class Equipment:BaseEntity
    {
        public int YearOfProduction { get; set; }
        public VoltLevel PrimaryVoltage { get; set; }
    }

    public class Transformer : Equipment
    {
        public VoltLevel SecondaryVoltage { get; set; }
        public VoltLevel TertiaryVoltage { get; set; }
        public VoltLevel QuarternaryVoltage { get; set; }
        public int Power { get; set; }
        public override string ToString()
        {
            return "Transformer " + base.ToString();
        }
    }
    
    public class Breaker : Equipment
    { 
       public BreakerAppointment Appointment { get; set; }
       public BreakerType Type { get; set; }
    }

    public class VoltageTransformer : Equipment
    { 
        public int CountOfSecondaryWinding { get; set; }
        public bool HasOpenedTriangle { get; set; }

        public override string ToString()
        {
            return "Voltage transformer " + base.ToString();
        }
    }

    public class CurrentTransformer : Equipment
    {
        public int CountOfSecondaryWinding { get; set; }

        public int CountOfPoles { get; set; }

        public int PrimaryCurrent { get; set; }

        public int SecondaryCurrent { get; set; }

        public override string ToString()
        {
            return "Current transformer " + base.ToString();
        }
    }
}
