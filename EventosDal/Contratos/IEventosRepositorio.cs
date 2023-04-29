using EventosDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    
namespace EventosDal.Contratos
{
    public interface IEventosRepositorio: IRepositorioGenerico<Eventos> 
    {
        Task<Eventos> GetEventosID(int Id);
        Task<List<Eventos>> GetListadoEventos();
    }
}
