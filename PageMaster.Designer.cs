namespace WebAutomation
{
    partial class PageMaster
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUniqueName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gdvWebPages = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uniquename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Absolutepath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearchControl = new System.Windows.Forms.Button();
            this.chkLoadWebPage = new System.Windows.Forms.CheckBox();
            this.txtAbsoluteURL = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnDynamicParameter = new System.Windows.Forms.Button();
            this.lblLoading = new System.Windows.Forms.Label();
            this.btnScenarios = new System.Windows.Forms.Button();
            this.btnExistingPages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvWebPages)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(112, 36);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(548, 20);
            this.txtURL.TabIndex = 26;
            this.txtURL.Text = "http://clabdevapp1:105/sites/ProjectCentral/SitePages/CreateProject.aspx";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(112, 78);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(395, 20);
            this.txtTitle.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "URL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Title";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(112, 142);
            this.txtNotes.MaxLength = 100;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(395, 20);
            this.txtNotes.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Notes";
            // 
            // txtUniqueName
            // 
            this.txtUniqueName.Location = new System.Drawing.Point(112, 112);
            this.txtUniqueName.MaxLength = 50;
            this.txtUniqueName.Name = "txtUniqueName";
            this.txtUniqueName.Size = new System.Drawing.Size(395, 20);
            this.txtUniqueName.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Unique Name";
            // 
            // gdvWebPages
            // 
            this.gdvWebPages.AllowUserToAddRows = false;
            this.gdvWebPages.AllowUserToDeleteRows = false;
            this.gdvWebPages.AllowUserToResizeColumns = false;
            this.gdvWebPages.AllowUserToResizeRows = false;
            this.gdvWebPages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gdvWebPages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvWebPages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Uniquename,
            this.Title,
            this.Frame,
            this.URL,
            this.Absolutepath});
            this.gdvWebPages.Location = new System.Drawing.Point(21, 274);
            this.gdvWebPages.MultiSelect = false;
            this.gdvWebPages.Name = "gdvWebPages";
            this.gdvWebPages.ReadOnly = true;
            this.gdvWebPages.RowHeadersVisible = false;
            this.gdvWebPages.Size = new System.Drawing.Size(861, 287);
            this.gdvWebPages.TabIndex = 37;
            this.gdvWebPages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvWebPages_CellClick);
            this.gdvWebPages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvWebPages_CellContentClick);
            this.gdvWebPages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvWebPages_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 24;
            // 
            // Uniquename
            // 
            this.Uniquename.HeaderText = "Uniquename";
            this.Uniquename.Name = "Uniquename";
            this.Uniquename.ReadOnly = true;
            this.Uniquename.Width = 92;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 52;
            // 
            // Frame
            // 
            this.Frame.HeaderText = "Frame";
            this.Frame.Name = "Frame";
            this.Frame.ReadOnly = true;
            this.Frame.Width = 61;
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.ReadOnly = true;
            this.URL.Width = 54;
            // 
            // Absolutepath
            // 
            this.Absolutepath.HeaderText = "Absolutepath";
            this.Absolutepath.Name = "Absolutepath";
            this.Absolutepath.ReadOnly = true;
            this.Absolutepath.Width = 94;
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(21, 222);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 46);
            this.btnGet.TabIndex = 38;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(108, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 46);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSearchControl);
            this.groupBox1.Controls.Add(this.chkLoadWebPage);
            this.groupBox1.Controls.Add(this.txtAbsoluteURL);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.btnDynamicParameter);
            this.groupBox1.Controls.Add(this.lblLoading);
            this.groupBox1.Controls.Add(this.btnScenarios);
            this.groupBox1.Controls.Add(this.btnExistingPages);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnGet);
            this.groupBox1.Controls.Add(this.gdvWebPages);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUniqueName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(195, 222);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 46);
            this.btnDelete.TabIndex = 61;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearchControl
            // 
            this.btnSearchControl.Location = new System.Drawing.Point(888, 231);
            this.btnSearchControl.Name = "btnSearchControl";
            this.btnSearchControl.Size = new System.Drawing.Size(75, 63);
            this.btnSearchControl.TabIndex = 60;
            this.btnSearchControl.Text = "Search Control";
            this.btnSearchControl.UseVisualStyleBackColor = true;
            this.btnSearchControl.Click += new System.EventHandler(this.btnSearchControl_Click);
            // 
            // chkLoadWebPage
            // 
            this.chkLoadWebPage.AutoSize = true;
            this.chkLoadWebPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLoadWebPage.Location = new System.Drawing.Point(305, 237);
            this.chkLoadWebPage.Name = "chkLoadWebPage";
            this.chkLoadWebPage.Size = new System.Drawing.Size(146, 21);
            this.chkLoadWebPage.TabIndex = 59;
            this.chkLoadWebPage.Text = "Load WebPage?";
            this.chkLoadWebPage.UseVisualStyleBackColor = true;
            // 
            // txtAbsoluteURL
            // 
            this.txtAbsoluteURL.Location = new System.Drawing.Point(112, 56);
            this.txtAbsoluteURL.Name = "txtAbsoluteURL";
            this.txtAbsoluteURL.ReadOnly = true;
            this.txtAbsoluteURL.Size = new System.Drawing.Size(395, 20);
            this.txtAbsoluteURL.TabIndex = 58;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(232, 184);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 57;
            this.txtID.Visible = false;
            // 
            // btnDynamicParameter
            // 
            this.btnDynamicParameter.Location = new System.Drawing.Point(888, 159);
            this.btnDynamicParameter.Name = "btnDynamicParameter";
            this.btnDynamicParameter.Size = new System.Drawing.Size(75, 63);
            this.btnDynamicParameter.TabIndex = 47;
            this.btnDynamicParameter.Text = "Dynamic Parameters";
            this.btnDynamicParameter.UseVisualStyleBackColor = true;
            this.btnDynamicParameter.Click += new System.EventHandler(this.btnDynamicParameter_Click);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(360, 181);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(262, 31);
            this.lblLoading.TabIndex = 46;
            this.lblLoading.Text = "Loading...................";
            this.lblLoading.Visible = false;
            // 
            // btnScenarios
            // 
            this.btnScenarios.Location = new System.Drawing.Point(888, 89);
            this.btnScenarios.Name = "btnScenarios";
            this.btnScenarios.Size = new System.Drawing.Size(75, 61);
            this.btnScenarios.TabIndex = 45;
            this.btnScenarios.Text = "Scenarios";
            this.btnScenarios.UseVisualStyleBackColor = true;
            this.btnScenarios.Click += new System.EventHandler(this.btnScenarios_Click);
            // 
            // btnExistingPages
            // 
            this.btnExistingPages.Location = new System.Drawing.Point(888, 19);
            this.btnExistingPages.Name = "btnExistingPages";
            this.btnExistingPages.Size = new System.Drawing.Size(75, 61);
            this.btnExistingPages.TabIndex = 40;
            this.btnExistingPages.Text = "Get existing Pages";
            this.btnExistingPages.UseVisualStyleBackColor = true;
            this.btnExistingPages.Click += new System.EventHandler(this.btnExistingPages_Click);
            // 
            // PageMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 574);
            this.Controls.Add(this.groupBox1);
            this.Name = "PageMaster";
            this.Text = "PageMaster";
            this.Load += new System.EventHandler(this.PageMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvWebPages)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUniqueName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gdvWebPages;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExistingPages;
        private System.Windows.Forms.Button btnScenarios;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Button btnDynamicParameter;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAbsoluteURL;
        private System.Windows.Forms.CheckBox chkLoadWebPage;
        private System.Windows.Forms.Button btnSearchControl;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uniquename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frame;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Absolutepath;



    }
}