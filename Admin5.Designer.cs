namespace Diplom
{
    partial class Admin5
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin5));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.журналДействийBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.управлениеПроцессамиDataSet = new Diplom.УправлениеПроцессамиDataSet();
            this.журналДействийTableAdapter = new Diplom.УправлениеПроцессамиDataSetTableAdapters.ЖурналДействийTableAdapter();
            this.btnRefresh = new SiticoneNetFrameworkUI.SiticoneImageButton();
            this.управлениеПроцессамиDataSet1 = new Diplom.УправлениеПроцессамиDataSet1();
            this.журналДействийBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.журналДействийTableAdapter1 = new Diplom.УправлениеПроцессамиDataSet1TableAdapters.ЖурналДействийTableAdapter();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.журналДействийBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.управлениеПроцессамиDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.операцииBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.операцииTableAdapter = new Diplom.УправлениеПроцессамиDataSet1TableAdapters.ОперацииTableAdapter();
            this.пользователиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.пользователиTableAdapter = new Diplom.УправлениеПроцессамиDataSet1TableAdapters.ПользователиTableAdapter();
            this.zapisidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.пользовательDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.операцияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.действиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.старыеДанныеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.новыеДанныеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOperation = new SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced();
            this.txtUser = new SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced();
            this.txtAction = new SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced();
            this.txtOldData = new SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced();
            this.txtDate = new SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced();
            this.txtNewData = new SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced();
            this.siticoneLabel5 = new SiticoneNetFrameworkUI.SiticoneLabel();
            this.siticoneLabel4 = new SiticoneNetFrameworkUI.SiticoneLabel();
            this.siticoneLabel3 = new SiticoneNetFrameworkUI.SiticoneLabel();
            this.siticoneLabel2 = new SiticoneNetFrameworkUI.SiticoneLabel();
            this.siticoneLabel1 = new SiticoneNetFrameworkUI.SiticoneLabel();
            this.siticoneLabel7 = new SiticoneNetFrameworkUI.SiticoneLabel();
            ((System.ComponentModel.ISupportInitialize)(this.журналДействийBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналДействийBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналДействийBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.операцииBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.пользователиBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // журналДействийBindingSource
            // 
            this.журналДействийBindingSource.DataMember = "ЖурналДействий";
            this.журналДействийBindingSource.DataSource = this.управлениеПроцессамиDataSet;
            // 
            // управлениеПроцессамиDataSet
            // 
            this.управлениеПроцессамиDataSet.DataSetName = "УправлениеПроцессамиDataSet";
            this.управлениеПроцессамиDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // журналДействийTableAdapter
            // 
            this.журналДействийTableAdapter.ClearBeforeFill = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AnimationSpeed = 0.15F;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRefresh.BadgeAnimationEnabled = true;
            this.btnRefresh.BadgeAnimationSpeed = 0.15F;
            this.btnRefresh.BadgeColor = System.Drawing.Color.White;
            this.btnRefresh.BadgeFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.BadgePosition = SiticoneNetFrameworkUI.BadgePositionExt.TopRight;
            this.btnRefresh.BadgeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRefresh.BadgeValue = 0;
            this.btnRefresh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRefresh.BorderThickness = 2;
            this.btnRefresh.CanBeep = true;
            this.btnRefresh.CanShake = true;
            this.btnRefresh.CornerRadiusBottomLeft = 15.5F;
            this.btnRefresh.CornerRadiusBottomRight = 15.5F;
            this.btnRefresh.CornerRadiusTopLeft = 15.5F;
            this.btnRefresh.CornerRadiusTopRight = 15.5F;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.ImageDown = null;
            this.btnRefresh.ImageHover = null;
            this.btnRefresh.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageNormal")));
            this.btnRefresh.ImageSizing = SiticoneNetFrameworkUI.ImageSizingMode.Zoom;
            this.btnRefresh.IsReadOnly = false;
            this.btnRefresh.Location = new System.Drawing.Point(426, 572);
            this.btnRefresh.MakeRadial = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PlaceholderImage = null;
            this.btnRefresh.RippleColor = System.Drawing.Color.White;
            this.btnRefresh.RippleEnabled = true;
            this.btnRefresh.Size = new System.Drawing.Size(38, 34);
            this.btnRefresh.SpringEffectEnabled = true;
            this.btnRefresh.TabIndex = 73;
            this.btnRefresh.Text = "btnRefresh";
            this.btnRefresh.TrackSystemTheme = false;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // управлениеПроцессамиDataSet1
            // 
            this.управлениеПроцессамиDataSet1.DataSetName = "УправлениеПроцессамиDataSet1";
            this.управлениеПроцессамиDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // журналДействийBindingSource1
            // 
            this.журналДействийBindingSource1.DataMember = "ЖурналДействий";
            this.журналДействийBindingSource1.DataSource = this.управлениеПроцессамиDataSet1;
            // 
            // журналДействийTableAdapter1
            // 
            this.журналДействийTableAdapter1.ClearBeforeFill = true;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.guna2DataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zapisidDataGridViewTextBoxColumn,
            this.пользовательDataGridViewTextBoxColumn,
            this.операцияDataGridViewTextBoxColumn,
            this.действиеDataGridViewTextBoxColumn,
            this.датаDataGridViewTextBoxColumn,
            this.старыеДанныеDataGridViewTextBoxColumn,
            this.новыеДанныеDataGridViewTextBoxColumn});
            this.guna2DataGridView1.DataSource = this.журналДействийBindingSource2;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle12;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1007, 320);
            this.guna2DataGridView1.TabIndex = 74;
            this.guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Blue;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 23;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
            // 
            // журналДействийBindingSource2
            // 
            this.журналДействийBindingSource2.DataMember = "ЖурналДействий";
            this.журналДействийBindingSource2.DataSource = this.управлениеПроцессамиDataSet1;
            // 
            // управлениеПроцессамиDataSet1BindingSource
            // 
            this.управлениеПроцессамиDataSet1BindingSource.DataSource = this.управлениеПроцессамиDataSet1;
            this.управлениеПроцессамиDataSet1BindingSource.Position = 0;
            // 
            // операцииBindingSource
            // 
            this.операцииBindingSource.DataMember = "Операции";
            this.операцииBindingSource.DataSource = this.управлениеПроцессамиDataSet1BindingSource;
            // 
            // операцииTableAdapter
            // 
            this.операцииTableAdapter.ClearBeforeFill = true;
            // 
            // пользователиBindingSource
            // 
            this.пользователиBindingSource.DataMember = "Пользователи";
            this.пользователиBindingSource.DataSource = this.управлениеПроцессамиDataSet1;
            // 
            // пользователиTableAdapter
            // 
            this.пользователиTableAdapter.ClearBeforeFill = true;
            // 
            // zapisidDataGridViewTextBoxColumn
            // 
            this.zapisidDataGridViewTextBoxColumn.DataPropertyName = "zapis_id";
            this.zapisidDataGridViewTextBoxColumn.HeaderText = "zapis_id";
            this.zapisidDataGridViewTextBoxColumn.Name = "zapisidDataGridViewTextBoxColumn";
            this.zapisidDataGridViewTextBoxColumn.ReadOnly = true;
            this.zapisidDataGridViewTextBoxColumn.Visible = false;
            // 
            // пользовательDataGridViewTextBoxColumn
            // 
            this.пользовательDataGridViewTextBoxColumn.DataPropertyName = "Пользователь№";
            this.пользовательDataGridViewTextBoxColumn.DataSource = this.пользователиBindingSource;
            this.пользовательDataGridViewTextBoxColumn.DisplayMember = "Логин";
            this.пользовательDataGridViewTextBoxColumn.FillWeight = 85F;
            this.пользовательDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.пользовательDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.пользовательDataGridViewTextBoxColumn.Name = "пользовательDataGridViewTextBoxColumn";
            this.пользовательDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.пользовательDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.пользовательDataGridViewTextBoxColumn.ValueMember = "id";
            // 
            // операцияDataGridViewTextBoxColumn
            // 
            this.операцияDataGridViewTextBoxColumn.DataPropertyName = "Операция№";
            this.операцияDataGridViewTextBoxColumn.DataSource = this.операцииBindingSource;
            this.операцияDataGridViewTextBoxColumn.DisplayMember = "НазваниеОперации";
            this.операцияDataGridViewTextBoxColumn.FillWeight = 125F;
            this.операцияDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.операцияDataGridViewTextBoxColumn.HeaderText = "Операция";
            this.операцияDataGridViewTextBoxColumn.Name = "операцияDataGridViewTextBoxColumn";
            this.операцияDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.операцияDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.операцияDataGridViewTextBoxColumn.ValueMember = "op_id";
            // 
            // действиеDataGridViewTextBoxColumn
            // 
            this.действиеDataGridViewTextBoxColumn.DataPropertyName = "Действие";
            this.действиеDataGridViewTextBoxColumn.FillWeight = 85F;
            this.действиеDataGridViewTextBoxColumn.HeaderText = "Действие";
            this.действиеDataGridViewTextBoxColumn.Name = "действиеDataGridViewTextBoxColumn";
            // 
            // датаDataGridViewTextBoxColumn
            // 
            this.датаDataGridViewTextBoxColumn.DataPropertyName = "Дата";
            this.датаDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.датаDataGridViewTextBoxColumn.Name = "датаDataGridViewTextBoxColumn";
            // 
            // старыеДанныеDataGridViewTextBoxColumn
            // 
            this.старыеДанныеDataGridViewTextBoxColumn.DataPropertyName = "СтарыеДанные";
            this.старыеДанныеDataGridViewTextBoxColumn.FillWeight = 130F;
            this.старыеДанныеDataGridViewTextBoxColumn.HeaderText = "СтарыеДанные";
            this.старыеДанныеDataGridViewTextBoxColumn.Name = "старыеДанныеDataGridViewTextBoxColumn";
            // 
            // новыеДанныеDataGridViewTextBoxColumn
            // 
            this.новыеДанныеDataGridViewTextBoxColumn.DataPropertyName = "НовыеДанные";
            this.новыеДанныеDataGridViewTextBoxColumn.FillWeight = 130F;
            this.новыеДанныеDataGridViewTextBoxColumn.HeaderText = "НовыеДанные";
            this.новыеДанныеDataGridViewTextBoxColumn.Name = "новыеДанныеDataGridViewTextBoxColumn";
            // 
            // txtOperation
            // 
            this.txtOperation.BackColor = System.Drawing.Color.Transparent;
            this.txtOperation.BackgroundColor = System.Drawing.Color.White;
            this.txtOperation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtOperation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOperation.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtOperation.FocusImage = null;
            this.txtOperation.HoverBorderColor = System.Drawing.Color.Gray;
            this.txtOperation.HoverImage = null;
            this.txtOperation.IdleImage = null;
            this.txtOperation.Location = new System.Drawing.Point(150, 382);
            this.txtOperation.Name = "txtOperation";
            this.txtOperation.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtOperation.PlaceholderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtOperation.PlaceholderText = "Название операции...";
            this.txtOperation.ReadOnlyColors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtOperation.ReadOnlyColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtOperation.ReadOnlyColors.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtOperation.ReadOnlyColors.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtOperation.Size = new System.Drawing.Size(242, 32);
            this.txtOperation.TabIndex = 75;
            this.txtOperation.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtOperation.TextContent = "";
            this.txtOperation.ValidationPattern = "";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.BackgroundColor = System.Drawing.Color.White;
            this.txtUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUser.FocusImage = null;
            this.txtUser.HoverBorderColor = System.Drawing.Color.Gray;
            this.txtUser.HoverImage = null;
            this.txtUser.IdleImage = null;
            this.txtUser.Location = new System.Drawing.Point(150, 326);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtUser.PlaceholderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtUser.PlaceholderText = "Пользователь...";
            this.txtUser.ReadOnlyColors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtUser.ReadOnlyColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUser.ReadOnlyColors.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtUser.ReadOnlyColors.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtUser.Size = new System.Drawing.Size(242, 32);
            this.txtUser.TabIndex = 76;
            this.txtUser.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtUser.TextContent = "";
            this.txtUser.ValidationPattern = "";
            // 
            // txtAction
            // 
            this.txtAction.BackColor = System.Drawing.Color.Transparent;
            this.txtAction.BackgroundColor = System.Drawing.Color.White;
            this.txtAction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtAction.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAction.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAction.FocusImage = null;
            this.txtAction.HoverBorderColor = System.Drawing.Color.Gray;
            this.txtAction.HoverImage = null;
            this.txtAction.IdleImage = null;
            this.txtAction.Location = new System.Drawing.Point(150, 438);
            this.txtAction.Name = "txtAction";
            this.txtAction.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtAction.PlaceholderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtAction.PlaceholderText = "Название действие...";
            this.txtAction.ReadOnlyColors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtAction.ReadOnlyColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAction.ReadOnlyColors.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtAction.ReadOnlyColors.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtAction.Size = new System.Drawing.Size(242, 32);
            this.txtAction.TabIndex = 77;
            this.txtAction.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtAction.TextContent = "";
            this.txtAction.ValidationPattern = "";
            // 
            // txtOldData
            // 
            this.txtOldData.BackColor = System.Drawing.Color.Transparent;
            this.txtOldData.BackgroundColor = System.Drawing.Color.White;
            this.txtOldData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtOldData.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldData.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtOldData.FocusImage = null;
            this.txtOldData.HoverBorderColor = System.Drawing.Color.Gray;
            this.txtOldData.HoverImage = null;
            this.txtOldData.IdleImage = null;
            this.txtOldData.Location = new System.Drawing.Point(622, 340);
            this.txtOldData.Name = "txtOldData";
            this.txtOldData.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtOldData.PlaceholderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtOldData.PlaceholderText = "Старые данные...";
            this.txtOldData.ReadOnlyColors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtOldData.ReadOnlyColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtOldData.ReadOnlyColors.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtOldData.ReadOnlyColors.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtOldData.Size = new System.Drawing.Size(373, 32);
            this.txtOldData.TabIndex = 78;
            this.txtOldData.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtOldData.TextContent = "";
            this.txtOldData.ValidationPattern = "";
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.Transparent;
            this.txtDate.BackgroundColor = System.Drawing.Color.White;
            this.txtDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDate.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDate.FocusImage = null;
            this.txtDate.HoverBorderColor = System.Drawing.Color.Gray;
            this.txtDate.HoverImage = null;
            this.txtDate.IdleImage = null;
            this.txtDate.Location = new System.Drawing.Point(150, 493);
            this.txtDate.Name = "txtDate";
            this.txtDate.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtDate.PlaceholderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtDate.PlaceholderText = "Дата...";
            this.txtDate.ReadOnlyColors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtDate.ReadOnlyColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtDate.ReadOnlyColors.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtDate.ReadOnlyColors.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtDate.Size = new System.Drawing.Size(242, 32);
            this.txtDate.TabIndex = 78;
            this.txtDate.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.TextContent = "";
            this.txtDate.ValidationPattern = "";
            // 
            // txtNewData
            // 
            this.txtNewData.BackColor = System.Drawing.Color.Transparent;
            this.txtNewData.BackgroundColor = System.Drawing.Color.White;
            this.txtNewData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtNewData.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewData.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtNewData.FocusImage = null;
            this.txtNewData.HoverBorderColor = System.Drawing.Color.Gray;
            this.txtNewData.HoverImage = null;
            this.txtNewData.IdleImage = null;
            this.txtNewData.Location = new System.Drawing.Point(622, 411);
            this.txtNewData.Name = "txtNewData";
            this.txtNewData.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtNewData.PlaceholderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtNewData.PlaceholderText = "Новые данные...";
            this.txtNewData.ReadOnlyColors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtNewData.ReadOnlyColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtNewData.ReadOnlyColors.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtNewData.ReadOnlyColors.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtNewData.Size = new System.Drawing.Size(373, 32);
            this.txtNewData.TabIndex = 79;
            this.txtNewData.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtNewData.TextContent = "";
            this.txtNewData.ValidationPattern = "";
            this.txtNewData.TextContentChanged += new System.EventHandler(this.siticoneTextBoxAdvanced5_TextContentChanged);
            // 
            // siticoneLabel5
            // 
            this.siticoneLabel5.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.siticoneLabel5.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel5.Location = new System.Drawing.Point(0, 493);
            this.siticoneLabel5.Name = "siticoneLabel5";
            this.siticoneLabel5.Size = new System.Drawing.Size(216, 39);
            this.siticoneLabel5.TabIndex = 84;
            this.siticoneLabel5.Text = "Дата:";
            // 
            // siticoneLabel4
            // 
            this.siticoneLabel4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.siticoneLabel4.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel4.Location = new System.Drawing.Point(462, 340);
            this.siticoneLabel4.Name = "siticoneLabel4";
            this.siticoneLabel4.Size = new System.Drawing.Size(223, 39);
            this.siticoneLabel4.TabIndex = 83;
            this.siticoneLabel4.Text = "Старые данные:";
            // 
            // siticoneLabel3
            // 
            this.siticoneLabel3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.siticoneLabel3.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel3.Location = new System.Drawing.Point(0, 438);
            this.siticoneLabel3.Name = "siticoneLabel3";
            this.siticoneLabel3.Size = new System.Drawing.Size(216, 39);
            this.siticoneLabel3.TabIndex = 82;
            this.siticoneLabel3.Text = "Действие:";
            // 
            // siticoneLabel2
            // 
            this.siticoneLabel2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.siticoneLabel2.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel2.Location = new System.Drawing.Point(0, 382);
            this.siticoneLabel2.Name = "siticoneLabel2";
            this.siticoneLabel2.Size = new System.Drawing.Size(216, 39);
            this.siticoneLabel2.TabIndex = 81;
            this.siticoneLabel2.Text = "Операция:";
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.siticoneLabel1.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel1.Location = new System.Drawing.Point(0, 326);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(205, 39);
            this.siticoneLabel1.TabIndex = 80;
            this.siticoneLabel1.Text = "Пользователь:";
            // 
            // siticoneLabel7
            // 
            this.siticoneLabel7.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.siticoneLabel7.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel7.Location = new System.Drawing.Point(462, 411);
            this.siticoneLabel7.Name = "siticoneLabel7";
            this.siticoneLabel7.Size = new System.Drawing.Size(223, 39);
            this.siticoneLabel7.TabIndex = 86;
            this.siticoneLabel7.Text = "Новые данные:";
            // 
            // Admin5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 672);
            this.Controls.Add(this.txtNewData);
            this.Controls.Add(this.siticoneLabel7);
            this.Controls.Add(this.txtOldData);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtAction);
            this.Controls.Add(this.txtOperation);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.siticoneLabel5);
            this.Controls.Add(this.siticoneLabel4);
            this.Controls.Add(this.siticoneLabel3);
            this.Controls.Add(this.siticoneLabel2);
            this.Controls.Add(this.siticoneLabel1);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin5";
            this.Text = "Admin5";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Admin5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.журналДействийBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналДействийBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.журналДействийBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.операцииBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.пользователиBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private УправлениеПроцессамиDataSet управлениеПроцессамиDataSet;
        private System.Windows.Forms.BindingSource журналДействийBindingSource;
        private УправлениеПроцессамиDataSetTableAdapters.ЖурналДействийTableAdapter журналДействийTableAdapter;
        private SiticoneNetFrameworkUI.SiticoneImageButton btnRefresh;
        private УправлениеПроцессамиDataSet1 управлениеПроцессамиDataSet1;
        private System.Windows.Forms.BindingSource журналДействийBindingSource1;
        private УправлениеПроцессамиDataSet1TableAdapters.ЖурналДействийTableAdapter журналДействийTableAdapter1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.BindingSource журналДействийBindingSource2;
        private System.Windows.Forms.BindingSource управлениеПроцессамиDataSet1BindingSource;
        private System.Windows.Forms.BindingSource операцииBindingSource;
        private УправлениеПроцессамиDataSet1TableAdapters.ОперацииTableAdapter операцииTableAdapter;
        private System.Windows.Forms.BindingSource пользователиBindingSource;
        private УправлениеПроцессамиDataSet1TableAdapters.ПользователиTableAdapter пользователиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn zapisidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn пользовательDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn операцияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn действиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn старыеДанныеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn новыеДанныеDataGridViewTextBoxColumn;
        private SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced txtOperation;
        private SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced txtUser;
        private SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced txtAction;
        private SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced txtOldData;
        private SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced txtDate;
        private SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced txtNewData;
        private SiticoneNetFrameworkUI.SiticoneLabel siticoneLabel5;
        private SiticoneNetFrameworkUI.SiticoneLabel siticoneLabel4;
        private SiticoneNetFrameworkUI.SiticoneLabel siticoneLabel3;
        private SiticoneNetFrameworkUI.SiticoneLabel siticoneLabel2;
        private SiticoneNetFrameworkUI.SiticoneLabel siticoneLabel1;
        private SiticoneNetFrameworkUI.SiticoneLabel siticoneLabel7;
    }
}