using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDal.Models
{
    public  class Eventos
    {
        public int Id { get; set; }
        public string? Lugar { get; set; }    
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int Nroentrada { get; set; } 
        public decimal Precio { get; set; }
        public bool Estado { get; set; }    
        public string? EstadoDesc { get; set; }
    }
}
