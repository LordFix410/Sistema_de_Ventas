using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_ReporteNegocio
    {
        private CD_ReporteDatos datos = new CD_ReporteDatos();

        public DataTable MostrarRegistroVentas()
        {
            return datos.ObtenerRegistroVentas();
        }

        public DataTable MostrarRegistroCompras()
        {
            return datos.ObtenerRegistroCompras();
        }
    }
}
