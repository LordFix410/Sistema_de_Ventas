using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";

            txtTotalPagar.Text = "0";
            txtPagaCon.Text = "0";
            txtCambio.Text = "0";

            txtCantidad.Minimum = 1;       
            txtCantidad.Maximum = 100000;  
            txtCantidad.DecimalPlaces = 0; 
            txtCantidad.Increment = 1;     


        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtDocumentoCliente.Text = modal._Cliente.Documento.ToString();
                    txtNombreCliente.Text = modal._Cliente.NombreCompleto.ToString();
                }
                else
                {
                    txtDocumentoCliente.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodigoProducto.Text = modal._Producto.Codigo;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtStock.Text = modal._Producto.Stock.ToString();
                    txtPrecioCompra.Text = modal._Producto.PrecioVenta.ToString("0.00");

                    txtCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            int stock = 0;
            bool producto_existente = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe de seleccionar un producto", "Mensaje de sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text, out precioCompra))
            {
                MessageBox.Show("Precio Compra - Formato incorrecto", "Mensaje de sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Precio Venta - Formato incorrecto", "Mensaje de sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    producto_existente = true;
                    break;
                }
            }

            if (!producto_existente)
            {
                bool respuesta = new CN_Venta().RestarStock(
                    Convert.ToInt32(txtIdProducto.Text),
                    Convert.ToInt32(txtCantidad.Value.ToString())
                    );


                if (respuesta)
                {
                   dataGridView1.Rows.Add(new object[]
                   {
                       txtIdProducto.Text.ToString(),
                        txtProducto.Text,
                        precioCompra,
                        txtCantidad.Value.ToString(),
                        (txtCantidad.Value*precioCompra).ToString("0.00")
                   });

                    calculatTotal();
                    limpiarProducto();
                    txtCodigoProducto.Select();

                }
               
            }
        }
        private void limpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtStock.Text = "";
            txtCantidad.Value = 1;
        }
        private void calculatTotal()
        {
            decimal total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
                txtTotalPagar.Text = total.ToString("0.00");
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 6)
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    bool respuesta = new CN_Venta().SumarStock(

                       Convert.ToInt32(dataGridView1.Rows[indice].Cells["IdProducto"].Value.ToString()),
                       Convert.ToInt32(dataGridView1.Rows[indice].Cells["Cantidad"].Value.ToString())
                    );

                    if (respuesta)
                    {
                        dataGridView1.Rows.RemoveAt(indice);
                        calculatTotal();
                    }
                    
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPagaCon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if(char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
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

        private void txtTotalPagar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtTotalPagar.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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
        private bool calcularCambio()
        {
            if (txtTotalPagar.Text.Trim() == "")
            {
                MessageBox.Show("No existe producto en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(txtTotalPagar.Text);

            if (txtPagaCon.Text.Trim() == "")
            {
                txtPagaCon.Text = "0";
            }

            if(decimal.TryParse(txtPagaCon.Text.Trim(),out pagacon))
            {
                if (pagacon < total)
                {
                    MessageBox.Show("Falta Dinero", "DINERITO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    decimal cambio = pagacon - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
            return true;
        }

        private void txtPagaCon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                calcularCambio();
                txtCambio.Select();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtDocumentoCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtNombreCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (dataGridView1.Rows.Count <1)
            {
                MessageBox.Show("Debe ingresar producto en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_venta = new DataTable();

            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("Precio", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                detalle_venta.Rows.Add(new object[]
                {
                    row.Cells["IdProducto"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["SubTotal"].Value.ToString()
                });
            }

            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);
            if (calcularCambio())
            {
                Venta oVenta = new Venta()
                {
                    oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                    TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem).Texto,
                    NumeroDocumento = numeroDocumento,
                    DocumentoCliente = txtDocumentoCliente.Text,
                    NombreCliente = txtNombreCliente.Text,
                    MontoPago = Convert.ToDecimal(txtPagaCon.Text),
                    MontoCambio = Convert.ToDecimal(txtCambio.Text),
                    MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
                };

                string mensaje = string.Empty;
                bool respuesta = new CN_Venta().Registrar(oVenta, detalle_venta, out mensaje);

                if (respuesta)
                {
                    var result = MessageBox.Show("Numero de venta generado: \n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        Clipboard.SetText(numeroDocumento);
                    }

                    txtDocumentoCliente.Text = "";
                    txtNombreCliente.Text = "";
                    dataGridView1.Rows.Clear();
                    calculatTotal();
                    txtPagaCon.Text = "";
                    txtCambio.Text = "";
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
                
            

            

            
        }

        private void txtCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                
                btnRegistrar.Select();
            }

        }

        private void txtCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Value < 1)
            {
                txtCantidad.Value = 1;
            }
        }
    }

    
}
