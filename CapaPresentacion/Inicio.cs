using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem botonActual = null;
        private static Form FormularioActivo=null;

        public Inicio(Usuario ousuario)
        {
            usuarioActual = ousuario;
            InitializeComponent();
            
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menuTitulo.Items)
            {
                bool encontrado = listaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Enabled = false;
                }
            }
            lblNombreUsuario.Text = usuarioActual.NombreCompleto.ToString();
        }
        private void AbrirFrm(IconMenuItem menu, Form formulario)
        {
            if(botonActual != null)
            {
                botonActual.BackColor = Color.White;
            }
            botonActual = menu;
            menu.BackColor = Color.BlanchedAlmond;

            if(FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel=false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new frmUsuarios());
        }

        private void menuVentas_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new frmCategoria());
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new frmProducto());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new frmClientes());
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender,new frmProveedores());
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
           
        }

        private void submRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new frmCompraRegistrar(usuarioActual));
        }

        private void iconDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new frmCompraVerDetalle());
        }

        private void menuMantenedor_Click(object sender, EventArgs e)
        {
            
        }

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            mdAcercade md = new mdAcercade();
            md.ShowDialog();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFrm(menuVentas, new frmVentas(usuarioActual));
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFrm(menuVentas, new frmDetalleVenta());
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void negocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFrm(menuVentas, new frmNegocio());
        }

        private void reporteComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFrm(menuReportes,new frmReportes());
            
        }

        private void cOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFrm(menuReportes, new frmReporteCompras());
        }
    }
}
