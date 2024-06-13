
namespace ClinicaVeterinaria.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {
        public Cliente()
        {
            this.Consulta = new HashSet<Consulta>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Nombres")]
        [StringLength(30, ErrorMessage = "El campo Nombres no puede tener más de 30 caracteres.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Primer Apellido")]
        [StringLength(30, ErrorMessage = "El campo Primer Apellido no puede tener más de 30 caracteres.")]
        public string? Apellidos1 { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Segundo Apellido")]
        [StringLength(30, ErrorMessage = "El campo Segundo Apellido no puede tener más de 30 caracteres.")]
        public string? Apellidos2 { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Dirección")]
        [StringLength(100, ErrorMessage = "El campo Dirección no puede tener más de 100 caracteres.")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Teléfono")]
        [StringLength(15, ErrorMessage = "El campo Teléfono no puede tener más de 15 caracteres.")]
        [Phone(ErrorMessage = "El campo Teléfono no tiene un formato válido.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(20, ErrorMessage = "El campo Correo Electrónico no puede tener más de 20 caracteres.")]
        [EmailAddress(ErrorMessage = "El campo Correo Electrónico no tiene un formato válido.")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Número de Identificación")]
        [StringLength(20, ErrorMessage = "El campo Número de Identificación no puede tener más de 20 caracteres.")]
        public string? N_Identificacion { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Cliente")]
        [StringLength(5, ErrorMessage = "El campo Código de Cliente no puede tener más de 5 caracteres.")]
        public string? CodigoCliente { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
