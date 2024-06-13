
namespace ClinicaVeterinaria.Data;

using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using System;

public partial class ClinicaContainer : DbContext
{
    public ClinicaContainer(DbContextOptions<ClinicaContainer> options)
        : base(options)
    {
    }


    public virtual DbSet<Cliente> ClienteSet { get; set; }
    public virtual DbSet<Mascota> MascotaSet { get; set; }
    public virtual DbSet<Especie> EspecieSet { get; set; }
    public virtual DbSet<Raza> RazaSet { get; set; }
    public virtual DbSet<Colores> ColoresSet { get; set; }
    public virtual DbSet<Medicamentos> MedicamentosSet { get; set; }
    public virtual DbSet<Consulta> ConsultaSet { get; set; }
    public virtual DbSet<Veterinario> VeterinarioSet { get; set; }
    public virtual DbSet<Especialidad> EspecialidadSet { get; set; }
    public virtual DbSet<RazaMascotas> RazaMascotasSet { get; set; }
    public virtual DbSet<EspecialidadesVeterinarios> EspecialidadesVeterinariosSet { get; set; }
    public virtual DbSet<DetalleConsulta> DetalleConsultaSet { get; set; }
    public virtual DbSet<MascotaColores> MascotaColoresSet { get; set; }
    public virtual DbSet<TipoMedicamento> TipoMedicamentoSet { get; set; }
}
