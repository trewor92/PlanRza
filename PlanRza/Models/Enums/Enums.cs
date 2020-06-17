using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanRza.Models.Enums
{
    public enum VoltLevel
    {
        [Description("None")]
        none,
        [Description("10 kV")]
        _10kV,
        [Description("35 kV")]
        _35kV,
        [Description("110 kV")]
        _110kV,
        [Description("220 kV")]
        _220kV,
        [Description("330 kV")]
        _330kV
    }

    [Flags]
    public enum BranchDirection
    {
        Electical = 1,
        Heat = 2
    }

    [Flags]
    public enum BreakerAppointment
    {
        Coupling = 1,
        Bypass = 2,
        BusCoupling = 4,
        Line = 8,
        Transformer = 16
    }

    public enum BreakerType
    {
        Oil=1,
        Vacuum=2,
        SF6=3,
        Air=4
    }
}
