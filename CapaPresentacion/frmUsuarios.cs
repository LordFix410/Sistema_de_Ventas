using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol) 
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion});
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            foreach(DataGridViewColumn columna in dgvData.Columns) {
                if(columna.Visible == true && columna.Name!= "btnSeleccionar")
                {
                    cboBuscar.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }    
            }
            cboBuscar.DisplayMember = "Texto";
            cboBuscar.ValueMember = "Valor";
            cboBuscar.SelectedIndex = 0;

            //Mostrar todos los usuarios:
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuarios)
            {
                dgvData.Rows.Add(new object[] { "",item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1 :0,
                item.Estado == true? "Activo":"Inactivo"
                });
            }
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Usuario objUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Clave = txtClave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };
            if(objUsuario.IdUsuario == 0 && txtClave.Text == txtClaveConfirmar.Text)
            {
               

                int idusuariogenerado = new CN_Usuario().Registrar(objUsuario, out mensaje);    

                if (mensaje == string.Empty && idusuariogenerado != 0)
                {
                    
                    MessageBox.Show("se ha registrado correctamente");
                    dgvData.Rows.Add("", txtId.Text, txtDocumento.Text, txtNombreCompleto.Text, txtCorreo.Text,
                        txtClave.Text,
                        ((OpcionCombo)cboRol.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString()
                    );
                    dgvData.Rows.Clear();
                    List<Usuario> listaUsuarios = new CN_Usuario().Listar();

                    foreach (Usuario item in listaUsuarios)
                    {
                        dgvData.Rows.Add(new object[] { "",item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                        item.oRol.IdRol,
                        item.oRol.Descripcion,
                        item.Estado == true ? 1 :0,
                        item.Estado == true? "Activo":"Inactivo"
                        });
                    }
                    LimpiarTxt();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error del Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }   
            }
            else
            {
                if (txtClave.Text == txtClaveConfirmar.Text)
                {
                    bool resultado = new CN_Usuario().Editar(objUsuario, out mensaje);
                    if (resultado)
                    {
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["IdUsuario"].Value = txtId.Text;
                        row.Cells["Documento"].Value = txtDocumento.Text;
                        row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                        row.Cells["Correo"].Value = txtCorreo.Text;
                        row.Cells["Clave"].Value = txtClave.Text;
                        row.Cells["IdRol"].Value = ((OpcionCombo)cboRol.SelectedItem).Valor.ToString();
                        row.Cells["Rol"].Value = ((OpcionCombo)cboRol.SelectedItem).Texto.ToString();
                        row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                        row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();

                        LimpiarTxt();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña no coincide!", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void LimpiarTxt()
        {
            txtIndice.Clear();
            txtId.Text = "0";
            txtDocumento.Clear();
            txtNombreCompleto.Clear();
            txtCorreo.Clear();
            txtClave.Clear();
            txtClaveConfirmar.Clear();
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
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

                e.Graphics.DrawImage(Properties.Resources.Check, new Rectangle (x,y,w,h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if(indice >= 0)
                {
                    txtIndice.Text= indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["IdUsuario"].Value.ToString();
                    txtDocumento.Text= dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text= dgvData.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text= dgvData.Rows[indice].Cells["Clave"].Value.ToString();
                    txtClaveConfirmar.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionCombo oc in cboRol.Items)
                    {
                        if(Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                        {
                            cboRol.SelectedIndex = cboRol.Items.IndexOf(oc); ;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if(Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            cboEstado.SelectedIndex = cboEstado.Items.IndexOf(oc);
                            break;
                        }

                    }
                }
            }
        }

        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if(MessageBox.Show("¿Desea eliminar al usuario?", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    string mensaje = string.Empty;
                    Usuario ousuario = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new CN_Usuario().Eliminar(ousuario, out mensaje);

                    if (respuesta) 
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text)); LimpiarTxt(); 
                    }
                    else MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                }
            }
            /*string mensaje = string.Empty;
            Usuario objUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Documento = txtNombreCompleto.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Clave = txtClave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) == 1 ? true : false
            };
            bool resultado = new CN_Usuario().Eliminar(objUsuario, out mensaje);fo

            if (resultado)
            {
                if (txtId.Text != "0")
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    dgvData.Rows.Remove(row);
                    MessageBox.Show("Se ha eliminado correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(mensaje);
            }*/
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
            }else if (((OpcionCombo)cboBuscar.SelectedItem).Valor.ToString() == "Estado"){

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

    }
}

