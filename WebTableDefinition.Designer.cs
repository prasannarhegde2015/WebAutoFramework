namespace WebAutomation
{
    partial class WebTableDefinition
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkAllRows = new System.Windows.Forms.CheckBox();
            this.txtTestCase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstColumns = new System.Windows.Forms.CheckedListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gdvWebtable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.txtColumnCount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvWebtable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 506);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.chkAll);
            this.tabPage1.Controls.Add(this.chkAllRows);
            this.tabPage1.Controls.Add(this.txtTestCase);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lstColumns);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.gdvWebtable);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtRowCount);
            this.tabPage1.Controls.Add(this.txtColumnCount);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(974, 480);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Webtable details";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(444, 7);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(80, 17);
            this.chkAll.TabIndex = 14;
            this.chkAll.Text = "All Columns";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkAllRows
            // 
            this.chkAllRows.AutoSize = true;
            this.chkAllRows.Location = new System.Drawing.Point(9, 65);
            this.chkAllRows.Name = "chkAllRows";
            this.chkAllRows.Size = new System.Drawing.Size(68, 17);
            this.chkAllRows.TabIndex = 13;
            this.chkAllRows.Text = "All rows?";
            this.chkAllRows.UseVisualStyleBackColor = true;
            this.chkAllRows.CheckedChanged += new System.EventHandler(this.chkAllRows_CheckedChanged);
            // 
            // txtTestCase
            // 
            this.txtTestCase.Enabled = false;
            this.txtTestCase.Location = new System.Drawing.Point(280, 37);
            this.txtTestCase.Name = "txtTestCase";
            this.txtTestCase.Size = new System.Drawing.Size(154, 20);
            this.txtTestCase.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(210, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Test Case";
            // 
            // lstColumns
            // 
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.Location = new System.Drawing.Point(526, 7);
            this.lstColumns.MultiColumn = true;
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(448, 94);
            this.lstColumns.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 20);
            this.txtName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name:";
            // 
            // gdvWebtable
            // 
            this.gdvWebtable.AllowUserToAddRows = false;
            this.gdvWebtable.AllowUserToDeleteRows = false;
            this.gdvWebtable.AllowUserToResizeColumns = false;
            this.gdvWebtable.AllowUserToResizeRows = false;
            this.gdvWebtable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvWebtable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvWebtable.Location = new System.Drawing.Point(9, 106);
            this.gdvWebtable.Name = "gdvWebtable";
            this.gdvWebtable.ReadOnly = true;
            this.gdvWebtable.RowHeadersVisible = false;
            this.gdvWebtable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvWebtable.Size = new System.Drawing.Size(918, 333);
            this.gdvWebtable.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rows";
            // 
            // txtRowCount
            // 
            this.txtRowCount.Location = new System.Drawing.Point(50, 3);
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(94, 20);
            this.txtRowCount.TabIndex = 4;
            // 
            // txtColumnCount
            // 
            this.txtColumnCount.Location = new System.Drawing.Point(210, 3);
            this.txtColumnCount.Name = "txtColumnCount";
            this.txtColumnCount.Size = new System.Drawing.Size(94, 20);
            this.txtColumnCount.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(88, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // WebTableDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 530);
            this.Controls.Add(this.tabControl1);
            this.Name = "WebTableDefinition";
            this.Text = "Design Webtable";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvWebtable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtColumnCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.DataGridView gdvWebtable;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox lstColumns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTestCase;
        private System.Windows.Forms.CheckBox chkAllRows;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnClose;

    }
}