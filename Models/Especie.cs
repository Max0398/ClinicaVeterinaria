
namespace ClinicaVeterinaria.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Especie", Schema = "CV")]

    public partial class Especie
    {
        public Especie()
        {
            this.Mascota = new HashSet<Mascota>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Especie")]
        [StringLength(5, ErrorMessage = "El campo Código de Especie no puede tener más de 5 caracteres.")]
        public string? CodigoEspecie { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripción")]
        [StringLength(40, ErrorMessage = "El campo Descripción no puede tener más de 40 caracteres.")]
        public string? Descripcion { get; set; }

        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
