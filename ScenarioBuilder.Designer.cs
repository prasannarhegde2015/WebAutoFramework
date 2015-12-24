namespace WebAutomation
{
    partial class ScenarioBuilder
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
            this.Scenarios = new System.Windows.Forms.TabPage();
            this.lblCurrentParentNode = new System.Windows.Forms.Label();
            this.nUpDownPosition = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAllScenarios = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dnWebpages = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gdvSelectedControls = new System.Windows.Forms.DataGridView();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gdvSelectedScenarios = new System.Windows.Forms.DataGridView();
            this.Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UniqueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WebPageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gdvSteps = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TstCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unqName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewScenario = new System.Windows.Forms.Button();
            this.tvwScenarios = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showSteps = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStep = new System.Windows.Forms.ToolStripMenuItem();
            this.run = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlText = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Scenarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelectedControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelectedScenarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSteps)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scenarios
            // 
            this.Scenarios.Controls.Add(this.lblCurrentParentNode);
            this.Scenarios.Controls.Add(this.nUpDownPosition);
            this.Scenarios.Controls.Add(this.label3);
            this.Scenarios.Controls.Add(this.chkAllScenarios);
            this.Scenarios.Controls.Add(this.btnFilter);
            this.Scenarios.Controls.Add(this.btnRefresh);
            this.Scenarios.Controls.Add(this.dnWebpages);
            this.Scenarios.Controls.Add(this.label1);
            this.Scenarios.Controls.Add(this.gdvSelectedControls);
            this.Scenarios.Controls.Add(this.btnRunAll);
            this.Scenarios.Controls.Add(this.label2);
            this.Scenarios.Controls.Add(this.gdvSelectedScenarios);
            this.Scenarios.Controls.Add(this.btnAdd);
            this.Scenarios.Controls.Add(this.gdvSteps);
            this.Scenarios.Controls.Add(this.btnNewScenario);
            this.Scenarios.Controls.Add(this.tvwScenarios);
            this.Scenarios.Location = new System.Drawing.Point(4, 22);
            this.Scenarios.Name = "Scenarios";
            this.Scenarios.Padding = new System.Windows.Forms.Padding(3);
            this.Scenarios.Size = new System.Drawing.Size(1135, 545);
            this.Scenarios.TabIndex = 0;
            this.Scenarios.Text = "Scenarios";
            this.Scenarios.UseVisualStyleBackColor = true;
            // 
            // lblCurrentParentNode
            // 
            this.lblCurrentParentNode.AutoSize = true;
            this.lblCurrentParentNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentParentNode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCurrentParentNode.Location = new System.Drawing.Point(322, 28);
            this.lblCurrentParentNode.Name = "lblCurrentParentNode";
            this.lblCurrentParentNode.Size = new System.Drawing.Size(86, 13);
            this.lblCurrentParentNode.TabIndex = 25;
            this.lblCurrentParentNode.Text = "Current Node:";
            // 
            // nUpDownPosition
            // 
            this.nUpDownPosition.Location = new System.Drawing.Point(250, 43);
            this.nUpDownPosition.Name = "nUpDownPosition";
            this.nUpDownPosition.Size = new System.Drawing.Size(43, 20);
            this.nUpDownPosition.TabIndex = 24;
            this.nUpDownPosition.ValueChanged += new System.EventHandler(this.nUpDownPosition_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Insert At";
            // 
            // chkAllScenarios
            // 
            this.chkAllScenarios.AutoSize = true;
            this.chkAllScenarios.Location = new System.Drawing.Point(211, 19);
            this.chkAllScenarios.Name = "chkAllScenarios";
            this.chkAllScenarios.Size = new System.Drawing.Size(93, 17);
            this.chkAllScenarios.TabIndex = 22;
            this.chkAllScenarios.Text = "All Scenarios?";
            this.chkAllScenarios.UseVisualStyleBackColor = true;
            this.chkAllScenarios.CheckedChanged += new System.EventHandler(this.chkAllScenarios_CheckedChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.btnFilter.Location = new System.Drawing.Point(888, 13);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 36);
            this.btnFilter.TabIndex = 21;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(969, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 36);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dnWebpages
            // 
            this.dnWebpages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnWebpages.FormattingEnabled = true;
            this.dnWebpages.Location = new System.Drawing.Point(628, 21);
            this.dnWebpages.Name = "dnWebpages";
            this.dnWebpages.Size = new System.Drawing.Size(254, 21);
            this.dnWebpages.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Web Page";
            // 
            // gdvSelectedControls
            // 
            this.gdvSelectedControls.AllowDrop = true;
            this.gdvSelectedControls.AllowUserToAddRows = false;
            this.gdvSelectedControls.AllowUserToDeleteRows = false;
            this.gdvSelectedControls.AllowUserToResizeColumns = false;
            this.gdvSelectedControls.AllowUserToResizeRows = false;
            this.gdvSelectedControls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gdvSelectedControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvSelectedControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ControlType,
            this.controlValue,
            this.StartFrom,
            this.EndOn,
            this.ControlText,
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
            this.gdvSelectedControls.Location = new System.Drawing.Point(313, 70);
            this.gdvSelectedControls.Name = "gdvSelectedControls";
            this.gdvSelectedControls.RowHeadersVisible = false;
            this.gdvSelectedControls.Size = new System.Drawing.Size(792, 468);
            this.gdvSelectedControls.TabIndex = 16;
            this.gdvSelectedControls.Visible = false;
            this.gdvSelectedControls.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSelectedControls_CellContentClick);
            this.gdvSelectedControls.DoubleClick += new System.EventHandler(this.gdvSelectedControls_DoubleClick);
            // 
            // btnRunAll
            // 
            this.btnRunAll.Location = new System.Drawing.Point(87, 6);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(75, 49);
            this.btnRunAll.TabIndex = 15;
            this.btnRunAll.Text = "Run All";
            this.btnRunAll.UseVisualStyleBackColor = true;
            this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Position";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gdvSelectedScenarios
            // 
            this.gdvSelectedScenarios.AllowUserToAddRows = false;
            this.gdvSelectedScenarios.AllowUserToDeleteRows = false;
            this.gdvSelectedScenarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvSelectedScenarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sequence,
            this.UniqueName,
            this.TestCase,
            this.WebPageID});
            this.gdvSelectedScenarios.Location = new System.Drawing.Point(915, 29);
            this.gdvSelectedScenarios.Name = "gdvSelectedScenarios";
            this.gdvSelectedScenarios.RowHeadersVisible = false;
            this.gdvSelectedScenarios.Size = new System.Drawing.Size(29, 23);
            this.gdvSelectedScenarios.TabIndex = 9;
            this.gdvSelectedScenarios.Visible = false;
            this.gdvSelectedScenarios.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSelectedScenarios_RowEnter);
            this.gdvSelectedScenarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvSelectedScenarios_KeyDown);
            this.gdvSelectedScenarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gdvSelectedScenarios_KeyPress);
            // 
            // Sequence
            // 
            this.Sequence.HeaderText = "Sequence";
            this.Sequence.Name = "Sequence";
            // 
            // UniqueName
            // 
            this.UniqueName.HeaderText = "UniqueName";
            this.UniqueName.Name = "UniqueName";
            // 
            // TestCase
            // 
            this.TestCase.HeaderText = "TestCase";
            this.TestCase.Name = "TestCase";
            // 
            // WebPageID
            // 
            this.WebPageID.HeaderText = "WebPageID";
            this.WebPageID.Name = "WebPageID";
            this.WebPageID.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(950, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 22);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Save steps";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gdvSteps
            // 
            this.gdvSteps.AllowUserToAddRows = false;
            this.gdvSteps.AllowUserToDeleteRows = false;
            this.gdvSteps.AllowUserToResizeColumns = false;
            this.gdvSteps.AllowUserToResizeRows = false;
            this.gdvSteps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.TstCase,
            this.unqName});
            this.gdvSteps.Location = new System.Drawing.Point(313, 57);
            this.gdvSteps.Name = "gdvSteps";
            this.gdvSteps.RowHeadersVisible = false;
            this.gdvSteps.Size = new System.Drawing.Size(806, 504);
            this.gdvSteps.TabIndex = 2;
            this.gdvSteps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSteps_CellClick);
            this.gdvSteps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSteps_CellContentClick);
            this.gdvSteps.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvSteps_CellDoubleClick);
            this.gdvSteps.DragLeave += new System.EventHandler(this.gdvSteps_DragLeave);
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // TstCase
            // 
            this.TstCase.HeaderText = "TestCase";
            this.TstCase.Name = "TstCase";
            // 
            // unqName
            // 
            this.unqName.HeaderText = "UniqueName";
            this.unqName.Name = "unqName";
            // 
            // btnNewScenario
            // 
            this.btnNewScenario.Location = new System.Drawing.Point(6, 6);
            this.btnNewScenario.Name = "btnNewScenario";
            this.btnNewScenario.Size = new System.Drawing.Size(75, 49);
            this.btnNewScenario.TabIndex = 1;
            this.btnNewScenario.Text = "New";
            this.btnNewScenario.UseVisualStyleBackColor = true;
            this.btnNewScenario.Click += new System.EventHandler(this.btnNewScenario_Click);
            // 
            // tvwScenarios
            // 
            this.tvwScenarios.AllowDrop = true;
            this.tvwScenarios.Location = new System.Drawing.Point(6, 70);
            this.tvwScenarios.Name = "tvwScenarios";
            this.tvwScenarios.Size = new System.Drawing.Size(287, 455);
            this.tvwScenarios.TabIndex = 0;
            this.tvwScenarios.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwScenarios_NodeMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Scenarios);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1143, 571);
            this.tabControl1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSteps,
            this.showDetailsToolStripMenuItem,
            this.deleteStep,
            this.run});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 92);
            // 
            // showSteps
            // 
            this.showSteps.Name = "showSteps";
            this.showSteps.Size = new System.Drawing.Size(170, 22);
            this.showSteps.Text = "Show Steps";
            this.showSteps.Click += new System.EventHandler(this.mnuItemSteps_Click);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.showDetailsToolStripMenuItem.Text = "Show Page Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // deleteStep
            // 
            this.deleteStep.Name = "deleteStep";
            this.deleteStep.Size = new System.Drawing.Size(170, 22);
            this.deleteStep.Text = "Delete Step";
            this.deleteStep.Click += new System.EventHandler(this.deleteStepToolStripMenuItem_Click);
            // 
            // run
            // 
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(170, 22);
            this.run.Text = "Run";
            this.run.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // ControlType
            // 
            this.ControlType.HeaderText = "ControlType";
            this.ControlType.Name = "ControlType";
            this.ControlType.Width = 89;
            // 
            // controlValue
            // 
            this.controlValue.HeaderText = "controlValue";
            this.controlValue.Name = "controlValue";
            this.controlValue.Width = 91;
            // 
            // StartFrom
            // 
            this.StartFrom.HeaderText = "From";
            this.StartFrom.Name = "StartFrom";
            this.StartFrom.Width = 55;
            // 
            // EndOn
            // 
            this.EndOn.HeaderText = "End";
            this.EndOn.Name = "EndOn";
            this.EndOn.Width = 51;
            // 
            // ControlText
            // 
            this.ControlText.HeaderText = "ControlText";
            this.ControlText.Name = "ControlText";
            this.ControlText.Visible = false;
            this.ControlText.Width = 86;
            // 
            // FramePosition
            // 
            this.FramePosition.HeaderText = "Frame";
            this.FramePosition.Name = "FramePosition";
            this.FramePosition.Visible = false;
            this.FramePosition.Width = 61;
            // 
            // OriginalControlID
            // 
            this.OriginalControlID.HeaderText = "OriginalControlID";
            this.OriginalControlID.Name = "OriginalControlID";
            this.OriginalControlID.Visible = false;
            this.OriginalControlID.Width = 111;
            // 
            // OriginalControlname
            // 
            this.OriginalControlname.HeaderText = "OriginalControlname";
            this.OriginalControlname.Name = "OriginalControlname";
            this.OriginalControlname.Visible = false;
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
            this.OriginalData.Width = 90;
            // 
            // originalVerificationData
            // 
            this.originalVerificationData.HeaderText = "OriginalVerificationData";
            this.originalVerificationData.Name = "originalVerificationData";
            this.originalVerificationData.Width = 142;
            // 
            // ScenarioBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 574);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ScenarioBuilder";
            this.Text = "ScenarioBuilder";
            this.Load += new System.EventHandler(this.ScenarioBuilder_Load);
            this.Scenarios.ResumeLayout(false);
            this.Scenarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelectedControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelectedScenarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSteps)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Scenarios;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TreeView tvwScenarios;
        private System.Windows.Forms.Button btnNewScenario;
        private System.Windows.Forms.DataGridView gdvSteps;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showSteps;
        private System.Windows.Forms.DataGridView gdvSelectedScenarios;
        private System.Windows.Forms.ToolStripMenuItem run;
        private System.Windows.Forms.ToolStripMenuItem deleteStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn UniqueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebPageID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn TstCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn unqName;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.DataGridView gdvSelectedControls;
        private System.Windows.Forms.ComboBox dnWebpages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox chkAllScenarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUpDownPosition;
        private System.Windows.Forms.Label lblCurrentParentNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlType;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlText;
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