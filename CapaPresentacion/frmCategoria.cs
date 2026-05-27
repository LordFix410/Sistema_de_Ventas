using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

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
            //dgvData.Rows.Add("", "hola1", "hola2", "hola3", "hola4", "hola5");
            //Mostrar todos las Categorias:
            List<Categoria> listaCategoria = new CN_Categoria().Listar();

            //if (listaCategoria.Count < 1) { MessageBox.Show("eror de lista"); } else { MessageBox.Show("no es error de lista"); }
            foreach (Categoria item in listaCategoria)
            {
                dgvData.Rows.Add(new object[] { "", item.IdCategoria.ToString(), item.Descripcion.ToString(),
                item.Estado == true ? 1 :0,
                item.Estado == true? "Activo":"Inactivo"
                });
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LimpiarTxt()
        {
            txtId.Text = "0";
            txtIndice.Clear();
            txtDescripcion.Clear();
            cboEstado.SelectedItem = 0;


        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Categoria objCategoria = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtId.Text),
                Descripcion = txtDescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };
            if (objCategoria.IdCategoria == 0)
            {
                int idGenerado = new CN_Categoria().Registrar(objCategoria, out mensaje);

                if (mensaje == string.Empty && idGenerado != 0)
                {
                    MessageBox.Show("se ha registrado correctamente");
                    dgvData.Rows.Add("", txtId.Text, txtDescripcion.Text,
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
                //MessageBox.Show("hola");
                bool resultado = new CN_Categoria().Editar(objCategoria, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();

                    LimpiarTxt();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            List<Categoria> listaCategoria = new CN_Categoria().Listar();

            //if (listaCategoria.Count < 1) { MessageBox.Show("eror de lista"); } else { MessageBox.Show("no es error de lista"); }
            dgvData.Rows.Clear();
            foreach (Categoria item in listaCategoria)
            {
                dgvData.Rows.Add(new object[] { "", item.IdCategoria.ToString(), item.Descripcion.ToString(),
                item.Estado == true ? 1 :0,
                item.Estado == true? "Activo":"Inactivo"
                });
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea Eliminar la Categoría?", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string mensaje = string.Empty;
                    Categoria ocategoria = new Categoria
                    {
                        IdCategoria = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new CN_Categoria().Eliminar(ocategoria, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text)); 
                        LimpiarTxt();
                    }
                    else MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvData.Rows.Clear();
                    List<Categoria> listaCategoria = new CN_Categoria().Listar();

                    //if (listaCategoria.Count < 1) { MessageBox.Show("eror de lista"); } else { MessageBox.Show("no es error de lista"); }
                    foreach (Categoria item in listaCategoria)
                    {
                        dgvData.Rows.Add(new object[] { "", item.IdCategoria.ToString(), item.Descripcion.ToString(),
                        item.Estado == true ? 1 :0,
                        item.Estado == true? "Activo":"Inactivo"
                });
                    }
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["Descripcion"].Value.ToString();  

                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
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

        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
