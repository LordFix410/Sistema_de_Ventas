using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_Cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "") Mensaje += "Es necesario el nombre del Cliente\n";

            if (obj.Documento == "") Mensaje += "Es necesario el documento\n";
            if (obj.Correo == "") Mensaje += "Es necesario un correo\n";

            if (obj.Telefono == "") Mensaje += "Es necesario un Telefono\n";

            if (Mensaje != string.Empty) return 0;
            else return objcd_Cliente.Registrar(obj, out Mensaje);
        }
        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "") Mensaje += "Es necesario el nombre del Cliente\n";

            if (obj.Documento == "") Mensaje += "Es necesario el documento\n";
            if (obj.Correo == "") Mensaje += "Es necesario un correo\n";

            if (obj.Telefono == "") Mensaje += "Es necesario un Telefono\n";

            if (Mensaje != string.Empty) return false;
            return objcd_Cliente.Editar(obj, out Mensaje);
        }
        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "") Mensaje += "Es necesario el nombre del Cliente\n";

            if (obj.Documento == "") Mensaje += "Es necesario el documento\n";
            if (obj.Correo == "") Mensaje += "Es necesario un correo\n";

            if (obj.Telefono == "") Mensaje += "Es necesario un Telefono\n";

            if (Mensaje != string.Empty) return false;
            return objcd_Cliente.Eliminar(obj, out Mensaje);
        }
    }
}
