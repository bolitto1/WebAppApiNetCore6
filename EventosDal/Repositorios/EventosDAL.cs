using EventosDal.Contratos;
using EventosDal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDal.Repositorios
{
    public class EventosDAL : IEventosRepositorio
    {
        private readonly string _cadenaconexion;
        public EventosDAL(string Cadenaconexion)
        {

            _cadenaconexion = Cadenaconexion;

        }
        public async  Task<bool> Grabar(Eventos entity)
        {
            using (SqlConnection con = new SqlConnection(_cadenaconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Add_Evento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Lugar", entity.Lugar );
                cmd.Parameters.AddWithValue("@Fecha", entity.Fecha );
                cmd.Parameters.AddWithValue("@Nroentrada", entity.Nroentrada);
                cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", entity.Precio);
                try
                {
                    await con.OpenAsync ();
                    cmd.ExecuteNonQuery ();
                    con.Close ();
                    return true;
                }
                catch (Exception ex) {
                    con.Close();
                    return false;
                }
            }
        }
        public async Task<bool> Actualizar(int Id,DateTime Fecha)
        {
            using (SqlConnection con = new SqlConnection(_cadenaconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_upd_evento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",  Id);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                try
                {
                    await con.OpenAsync();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    return false;
                }
            }
        }
        public async  Task<bool> Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(_cadenaconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Del_Evento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    await con.OpenAsync();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    return false;
                }
            }
        }

        public async  Task<Eventos> GetEventosID(int Id)
        {
            Eventos GetEventoID = new Eventos ();
            using (SqlConnection con = new SqlConnection(_cadenaconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Get_Evento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    while (sdr.Read())
                    {
                        GetEventoID.Id = Convert.ToInt32(sdr["Id"]);
                        if (sdr["Estado"].ToString() == "True")
                        {
                            GetEventoID.Estado = true;
                        }
                        else {
                            GetEventoID.Estado = false; 
                        }
                        GetEventoID.EstadoDesc = sdr["EstadoDesc"].ToString();
                        GetEventoID.Descripcion  = sdr["Descripcion"].ToString();
                        GetEventoID.Lugar  = sdr["Lugar"].ToString();
                        GetEventoID.Fecha  =  Convert.ToDateTime (sdr["Fecha"].ToString());
                        GetEventoID.Precio  = Convert.ToDecimal ( sdr["Precio"].ToString());
                        GetEventoID.Nroentrada   = Convert.ToInt32  ( sdr["Nroentrada"].ToString());
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                }
            }
            return GetEventoID;
        }

        public async  Task<List<Eventos>> GetListadoEventos()
        {
            List <Eventos> GetEventosList = new List<Eventos>();
            Eventos GetEventoID = new Eventos();
            using (SqlConnection con = new SqlConnection(_cadenaconexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Get_EventoTodos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    while (sdr.Read())
                    {
                        bool valor;
                        if (sdr["Estado"].ToString() == "True")
                        {
                            valor = true;
                        }
                        else
                        {
                            valor = false;
                        }
                        GetEventosList.Add ( new Eventos { 
                            Id = Convert.ToInt32(sdr["Id"]),
                            EstadoDesc = sdr["EstadoDesc"].ToString(),
                            Descripcion = sdr["Descripcion"].ToString(),
                            Lugar = sdr["Lugar"].ToString(),
                            Fecha = Convert.ToDateTime(sdr["Fecha"].ToString()),
                            Precio = Convert.ToDecimal(sdr["Precio"].ToString()),
                            Nroentrada = Convert.ToInt32(sdr["Nroentrada"].ToString()),
                            Estado = valor
                        }
                       );
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                }
            }
            return GetEventosList;
        }


    }
}
