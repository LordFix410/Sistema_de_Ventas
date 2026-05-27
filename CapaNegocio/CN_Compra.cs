using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Compra
    {

        public CD_Compra objcd_compra = new CD_Compra();

        public int obtenerCorrelativo()
        {
            return objcd_compra.obtenerCorrelativo();
        }
       
        public bool Registrar(Compra obj,DataTable detalleCompra, out string Mensaje)
        {
            return objcd_compra.Registrar(obj, detalleCompra, out Mensaje);
        }

        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = objcd_compra.obtenerCompra(numero);

            if (oCompra.IdCompra != 0)
            {
                List<Detalle_Compra> oDetalleCompras = objcd_compra.ObtenerDetalleCompra(oCompra.IdCompra);
                oCompra.oDetalleCompras= oDetalleCompras;
            }
            return oCompra;

        }

    
    }
}
