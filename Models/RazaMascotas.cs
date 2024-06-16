
namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RazaMascota", Schema = "CV")]
    public partial class RazaMascotas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "ID de Mascota")]
        public int MascotaId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "ID de Raza")]
        public int RazaId { get; set; }

        public virtual Mascota Mascota { get; set; }
        public virtual Raza Raza { get; set; }
    }
}
