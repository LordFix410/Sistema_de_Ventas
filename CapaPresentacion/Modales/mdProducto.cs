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
    public partial class mdProducto : Form
    {
        public Producto _Producto { get; set; }
        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true)
                {
                    cboBuscar.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBuscar.DisplayMember = "Texto";
            cboBuscar.ValueMember = "Valor";
            cboBuscar.SelectedIndex = 1;

            //Mostrar todos los productos:
            List<Producto> listaProductos = new CN_Producto().Listar();

            foreach (Producto item in listaProductos)
            {
                dgvData.Rows.Add(new object[] { item.IdProducto, item.Codigo, item.Nombre,
                    item.oCategoria.Descripcion, item.Stock, item.PrecioCompra, item.PrecioVenta
                });
            }
            txtBusqueda.Select();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn > 0)
            {
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvData.Rows[iRow].Cells["IdProducto"].Value.ToString()),
                    Codigo = dgvData.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvData.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dgvData.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(dgvData.Rows[iRow].Cells["PRECIOCOMPRA"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvData.Rows[iRow].Cells["PRECIOVENTA"].Value.ToString())
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
            if (txtBusqueda.Text != "")
            {
                txtBusqueda.Text = "";
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    row.Visible = true;
                }
            }
        }
    }
}
