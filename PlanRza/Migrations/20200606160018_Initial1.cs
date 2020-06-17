using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanRza.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Direction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Substations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    VoltageLevel = table.Column<int>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Substations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<int>(nullable: false),
                    PrimaryVoltage = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    SubstationId = table.Column<int>(nullable: true),
                    Appointment = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    CountOfSecondaryWinding = table.Column<int>(nullable: true),
                    CountOfPoles = table.Column<int>(nullable: true),
                    PrimaryCurrent = table.Column<int>(nullable: true),
                    SecondaryCurrent = table.Column<int>(nullable: true),
                    SecondaryVoltage = table.Column<int>(nullable: true),
                    TertiaryVoltage = table.Column<int>(nullable: true),
                    QuarternaryVoltage = table.Column<int>(nullable: true),
                    Power = table.Column<int>(nullable: true),
                    VoltageTransformer_CountOfSecondaryWinding = table.Column<int>(nullable: true),
                    HasOpenedTriangle = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Substations_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "Substations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SubstationId",
                table: "Equipments",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_Substations_BranchId",
                table: "Substations",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Substations");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
