using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class TablasBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CV");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    N_Identificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CodigoCliente = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoColor = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                schema: "CV",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEspecialidad = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEspecie = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raza",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRaza = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMedicamento",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTipo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedicamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoVeterinario = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMascota = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PesoActual = table.Column<double>(type: "float", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EspecieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_Especie_EspecieId",
                        column: x => x.EspecieId,
                        principalSchema: "CV",
                        principalTable: "Especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoVacuna = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoMedicamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_TipoMedicamento_TipoMedicamentoId",
                        column: x => x.TipoMedicamentoId,
                        principalSchema: "CV",
                        principalTable: "TipoMedicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadVeterinario",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    TituloObtenido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadVeterinario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecialidadVeterinario_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalSchema: "CV",
                        principalTable: "Especialidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadVeterinario_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalSchema: "CV",
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoConsulta = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescripcionConsulta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescripcionCita = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "CV",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalSchema: "CV",
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalSchema: "CV",
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MascotaColores",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    ColoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotaColores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MascotaColores_Colores_ColoresId",
                        column: x => x.ColoresId,
                        principalSchema: "CV",
                        principalTable: "Colores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MascotaColores_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalSchema: "CV",
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RazaMascota",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    RazaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RazaMascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RazaMascota_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalSchema: "CV",
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RazaMascota_Raza_RazaId",
                        column: x => x.RazaId,
                        principalSchema: "CV",
                        principalTable: "Raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleConsulta",
                schema: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaId = table.Column<int>(type: "int", nullable: false),
                    Aplicacion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    MedicamentosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleConsulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleConsulta_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalSchema: "CV",
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleConsulta_Medicamento_MedicamentosId",
                        column: x => x.MedicamentosId,
                        principalSchema: "CV",
                        principalTable: "Medicamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ClienteId",
                schema: "CV",
                table: "Consultas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MascotaId",
                schema: "CV",
                table: "Consultas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_VeterinarioId",
                schema: "CV",
                table: "Consultas",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleConsulta_ConsultaId",
                schema: "CV",
                table: "DetalleConsulta",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleConsulta_MedicamentosId",
                schema: "CV",
                table: "DetalleConsulta",
                column: "MedicamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadVeterinario_EspecialidadId",
                schema: "CV",
                table: "EspecialidadVeterinario",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadVeterinario_VeterinarioId",
                schema: "CV",
                table: "EspecialidadVeterinario",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_EspecieId",
                schema: "CV",
                table: "Mascota",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaColores_ColoresId",
                schema: "CV",
                table: "MascotaColores",
                column: "ColoresId");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaColores_MascotaId",
                schema: "CV",
                table: "MascotaColores",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_TipoMedicamentoId",
                schema: "CV",
                table: "Medicamento",
                column: "TipoMedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RazaMascota_MascotaId",
                schema: "CV",
                table: "RazaMascota",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_RazaMascota_RazaId",
                schema: "CV",
                table: "RazaMascota",
                column: "RazaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleConsulta",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "EspecialidadVeterinario",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "MascotaColores",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "RazaMascota",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Consultas",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Medicamento",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Especialidad",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Colores",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Raza",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Mascota",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Veterinario",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "TipoMedicamento",
                schema: "CV");

            migrationBuilder.DropTable(
                name: "Especie",
                schema: "CV");
        }
    }
}
