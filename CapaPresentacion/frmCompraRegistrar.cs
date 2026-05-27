using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Office2019.Presentation;
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
using System.Windows.Input;

namespace CapaPresentacion
{
    public partial class frmCompraRegistrar : Form
    {
        private Usuario _Usuario;
        public frmCompraRegistrar(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmCompraRegistrar_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";
            txtIdProveedor.Text = "0";

            txtCantidad.Minimum = 1;
            txtCantidad.Maximum = 100000;
            txtCantidad.DecimalPlaces = 0;
            txtCantidad.Increment = 1;

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor()){
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtNuevoDocumento.Text = modal._Proveedor.Documento.ToString();
                    txtRazonSocial.Text = modal._Proveedor.RazonSocial.ToString();
                }
                else
                {
                    txtNuevoDocumento.Select();
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
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool producto_existente = false;

            if(int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe de seleccionar un producto", "Mensaje de sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if(!decimal.TryParse(txtPrecioCompra.Text, out precioCompra))
            {
                MessageBox.Show("Precio Compra - Formato incorrecto", "Mensaje de sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(!decimal.TryParse(txtPrecioVenta.Text, out precioCompra))
            {
                MessageBox.Show("Precio Venta - Formato incorrecto", "Mensaje de sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach(DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    producto_existente = true;
                    break;
                }
            }

            if (!producto_existente)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    precioCompra.ToString("0.00"),
                    precioVenta.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value*precioCompra).ToString("0.00")
                });
                calculatTotal();
                limpiarProducto();
                txtCodigoProducto.Select();
            }
        }

        private void limpiarProducto()
        {
            txtIdProducto.Text = "";
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtCantidad.Value = 1;
            txtCodigoProducto.Text = "";
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(txtIdProveedor.Text)==0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.Rows.Count < 1) {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        row.Cells["PrecioVenta"].Value.ToString(),
                        row.Cells["PrecioCompra"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["SubTotal"].Value.ToString(),

                    });
            }

            int idCorrelativo = new CN_Compra().obtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idCorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };


            String mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de Compra generada: \n"+numerodocumento+"\n\n¿Desea Copiar al porta papeles?", "Mensaje", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);
                }

                txtIdProducto.Text = "";
                txtNuevoDocumento.Text = "";
                txtIdProveedor.Text = "";
                txtRazonSocial.Text = "";
                dataGridView1.Rows.Clear();
                calculatTotal();

            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
            int index = e.RowIndex;

            if (index >= 0)
            {
                    
                if (MessageBox.Show("¿Desea eliminar Producto?", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    dataGridView1.Rows.RemoveAt(index);
                    //string mensaje = string.Empty;
                    //Producto oProducto = new Producto
                    //{
                    //    IdProducto = Convert.ToInt32(dataGridView1.Rows[index].Cells["IdProducto"].Value.ToString())
                    //};    

                    //bool respuesta = new CN_Producto().Eliminar(oProducto, out mensaje);

                    //if (respuesta)
                    //{
                        
                    //}
                    //else MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                    
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
