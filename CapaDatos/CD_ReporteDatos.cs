using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_ReporteDatos
    {
        public DataTable ObtenerRegistroVentas()
        {

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerRegistroVentas", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                oconexion.Open();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerRegistroCompras()
        {

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRegistroCompra", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                oconexion.Open();
                da.Fill(dt);
                return dt;
            }
        }
    }

}

