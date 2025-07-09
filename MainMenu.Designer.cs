namespace PuppeteerWebView
{
    partial class PuppeteerForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelWebView = new System.Windows.Forms.Label();
            this.logs_text = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Proses = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.labelKategori = new System.Windows.Forms.Label();
            this.labelJumlahData = new System.Windows.Forms.Label();
            this.labelOpsi = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_DisableImage = new System.Windows.Forms.CheckBox();
            this.checkBox_Debug = new System.Windows.Forms.CheckBox();
            this.comboBox_Kategori = new System.Windows.Forms.ComboBox();
            this.num_JumlahData = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.Name_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reviews_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logs = new System.Windows.Forms.TabPage();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.id_logs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStamp_logs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Logs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_Logs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Proses.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_JumlahData)).BeginInit();
            this.Result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.Logs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 475);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelWebView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.logs_text, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 428);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 44);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // labelWebView
            // 
            this.labelWebView.AutoSize = true;
            this.labelWebView.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelWebView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWebView.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWebView.ForeColor = System.Drawing.Color.White;
            this.labelWebView.Location = new System.Drawing.Point(0, 0);
            this.labelWebView.Margin = new System.Windows.Forms.Padding(0);
            this.labelWebView.Name = "labelWebView";
            this.labelWebView.Size = new System.Drawing.Size(100, 44);
            this.labelWebView.TabIndex = 0;
            this.labelWebView.Text = "WebView";
            this.labelWebView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logs_text
            // 
            this.logs_text.AutoSize = true;
            this.logs_text.BackColor = System.Drawing.Color.White;
            this.logs_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs_text.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logs_text.ForeColor = System.Drawing.Color.Gray;
            this.logs_text.Location = new System.Drawing.Point(100, 0);
            this.logs_text.Margin = new System.Windows.Forms.Padding(0);
            this.logs_text.Name = "logs_text";
            this.logs_text.Size = new System.Drawing.Size(694, 44);
            this.logs_text.TabIndex = 1;
            this.logs_text.Text = "Open Application";
            this.logs_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.webView21);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(794, 419);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 1;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(794, 239);
            this.webView21.TabIndex = 0;
            this.webView21.ZoomFactor = 1D;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.Proses);
            this.tabControl1.Controls.Add(this.Result);
            this.tabControl1.Controls.Add(this.Logs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(30, 8);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 176);
            this.tabControl1.TabIndex = 0;
            // 
            // Proses
            // 
            this.Proses.Controls.Add(this.tableLayoutPanel3);
            this.Proses.Location = new System.Drawing.Point(4, 4);
            this.Proses.Name = "Proses";
            this.Proses.Padding = new System.Windows.Forms.Padding(3);
            this.Proses.Size = new System.Drawing.Size(786, 130);
            this.Proses.TabIndex = 0;
            this.Proses.Text = "Proses";
            this.Proses.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.81879F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.42282F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.62416F));
            this.tableLayoutPanel3.Controls.Add(this.btnSetting, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnStop, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelKategori, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelJumlahData, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelOpsi, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.comboBox_Kategori, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.num_JumlahData, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnStart, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(19, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.30303F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(745, 165);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetting.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Location = new System.Drawing.Point(571, 113);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(171, 49);
            this.btnSetting.TabIndex = 8;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.Open_Setting);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(571, 53);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(171, 54);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labelKategori
            // 
            this.labelKategori.AutoSize = true;
            this.labelKategori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelKategori.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKategori.Location = new System.Drawing.Point(3, 0);
            this.labelKategori.Name = "labelKategori";
            this.labelKategori.Size = new System.Drawing.Size(164, 50);
            this.labelKategori.TabIndex = 0;
            this.labelKategori.Text = "Kategori";
            this.labelKategori.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelJumlahData
            // 
            this.labelJumlahData.AutoSize = true;
            this.labelJumlahData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelJumlahData.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJumlahData.Location = new System.Drawing.Point(3, 50);
            this.labelJumlahData.Name = "labelJumlahData";
            this.labelJumlahData.Size = new System.Drawing.Size(164, 60);
            this.labelJumlahData.TabIndex = 1;
            this.labelJumlahData.Text = "Jumlah Data";
            this.labelJumlahData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOpsi
            // 
            this.labelOpsi.AutoSize = true;
            this.labelOpsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOpsi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpsi.Location = new System.Drawing.Point(3, 110);
            this.labelOpsi.Name = "labelOpsi";
            this.labelOpsi.Size = new System.Drawing.Size(164, 55);
            this.labelOpsi.TabIndex = 2;
            this.labelOpsi.Text = "Opsi";
            this.labelOpsi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.checkBox_DisableImage, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkBox_Debug, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(170, 110);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(398, 55);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // checkBox_DisableImage
            // 
            this.checkBox_DisableImage.AutoSize = true;
            this.checkBox_DisableImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_DisableImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_DisableImage.Location = new System.Drawing.Point(3, 3);
            this.checkBox_DisableImage.Name = "checkBox_DisableImage";
            this.checkBox_DisableImage.Size = new System.Drawing.Size(193, 49);
            this.checkBox_DisableImage.TabIndex = 0;
            this.checkBox_DisableImage.Text = "Enable Image";
            this.checkBox_DisableImage.UseVisualStyleBackColor = true;
            this.checkBox_DisableImage.CheckedChanged += new System.EventHandler(this.Image_Load);
            // 
            // checkBox_Debug
            // 
            this.checkBox_Debug.AutoSize = true;
            this.checkBox_Debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Debug.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Debug.Location = new System.Drawing.Point(202, 3);
            this.checkBox_Debug.Name = "checkBox_Debug";
            this.checkBox_Debug.Size = new System.Drawing.Size(193, 49);
            this.checkBox_Debug.TabIndex = 1;
            this.checkBox_Debug.Text = "Debug";
            this.checkBox_Debug.UseVisualStyleBackColor = true;
            this.checkBox_Debug.CheckedChanged += new System.EventHandler(this.Debug_Check);
            // 
            // comboBox_Kategori
            // 
            this.comboBox_Kategori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_Kategori.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Kategori.FormattingEnabled = true;
            this.comboBox_Kategori.Items.AddRange(new object[] {
            "Mesin Peralatan Industri",
            "Perlengkapan Listrik dan Elektronik",
            "Furnitur & Peralatan Rumah Tangga",
            "Bahan Bangunan",
            "Komputer & Laptop",
            "Pakaian & Aksesoris",
            "Otomotif & Transportasi",
            "Agrobisnis & Produk Pangan",
            "Kerajinan & Souvenir",
            "Bahan Kimia"});
            this.comboBox_Kategori.Location = new System.Drawing.Point(173, 8);
            this.comboBox_Kategori.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.comboBox_Kategori.Name = "comboBox_Kategori";
            this.comboBox_Kategori.Size = new System.Drawing.Size(392, 36);
            this.comboBox_Kategori.TabIndex = 4;
            this.comboBox_Kategori.SelectedIndexChanged += new System.EventHandler(this.Select_Kategori);
            // 
            // num_JumlahData
            // 
            this.num_JumlahData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_JumlahData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_JumlahData.Location = new System.Drawing.Point(173, 58);
            this.num_JumlahData.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.num_JumlahData.Name = "num_JumlahData";
            this.num_JumlahData.Size = new System.Drawing.Size(392, 34);
            this.num_JumlahData.TabIndex = 5;
            this.num_JumlahData.ValueChanged += new System.EventHandler(this.Jumlah_Data);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(571, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(171, 44);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.StartScrape);
            // 
            // Result
            // 
            this.Result.Controls.Add(this.dgvResult);
            this.Result.Location = new System.Drawing.Point(4, 4);
            this.Result.Name = "Result";
            this.Result.Padding = new System.Windows.Forms.Padding(3);
            this.Result.Size = new System.Drawing.Size(786, 130);
            this.Result.TabIndex = 1;
            this.Result.Text = "Result";
            this.Result.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_Result,
            this.Phone_Result,
            this.Email_Result,
            this.Website_Result,
            this.Rating_Result,
            this.Reviews_Result,
            this.Address_Result});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersWidth = 51;
            this.dgvResult.RowTemplate.Height = 24;
            this.dgvResult.Size = new System.Drawing.Size(780, 124);
            this.dgvResult.TabIndex = 0;
            // 
            // Name_Result
            // 
            this.Name_Result.HeaderText = "Name";
            this.Name_Result.MinimumWidth = 6;
            this.Name_Result.Name = "Name_Result";
            // 
            // Phone_Result
            // 
            this.Phone_Result.HeaderText = "Phone";
            this.Phone_Result.MinimumWidth = 6;
            this.Phone_Result.Name = "Phone_Result";
            // 
            // Email_Result
            // 
            this.Email_Result.HeaderText = "Email";
            this.Email_Result.MinimumWidth = 6;
            this.Email_Result.Name = "Email_Result";
            // 
            // Website_Result
            // 
            this.Website_Result.HeaderText = "Website";
            this.Website_Result.MinimumWidth = 6;
            this.Website_Result.Name = "Website_Result";
            // 
            // Rating_Result
            // 
            this.Rating_Result.HeaderText = "Rating";
            this.Rating_Result.MinimumWidth = 6;
            this.Rating_Result.Name = "Rating_Result";
            // 
            // Reviews_Result
            // 
            this.Reviews_Result.HeaderText = "Reviews";
            this.Reviews_Result.MinimumWidth = 6;
            this.Reviews_Result.Name = "Reviews_Result";
            // 
            // Address_Result
            // 
            this.Address_Result.HeaderText = "Address";
            this.Address_Result.MinimumWidth = 6;
            this.Address_Result.Name = "Address_Result";
            // 
            // Logs
            // 
            this.Logs.Controls.Add(this.dgvLogs);
            this.Logs.Location = new System.Drawing.Point(4, 4);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(786, 130);
            this.Logs.TabIndex = 2;
            this.Logs.Text = "Logs";
            this.Logs.UseVisualStyleBackColor = true;
            // 
            // dgvLogs
            // 
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_logs,
            this.TimeStamp_logs,
            this.Type_Logs,
            this.Data_Logs});
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(0, 0);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.RowTemplate.Height = 24;
            this.dgvLogs.Size = new System.Drawing.Size(786, 130);
            this.dgvLogs.TabIndex = 1;
            // 
            // id_logs
            // 
            this.id_logs.HeaderText = "id";
            this.id_logs.MinimumWidth = 6;
            this.id_logs.Name = "id_logs";
            this.id_logs.Visible = false;
            // 
            // TimeStamp_logs
            // 
            this.TimeStamp_logs.HeaderText = "Time Stamp";
            this.TimeStamp_logs.MinimumWidth = 6;
            this.TimeStamp_logs.Name = "TimeStamp_logs";
            // 
            // Type_Logs
            // 
            this.Type_Logs.HeaderText = "Type";
            this.Type_Logs.MinimumWidth = 6;
            this.Type_Logs.Name = "Type_Logs";
            // 
            // Data_Logs
            // 
            this.Data_Logs.HeaderText = "Data";
            this.Data_Logs.MinimumWidth = 6;
            this.Data_Logs.Name = "Data_Logs";
            // 
            // PuppeteerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PuppeteerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoadForm);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Proses.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_JumlahData)).EndInit();
            this.Result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.Logs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelWebView;
        private System.Windows.Forms.Label logs_text;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Proses;
        private System.Windows.Forms.TabPage Result;
        private System.Windows.Forms.TabPage Logs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelKategori;
        private System.Windows.Forms.Label labelJumlahData;
        private System.Windows.Forms.Label labelOpsi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox checkBox_DisableImage;
        private System.Windows.Forms.CheckBox checkBox_Debug;
        private System.Windows.Forms.ComboBox comboBox_Kategori;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown num_JumlahData;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviews_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address_Result;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_logs;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp_logs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Logs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_Logs;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}

