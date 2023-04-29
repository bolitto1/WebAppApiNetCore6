using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationEventos.Models
{
    public class Eventos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;

        [StringLength(50,MinimumLength =4) ]
        [Required(ErrorMessage ="Lugar es Obligatorio")]
        [Display(Name = "Lugar")]
        public string Lugar { get; set; }

        [StringLength(150, MinimumLength = 4)]
        [Required(ErrorMessage = "Descripcion es Obligatorio")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        // [Range(typeof(DateTime), "01/01/1900", "31/12/2099", ErrorMessage = "Fecha fuera de rango")]
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])\/(0?[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "La fecha debe estar en formato dd/MM/yyyy")]

        public DateTime Fecha { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor a cero.")]

        public int Nroentrada { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor a cero.")]
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
        public string EstadoDesc { get; set; }
    }
}
