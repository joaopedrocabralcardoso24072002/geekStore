namespace geekStore
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.strMenu = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demonstrativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblVendas = new System.Windows.Forms.Label();
            this.lblDemonstrativo = new System.Windows.Forms.Label();
            this.lblSobre = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.pbxSobre = new System.Windows.Forms.PictureBox();
            this.pbxProdutos = new System.Windows.Forms.PictureBox();
            this.pbxVendas = new System.Windows.Forms.PictureBox();
            this.pbxDemonstrativo = new System.Windows.Forms.PictureBox();
            this.pbxClientes = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblPreço = new System.Windows.Forms.Label();
            this.strMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSobre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDemonstrativo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // strMenu
            // 
            this.strMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(34)))));
            this.strMenu.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.demonstrativoToolStripMenuItem,
            this.sairToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.strMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.strMenu.Location = new System.Drawing.Point(0, 0);
            this.strMenu.Name = "strMenu";
            this.strMenu.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.strMenu.Size = new System.Drawing.Size(900, 40);
            this.strMenu.TabIndex = 1;
            this.strMenu.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem});
            this.cadastroToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(96, 32);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(33)))));
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(33)))));
            this.produtosToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(81, 32);
            this.vendasToolStripMenuItem.Text = "Vendas";
            this.vendasToolStripMenuItem.Click += new System.EventHandler(this.vendasToolStripMenuItem_Click);
            // 
            // demonstrativoToolStripMenuItem
            // 
            this.demonstrativoToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.demonstrativoToolStripMenuItem.Name = "demonstrativoToolStripMenuItem";
            this.demonstrativoToolStripMenuItem.Size = new System.Drawing.Size(144, 32);
            this.demonstrativoToolStripMenuItem.Text = "Demonstrativo";
            this.demonstrativoToolStripMenuItem.Click += new System.EventHandler(this.demonstrativoToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sobreToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(68, 32);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sairToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.sairToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(56, 32);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BorderSkin.BorderWidth = 2;
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 20;
            chartArea1.Area3DStyle.Rotation = 20;
            chartArea1.Area3DStyle.WallWidth = 5;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.WhiteSmoke;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(273, 319);
            this.chart1.Margin = new System.Windows.Forms.Padding(15, 20, 18, 20);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(600, 300);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chtMenu";
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClientes.Location = new System.Drawing.Point(64, 220);
            this.lblClientes.Margin = new System.Windows.Forms.Padding(55, 0, 3, 0);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(75, 28);
            this.lblClientes.TabIndex = 13;
            this.lblClientes.Text = "Clientes";
            this.lblClientes.Click += new System.EventHandler(this.lblClientes_Click);
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblProdutos.Location = new System.Drawing.Point(234, 220);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(85, 28);
            this.lblProdutos.TabIndex = 14;
            this.lblProdutos.Text = "Produtos";
            this.lblProdutos.Click += new System.EventHandler(this.lblProdutos_Click);
            // 
            // lblVendas
            // 
            this.lblVendas.AutoSize = true;
            this.lblVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVendas.Location = new System.Drawing.Point(416, 220);
            this.lblVendas.Name = "lblVendas";
            this.lblVendas.Size = new System.Drawing.Size(69, 28);
            this.lblVendas.TabIndex = 15;
            this.lblVendas.Text = "Vendas";
            this.lblVendas.Click += new System.EventHandler(this.lblVendas_Click);
            // 
            // lblDemonstrativo
            // 
            this.lblDemonstrativo.AutoSize = true;
            this.lblDemonstrativo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDemonstrativo.Location = new System.Drawing.Point(559, 220);
            this.lblDemonstrativo.Name = "lblDemonstrativo";
            this.lblDemonstrativo.Size = new System.Drawing.Size(132, 28);
            this.lblDemonstrativo.TabIndex = 16;
            this.lblDemonstrativo.Text = "Demonstrativo";
            this.lblDemonstrativo.Click += new System.EventHandler(this.lblDemonstrativo_Click);
            // 
            // lblSobre
            // 
            this.lblSobre.AutoSize = true;
            this.lblSobre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSobre.Location = new System.Drawing.Point(770, 220);
            this.lblSobre.Name = "lblSobre";
            this.lblSobre.Size = new System.Drawing.Size(56, 28);
            this.lblSobre.TabIndex = 17;
            this.lblSobre.Text = "Sobre";
            this.lblSobre.Click += new System.EventHandler(this.lblSobre_Click);
            // 
            // cbxTipo
            // 
            this.cbxTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.cbxTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(33)))));
            this.cbxTipo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxTipo.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(15, 350);
            this.cbxTipo.Margin = new System.Windows.Forms.Padding(6, 3, 3, 6);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(240, 25);
            this.cbxTipo.TabIndex = 31;
            // 
            // lblTipo
            // 
            this.lblTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTipo.Location = new System.Drawing.Point(15, 319);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(6, 3, 6, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(103, 28);
            this.lblTipo.TabIndex = 30;
            this.lblTipo.Text = "Tipo";
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.AutoSize = true;
            this.btnFiltrar.BackColor = System.Drawing.Color.Transparent;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFiltrar.Image = global::geekStore.Properties.Resources.filter_30;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(81, 387);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(6);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(108, 40);
            this.btnFiltrar.TabIndex = 32;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // pbxSobre
            // 
            this.pbxSobre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSobre.Image = global::geekStore.Properties.Resources.about_100;
            this.pbxSobre.Location = new System.Drawing.Point(723, 58);
            this.pbxSobre.Margin = new System.Windows.Forms.Padding(12, 48, 18, 12);
            this.pbxSobre.Name = "pbxSobre";
            this.pbxSobre.Size = new System.Drawing.Size(150, 150);
            this.pbxSobre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSobre.TabIndex = 11;
            this.pbxSobre.TabStop = false;
            this.pbxSobre.Click += new System.EventHandler(this.pbxSobre_Click);
            // 
            // pbxProdutos
            // 
            this.pbxProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxProdutos.Image = global::geekStore.Properties.Resources.products_box_100;
            this.pbxProdutos.Location = new System.Drawing.Point(201, 58);
            this.pbxProdutos.Margin = new System.Windows.Forms.Padding(12, 48, 12, 12);
            this.pbxProdutos.Name = "pbxProdutos";
            this.pbxProdutos.Size = new System.Drawing.Size(150, 150);
            this.pbxProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProdutos.TabIndex = 10;
            this.pbxProdutos.TabStop = false;
            this.pbxProdutos.Click += new System.EventHandler(this.pbxProdutos_Click);
            // 
            // pbxVendas
            // 
            this.pbxVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxVendas.Image = global::geekStore.Properties.Resources.products_100;
            this.pbxVendas.Location = new System.Drawing.Point(375, 58);
            this.pbxVendas.Margin = new System.Windows.Forms.Padding(12, 48, 12, 12);
            this.pbxVendas.Name = "pbxVendas";
            this.pbxVendas.Size = new System.Drawing.Size(150, 150);
            this.pbxVendas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxVendas.TabIndex = 9;
            this.pbxVendas.TabStop = false;
            this.pbxVendas.Click += new System.EventHandler(this.pbxVendas_Click);
            // 
            // pbxDemonstrativo
            // 
            this.pbxDemonstrativo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxDemonstrativo.Image = global::geekStore.Properties.Resources.demonstrative_100;
            this.pbxDemonstrativo.Location = new System.Drawing.Point(549, 58);
            this.pbxDemonstrativo.Margin = new System.Windows.Forms.Padding(12, 36, 12, 12);
            this.pbxDemonstrativo.Name = "pbxDemonstrativo";
            this.pbxDemonstrativo.Size = new System.Drawing.Size(150, 150);
            this.pbxDemonstrativo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDemonstrativo.TabIndex = 8;
            this.pbxDemonstrativo.TabStop = false;
            this.pbxDemonstrativo.Click += new System.EventHandler(this.pbxDemonstrativo_Click);
            // 
            // pbxClientes
            // 
            this.pbxClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClientes.Image = global::geekStore.Properties.Resources.user;
            this.pbxClientes.Location = new System.Drawing.Point(27, 58);
            this.pbxClientes.Margin = new System.Windows.Forms.Padding(18, 18, 12, 12);
            this.pbxClientes.Name = "pbxClientes";
            this.pbxClientes.Size = new System.Drawing.Size(150, 150);
            this.pbxClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxClientes.TabIndex = 7;
            this.pbxClientes.TabStop = false;
            this.pbxClientes.Click += new System.EventHandler(this.pbxClientes_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.AutoSize = true;
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.Image = global::geekStore.Properties.Resources.close_30;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(777, 645);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(6);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(108, 40);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(33)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtTotal.Location = new System.Drawing.Point(15, 583);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(240, 36);
            this.txtTotal.TabIndex = 34;
            // 
            // lblPreço
            // 
            this.lblPreço.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPreço.Location = new System.Drawing.Point(15, 552);
            this.lblPreço.Margin = new System.Windows.Forms.Padding(6, 3, 6, 0);
            this.lblPreço.Name = "lblPreço";
            this.lblPreço.Size = new System.Drawing.Size(103, 28);
            this.lblPreço.TabIndex = 33;
            this.lblPreço.Text = "Total (R$)";
            this.lblPreço.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblPreço);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblSobre);
            this.Controls.Add(this.lblDemonstrativo);
            this.Controls.Add(this.lblVendas);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pbxSobre);
            this.Controls.Add(this.pbxProdutos);
            this.Controls.Add(this.pbxVendas);
            this.Controls.Add(this.pbxDemonstrativo);
            this.Controls.Add(this.pbxClientes);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.strMenu);
            this.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.strMenu;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Shown += new System.EventHandler(this.frmMenu_Shown);
            this.strMenu.ResumeLayout(false);
            this.strMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSobre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDemonstrativo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip strMenu;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demonstrativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.PictureBox pbxClientes;
        private System.Windows.Forms.PictureBox pbxDemonstrativo;
        private System.Windows.Forms.PictureBox pbxVendas;
        private System.Windows.Forms.PictureBox pbxProdutos;
        private System.Windows.Forms.PictureBox pbxSobre;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblVendas;
        private System.Windows.Forms.Label lblDemonstrativo;
        private System.Windows.Forms.Label lblSobre;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblPreço;
    }
}