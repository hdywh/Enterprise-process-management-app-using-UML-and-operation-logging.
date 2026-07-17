namespace Diplom
{
    partial class Sotr3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sotr3));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.управлениеПроцессамиDataSet = new Diplom.УправлениеПроцессамиDataSet();
            this.комментарииBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.комментарииTableAdapter = new Diplom.УправлениеПроцессамиDataSetTableAdapters.КомментарииTableAdapter();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.операцииBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.управлениеПроцессамиDataSet2 = new Diplom.УправлениеПроцессамиDataSet2();
            this.btnRefresh = new SiticoneNetFrameworkUI.SiticoneImageButton();
            this.btDelete = new SiticoneNetFrameworkUI.SiticoneButtonAdvanced();
            this.btnEdit = new SiticoneNetFrameworkUI.SiticoneButtonAdvanced();
            this.btnAdd = new SiticoneNetFrameworkUI.SiticoneButtonAdvanced();
            this.siticoneAdvancedTextArea1 = new SiticoneNetFrameworkUI.SiticoneAdvancedTextArea();
            this.txtopernom = new SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced();
            this.siticoneDateTimePicker1 = new SiticoneNetFrameworkUI.SiticoneDateTimePicker();
            this.операцииTableAdapter = new Diplom.УправлениеПроцессамиDataSet2TableAdapters.ОперацииTableAdapter();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.операцияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.пользовательDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.текстDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаДобавленияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.комментарииBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.операцииBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // управлениеПроцессамиDataSet
            // 
            this.управлениеПроцессамиDataSet.DataSetName = "УправлениеПроцессамиDataSet";
            this.управлениеПроцессамиDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // комментарииBindingSource
            // 
            this.комментарииBindingSource.DataMember = "Комментарии";
            this.комментарииBindingSource.DataSource = this.управлениеПроцессамиDataSet;
            // 
            // комментарииTableAdapter
            // 
            this.комментарииTableAdapter.ClearBeforeFill = true;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comidDataGridViewTextBoxColumn,
            this.операцияDataGridViewTextBoxColumn,
            this.пользовательDataGridViewTextBoxColumn,
            this.текстDataGridViewTextBoxColumn,
            this.датаДобавленияDataGridViewTextBoxColumn});
            this.guna2DataGridView1.DataSource = this.комментарииBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(0, -1);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.guna2DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.guna2DataGridView1.Size = new System.Drawing.Size(830, 243);
            this.guna2DataGridView1.TabIndex = 0;
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
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 23;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // операцииBindingSource
            // 
            this.операцииBindingSource.DataMember = "Операции";
            this.операцииBindingSource.DataSource = this.управлениеПроцессамиDataSet2;
            // 
            // управлениеПроцессамиDataSet2
            // 
            this.управлениеПроцессамиDataSet2.DataSetName = "УправлениеПроцессамиDataSet2";
            this.управлениеПроцессамиDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.btnRefresh.Location = new System.Drawing.Point(752, 514);
            this.btnRefresh.MakeRadial = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PlaceholderImage = null;
            this.btnRefresh.RippleColor = System.Drawing.Color.White;
            this.btnRefresh.RippleEnabled = true;
            this.btnRefresh.Size = new System.Drawing.Size(38, 34);
            this.btnRefresh.SpringEffectEnabled = true;
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "btnRefresh";
            this.btnRefresh.TrackSystemTheme = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.Transparent;
            this.btDelete.BadgeBackColor = System.Drawing.Color.Red;
            this.btDelete.BadgeForeColor = System.Drawing.Color.White;
            this.btDelete.BadgeRadius = 8;
            this.btDelete.BadgeRightMargin = 10;
            this.btDelete.BadgeValue = 0;
            this.btDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.btDelete.BorderColorEnd = System.Drawing.Color.Gray;
            this.btDelete.BorderColorStart = System.Drawing.Color.White;
            this.btDelete.BorderRadiusBottomLeft = 35;
            this.btDelete.BorderRadiusBottomRight = 35;
            this.btDelete.BorderRadiusTopLeft = 35;
            this.btDelete.BorderRadiusTopRight = 35;
            this.btDelete.BorderThickness = 0;
            this.btDelete.ButtonColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.btDelete.ButtonColorStart = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btDelete.ButtonImage = null;
            this.btDelete.CanBeep = false;
            this.btDelete.CanShake = false;
            this.btDelete.ClickSoundPath = null;
            this.btDelete.DisabledOverlayOpacity = 0.5F;
            this.btDelete.EnableBorderGradient = false;
            this.btDelete.EnableClickSound = false;
            this.btDelete.EnableFocusBorder = false;
            this.btDelete.EnableHoverSound = false;
            this.btDelete.EnablePressScale = false;
            this.btDelete.EnableTextShadow = false;
            this.btDelete.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btDelete.FocusBorderThickness = 2;
            this.btDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDelete.ForeColor = System.Drawing.Color.White;
            this.btDelete.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDelete.HoverSoundPath = null;
            this.btDelete.HoverTransitionSpeed = 0.08F;
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.ImageLeftMargin = 5;
            this.btDelete.ImageRightMargin = 8;
            this.btDelete.ImageSize = 24;
            this.btDelete.IsReadOnly = false;
            this.btDelete.Location = new System.Drawing.Point(518, 500);
            this.btDelete.MakeRadial = false;
            this.btDelete.Name = "btDelete";
            this.btDelete.PressAnimationSpeed = 0.2F;
            this.btDelete.PressDepth = 1;
            this.btDelete.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDelete.RippleExpandSpeedFactor = 0.05F;
            this.btDelete.RippleFadeSpeedFactor = 0.03F;
            this.btDelete.ShadowBlurFactor = 0.7F;
            this.btDelete.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.btDelete.ShadowOffsetX = 0;
            this.btDelete.ShadowOffsetY = 4;
            this.btDelete.Size = new System.Drawing.Size(216, 60);
            this.btDelete.TabIndex = 24;
            this.btDelete.Text = "Удалить";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btDelete.TextPaddingBottom = 0;
            this.btDelete.TextPaddingLeft = 0;
            this.btDelete.TextPaddingRight = 0;
            this.btDelete.TextPaddingTop = 0;
            this.btDelete.TextShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btDelete.TextShadowOffsetX = 1;
            this.btDelete.TextShadowOffsetY = 1;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BadgeBackColor = System.Drawing.Color.Red;
            this.btnEdit.BadgeForeColor = System.Drawing.Color.White;
            this.btnEdit.BadgeRadius = 8;
            this.btnEdit.BadgeRightMargin = 10;
            this.btnEdit.BadgeValue = 0;
            this.btnEdit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.btnEdit.BorderColorEnd = System.Drawing.Color.Gray;
            this.btnEdit.BorderColorStart = System.Drawing.Color.White;
            this.btnEdit.BorderRadiusBottomLeft = 35;
            this.btnEdit.BorderRadiusBottomRight = 35;
            this.btnEdit.BorderRadiusTopLeft = 35;
            this.btnEdit.BorderRadiusTopRight = 35;
            this.btnEdit.BorderThickness = 0;
            this.btnEdit.ButtonColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnEdit.ButtonColorStart = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnEdit.ButtonImage = null;
            this.btnEdit.CanBeep = false;
            this.btnEdit.CanShake = false;
            this.btnEdit.ClickSoundPath = null;
            this.btnEdit.DisabledOverlayOpacity = 0.5F;
            this.btnEdit.EnableBorderGradient = false;
            this.btnEdit.EnableClickSound = false;
            this.btnEdit.EnableFocusBorder = false;
            this.btnEdit.EnableHoverSound = false;
            this.btnEdit.EnablePressScale = false;
            this.btnEdit.EnableTextShadow = false;
            this.btnEdit.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnEdit.FocusBorderThickness = 2;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEdit.HoverSoundPath = null;
            this.btnEdit.HoverTransitionSpeed = 0.08F;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.ImageLeftMargin = 5;
            this.btnEdit.ImageRightMargin = 8;
            this.btnEdit.ImageSize = 24;
            this.btnEdit.IsReadOnly = false;
            this.btnEdit.Location = new System.Drawing.Point(287, 500);
            this.btnEdit.MakeRadial = false;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressAnimationSpeed = 0.2F;
            this.btnEdit.PressDepth = 1;
            this.btnEdit.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEdit.RippleExpandSpeedFactor = 0.05F;
            this.btnEdit.RippleFadeSpeedFactor = 0.03F;
            this.btnEdit.ShadowBlurFactor = 0.7F;
            this.btnEdit.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.btnEdit.ShadowOffsetX = 0;
            this.btnEdit.ShadowOffsetY = 4;
            this.btnEdit.Size = new System.Drawing.Size(210, 60);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.TextPaddingBottom = 0;
            this.btnEdit.TextPaddingLeft = 0;
            this.btnEdit.TextPaddingRight = 0;
            this.btnEdit.TextPaddingTop = 0;
            this.btnEdit.TextShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEdit.TextShadowOffsetX = 1;
            this.btnEdit.TextShadowOffsetY = 1;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BadgeBackColor = System.Drawing.Color.Red;
            this.btnAdd.BadgeForeColor = System.Drawing.Color.White;
            this.btnAdd.BadgeRadius = 8;
            this.btnAdd.BadgeRightMargin = 10;
            this.btnAdd.BadgeValue = 0;
            this.btnAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.btnAdd.BorderColorEnd = System.Drawing.Color.Gray;
            this.btnAdd.BorderColorStart = System.Drawing.Color.White;
            this.btnAdd.BorderRadiusBottomLeft = 35;
            this.btnAdd.BorderRadiusBottomRight = 35;
            this.btnAdd.BorderRadiusTopLeft = 35;
            this.btnAdd.BorderRadiusTopRight = 35;
            this.btnAdd.BorderThickness = 0;
            this.btnAdd.ButtonColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnAdd.ButtonColorStart = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.btnAdd.ButtonImage = null;
            this.btnAdd.CanBeep = false;
            this.btnAdd.CanShake = false;
            this.btnAdd.ClickSoundPath = null;
            this.btnAdd.DisabledOverlayOpacity = 0.5F;
            this.btnAdd.EnableBorderGradient = false;
            this.btnAdd.EnableClickSound = false;
            this.btnAdd.EnableFocusBorder = false;
            this.btnAdd.EnableHoverSound = false;
            this.btnAdd.EnablePressScale = false;
            this.btnAdd.EnableTextShadow = false;
            this.btnAdd.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnAdd.FocusBorderThickness = 2;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.HoverSoundPath = null;
            this.btnAdd.HoverTransitionSpeed = 0.08F;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageLeftMargin = 5;
            this.btnAdd.ImageRightMargin = 8;
            this.btnAdd.ImageSize = 24;
            this.btnAdd.IsReadOnly = false;
            this.btnAdd.Location = new System.Drawing.Point(42, 500);
            this.btnAdd.MakeRadial = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressAnimationSpeed = 0.2F;
            this.btnAdd.PressDepth = 1;
            this.btnAdd.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.RippleExpandSpeedFactor = 0.05F;
            this.btnAdd.RippleFadeSpeedFactor = 0.03F;
            this.btnAdd.ShadowBlurFactor = 0.7F;
            this.btnAdd.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(232)))));
            this.btnAdd.ShadowOffsetX = 0;
            this.btnAdd.ShadowOffsetY = 4;
            this.btnAdd.Size = new System.Drawing.Size(205, 60);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.TextPaddingBottom = 0;
            this.btnAdd.TextPaddingLeft = 0;
            this.btnAdd.TextPaddingRight = 0;
            this.btnAdd.TextPaddingTop = 0;
            this.btnAdd.TextShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAdd.TextShadowOffsetX = 1;
            this.btnAdd.TextShadowOffsetY = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // siticoneAdvancedTextArea1
            // 
            this.siticoneAdvancedTextArea1.CurrentLineHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.siticoneAdvancedTextArea1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.siticoneAdvancedTextArea1.Location = new System.Drawing.Point(311, 248);
            this.siticoneAdvancedTextArea1.Margin = new System.Windows.Forms.Padding(5);
            this.siticoneAdvancedTextArea1.MinimumSize = new System.Drawing.Size(100, 100);
            this.siticoneAdvancedTextArea1.Name = "siticoneAdvancedTextArea1";
            this.siticoneAdvancedTextArea1.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.siticoneAdvancedTextArea1.Size = new System.Drawing.Size(254, 216);
            this.siticoneAdvancedTextArea1.TabIndex = 27;
            // 
            // txtopernom
            // 
            this.txtopernom.BackColor = System.Drawing.Color.Transparent;
            this.txtopernom.BackgroundColor = System.Drawing.Color.White;
            this.txtopernom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtopernom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtopernom.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.txtopernom.FocusImage = null;
            this.txtopernom.HoverBorderColor = System.Drawing.Color.Gray;
            this.txtopernom.HoverImage = null;
            this.txtopernom.IdleImage = null;
            this.txtopernom.Location = new System.Drawing.Point(12, 248);
            this.txtopernom.Name = "txtopernom";
            this.txtopernom.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtopernom.PlaceholderFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtopernom.PlaceholderText = "Введите номер операции...";
            this.txtopernom.ReadOnlyColors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtopernom.ReadOnlyColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtopernom.ReadOnlyColors.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtopernom.ReadOnlyColors.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtopernom.Size = new System.Drawing.Size(205, 36);
            this.txtopernom.TabIndex = 29;
            this.txtopernom.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtopernom.TextContent = "";
            this.txtopernom.ValidationPattern = "";
            this.txtopernom.Visible = false;
            this.txtopernom.TextContentChanged += new System.EventHandler(this.txtopernom_TextContentChanged);
            // 
            // siticoneDateTimePicker1
            // 
            this.siticoneDateTimePicker1.AutoScaleFonts = true;
            this.siticoneDateTimePicker1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneDateTimePicker1.BaseCalendarFormSize = new System.Drawing.Size(535, 460);
            this.siticoneDateTimePicker1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.siticoneDateTimePicker1.BorderWidth = 2;
            this.siticoneDateTimePicker1.BottomLeftBorderRadius = 21;
            this.siticoneDateTimePicker1.BottomRightBorderRadius = 21;
            this.siticoneDateTimePicker1.CalendarBackgroundColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.CalendarChevronColor = System.Drawing.Color.Gray;
            this.siticoneDateTimePicker1.CalendarChevronHoverColor = System.Drawing.Color.Blue;
            this.siticoneDateTimePicker1.CalendarDayButtonBackColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.CalendarDayButtonForeColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.CalendarDayHeaderBackColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.CalendarDayHeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.siticoneDateTimePicker1.CalendarDayLabelFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.siticoneDateTimePicker1.CalendarDisabledDateBackColor = System.Drawing.Color.LightGray;
            this.siticoneDateTimePicker1.CalendarDisabledDateForeColor = System.Drawing.Color.DarkGray;
            this.siticoneDateTimePicker1.CalendarFormAnimationSpeed = 15;
            this.siticoneDateTimePicker1.CalendarFormAnimationStep = 0.08D;
            this.siticoneDateTimePicker1.CalendarFormBackColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.CalendarFormBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.siticoneDateTimePicker1.CalendarFormBorderWidth = 2;
            this.siticoneDateTimePicker1.CalendarFormCornerRadius = 2;
            this.siticoneDateTimePicker1.CalendarFormFadeOutStep = 0.1D;
            this.siticoneDateTimePicker1.CalendarFormHeight = 320;
            this.siticoneDateTimePicker1.CalendarFormShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siticoneDateTimePicker1.CalendarFormShadowDepth = 5;
            this.siticoneDateTimePicker1.CalendarFormWidth = 280;
            this.siticoneDateTimePicker1.CalendarGridMargin = new System.Windows.Forms.Padding(8);
            this.siticoneDateTimePicker1.CalendarGridPadding = new System.Windows.Forms.Padding(5);
            this.siticoneDateTimePicker1.CalendarLockedDateBackColor = System.Drawing.Color.LightGray;
            this.siticoneDateTimePicker1.CalendarLockedDateForeColor = System.Drawing.Color.DarkGray;
            this.siticoneDateTimePicker1.CalendarLockedDates = ((System.Collections.Generic.List<System.DateTime>)(resources.GetObject("siticoneDateTimePicker1.CalendarLockedDates")));
            this.siticoneDateTimePicker1.CalendarMargin = 5;
            this.siticoneDateTimePicker1.CalendarMaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.siticoneDateTimePicker1.CalendarMaxYear = 2126;
            this.siticoneDateTimePicker1.CalendarMinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.siticoneDateTimePicker1.CalendarMinYear = 1926;
            this.siticoneDateTimePicker1.CalendarRangeDateBackColor = System.Drawing.Color.LightBlue;
            this.siticoneDateTimePicker1.CalendarRangeEndDateBackColor = System.Drawing.Color.DodgerBlue;
            this.siticoneDateTimePicker1.CalendarRangeSelectedForeColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.CalendarRangeStartDateBackColor = System.Drawing.Color.DodgerBlue;
            this.siticoneDateTimePicker1.CalendarSelectedDateBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.siticoneDateTimePicker1.CalendarSelectedDateForeColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.CalendarSelectionMode = SiticoneNetFrameworkUI.SelectionMode.Single;
            this.siticoneDateTimePicker1.CalendarTodayBackColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.CalendarYearPickerHeight = 10;
            this.siticoneDateTimePicker1.CanBeep = true;
            this.siticoneDateTimePicker1.CanShake = true;
            this.siticoneDateTimePicker1.ChevronColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.siticoneDateTimePicker1.ChevronHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(245)))));
            this.siticoneDateTimePicker1.ChevronHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(184)))));
            this.siticoneDateTimePicker1.ChevronPanelBorderRadius = 16;
            this.siticoneDateTimePicker1.ChevronPanelHeight = 32;
            this.siticoneDateTimePicker1.ChevronPenThickness = 1.8F;
            this.siticoneDateTimePicker1.ChevronRightMargin = 18;
            this.siticoneDateTimePicker1.ChevronSize = new System.Drawing.Size(9, 14);
            this.siticoneDateTimePicker1.ChevronStep = 15F;
            this.siticoneDateTimePicker1.ChevronTimerInterval = 15;
            this.siticoneDateTimePicker1.ClearIconColor = System.Drawing.Color.Gray;
            this.siticoneDateTimePicker1.ClearIconHoverColor = System.Drawing.Color.Red;
            this.siticoneDateTimePicker1.ClearIconRightMargin = 48;
            this.siticoneDateTimePicker1.ClearIconSize = 11;
            this.siticoneDateTimePicker1.ContainerPanelMargin = new System.Windows.Forms.Padding(5);
            this.siticoneDateTimePicker1.ContainerPanelPadding = new System.Windows.Forms.Padding(0);
            this.siticoneDateTimePicker1.CustomDateFormat = "d";
            this.siticoneDateTimePicker1.CustomDateFormatter = null;
            this.siticoneDateTimePicker1.DateFormat = SiticoneNetFrameworkUI.DateFormat.LongDate;
            this.siticoneDateTimePicker1.DayButtonBorderRadius = 16;
            this.siticoneDateTimePicker1.DayButtonClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.siticoneDateTimePicker1.DayButtonFont = new System.Drawing.Font("Segoe UI", 10.5F);
            this.siticoneDateTimePicker1.DayButtonHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.siticoneDateTimePicker1.DayButtonHoverForeColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.DayButtonMargin = new System.Windows.Forms.Padding(3);
            this.siticoneDateTimePicker1.DayButtonRowHeight = 16.66F;
            this.siticoneDateTimePicker1.DayHeaderFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.siticoneDateTimePicker1.DayHeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.siticoneDateTimePicker1.DayHeaderMargin = new System.Windows.Forms.Padding(1, 1, 1, 8);
            this.siticoneDateTimePicker1.DayHeaderRowHeight = 30F;
            this.siticoneDateTimePicker1.DisabledDayFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.siticoneDateTimePicker1.DropdownBackColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.DropdownFont = new System.Drawing.Font("Segoe UI", 11F);
            this.siticoneDateTimePicker1.DropdownHeight = 250;
            this.siticoneDateTimePicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.siticoneDateTimePicker1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.siticoneDateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneDateTimePicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.siticoneDateTimePicker1.GradientEndColor = System.Drawing.Color.Gray;
            this.siticoneDateTimePicker1.GradientStartColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.HighlightWeekends = true;
            this.siticoneDateTimePicker1.IconSize = 16;
            this.siticoneDateTimePicker1.IsReadonly = false;
            this.siticoneDateTimePicker1.Location = new System.Drawing.Point(573, 248);
            this.siticoneDateTimePicker1.LockedDates = ((System.Collections.Generic.List<System.DateTime>)(resources.GetObject("siticoneDateTimePicker1.LockedDates")));
            this.siticoneDateTimePicker1.MakeRadial = true;
            this.siticoneDateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.siticoneDateTimePicker1.MaxFontScale = 1.8F;
            this.siticoneDateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.siticoneDateTimePicker1.MinFontScale = 0.4F;
            this.siticoneDateTimePicker1.MinimumFormSize = new System.Drawing.Size(150, 150);
            this.siticoneDateTimePicker1.MonthChevronPanelMargin = new System.Windows.Forms.Padding(4, 17, 4, 0);
            this.siticoneDateTimePicker1.MonthChevronSpacing = 5;
            this.siticoneDateTimePicker1.MonthComboBoxMargin = new System.Windows.Forms.Padding(0, 17, 5, 0);
            this.siticoneDateTimePicker1.MonthComboBoxSize = new System.Drawing.Size(130, 30);
            this.siticoneDateTimePicker1.Name = "siticoneDateTimePicker1";
            this.siticoneDateTimePicker1.NavigationFlowPadding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.siticoneDateTimePicker1.NavigationPanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.siticoneDateTimePicker1.NavigationPanelHeight = 65;
            this.siticoneDateTimePicker1.NextMonthPanelWidth = 34;
            this.siticoneDateTimePicker1.NextYearPanelWidth = 40;
            this.siticoneDateTimePicker1.PlaceholderText = "Выберите дату";
            this.siticoneDateTimePicker1.PrevMonthPanelWidth = 34;
            this.siticoneDateTimePicker1.PrevYearPanelWidth = 40;
            this.siticoneDateTimePicker1.RangeStartEndCornerRadius = 16;
            this.siticoneDateTimePicker1.ReadonlyBorderColor = System.Drawing.Color.Gray;
            this.siticoneDateTimePicker1.ReadonlyFillColor = System.Drawing.Color.LightGray;
            this.siticoneDateTimePicker1.ReadOnlyForeColor = System.Drawing.Color.DarkGray;
            this.siticoneDateTimePicker1.ReadonlyPlaceHolderColor = System.Drawing.Color.DarkGray;
            this.siticoneDateTimePicker1.SelectedDate = null;
            this.siticoneDateTimePicker1.SelectedDateBorderColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.SelectedDateBorderThickness = 1F;
            this.siticoneDateTimePicker1.SelectedDates = ((System.Collections.Generic.List<System.DateTime>)(resources.GetObject("siticoneDateTimePicker1.SelectedDates")));
            this.siticoneDateTimePicker1.SelectionMode = SiticoneNetFrameworkUI.SelectionMode.Single;
            this.siticoneDateTimePicker1.ShakeAmplitude = 4;
            this.siticoneDateTimePicker1.ShakeTimerInterval = 30;
            this.siticoneDateTimePicker1.ShakeTotalShakes = 8;
            this.siticoneDateTimePicker1.ShowClearButton = true;
            this.siticoneDateTimePicker1.ShowMonthYearNavigation = true;
            this.siticoneDateTimePicker1.ShowTodayButton = true;
            this.siticoneDateTimePicker1.Size = new System.Drawing.Size(202, 42);
            this.siticoneDateTimePicker1.TabIndex = 30;
            this.siticoneDateTimePicker1.Text = "siticoneDateTimePicker1";
            this.siticoneDateTimePicker1.TodayBorderColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.TodayBorderThickness = 2F;
            this.siticoneDateTimePicker1.TodayButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.siticoneDateTimePicker1.TodayButtonBorderRadius = 16;
            this.siticoneDateTimePicker1.TodayButtonClickBackColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.TodayButtonFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.siticoneDateTimePicker1.TodayButtonForeColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.TodayButtonHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(184)))));
            this.siticoneDateTimePicker1.TodayButtonMargin = new System.Windows.Forms.Padding(0, 17, 15, 0);
            this.siticoneDateTimePicker1.TodayButtonSize = new System.Drawing.Size(70, 35);
            this.siticoneDateTimePicker1.TodayButtonText = "Today";
            this.siticoneDateTimePicker1.TodayTextColor = System.Drawing.Color.Black;
            this.siticoneDateTimePicker1.TodayTextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.siticoneDateTimePicker1.TopLeftBorderRadius = 21;
            this.siticoneDateTimePicker1.TopRightBorderRadius = 21;
            this.siticoneDateTimePicker1.UseCalendarFormAnimation = true;
            this.siticoneDateTimePicker1.UseCalendarFormShadow = true;
            this.siticoneDateTimePicker1.UseChevronAnimation = true;
            this.siticoneDateTimePicker1.UseGradientFill = false;
            this.siticoneDateTimePicker1.Value = null;
            this.siticoneDateTimePicker1.WeekendDayBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.siticoneDateTimePicker1.WeekendDayForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siticoneDateTimePicker1.YearChevronPanelMargin = new System.Windows.Forms.Padding(4, 17, 4, 0);
            this.siticoneDateTimePicker1.YearChevronSpacing = 1;
            this.siticoneDateTimePicker1.YearComboBoxMargin = new System.Windows.Forms.Padding(5, 17, 0, 0);
            this.siticoneDateTimePicker1.YearComboBoxSize = new System.Drawing.Size(90, 30);
            // 
            // операцииTableAdapter
            // 
            this.операцииTableAdapter.ClearBeforeFill = true;
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Location = new System.Drawing.Point(12, 248);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(291, 36);
            this.guna2ComboBox1.TabIndex = 35;
            this.guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // comidDataGridViewTextBoxColumn
            // 
            this.comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
            this.comidDataGridViewTextBoxColumn.HeaderText = "com_id";
            this.comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
            this.comidDataGridViewTextBoxColumn.ReadOnly = true;
            this.comidDataGridViewTextBoxColumn.Visible = false;
            // 
            // операцияDataGridViewTextBoxColumn
            // 
            this.операцияDataGridViewTextBoxColumn.DataPropertyName = "Операция№";
            this.операцияDataGridViewTextBoxColumn.DataSource = this.операцииBindingSource;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.операцияDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.операцияDataGridViewTextBoxColumn.DisplayMember = "НазваниеОперации";
            this.операцияDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.операцияDataGridViewTextBoxColumn.HeaderText = "Операция№";
            this.операцияDataGridViewTextBoxColumn.Name = "операцияDataGridViewTextBoxColumn";
            this.операцияDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.операцияDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.операцияDataGridViewTextBoxColumn.ValueMember = "op_id";
            // 
            // пользовательDataGridViewTextBoxColumn
            // 
            this.пользовательDataGridViewTextBoxColumn.DataPropertyName = "Пользователь№";
            this.пользовательDataGridViewTextBoxColumn.HeaderText = "Пользователь№";
            this.пользовательDataGridViewTextBoxColumn.Name = "пользовательDataGridViewTextBoxColumn";
            this.пользовательDataGridViewTextBoxColumn.Visible = false;
            // 
            // текстDataGridViewTextBoxColumn
            // 
            this.текстDataGridViewTextBoxColumn.DataPropertyName = "Текст";
            this.текстDataGridViewTextBoxColumn.HeaderText = "Текст";
            this.текстDataGridViewTextBoxColumn.Name = "текстDataGridViewTextBoxColumn";
            // 
            // датаДобавленияDataGridViewTextBoxColumn
            // 
            this.датаДобавленияDataGridViewTextBoxColumn.DataPropertyName = "ДатаДобавления";
            this.датаДобавленияDataGridViewTextBoxColumn.FillWeight = 60F;
            this.датаДобавленияDataGridViewTextBoxColumn.HeaderText = "ДатаДобавления";
            this.датаДобавленияDataGridViewTextBoxColumn.Name = "датаДобавленияDataGridViewTextBoxColumn";
            // 
            // Sotr3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(830, 572);
            this.Controls.Add(this.guna2ComboBox1);
            this.Controls.Add(this.siticoneDateTimePicker1);
            this.Controls.Add(this.txtopernom);
            this.Controls.Add(this.siticoneAdvancedTextArea1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.guna2DataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sotr3";
            this.Text = "Sotr3";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Sotr3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.комментарииBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.операцииBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.управлениеПроцессамиDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private УправлениеПроцессамиDataSet управлениеПроцессамиDataSet;
        private System.Windows.Forms.BindingSource комментарииBindingSource;
        private УправлениеПроцессамиDataSetTableAdapters.КомментарииTableAdapter комментарииTableAdapter;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private SiticoneNetFrameworkUI.SiticoneImageButton btnRefresh;
        private SiticoneNetFrameworkUI.SiticoneButtonAdvanced btDelete;
        private SiticoneNetFrameworkUI.SiticoneButtonAdvanced btnEdit;
        private SiticoneNetFrameworkUI.SiticoneButtonAdvanced btnAdd;
        private SiticoneNetFrameworkUI.SiticoneAdvancedTextArea siticoneAdvancedTextArea1;
        private SiticoneNetFrameworkUI.SiticoneTextBoxAdvanced txtopernom;
        private SiticoneNetFrameworkUI.SiticoneDateTimePicker siticoneDateTimePicker1;
        private УправлениеПроцессамиDataSet2 управлениеПроцессамиDataSet2;
        private System.Windows.Forms.BindingSource операцииBindingSource;
        private УправлениеПроцессамиDataSet2TableAdapters.ОперацииTableAdapter операцииTableAdapter;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn операцияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn пользовательDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn текстDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаДобавленияDataGridViewTextBoxColumn;
    }
}