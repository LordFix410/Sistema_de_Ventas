using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class frmReportes : Form
    {


        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                cboBuscar.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cboBuscar.DisplayMember = "Texto";
            cboBuscar.ValueMember = "Valor";
            cboBuscar.SelectedIndex = 0;
        }

        private void iconButton1_Click(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            lista = new CN_Reporte().Venta(
                txtFechaInicio.Value.ToString("dd/MM/yyyy"),
                txtFechaFinal.Value.ToString("dd/MM/yyyy")
                );
            dgvData.Rows.Clear();

            foreach (ReporteVenta rc in lista)
            {
                dgvData.Rows.Add(new object[]
                {
                    rc.FechaRegistro,
                    rc.TipoDocumento,
                    rc.NumeroDocumento,
                    rc.MontoTotal,
                    rc.UsuarioRegistro,
                    rc.DocumentoCliente,
                    rc.NombreCliente,
                    rc.CodigoProducto,
                    rc.NombreProducto,
                    rc.Categoria,
                    rc.PrecioVenta,
                    rc.Cantidad,
                    rc.SubTotal
                });
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {

                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvData.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString()
                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
        }
        //donde hicimos el trabajo, va a venir el familiar, lo que va a hacer es el trabjao de electricidad 550, 
    }
}
