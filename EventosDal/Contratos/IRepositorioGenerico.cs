using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDal.Contratos
{
    public  interface IRepositorioGenerico<T> where T : class
    {
        Task<bool> Grabar(T entity);
        Task<bool> Actualizar(int Id, DateTime Fecha);
        Task<bool> Eliminar(int id);

    }
}
