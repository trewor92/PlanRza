using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlanRza.Models.Data;
using PlanRza.Models.Enums;

namespace PlanRza.Models.Data.Test
{
    public class TestSeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            IServiceScope _serviceScope = app.ApplicationServices.CreateScope();
            ApplicationDbContext _context = _serviceScope.ServiceProvider
                .GetService<ApplicationDbContext>();

            if (!_context.Branches.Any())
            {
                _context.Branches.AddRange(
                new Branch
                {
                    Direction = BranchDirection.Electical,
                    Name = "PinES",
                    Substations = new List<Substation>
                    {
                        new Substation
                        {
                            Area="DrogichinRES",
                            Name="Drogichin",
                            VoltageLevel=VoltLevel._110kV,
                            Equipments= new List<Equipment>
                            {
                                new Transformer
                                {
                                    Name="T-1",
                                    Power=10000,
                                    PrimaryVoltage=VoltLevel._110kV,
                                    SecondaryVoltage=VoltLevel._35kV,
                                    TertiaryVoltage=VoltLevel._10kV,
                                    QuarternaryVoltage=VoltLevel.none,
                                    YearOfProduction=1960
                                },
                                new Breaker
                                {
                                    Appointment=BreakerAppointment.Coupling,
                                    Name="SV",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=2010,
                                    Type=BreakerType.SF6
                                }
                            }
                        },
                        new Substation
                        {
                            Area="PinskGorRES",
                            Name="Severnaya",
                            VoltageLevel=VoltLevel._110kV,
                            Equipments= new List<Equipment>
                            {
                                new CurrentTransformer
                                {
                                    Name="CT T-1",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=1980,
                                    CountOfPoles=3,
                                    CountOfSecondaryWinding=4,
                                    PrimaryCurrent=200,
                                    SecondaryCurrent=5
                                },
                                new VoltageTransformer
                                {
                                    Name="VT Bus #1",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=2000,
                                    CountOfSecondaryWinding=2,
                                    HasOpenedTriangle=true
                                }
                            }
                        }
                    }


                },
                new Branch
                {
                    Direction = BranchDirection.Heat,
                    Name = "PinTS",
                        Substations = new List<Substation> { 
                    
                        new Substation
                        {
                            Area="Pin TEC",
                            Name="ORU-110",
                            VoltageLevel=VoltLevel._110kV,
                            Equipments= new List<Equipment>
                            {
                                new Transformer
                                {
                                    Name="T-2",
                                    Power=25000,
                                    PrimaryVoltage=VoltLevel._110kV,
                                    SecondaryVoltage=VoltLevel._10kV,
                                    TertiaryVoltage=VoltLevel._10kV,
                                    QuarternaryVoltage=VoltLevel.none,
                                    YearOfProduction=1975
                                },
                                new Breaker
                                {
                                    Appointment=BreakerAppointment.Coupling,
                                    Name="SV",
                                    PrimaryVoltage=VoltLevel._110kV,
                                    YearOfProduction=1955,
                                    Type=BreakerType.Oil
                                }
                            }
                        },
                        new Substation
                        {
                            Area="ZapTEC",
                            Name="RU-10",
                            VoltageLevel=VoltLevel._10kV,
                            Equipments= new List<Equipment>
                            {
                                new CurrentTransformer
                                {
                                    Name="CT vvoda #1",
                                    PrimaryVoltage=VoltLevel._10kV,
                                    YearOfProduction=1990,
                                    CountOfPoles=2,
                                    CountOfSecondaryWinding=2,
                                    PrimaryCurrent=100,
                                    SecondaryCurrent=5
                                },
                                new VoltageTransformer
                                {
                                    Name="VT Bus #1",
                                    PrimaryVoltage=VoltLevel._10kV,
                                    YearOfProduction=2000,
                                    CountOfSecondaryWinding=2,
                                    HasOpenedTriangle=true
                                }
                            }
                        }
                    }
                }); 
                _context.SaveChanges();
            }
        }
    }
}