

namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Mascota
    {
        public Mascota()
        {
            this.RazaMascotas = new HashSet<RazaMascotas>();
            this.Consulta = new HashSet<Consulta>();
            this.MascotaColores = new HashSet<MascotaColores>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Código de Mascota")]
        [StringLength(5, ErrorMessage = "El campo Código de Mascota no puede tener más de 5 caracteres.")]
        public string? CodigoMascota { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Nombre")]
        [StringLength(30, ErrorMessage = "El campo Nombre no puede tener más de 30 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Range(0.1, double.MaxValue, ErrorMessage = "El peso debe ser un número positivo.")]
        [Display(Name = "Peso Actual")]
        public double PesoActual { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public System.DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Especie")]
        public int EspecieId { get; set; }

        public virtual Especie? Especie { get; set; }
        public virtual ICollection<RazaMascotas> RazaMascotas { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<MascotaColores> MascotaColores { get; set; }
    }
}
