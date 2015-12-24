namespace WebAutomation
{
    partial class Scenarios
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSaveScenario = new System.Windows.Forms.Button();
            this.btnNewScenario = new System.Windows.Forms.Button();
            this.txtTestCase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dnActions = new System.Windows.Forms.ComboBox();
            this.txtWebPageID = new System.Windows.Forms.TextBox();
            this.txtScenarioID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchWebpage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchScenario = new System.Windows.Forms.TextBox();
            this.gdvWebPage = new System.Windows.Forms.DataGridView();
            this.gdvTestCases = new System.Windows.Forms.DataGridView();
            this.gdvScenarios = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvWebPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTestCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvScenarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1242, 483);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRun);
            this.tabPage1.Controls.Add(this.btnSaveScenario);
            this.tabPage1.Controls.Add(this.btnNewScenario);
            this.tabPage1.Controls.Add(this.txtTestCase);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dnActions);
            this.tabPage1.Controls.Add(this.txtWebPageID);
            this.tabPage1.Controls.Add(this.txtScenarioID);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtSearchWebpage);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtSearchScenario);
            this.tabPage1.Controls.Add(this.gdvWebPage);
            this.tabPage1.Controls.Add(this.gdvTestCases);
            this.tabPage1.Controls.Add(this.gdvScenarios);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1234, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Develop the Scenarios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(209, 402);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 37);
            this.btnRun.TabIndex = 21;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSaveScenario
            // 
            this.btnSaveScenario.Location = new System.Drawing.Point(748, 386);
            this.btnSaveScenario.Name = "btnSaveScenario";
            this.btnSaveScenario.Size = new System.Drawing.Size(75, 36);
            this.btnSaveScenario.TabIndex = 20;
            this.btnSaveScenario.Text = "Save";
            this.btnSaveScenario.UseVisualStyleBackColor = true;
            this.btnSaveScenario.Click += new System.EventHandler(this.btnSaveScenario_Click);
            // 
            // btnNewScenario
            // 
            this.btnNewScenario.Location = new System.Drawing.Point(114, 402);
            this.btnNewScenario.Name = "btnNewScenario";
            this.btnNewScenario.Size = new System.Drawing.Size(75, 38);
            this.btnNewScenario.TabIndex = 19;
            this.btnNewScenario.Text = "New";
            this.btnNewScenario.UseVisualStyleBackColor = true;
            this.btnNewScenario.Click += new System.EventHandler(this.btnNewScenario_Click);
            // 
            // txtTestCase
            // 
            this.txtTestCase.Enabled = false;
            this.txtTestCase.Location = new System.Drawing.Point(794, 16);
            this.txtTestCase.Name = "txtTestCase";
            this.txtTestCase.Size = new System.Drawing.Size(145, 20);
            this.txtTestCase.TabIndex = 18;
            this.txtTestCase.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(745, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Action";
            // 
            // dnActions
            // 
            this.dnActions.FormattingEnabled = true;
            this.dnActions.Items.AddRange(new object[] {
            "Add",
            "Verify"});
            this.dnActions.Location = new System.Drawing.Point(794, 334);
            this.dnActions.Name = "dnActions";
            this.dnActions.Size = new System.Drawing.Size(121, 21);
            this.dnActions.TabIndex = 7;
            // 
            // txtWebPageID
            // 
            this.txtWebPageID.Enabled = false;
            this.txtWebPageID.Location = new System.Drawing.Point(750, 16);
            this.txtWebPageID.Name = "txtWebPageID";
            this.txtWebPageID.Size = new System.Drawing.Size(38, 20);
            this.txtWebPageID.TabIndex = 4;
            this.txtWebPageID.TabStop = false;
            // 
            // txtScenarioID
            // 
            this.txtScenarioID.Enabled = false;
            this.txtScenarioID.Location = new System.Drawing.Point(706, 16);
            this.txtScenarioID.Name = "txtScenarioID";
            this.txtScenarioID.Size = new System.Drawing.Size(38, 20);
            this.txtScenarioID.TabIndex = 3;
            this.txtScenarioID.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(21, 402);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 38);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Filter";
            // 
            // txtSearchWebpage
            // 
            this.txtSearchWebpage.Location = new System.Drawing.Point(460, 16);
            this.txtSearchWebpage.Name = "txtSearchWebpage";
            this.txtSearchWebpage.Size = new System.Drawing.Size(240, 20);
            this.txtSearchWebpage.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filter";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSearchScenario
            // 
            this.txtSearchScenario.Location = new System.Drawing.Point(71, 13);
            this.txtSearchScenario.Name = "txtSearchScenario";
            this.txtSearchScenario.Size = new System.Drawing.Size(240, 20);
            this.txtSearchScenario.TabIndex = 1;
            this.txtSearchScenario.TextChanged += new System.EventHandler(this.txtSearchScenario_TextChanged);
            // 
            // gdvWebPage
            // 
            this.gdvWebPage.AllowUserToAddRows = false;
            this.gdvWebPage.AllowUserToDeleteRows = false;
            this.gdvWebPage.AllowUserToResizeColumns = false;
            this.gdvWebPage.AllowUserToResizeRows = false;
            this.gdvWebPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvWebPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvWebPage.Location = new System.Drawing.Point(418, 42);
            this.gdvWebPage.Name = "gdvWebPage";
            this.gdvWebPage.RowHeadersVisible = false;
            this.gdvWebPage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvWebPage.Size = new System.Drawing.Size(809, 269);
            this.gdvWebPage.TabIndex = 6;
            this.gdvWebPage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvWebPage_CellClick);
            this.gdvWebPage.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvWebPage_RowEnter);
            // 
            // gdvTestCases
            // 
            this.gdvTestCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvTestCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvTestCases.Location = new System.Drawing.Point(418, 317);
            this.gdvTestCases.Name = "gdvTestCases";
            this.gdvTestCases.RowHeadersVisible = false;
            this.gdvTestCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvTestCases.Size = new System.Drawing.Size(321, 105);
            this.gdvTestCases.TabIndex = 7;
            this.gdvTestCases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvTestCases_CellClick);
            this.gdvTestCases.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvTestCases_RowEnter);
            // 
            // gdvScenarios
            // 
            this.gdvScenarios.AllowUserToAddRows = false;
            this.gdvScenarios.AllowUserToDeleteRows = false;
            this.gdvScenarios.AllowUserToResizeColumns = false;
            this.gdvScenarios.AllowUserToResizeRows = false;
            this.gdvScenarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvScenarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvScenarios.Location = new System.Drawing.Point(21, 42);
            this.gdvScenarios.MultiSelect = false;
            this.gdvScenarios.Name = "gdvScenarios";
            this.gdvScenarios.RowHeadersVisible = false;
            this.gdvScenarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvScenarios.Size = new System.Drawing.Size(327, 354);
            this.gdvScenarios.TabIndex = 5;
            this.gdvScenarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvScenarios_CellClick);
            this.gdvScenarios.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvScenarios_RowEnter);
            // 
            // Scenarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 507);
            this.Controls.Add(this.tabControl1);
            this.Name = "Scenarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scenarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Scenarios_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvWebPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTestCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvScenarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchWebpage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchScenario;
        private System.Windows.Forms.DataGridView gdvWebPage;
        private System.Windows.Forms.DataGridView gdvScenarios;
        private System.Windows.Forms.TextBox txtWebPageID;
        private System.Windows.Forms.TextBox txtScenarioID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dnActions;
        private System.Windows.Forms.DataGridView gdvTestCases;
        private System.Windows.Forms.TextBox txtTestCase;
        private System.Windows.Forms.Button btnNewScenario;
        private System.Windows.Forms.Button btnSaveScenario;
        private System.Windows.Forms.Button btnRun;

    }
}