

namespace ClinicaVeterinaria.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DetalleConsulta", Schema = "CV")]

    public partial class DetalleConsulta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        public int ConsultaId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Aplicación")]
        [StringLength(80, ErrorMessage = "El campo Aplicación no puede tener más de 80 caracteres.")]
        public string? Aplicacion { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        public int MedicamentoId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un número positivo.")]
        public int Cantidad { get; set; }

        public virtual Consulta? Consulta { get; set; }
        public virtual Medicamentos? Medicamentos { get; set; }
    }
}
