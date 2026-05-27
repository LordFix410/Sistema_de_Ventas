using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select IdNegocio, Nombre, NIT, Direccion from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RTU = dr["NIT"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            };
                        }
                    }
                }
            }catch(Exception ex)
            {
                obj = new Negocio();
            }
            return obj;
        }

        public bool GuardarDatos(Negocio objeto, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Nombre = @nombre, ");
                    query.AppendLine("NIT = @nit,");
                    query.AppendLine("Direccion = @direccion");
                    query.AppendLine("where IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@nit", objeto.RTU);
                    cmd.Parameters.AddWithValue("@direccion", objeto.Direccion);
                    cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo guardar los datos";
                        respuesta = false;
                    }
                }
            }catch(Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] logoByte = new byte[0];
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select Logo from NEGOCIO where IdNegocio= 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            logoByte = (byte[])dr["Logo"];
                        }
                    }
                }

            }
            catch (Exception ex) {
                obtenido = false;
                logoByte = new byte[0];
            
            }
            return logoByte;

        }

        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Logo = @imagen");
                    query.AppendLine("where IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex) {
                mensaje = ex.Message;
                respuesta = false;
            
            }
            return respuesta;
        }

    }
}
