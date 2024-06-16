
namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoMedicamento", Schema = "CV")]

    public partial class TipoMedicamento
    {
        public TipoMedicamento()
        {
            this.Medicamentos = new HashSet<Medicamentos>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Tipo")]
        [StringLength(5, ErrorMessage = "El campo Código de Tipo debe tener exactamente 5 caracteres.")]
        public string CodigoTipo { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Descripción")]
        [StringLength(100, ErrorMessage = "El campo Descripción no puede tener más de 100 caracteres.")]
        public string Descripcion { get; set; }

        public virtual ICollection<Medicamentos> Medicamentos { get; set; }
    }
}
