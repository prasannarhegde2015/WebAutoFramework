namespace WebAutomation
{
    partial class PageDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.upDownFlash = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtWebPageId = new System.Windows.Forms.TextBox();
            this.mnuGridOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTestCases = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gdvSelectedControls = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.gdvTestCaseList = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UniqueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WebPageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.upDownOrdinalPosition = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateData = new System.Windows.Forms.Button();
            this.chkAllControls = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dnDynamicData = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dnAddVerify = new System.Windows.Forms.ComboBox();
            this.btnAddVerification = new System.Windows.Forms.Button();
            this.chkIdentifyControls = new System.Windows.Forms.CheckBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.UserFriendlyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IgnoreSuffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IgnorePrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FramePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalControlID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalControlname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageDataID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageControlID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdinalPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalVerificationData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.upDownFlash)).BeginInit();
            this.mnuGridOperations.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelectedControls)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTestCaseList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownOrdinalPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(60, 10);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(468, 23);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "http://clabdevapp1:105/sites/ProjectCentral/SitePages/CreateProject.aspx";
            // 
            // upDownFlash
            // 
            this.upDownFlash.Location = new System.Drawing.Point(194, 73);
            this.upDownFlash.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.upDownFlash.Name = "upDownFlash";
            this.upDownFlash.Size = new System.Drawing.Size(53, 20);
            this.upDownFlash.TabIndex = 11;
            this.upDownFlash.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownFlash.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Highlight";
            this.label4.Visible = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(60, 37);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(238, 23);
            this.txtTitle.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Title";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1007, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtWebPageId
            // 
            this.txtWebPageId.Location = new System.Drawing.Point(304, 39);
            this.txtWebPageId.Name = "txtWebPageId";
            this.txtWebPageId.ReadOnly = true;
            this.txtWebPageId.Size = new System.Drawing.Size(100, 20);
            this.txtWebPageId.TabIndex = 29;
            // 
            // mnuGridOperations
            // 
            this.mnuGridOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripInsert,
            this.toolStripDelete});
            this.mnuGridOperations.Name = "mnuGridOperations";
            this.mnuGridOperations.Size = new System.Drawing.Size(116, 48);
            this.mnuGridOperations.Opening += new System.ComponentModel.CancelEventHandler(this.mnuGridOperations_Opening);
            this.mnuGridOperations.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuGridOperations_ItemClicked);
            // 
            // toolStripInsert
            // 
            this.toolStripInsert.Name = "toolStripInsert";
            this.toolStripInsert.Size = new System.Drawing.Size(115, 22);
            this.toolStripInsert.Text = "Highlight";
            this.toolStripInsert.Click += new System.EventHandler(this.toolStripInsert_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(115, 22);
            this.toolStripDelete.Text = "Delete";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // txtTestCases
            // 
            this.txtTestCases.Location = new System.Drawing.Point(788, 13);
            this.txtTestCases.MaxLength = 50;
            this.txtTestCases.Name = "txtTestCases";
            this.txtTestCases.Size = new System.Drawing.Size(213, 20);
            this.txtTestCases.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(718, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Test Case";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gdvSelectedControls);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1047, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Selected Controls";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gdvSelectedControls
            // 
            this.gdvSelectedControls.AllowDrop = true;
            this.gdvSelectedControls.AllowUserToAddRows = false;
            this.gdvSelectedControls.AllowUserToDeleteRows = false;
            this.gdvSelectedControls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gdvSelectedControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvSelectedControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserFriendlyName,
            this.ControlType,
            this.ControlText,
            this.ControlValue,
            this.IgnoreSuffix,
            this.IgnorePrefix,
            this.Visible,
            this.FramePosition,
            this.OriginalControlID,
            this.OriginalControlname,
            this.IsAction,
            this.Identifier,
            this.DeleteRow,
            this.PageDataID,
            this.PageControlID,
            this.ControlName,
            this.ControlID,
            this.DataName,
            this.OrdinalPosition,
            this.Data,
            this.Index,
            this.OriginalData,
            this.originalVerificationData});
            this.gdvSelectedControls.GridColor = System.Drawing.Color.Maroon;
            this.gdvSelectedControls.Location = new System.Drawing.Point(-4, 6);
            this.gdvSelectedControls.Name = "gdvSelectedControls";
            this.gdvSelectedControls.RowHeadersVisible = false;
            this.gdvSelectedControls.Size = new System.Drawing.Size(1038, 462);
            this.gdvSelectedControls.TabIndex = 6;
            this.gdvSelectedControls.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSelectedControls_CellClick);
            this.gdvSelectedControls.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSelectedControls_CellContentClick);
            this.gdvSelectedControls.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSelectedControls_CellDoubleClick);
            this.gdvSelectedControls.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSelectedControls_CellEnter);
            this.gdvSelectedControls.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSelectedControls_RowEnter);
            this.gdvSelectedControls.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvSelectedControls_KeyDown);
            this.gdvSelectedControls.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gdvSelectedControls_MouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 215);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1055, 487);
            this.tabControl1.TabIndex = 21;
            // 
            // gdvTestCaseList
            // 
            this.gdvTestCaseList.AllowUserToAddRows = false;
            this.gdvTestCaseList.AllowUserToDeleteRows = false;
            this.gdvTestCaseList.AllowUserToResizeColumns = false;
            this.gdvTestCaseList.AllowUserToResizeRows = false;
            this.gdvTestCaseList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gdvTestCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvTestCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.TestCase,
            this.UniqueName,
            this.Title,
            this.Notes,
            this.WebPageID});
            this.gdvTestCaseList.Location = new System.Drawing.Point(587, 38);
            this.gdvTestCaseList.MultiSelect = false;
            this.gdvTestCaseList.Name = "gdvTestCaseList";
            this.gdvTestCaseList.ReadOnly = true;
            this.gdvTestCaseList.RowHeadersVisible = false;
            this.gdvTestCaseList.Size = new System.Drawing.Size(349, 193);
            this.gdvTestCaseList.TabIndex = 34;
            this.gdvTestCaseList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvTestCaseList_CellClick);
            this.gdvTestCaseList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvTestCaseList_CellContentClick);
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Width = 62;
            // 
            // TestCase
            // 
            this.TestCase.HeaderText = "TestCase";
            this.TestCase.Name = "TestCase";
            this.TestCase.ReadOnly = true;
            this.TestCase.Width = 77;
            // 
            // UniqueName
            // 
            this.UniqueName.HeaderText = "UniqueName";
            this.UniqueName.Name = "UniqueName";
            this.UniqueName.ReadOnly = true;
            this.UniqueName.Width = 94;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 52;
            // 
            // Notes
            // 
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            this.Notes.Width = 60;
            // 
            // WebPageID
            // 
            this.WebPageID.HeaderText = "WebPageID";
            this.WebPageID.Name = "WebPageID";
            this.WebPageID.ReadOnly = true;
            this.WebPageID.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(1007, 189);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 38);
            this.btnRun.TabIndex = 37;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(1007, 51);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 38);
            this.btnNew.TabIndex = 38;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Controls.Add(this.upDownOrdinalPosition);
            this.groupBox1.Controls.Add(this.btnGenerateData);
            this.groupBox1.Controls.Add(this.chkAllControls);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dnDynamicData);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.upDownFlash);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(17, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 69);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // upDownOrdinalPosition
            // 
            this.upDownOrdinalPosition.Location = new System.Drawing.Point(148, 31);
            this.upDownOrdinalPosition.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.upDownOrdinalPosition.Name = "upDownOrdinalPosition";
            this.upDownOrdinalPosition.Size = new System.Drawing.Size(120, 20);
            this.upDownOrdinalPosition.TabIndex = 42;
            this.upDownOrdinalPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.Location = new System.Drawing.Point(15, 63);
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.Size = new System.Drawing.Size(75, 38);
            this.btnGenerateData.TabIndex = 41;
            this.btnGenerateData.Text = "Generate";
            this.btnGenerateData.UseVisualStyleBackColor = true;
            this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
            // 
            // chkAllControls
            // 
            this.chkAllControls.AutoSize = true;
            this.chkAllControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllControls.Location = new System.Drawing.Point(274, 33);
            this.chkAllControls.Name = "chkAllControls";
            this.chkAllControls.Size = new System.Drawing.Size(97, 17);
            this.chkAllControls.TabIndex = 40;
            this.chkAllControls.Text = "All Controls?";
            this.chkAllControls.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(145, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Ordinal Position ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Dynamic data";
            // 
            // dnDynamicData
            // 
            this.dnDynamicData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnDynamicData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dnDynamicData.FormattingEnabled = true;
            this.dnDynamicData.Items.AddRange(new object[] {
            "Guid"});
            this.dnDynamicData.Location = new System.Drawing.Point(13, 30);
            this.dnDynamicData.Name = "dnDynamicData";
            this.dnDynamicData.Size = new System.Drawing.Size(121, 21);
            this.dnDynamicData.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(16, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Select Control on Web page and click on a row";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Action";
            // 
            // dnAddVerify
            // 
            this.dnAddVerify.FormattingEnabled = true;
            this.dnAddVerify.Items.AddRange(new object[] {
            "Add",
            "Verify"});
            this.dnAddVerify.Location = new System.Drawing.Point(587, 11);
            this.dnAddVerify.Name = "dnAddVerify";
            this.dnAddVerify.Size = new System.Drawing.Size(121, 21);
            this.dnAddVerify.TabIndex = 41;
            // 
            // btnAddVerification
            // 
            this.btnAddVerification.Location = new System.Drawing.Point(489, 59);
            this.btnAddVerification.Name = "btnAddVerification";
            this.btnAddVerification.Size = new System.Drawing.Size(92, 43);
            this.btnAddVerification.TabIndex = 44;
            this.btnAddVerification.Text = "Add Verification";
            this.btnAddVerification.UseVisualStyleBackColor = true;
            this.btnAddVerification.Visible = false;
            this.btnAddVerification.Click += new System.EventHandler(this.btnAddVerification_Click);
            // 
            // chkIdentifyControls
            // 
            this.chkIdentifyControls.AutoSize = true;
            this.chkIdentifyControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIdentifyControls.ForeColor = System.Drawing.Color.Firebrick;
            this.chkIdentifyControls.Location = new System.Drawing.Point(230, 206);
            this.chkIdentifyControls.Name = "chkIdentifyControls";
            this.chkIdentifyControls.Size = new System.Drawing.Size(143, 21);
            this.chkIdentifyControls.TabIndex = 45;
            this.chkIdentifyControls.Text = "Identify controls";
            this.chkIdentifyControls.UseVisualStyleBackColor = false;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(1007, 93);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 38);
            this.btnRename.TabIndex = 46;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1007, 135);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 38);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // UserFriendlyName
            // 
            this.UserFriendlyName.HeaderText = "FieldName";
            this.UserFriendlyName.Name = "UserFriendlyName";
            this.UserFriendlyName.Width = 82;
            // 
            // ControlType
            // 
            this.ControlType.HeaderText = "ControlType";
            this.ControlType.Name = "ControlType";
            this.ControlType.Width = 89;
            // 
            // ControlText
            // 
            this.ControlText.HeaderText = "ControlText";
            this.ControlText.Name = "ControlText";
            this.ControlText.Visible = false;
            this.ControlText.Width = 86;
            // 
            // ControlValue
            // 
            this.ControlValue.HeaderText = "ControlValue";
            this.ControlValue.Name = "ControlValue";
            this.ControlValue.Visible = false;
            this.ControlValue.Width = 92;
            // 
            // IgnoreSuffix
            // 
            this.IgnoreSuffix.HeaderText = "IgnoreSuffix";
            this.IgnoreSuffix.Name = "IgnoreSuffix";
            this.IgnoreSuffix.ReadOnly = true;
            this.IgnoreSuffix.Visible = false;
            this.IgnoreSuffix.Width = 88;
            // 
            // IgnorePrefix
            // 
            this.IgnorePrefix.HeaderText = "IgnorePrefix";
            this.IgnorePrefix.Name = "IgnorePrefix";
            this.IgnorePrefix.ReadOnly = true;
            this.IgnorePrefix.Visible = false;
            this.IgnorePrefix.Width = 88;
            // 
            // Visible
            // 
            this.Visible.HeaderText = "Visible";
            this.Visible.Name = "Visible";
            this.Visible.Visible = false;
            this.Visible.Width = 62;
            // 
            // FramePosition
            // 
            this.FramePosition.HeaderText = "Frame";
            this.FramePosition.Name = "FramePosition";
            this.FramePosition.Width = 61;
            // 
            // OriginalControlID
            // 
            this.OriginalControlID.HeaderText = "OriginalControlID";
            this.OriginalControlID.Name = "OriginalControlID";
            this.OriginalControlID.Width = 111;
            // 
            // OriginalControlname
            // 
            this.OriginalControlname.HeaderText = "OriginalControlname";
            this.OriginalControlname.Name = "OriginalControlname";
            this.OriginalControlname.Width = 126;
            // 
            // IsAction
            // 
            this.IsAction.HeaderText = "IsAction";
            this.IsAction.Name = "IsAction";
            this.IsAction.Visible = false;
            this.IsAction.Width = 70;
            // 
            // Identifier
            // 
            this.Identifier.HeaderText = "Identifier";
            this.Identifier.Name = "Identifier";
            this.Identifier.Width = 72;
            // 
            // DeleteRow
            // 
            this.DeleteRow.HeaderText = "DeleteRow";
            this.DeleteRow.Name = "DeleteRow";
            this.DeleteRow.Visible = false;
            this.DeleteRow.Width = 85;
            // 
            // PageDataID
            // 
            this.PageDataID.HeaderText = "PageDataID";
            this.PageDataID.Name = "PageDataID";
            this.PageDataID.Visible = false;
            this.PageDataID.Width = 91;
            // 
            // PageControlID
            // 
            this.PageControlID.HeaderText = "PageControlID";
            this.PageControlID.Name = "PageControlID";
            this.PageControlID.Visible = false;
            this.PageControlID.Width = 101;
            // 
            // ControlName
            // 
            this.ControlName.HeaderText = "ControlName";
            this.ControlName.Name = "ControlName";
            this.ControlName.Visible = false;
            this.ControlName.Width = 93;
            // 
            // ControlID
            // 
            this.ControlID.HeaderText = "ControlID";
            this.ControlID.Name = "ControlID";
            this.ControlID.Visible = false;
            this.ControlID.Width = 76;
            // 
            // DataName
            // 
            this.DataName.HeaderText = "DataName";
            this.DataName.Name = "DataName";
            this.DataName.Width = 83;
            // 
            // OrdinalPosition
            // 
            this.OrdinalPosition.HeaderText = "OrdinalPosition";
            this.OrdinalPosition.Name = "OrdinalPosition";
            this.OrdinalPosition.Visible = false;
            this.OrdinalPosition.Width = 102;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.Width = 55;
            // 
            // Index
            // 
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.Width = 58;
            // 
            // OriginalData
            // 
            this.OriginalData.HeaderText = "OriginalData";
            this.OriginalData.Name = "OriginalData";
            this.OriginalData.Visible = false;
            this.OriginalData.Width = 90;
            // 
            // originalVerificationData
            // 
            this.originalVerificationData.HeaderText = "OriginalVerificationData";
            this.originalVerificationData.Name = "originalVerificationData";
            this.originalVerificationData.Visible = false;
            this.originalVerificationData.Width = 142;
            // 
            // PageDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 737);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.chkIdentifyControls);
            this.Controls.Add(this.btnAddVerification);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dnAddVerify);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gdvTestCaseList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTestCases);
            this.Controls.Add(this.txtWebPageId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "PageDetails";
            this.Text = "Web Page Details";
            this.Load += new System.EventHandler(this.PageDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PageDetails_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.upDownFlash)).EndInit();
            this.mnuGridOperations.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelectedControls)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvTestCaseList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownOrdinalPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.NumericUpDown upDownFlash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtWebPageId;
        private System.Windows.Forms.ContextMenuStrip mnuGridOperations;
        private System.Windows.Forms.ToolStripMenuItem toolStripInsert;
        private System.Windows.Forms.ToolStripMenuItem toolStripDelete;
        private System.Windows.Forms.TextBox txtTestCases;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gdvSelectedControls;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView gdvTestCaseList;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown upDownOrdinalPosition;
        private System.Windows.Forms.Button btnGenerateData;
        private System.Windows.Forms.CheckBox chkAllControls;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dnDynamicData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dnAddVerify;
        private System.Windows.Forms.Button btnAddVerification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn UniqueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebPageID;
        private System.Windows.Forms.CheckBox chkIdentifyControls;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserFriendlyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn IgnoreSuffix;
        private System.Windows.Forms.DataGridViewTextBoxColumn IgnorePrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visible;
        private System.Windows.Forms.DataGridViewTextBoxColumn FramePosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalControlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalControlname;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageDataID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageControlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdinalPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalVerificationData;
    }
}

