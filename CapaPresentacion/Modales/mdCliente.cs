using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdCliente : Form
    {
        public Cliente _Cliente { get; set; }
        public mdCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBuscar.SelectedItem).Valor.ToString();
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
                row.Visible = true;
            cboBuscar.SelectedIndex = 0;
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBuscar.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBuscar.DisplayMember = "Texto";
            cboBuscar.ValueMember = "Valor";
            cboBuscar.SelectedIndex = 0;

            
            //mostrar clientes:
            List<Cliente> listCliente = new CN_Cliente().Listar();

            foreach (Cliente item in listCliente)
            {
                if (item.Estado == true)
                {
                    dgvData.Rows.Add(new object[] {item.IdCliente, item.Documento, item.NombreCompleto, item.Correo, item.Telefono}
                    );
                }
            }

            txtBusqueda.Select();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn > 0)
            {
                _Cliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(dgvData.Rows[iRow].Cells["Id"].Value.ToString()),
                    Documento = dgvData.Rows[iRow].Cells["Documento"].Value.ToString(),
                    NombreCompleto = dgvData.Rows[iRow].Cells["NombreCompleto"].Value.ToString(),
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
