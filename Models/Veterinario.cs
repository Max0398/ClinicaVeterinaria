

namespace ClinicaVeterinaria.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Veterinario", Schema = "CV")]
    public partial class Veterinario
    {
        public Veterinario()
        {
            EspecialidadesVeterinarios = new HashSet<EspecialidadesVeterinarios>();
            Consulta = new HashSet<Consulta>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Veterinario")]
        [StringLength(5, ErrorMessage = "El campo Código de Veterinario debe tener exactamente 5 caracteres.")]
        public string? CodigoVeterinario { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Nombres")]
        [StringLength(50, ErrorMessage = "El campo Nombres no puede tener más de 50 caracteres.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Primer Apellido")]
        [StringLength(50, ErrorMessage = "El campo Primer Apellido no puede tener más de 50 caracteres.")]
        public string? Apellidos1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        [StringLength(50, ErrorMessage = "El campo Segundo Apellido no puede tener más de 50 caracteres.")]
        public string? Apellidos2 { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Teléfono")]
        [StringLength(15, ErrorMessage = "El campo Teléfono no puede tener más de 15 caracteres.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(30, ErrorMessage = "El campo Correo Electrónico no puede tener más de 30 caracteres.")]
        [EmailAddress(ErrorMessage = "El campo Correo Electrónico no tiene un formato válido.")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Dirección")]
        [StringLength(100, ErrorMessage = "El campo Dirección no puede tener más de 100 caracteres.")]
        public string? Direccion { get; set; }


        public virtual ICollection<EspecialidadesVeterinarios> EspecialidadesVeterinarios { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
