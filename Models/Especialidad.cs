
namespace ClinicaVeterinaria.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Especialidad
    {
      
        public Especialidad()
        {
            this.EspecialidadesVeterinarios = new HashSet<EspecialidadesVeterinarios>();
        }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Especialidad")]
        [StringLength(5, ErrorMessage = "El campo Código de Especialidad no puede tener más de 5 caracteres.")]
        public string? CodigoEspecialidad { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "El campo Descripción no puede tener más de 50 caracteres.")]
        public string? Descripcion { get; set; }


        public virtual ICollection<EspecialidadesVeterinarios> EspecialidadesVeterinarios { get; set; }
    }
}
