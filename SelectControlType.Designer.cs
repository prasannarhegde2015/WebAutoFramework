namespace WebAutomation
{
    partial class SelectControlType
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
            this.dnControls = new System.Windows.Forms.ComboBox();
            this.radioControls = new System.Windows.Forms.RadioButton();
            this.radioActions = new System.Windows.Forms.RadioButton();
            this.grpBoxControls = new System.Windows.Forms.GroupBox();
            this.dnVisible = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIgnoreSuffix = new System.Windows.Forms.TextBox();
            this.txtIgnorePrefix = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Identifier = new System.Windows.Forms.Label();
            this.dnSearchBy = new System.Windows.Forms.ComboBox();
            this.txtControlValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioWindowsLogon = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageControls = new System.Windows.Forms.TabPage();
            this.tabPageLogon = new System.Windows.Forms.TabPage();
            this.grpWindowsLogon = new System.Windows.Forms.GroupBox();
            this.btnWindowsLogonOk = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageActions = new System.Windows.Forms.TabPage();
            this.grpBoxActions = new System.Windows.Forms.GroupBox();
            this.nupDownIndex = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnActionsOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.tabPageJavaScriptButtons = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnJavaScriptsOk = new System.Windows.Forms.Button();
            this.txtWindowTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtButtonName = new System.Windows.Forms.TextBox();
            this.radioJavaScript = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.grpBoxControls.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageControls.SuspendLayout();
            this.tabPageLogon.SuspendLayout();
            this.grpWindowsLogon.SuspendLayout();
            this.tabPageActions.SuspendLayout();
            this.grpBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDownIndex)).BeginInit();
            this.tabPageJavaScriptButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dnControls
            // 
            this.dnControls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnControls.FormattingEnabled = true;
            this.dnControls.Items.AddRange(new object[] {
            "SelectList",
            "Text"});
            this.dnControls.Location = new System.Drawing.Point(76, 43);
            this.dnControls.Name = "dnControls";
            this.dnControls.Size = new System.Drawing.Size(179, 21);
            this.dnControls.Sorted = true;
            this.dnControls.TabIndex = 0;
            // 
            // radioControls
            // 
            this.radioControls.AutoSize = true;
            this.radioControls.Location = new System.Drawing.Point(13, 13);
            this.radioControls.Name = "radioControls";
            this.radioControls.Size = new System.Drawing.Size(63, 17);
            this.radioControls.TabIndex = 3;
            this.radioControls.TabStop = true;
            this.radioControls.Text = "Controls";
            this.radioControls.UseVisualStyleBackColor = true;
            this.radioControls.CheckedChanged += new System.EventHandler(this.radioControls_CheckedChanged);
            this.radioControls.Click += new System.EventHandler(this.radioControls_Click);
            // 
            // radioActions
            // 
            this.radioActions.AutoSize = true;
            this.radioActions.Location = new System.Drawing.Point(82, 13);
            this.radioActions.Name = "radioActions";
            this.radioActions.Size = new System.Drawing.Size(60, 17);
            this.radioActions.TabIndex = 4;
            this.radioActions.TabStop = true;
            this.radioActions.Text = "Actions";
            this.radioActions.UseVisualStyleBackColor = true;
            this.radioActions.CheckedChanged += new System.EventHandler(this.radioActions_CheckedChanged);
            this.radioActions.Click += new System.EventHandler(this.radioActions_Click);
            // 
            // grpBoxControls
            // 
            this.grpBoxControls.Controls.Add(this.label1);
            this.grpBoxControls.Controls.Add(this.txtData);
            this.grpBoxControls.Controls.Add(this.dnVisible);
            this.grpBoxControls.Controls.Add(this.label12);
            this.grpBoxControls.Controls.Add(this.txtIgnoreSuffix);
            this.grpBoxControls.Controls.Add(this.txtIgnorePrefix);
            this.grpBoxControls.Controls.Add(this.label11);
            this.grpBoxControls.Controls.Add(this.label10);
            this.grpBoxControls.Controls.Add(this.btnOk);
            this.grpBoxControls.Controls.Add(this.label2);
            this.grpBoxControls.Controls.Add(this.Identifier);
            this.grpBoxControls.Controls.Add(this.dnSearchBy);
            this.grpBoxControls.Controls.Add(this.txtControlValue);
            this.grpBoxControls.Location = new System.Drawing.Point(6, 6);
            this.grpBoxControls.Name = "grpBoxControls";
            this.grpBoxControls.Size = new System.Drawing.Size(513, 311);
            this.grpBoxControls.TabIndex = 7;
            this.grpBoxControls.TabStop = false;
            // 
            // dnVisible
            // 
            this.dnVisible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnVisible.FormattingEnabled = true;
            this.dnVisible.ItemHeight = 13;
            this.dnVisible.Items.AddRange(new object[] {
            "NA",
            "False",
            "True"});
            this.dnVisible.Location = new System.Drawing.Point(79, 211);
            this.dnVisible.Name = "dnVisible";
            this.dnVisible.Size = new System.Drawing.Size(121, 21);
            this.dnVisible.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Is Visible ";
            // 
            // txtIgnoreSuffix
            // 
            this.txtIgnoreSuffix.Location = new System.Drawing.Point(80, 170);
            this.txtIgnoreSuffix.MaxLength = 500;
            this.txtIgnoreSuffix.Name = "txtIgnoreSuffix";
            this.txtIgnoreSuffix.Size = new System.Drawing.Size(387, 20);
            this.txtIgnoreSuffix.TabIndex = 11;
            // 
            // txtIgnorePrefix
            // 
            this.txtIgnorePrefix.Location = new System.Drawing.Point(80, 129);
            this.txtIgnorePrefix.MaxLength = 500;
            this.txtIgnorePrefix.Name = "txtIgnorePrefix";
            this.txtIgnorePrefix.Size = new System.Drawing.Size(387, 20);
            this.txtIgnorePrefix.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Ignore Suffix";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Ignore Prefix";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(10, 260);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 35);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "SearchBy";
            // 
            // Identifier
            // 
            this.Identifier.AutoSize = true;
            this.Identifier.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Identifier.Location = new System.Drawing.Point(6, 65);
            this.Identifier.Name = "Identifier";
            this.Identifier.Size = new System.Drawing.Size(45, 13);
            this.Identifier.TabIndex = 8;
            this.Identifier.Text = "Identifer";
            // 
            // dnSearchBy
            // 
            this.dnSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dnSearchBy.FormattingEnabled = true;
            this.dnSearchBy.Items.AddRange(new object[] {
            "ID",
            "Name",
            "Text",
            "Value"});
            this.dnSearchBy.Location = new System.Drawing.Point(79, 23);
            this.dnSearchBy.Name = "dnSearchBy";
            this.dnSearchBy.Size = new System.Drawing.Size(121, 21);
            this.dnSearchBy.TabIndex = 7;
            // 
            // txtControlValue
            // 
            this.txtControlValue.Location = new System.Drawing.Point(79, 58);
            this.txtControlValue.MaxLength = 100;
            this.txtControlValue.Name = "txtControlValue";
            this.txtControlValue.Size = new System.Drawing.Size(284, 20);
            this.txtControlValue.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select";
            // 
            // radioWindowsLogon
            // 
            this.radioWindowsLogon.AutoSize = true;
            this.radioWindowsLogon.Location = new System.Drawing.Point(149, 13);
            this.radioWindowsLogon.Name = "radioWindowsLogon";
            this.radioWindowsLogon.Size = new System.Drawing.Size(102, 17);
            this.radioWindowsLogon.TabIndex = 9;
            this.radioWindowsLogon.TabStop = true;
            this.radioWindowsLogon.Text = "Windows Logon";
            this.radioWindowsLogon.UseVisualStyleBackColor = true;
            this.radioWindowsLogon.CheckedChanged += new System.EventHandler(this.radioWindowsLogon_CheckedChanged);
            this.radioWindowsLogon.Click += new System.EventHandler(this.radioWindowsLogon_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageControls);
            this.tabControl1.Controls.Add(this.tabPageLogon);
            this.tabControl1.Controls.Add(this.tabPageActions);
            this.tabControl1.Controls.Add(this.tabPageJavaScriptButtons);
            this.tabControl1.Location = new System.Drawing.Point(13, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 360);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPageControls
            // 
            this.tabPageControls.Controls.Add(this.grpBoxControls);
            this.tabPageControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControls.Size = new System.Drawing.Size(547, 334);
            this.tabPageControls.TabIndex = 0;
            this.tabPageControls.Text = "Controls";
            this.tabPageControls.UseVisualStyleBackColor = true;
            // 
            // tabPageLogon
            // 
            this.tabPageLogon.Controls.Add(this.grpWindowsLogon);
            this.tabPageLogon.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogon.Name = "tabPageLogon";
            this.tabPageLogon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogon.Size = new System.Drawing.Size(547, 334);
            this.tabPageLogon.TabIndex = 1;
            this.tabPageLogon.Text = "Windows Logon";
            this.tabPageLogon.UseVisualStyleBackColor = true;
            // 
            // grpWindowsLogon
            // 
            this.grpWindowsLogon.Controls.Add(this.btnWindowsLogonOk);
            this.grpWindowsLogon.Controls.Add(this.txtPassword);
            this.grpWindowsLogon.Controls.Add(this.txtUserName);
            this.grpWindowsLogon.Controls.Add(this.label5);
            this.grpWindowsLogon.Controls.Add(this.label6);
            this.grpWindowsLogon.Location = new System.Drawing.Point(6, 6);
            this.grpWindowsLogon.Name = "grpWindowsLogon";
            this.grpWindowsLogon.Size = new System.Drawing.Size(364, 145);
            this.grpWindowsLogon.TabIndex = 11;
            this.grpWindowsLogon.TabStop = false;
            // 
            // btnWindowsLogonOk
            // 
            this.btnWindowsLogonOk.Location = new System.Drawing.Point(6, 101);
            this.btnWindowsLogonOk.Name = "btnWindowsLogonOk";
            this.btnWindowsLogonOk.Size = new System.Drawing.Size(75, 35);
            this.btnWindowsLogonOk.TabIndex = 9;
            this.btnWindowsLogonOk.Text = "Ok";
            this.btnWindowsLogonOk.UseVisualStyleBackColor = true;
            this.btnWindowsLogonOk.Click += new System.EventHandler(this.btnWindowsLogonOk_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(104, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(194, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(104, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(194, 20);
            this.txtUserName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "User name";
            // 
            // tabPageActions
            // 
            this.tabPageActions.Controls.Add(this.grpBoxActions);
            this.tabPageActions.Location = new System.Drawing.Point(4, 22);
            this.tabPageActions.Name = "tabPageActions";
            this.tabPageActions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActions.Size = new System.Drawing.Size(547, 334);
            this.tabPageActions.TabIndex = 2;
            this.tabPageActions.Text = "Actions";
            this.tabPageActions.UseVisualStyleBackColor = true;
            // 
            // grpBoxActions
            // 
            this.grpBoxActions.Controls.Add(this.nupDownIndex);
            this.grpBoxActions.Controls.Add(this.label9);
            this.grpBoxActions.Controls.Add(this.btnActionsOk);
            this.grpBoxActions.Controls.Add(this.label4);
            this.grpBoxActions.Controls.Add(this.txtValue);
            this.grpBoxActions.Location = new System.Drawing.Point(22, 15);
            this.grpBoxActions.Name = "grpBoxActions";
            this.grpBoxActions.Size = new System.Drawing.Size(517, 138);
            this.grpBoxActions.TabIndex = 7;
            this.grpBoxActions.TabStop = false;
            // 
            // nupDownIndex
            // 
            this.nupDownIndex.Location = new System.Drawing.Point(64, 65);
            this.nupDownIndex.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupDownIndex.Name = "nupDownIndex";
            this.nupDownIndex.Size = new System.Drawing.Size(59, 20);
            this.nupDownIndex.TabIndex = 7;
            this.nupDownIndex.Enter += new System.EventHandler(this.nupDownIndex_Enter);
            this.nupDownIndex.Leave += new System.EventHandler(this.nupDownIndex_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Index";
            // 
            // btnActionsOk
            // 
            this.btnActionsOk.Location = new System.Drawing.Point(6, 97);
            this.btnActionsOk.Name = "btnActionsOk";
            this.btnActionsOk.Size = new System.Drawing.Size(75, 35);
            this.btnActionsOk.TabIndex = 8;
            this.btnActionsOk.Text = "Ok";
            this.btnActionsOk.UseVisualStyleBackColor = true;
            this.btnActionsOk.Click += new System.EventHandler(this.btnActionsOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(64, 14);
            this.txtValue.MaxLength = 100;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(447, 20);
            this.txtValue.TabIndex = 6;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // tabPageJavaScriptButtons
            // 
            this.tabPageJavaScriptButtons.Controls.Add(this.groupBox1);
            this.tabPageJavaScriptButtons.Location = new System.Drawing.Point(4, 22);
            this.tabPageJavaScriptButtons.Name = "tabPageJavaScriptButtons";
            this.tabPageJavaScriptButtons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJavaScriptButtons.Size = new System.Drawing.Size(547, 334);
            this.tabPageJavaScriptButtons.TabIndex = 3;
            this.tabPageJavaScriptButtons.Text = "Javascript Buttons";
            this.tabPageJavaScriptButtons.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnJavaScriptsOk);
            this.groupBox1.Controls.Add(this.txtWindowTitle);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtButtonName);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 135);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnJavaScriptsOk
            // 
            this.btnJavaScriptsOk.Location = new System.Drawing.Point(9, 94);
            this.btnJavaScriptsOk.Name = "btnJavaScriptsOk";
            this.btnJavaScriptsOk.Size = new System.Drawing.Size(75, 35);
            this.btnJavaScriptsOk.TabIndex = 12;
            this.btnJavaScriptsOk.Text = "Ok";
            this.btnJavaScriptsOk.UseVisualStyleBackColor = true;
            this.btnJavaScriptsOk.Click += new System.EventHandler(this.btnJavaScriptsOk_Click);
            // 
            // txtWindowTitle
            // 
            this.txtWindowTitle.Location = new System.Drawing.Point(80, 23);
            this.txtWindowTitle.MaxLength = 100;
            this.txtWindowTitle.Name = "txtWindowTitle";
            this.txtWindowTitle.Size = new System.Drawing.Size(253, 20);
            this.txtWindowTitle.TabIndex = 10;
            this.txtWindowTitle.Text = "Message from webpage";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Window Title";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Value";
            // 
            // txtButtonName
            // 
            this.txtButtonName.Location = new System.Drawing.Point(80, 62);
            this.txtButtonName.MaxLength = 100;
            this.txtButtonName.Name = "txtButtonName";
            this.txtButtonName.Size = new System.Drawing.Size(253, 20);
            this.txtButtonName.TabIndex = 11;
            // 
            // radioJavaScript
            // 
            this.radioJavaScript.AutoSize = true;
            this.radioJavaScript.Location = new System.Drawing.Point(257, 13);
            this.radioJavaScript.Name = "radioJavaScript";
            this.radioJavaScript.Size = new System.Drawing.Size(73, 17);
            this.radioJavaScript.TabIndex = 12;
            this.radioJavaScript.TabStop = true;
            this.radioJavaScript.Text = "Javascript";
            this.radioJavaScript.UseVisualStyleBackColor = true;
            this.radioJavaScript.Click += new System.EventHandler(this.radioJavaScript_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(80, 91);
            this.txtData.MaxLength = 100;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(284, 20);
            this.txtData.TabIndex = 9;
            // 
            // SelectControlType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 442);
            this.Controls.Add(this.radioJavaScript);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.radioWindowsLogon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioActions);
            this.Controls.Add(this.radioControls);
            this.Controls.Add(this.dnControls);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectControlType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectControlType";
            this.Load += new System.EventHandler(this.SelectControlType_Load);
            this.grpBoxControls.ResumeLayout(false);
            this.grpBoxControls.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageControls.ResumeLayout(false);
            this.tabPageLogon.ResumeLayout(false);
            this.grpWindowsLogon.ResumeLayout(false);
            this.grpWindowsLogon.PerformLayout();
            this.tabPageActions.ResumeLayout(false);
            this.grpBoxActions.ResumeLayout(false);
            this.grpBoxActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDownIndex)).EndInit();
            this.tabPageJavaScriptButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dnControls;
        private System.Windows.Forms.RadioButton radioControls;
        private System.Windows.Forms.RadioButton radioActions;
        private System.Windows.Forms.GroupBox grpBoxControls;
        private System.Windows.Forms.TextBox txtControlValue;
        private System.Windows.Forms.ComboBox dnSearchBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Identifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioWindowsLogon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageControls;
        private System.Windows.Forms.TabPage tabPageLogon;
        private System.Windows.Forms.GroupBox grpWindowsLogon;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPageActions;
        private System.Windows.Forms.GroupBox grpBoxActions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TabPage tabPageJavaScriptButtons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWindowTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtButtonName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton radioJavaScript;
        private System.Windows.Forms.Button btnWindowsLogonOk;
        private System.Windows.Forms.Button btnActionsOk;
        private System.Windows.Forms.Button btnJavaScriptsOk;
        private System.Windows.Forms.NumericUpDown nupDownIndex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIgnoreSuffix;
        private System.Windows.Forms.TextBox txtIgnorePrefix;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox dnVisible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtData;
    }
}