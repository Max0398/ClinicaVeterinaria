
namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Raza", Schema = "CV")]
    public partial class Raza
    {
        public Raza()
        {
            this.RazaMascotas = new HashSet<RazaMascotas>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Raza")]
        [StringLength(5, ErrorMessage = "El campo Código de Raza debe tener exactamente 5 caracteres.")]
        public string? CodigoRaza { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripción")]
        [StringLength(80, ErrorMessage = "El campo Descripción no puede tener más de 80 caracteres.")]
        public string? Descripcion { get; set; }

        public virtual ICollection<RazaMascotas> RazaMascotas { get; set; }
    }
}
