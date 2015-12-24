namespace WebAutomation
{
    partial class DynamicValues
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dnFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nupLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dnType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gdvDynamicParameters = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvDynamicParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dnFormat);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nupLength);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dnType);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 217);
            this.panel1.TabIndex = 6;
            // 
            // dnFormat
            // 
            this.dnFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnFormat.FormattingEnabled = true;
            this.dnFormat.Items.AddRange(new object[] {
            "MM/DD/YYYY",
            "DD/MM/YYYY"});
            this.dnFormat.Location = new System.Drawing.Point(83, 133);
            this.dnFormat.Name = "dnFormat";
            this.dnFormat.Size = new System.Drawing.Size(121, 21);
            this.dnFormat.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Format";
            // 
            // nupLength
            // 
            this.nupLength.Location = new System.Drawing.Point(83, 90);
            this.nupLength.Name = "nupLength";
            this.nupLength.Size = new System.Drawing.Size(71, 20);
            this.nupLength.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Length";
            // 
            // dnType
            // 
            this.dnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnType.FormattingEnabled = true;
            this.dnType.Items.AddRange(new object[] {
            "CurrentDate",
            "GUID",
            "String",
            "UniqueNumber"});
            this.dnType.Location = new System.Drawing.Point(83, 12);
            this.dnType.Name = "dnType";
            this.dnType.Size = new System.Drawing.Size(121, 21);
            this.dnType.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 51);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(273, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // gdvDynamicParameters
            // 
            this.gdvDynamicParameters.AllowUserToAddRows = false;
            this.gdvDynamicParameters.AllowUserToDeleteRows = false;
            this.gdvDynamicParameters.AllowUserToOrderColumns = true;
            this.gdvDynamicParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvDynamicParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvDynamicParameters.Location = new System.Drawing.Point(12, 257);
            this.gdvDynamicParameters.Name = "gdvDynamicParameters";
            this.gdvDynamicParameters.RowHeadersVisible = false;
            this.gdvDynamicParameters.Size = new System.Drawing.Size(419, 150);
            this.gdvDynamicParameters.TabIndex = 7;
            // 
            // DynamicValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 442);
            this.Controls.Add(this.gdvDynamicParameters);
            this.Controls.Add(this.panel1);
            this.Name = "DynamicValues";
            this.Text = "Dynamic Parameters";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvDynamicParameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dnType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dnFormat;
        private System.Windows.Forms.DataGridView gdvDynamicParameters;
    }
}