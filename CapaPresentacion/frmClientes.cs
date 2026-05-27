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

namespace CapaPresentacion
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();
                      
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

            //Mostrar todos los cli:entes
            List<Cliente> listCliente = new CN_Cliente().Listar();

            foreach (Cliente item in listCliente)
            {
                
                    dgvData.Rows.Add(new object[] {"",item.IdCliente, item.Documento, item.NombreCompleto, item.Correo, item.Telefono,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true? "Activo":"Inactivo" }
                    );
                   
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Cliente objUsuario = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };
            if (objUsuario.IdCliente == 0)
            {
                int idusuariogenerado = new CN_Cliente().Registrar(objUsuario, out mensaje);

                if (mensaje == string.Empty && idusuariogenerado != 0)
                {
                    MessageBox.Show("se ha registrado correctamente");
                    dgvData.Rows.Add("", txtId.Text, txtDocumento.Text, txtNombreCompleto.Text, txtCorreo.Text, txtTelefono.Text,
                       
                        ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString()
                    );
                    LimpiarTxt();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error del Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                bool resultado = new CN_Cliente().Editar(objUsuario, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();

                    LimpiarTxt();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            dgvData.Rows.Clear();
            List<Cliente> listCliente = new CN_Cliente().Listar();

            foreach (Cliente item in listCliente)
            {

                dgvData.Rows.Add(new object[] {"",item.IdCliente, item.Documento, item.NombreCompleto, item.Correo, item.Telefono,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true? "Activo":"Inactivo" }
                );

            }
        }
        private void LimpiarTxt()
        {
            txtIndice.Clear();
            txtId.Text = "0";
            txtDocumento.Clear();
            txtNombreCompleto.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            cboEstado.SelectedIndex = 0;
        }
        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar al Cliente?", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string mensaje = string.Empty;
                    Cliente oCliente = new Cliente
                    {
                        IdCliente = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new CN_Cliente().Eliminar(oCliente, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text)); LimpiarTxt();
                    }
                    else MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.Check.Width;
                var h = Properties.Resources.Check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvData.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        //no tiene la entrada correcta
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            cboEstado.SelectedIndex = cboEstado.Items.IndexOf(oc);
                            break;
                        }

                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBuscar.SelectedItem).Valor.ToString();
            if (dgvData.Rows.Count > 0 && ((OpcionCombo)cboBuscar.SelectedItem).Valor.ToString() != "Estado")
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
            else if (((OpcionCombo)cboBuscar.SelectedItem).Valor.ToString() == "Estado")
            {

                bool buscado;
                if (txtBusqueda.Text.ToString().Trim().ToUpper() == "INACTIVO")
                    buscado = false;
                else
                    buscado = true;

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    bool estado;
                    if (row.Cells["Estado"].Value.ToString().Trim().ToUpper() == "INACTIVO")
                    {
                        estado = false;
                    }
                    else
                        estado = true;

                    if (buscado == estado)
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

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtTelefono.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
