
namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Medicamento", Schema = "CV")]
    public partial class Medicamentos
    {
        public Medicamentos()
        {
            this.DetalleConsulta = new HashSet<DetalleConsulta>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Vacuna")]
        [StringLength(5, ErrorMessage = "El campo Código de Vacuna debe tener exactamente 5 caracteres.")]
        public string? CodigoVacuna { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripción")]
        [StringLength(100, ErrorMessage = "El campo Descripción no puede tener más de 100 caracteres.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "ID de Tipo de Medicamento")]
        public int TipoMedicamentoId { get; set; }

        public virtual TipoMedicamento? TipoMedicamento { get; set; }
        public virtual ICollection<DetalleConsulta> DetalleConsulta { get; set; }
    }
}
