
namespace ClinicaVeterinaria.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Colores", Schema = "CV")]
    public partial class Colores
    {
        public Colores()
        {
            this.MascotaColores = new HashSet<MascotaColores>();
        }

        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Campo Necesario")]
        [Display(Name ="Codigo de Color")]
        [StringLength(5)]
        public string? CodigoColor { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripcion")]
        [StringLength(40)]
        public string? Descripcion { get; set; }
    
        public virtual ICollection<MascotaColores> MascotaColores { get; set; }
    }
}
