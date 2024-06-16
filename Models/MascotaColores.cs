
namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MascotaColores", Schema = "CV")]
    public partial class MascotaColores
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Mascota")]
        public int MascotaId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Color")]
        public int ColoresId { get; set; }

        public virtual Mascota? Mascota { get; set; }
        public virtual Colores? Colores { get; set; }
    }
}
