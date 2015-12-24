namespace WebAutomation
{
    partial class Search_Controls
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dnSearchBy = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGetTargetFrame = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTargetControl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPageFrame = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(137, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(227, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Webpage Title";
            // 
            // dnSearchBy
            // 
            this.dnSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnSearchBy.FormattingEnabled = true;
            this.dnSearchBy.Items.AddRange(new object[] {
            "ID",
            "Name",
            "Text"});
            this.dnSearchBy.Location = new System.Drawing.Point(137, 86);
            this.dnSearchBy.Name = "dnSearchBy";
            this.dnSearchBy.Size = new System.Drawing.Size(121, 21);
            this.dnSearchBy.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(24, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Search By";
            // 
            // btnGetTargetFrame
            // 
            this.btnGetTargetFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetTargetFrame.Location = new System.Drawing.Point(23, 180);
            this.btnGetTargetFrame.Name = "btnGetTargetFrame";
            this.btnGetTargetFrame.Size = new System.Drawing.Size(75, 46);
            this.btnGetTargetFrame.TabIndex = 4;
            this.btnGetTargetFrame.Text = "Search";
            this.btnGetTargetFrame.UseVisualStyleBackColor = true;
            this.btnGetTargetFrame.Click += new System.EventHandler(this.btnGetTargetFrame_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(20, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 69;
            this.label7.Text = "Target Control";
            // 
            // txtTargetControl
            // 
            this.txtTargetControl.Location = new System.Drawing.Point(137, 53);
            this.txtTargetControl.Name = "txtTargetControl";
            this.txtTargetControl.Size = new System.Drawing.Size(279, 20);
            this.txtTargetControl.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(24, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Page Frame";
            // 
            // txtPageFrame
            // 
            this.txtPageFrame.Location = new System.Drawing.Point(137, 122);
            this.txtPageFrame.MaxLength = 2;
            this.txtPageFrame.Name = "txtPageFrame";
            this.txtPageFrame.ReadOnly = true;
            this.txtPageFrame.Size = new System.Drawing.Size(31, 20);
            this.txtPageFrame.TabIndex = 3;
            // 
            // Search_Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 233);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dnSearchBy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGetTargetFrame);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTargetControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPageFrame);
            this.Name = "Search_Controls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search_Controls";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dnSearchBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGetTargetFrame;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTargetControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPageFrame;

    }
}