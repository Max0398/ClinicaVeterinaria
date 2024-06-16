
namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Consultas", Schema = "CV")]

    public partial class Consulta
    {
        public Consulta()
        {
            this.DetalleConsulta = new HashSet<DetalleConsulta>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Consulta")]
        [StringLength(5, ErrorMessage = "El campo Código de Consulta no puede tener más de 10 caracteres.")]
        public string? CodigoConsulta { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Fecha de Consulta")]
        [DataType(DataType.Date)]
        public DateTime FechaConsulta { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripción de la Consulta")]
        [StringLength(100, ErrorMessage = "El campo Descripción de la Consulta no puede tener más de 100 caracteres.")]
        public string? DescripcionConsulta { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "ID de Mascota")]
        public int MascotaId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Fecha de Cita")]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripción de la Cita")]
        [StringLength(100, ErrorMessage = "El campo Descripción de la Cita no puede tener más de 200 caracteres.")]
        public string? DescripcionCita { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Veterinario")]
        public int VeterinarioId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public virtual Mascota? Mascota { get; set; }
        public virtual ICollection<DetalleConsulta> DetalleConsulta { get; set; }
        public virtual Veterinario? Veterinario { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
