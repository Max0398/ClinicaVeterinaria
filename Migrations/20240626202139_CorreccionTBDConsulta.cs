using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionTBDConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleConsulta_Medicamento_MedicamentosId",
                schema: "CV",
                table: "DetalleConsulta");

            migrationBuilder.DropIndex(
                name: "IX_DetalleConsulta_MedicamentosId",
                schema: "CV",
                table: "DetalleConsulta");

            migrationBuilder.DropColumn(
                name: "MedicamentosId",
                schema: "CV",
                table: "DetalleConsulta");

            migrationBuilder.RenameColumn(
                name: "CodigoVacuna",
                schema: "CV",
                table: "Medicamento",
                newName: "CodigoMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleConsulta_MedicamentoId",
                schema: "CV",
                table: "DetalleConsulta",
                column: "MedicamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleConsulta_Medicamento_MedicamentoId",
                schema: "CV",
                table: "DetalleConsulta",
                column: "MedicamentoId",
                principalSchema: "CV",
                principalTable: "Medicamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleConsulta_Medicamento_MedicamentoId",
                schema: "CV",
                table: "DetalleConsulta");

            migrationBuilder.DropIndex(
                name: "IX_DetalleConsulta_MedicamentoId",
                schema: "CV",
                table: "DetalleConsulta");

            migrationBuilder.RenameColumn(
                name: "CodigoMedicamento",
                schema: "CV",
                table: "Medicamento",
                newName: "CodigoVacuna");

            migrationBuilder.AddColumn<int>(
                name: "MedicamentosId",
                schema: "CV",
                table: "DetalleConsulta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleConsulta_MedicamentosId",
                schema: "CV",
                table: "DetalleConsulta",
                column: "MedicamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleConsulta_Medicamento_MedicamentosId",
                schema: "CV",
                table: "DetalleConsulta",
                column: "MedicamentosId",
                principalSchema: "CV",
                principalTable: "Medicamento",
                principalColumn: "Id");
        }
    }
}
