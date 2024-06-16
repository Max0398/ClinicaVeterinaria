
namespace ClinicaVeterinaria.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EspecialidadVeterinario", Schema = "CV")]
    public partial class EspecialidadesVeterinarios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Veterinario")]
        public int VeterinarioId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Especialidad")]
        public int EspecialidadId { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Título Obtenido")]
        [StringLength(50, ErrorMessage = "El campo Título Obtenido no puede tener más de 50 caracteres.")]
        public string? TituloObtenido { get; set; }

        public virtual Veterinario? Veterinario { get; set; }
        public virtual Especialidad? Especialidad { get; set; }
    }
}
