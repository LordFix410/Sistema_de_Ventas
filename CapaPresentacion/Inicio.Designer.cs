namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menuMantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.btnCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.btnProducto = new FontAwesome.Sharp.IconMenuItem();
            this.negocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submRegistrarCompra = new FontAwesome.Sharp.IconMenuItem();
            this.iconDetalleCompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.vENTASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPRASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercaDe = new FontAwesome.Sharp.IconMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.menuTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTitulo
            // 
            this.menuTitulo.BackColor = System.Drawing.Color.White;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuMantenedor,
            this.menuVentas,
            this.menuCompras,
            this.menuClientes,
            this.menuProveedores,
            this.menuReportes,
            this.menuAcercaDe});
            this.menuTitulo.Location = new System.Drawing.Point(0, 50);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuTitulo.Size = new System.Drawing.Size(1142, 78);
            this.menuTitulo.TabIndex = 0;
            this.menuTitulo.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 50;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(80, 74);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.AutoSize = false;
            this.menuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCategoria,
            this.btnProducto,
            this.negocioToolStripMenuItem});
            this.menuMantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menuMantenedor.IconColor = System.Drawing.Color.Black;
            this.menuMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenedor.IconSize = 50;
            this.menuMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Size = new System.Drawing.Size(100, 74);
            this.menuMantenedor.Text = "Mantenedor";
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuMantenedor.Click += new System.EventHandler(this.menuMantenedor_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCategoria.IconColor = System.Drawing.Color.Black;
            this.btnCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(125, 22);
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnProducto.IconColor = System.Drawing.Color.Black;
            this.btnProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(125, 22);
            this.btnProducto.Text = "Producto";
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // negocioToolStripMenuItem
            // 
            this.negocioToolStripMenuItem.Name = "negocioToolStripMenuItem";
            this.negocioToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.negocioToolStripMenuItem.Text = "Negocio";
            this.negocioToolStripMenuItem.Click += new System.EventHandler(this.negocioToolStripMenuItem_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem,
            this.verDetalleToolStripMenuItem});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(100, 74);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuVentas.Click += new System.EventHandler(this.menuVentas_Click);
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.registrarToolStripMenuItem.Text = "Registrar";
            this.registrarToolStripMenuItem.Click += new System.EventHandler(this.registrarToolStripMenuItem_Click);
            // 
            // verDetalleToolStripMenuItem
            // 
            this.verDetalleToolStripMenuItem.Name = "verDetalleToolStripMenuItem";
            this.verDetalleToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verDetalleToolStripMenuItem.Text = "Ver Detalle";
            this.verDetalleToolStripMenuItem.Click += new System.EventHandler(this.verDetalleToolStripMenuItem_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.AutoSize = false;
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submRegistrarCompra,
            this.iconDetalleCompra});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.Dolly;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompras.IconSize = 50;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(122, 74);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submRegistrarCompra
            // 
            this.submRegistrarCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submRegistrarCompra.IconColor = System.Drawing.Color.Black;
            this.submRegistrarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submRegistrarCompra.Name = "submRegistrarCompra";
            this.submRegistrarCompra.Size = new System.Drawing.Size(184, 26);
            this.submRegistrarCompra.Text = "Registrar";
            this.submRegistrarCompra.Click += new System.EventHandler(this.submRegistrarCompra_Click);
            // 
            // iconDetalleCompra
            // 
            this.iconDetalleCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDetalleCompra.IconColor = System.Drawing.Color.Black;
            this.iconDetalleCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDetalleCompra.Name = "iconDetalleCompra";
            this.iconDetalleCompra.Size = new System.Drawing.Size(184, 26);
            this.iconDetalleCompra.Text = "Ver Detalle";
            this.iconDetalleCompra.Click += new System.EventHandler(this.iconDetalleCompra_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(100, 74);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.AutoSize = false;
            this.menuProveedores.IconChar = FontAwesome.Sharp.IconChar.ContactBook;
            this.menuProveedores.IconColor = System.Drawing.Color.Black;
            this.menuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedores.IconSize = 50;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(120, 74);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vENTASToolStripMenuItem,
            this.cOMPRASToolStripMenuItem});
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(122, 74);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReportes.Click += new System.EventHandler(this.menuReportes_Click);
            // 
            // vENTASToolStripMenuItem
            // 
            this.vENTASToolStripMenuItem.Name = "vENTASToolStripMenuItem";
            this.vENTASToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.vENTASToolStripMenuItem.Text = "VENTAS";
            this.vENTASToolStripMenuItem.Click += new System.EventHandler(this.vENTASToolStripMenuItem_Click);
            // 
            // cOMPRASToolStripMenuItem
            // 
            this.cOMPRASToolStripMenuItem.Name = "cOMPRASToolStripMenuItem";
            this.cOMPRASToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.cOMPRASToolStripMenuItem.Text = "COMPRAS";
            this.cOMPRASToolStripMenuItem.Click += new System.EventHandler(this.cOMPRASToolStripMenuItem_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.AutoSize = false;
            this.menuAcercaDe.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercaDe.IconColor = System.Drawing.Color.Black;
            this.menuAcercaDe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercaDe.IconSize = 50;
            this.menuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(152, 74);
            this.menuAcercaDe.Text = "Acerca de";
            this.menuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuAcercaDe.Click += new System.EventHandler(this.menuAcercaDe_Click);
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menu.Size = new System.Drawing.Size(1142, 50);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema De Ventas";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 128);
            this.contenedor.Margin = new System.Windows.Forms.Padding(2);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1142, 612);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Raleway Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(521, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Raleway Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(638, 9);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(113, 34);
            this.lblNombreUsuario.TabIndex = 5;
            this.lblNombreUsuario.Text = "Usuario:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 740);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuTitulo);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menuTitulo;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menuTitulo.ResumeLayout(false);
            this.menuTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menuAcercaDe;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuProveedores;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuMantenedor;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreUsuario;
        private FontAwesome.Sharp.IconMenuItem btnCategoria;
        private FontAwesome.Sharp.IconMenuItem btnProducto;
        private FontAwesome.Sharp.IconMenuItem submRegistrarCompra;
        private FontAwesome.Sharp.IconMenuItem iconDetalleCompra;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDetalleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vENTASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMPRASToolStripMenuItem;
    }
}

