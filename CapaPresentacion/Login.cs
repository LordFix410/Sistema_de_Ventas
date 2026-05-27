using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtNumeroDoc.Text && u.Clave == txtContrasena.Text).FirstOrDefault();

            if (ousuario != null)
            {
                Inicio frmInicio = new Inicio(ousuario);

                frmInicio.Show();
                this.Hide();
                 
                frmInicio.FormClosing += Frm_Closing;

            }
            else
            {
                MessageBox.Show("Usuario incorrecto", "Ingreso Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            txtContrasena.Text = "";
            txtNumeroDoc.Text = "";
            this.Show();
        }
    }
}
