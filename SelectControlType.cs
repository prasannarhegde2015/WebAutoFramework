using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WebAutomation
{
    public partial class SelectControlType : Form
    {
        DataGridViewCell currentCell;
        int frame = -1;
        string currentcontrolType, currentAction, currentData, currentIdentifier,visible = "";
        public SelectControlType(DataGridViewCell cell)
        {
            currentCell = cell;

            InitializeComponent();

            string[] words;
            if (currentCell.OwningRow.Cells["controltype"].Value != null)
            {
                currentcontrolType = currentCell.OwningRow.Cells["controltype"].Value.ToString();
                frame = int.Parse(currentCell.OwningRow.Cells["Frameposition"].Value.ToString());
                currentAction = currentCell.OwningRow.Cells["ISAction"].Value != null ? currentCell.OwningRow.Cells["ISAction"].Value.ToString() : "";
                currentData = currentCell.OwningRow.Cells["Data"].Value != null ? currentCell.OwningRow.Cells["Data"].Value.ToString() : "";
                currentIdentifier = currentCell.OwningRow.Cells["identifier"].Value != null ? currentCell.OwningRow.Cells["identifier"].Value.ToString() : "";

                visible = currentCell.OwningRow.Cells["Visible"].Value != null ? currentCell.OwningRow.Cells["Visible"].Value.ToString() : "";

                if (visible.Trim().Length > 0)
                {
                    dnVisible.Text = visible;
                }
                if (currentcontrolType.Length > 0)
                {
                    if (currentAction.ToLower() == "y" && (currentcontrolType.ToLower() != "windowslogon" && currentcontrolType.ToLower() != "javascriptbutton"))
                    {
                        radioActions.Select();

                        dnControls.Text = currentcontrolType;
                        txtValue.Text = currentData;
                    }
                    else
                    {
                        switch (currentcontrolType.ToLower())
                        {
                            case "windowslogon":
                                radioWindowsLogon.Select();
                                txtUserName.Text = UIHelper.GetUserNameAndPassword("u", currentData);
                                txtPassword.Text = UIHelper.GetUserNameAndPassword("p", currentData);
                                break;
                            case "javascriptbutton":
                                radioJavaScript.Select();
                                txtWindowTitle.Text = currentData;
                                words = currentData.Split('|');
                                txtWindowTitle.Text = words[0].Trim().Split(':')[1];
                                txtButtonName.Text = words[1].Trim().Split(':')[1];
                                break;
                            default:
                                radioControls.Select();
                                dnControls.Text = currentcontrolType;
                                words = currentIdentifier.Split(':');
                                txtData.Text = currentData;
                                if (words[0].ToLower() == "id")
                                {
                                    dnSearchBy.Text = "ID";
                                    txtControlValue.Text = words[1].Trim();
                                }
                                else if (words[0].ToLower() == "name")
                                {
                                    dnSearchBy.Text = "Name";
                                    txtControlValue.Text = words[1].Trim();
                                }
                                else if (words[0].ToLower() == "text")
                                {
                                    dnSearchBy.Text = "Name";
                                    txtControlValue.Text = words[1].Trim();
                                }
                                else if (words[0].ToLower() == "value")
                                {
                                    dnSearchBy.Text = "value";
                                    txtControlValue.Text = words[1].Trim();
                                }
                                else
                                    MessageBox.Show("Not a valid identifer");
                                break;
                        }
                    }
                }
            }
            else
            {
                radioControls.Select();
                dnControls.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtControlValue.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtControlValue.Focus();
                return;
            }

            if (dnSearchBy.Text.ToLower() == "id")
            {
                currentCell.OwningRow.Cells["controlId"].Value = txtControlValue.Text;
                currentCell.OwningRow.Cells["Identifier"].Value = "ID:" + txtControlValue.Text;
            }
            else if (dnSearchBy.Text.ToLower() == "name")
            {
                currentCell.OwningRow.Cells["controlname"].Value = txtControlValue.Text;
                currentCell.OwningRow.Cells["Identifier"].Value = "Name:" + txtControlValue.Text;

            }
            else if (dnSearchBy.Text.ToLower() == "text")
            {
                currentCell.OwningRow.Cells["controltext"].Value = txtControlValue.Text;
                currentCell.OwningRow.Cells["Identifier"].Value = "Text:" + txtControlValue.Text;
            }
            else if (dnSearchBy.Text.ToLower() == "value")
            {
                currentCell.OwningRow.Cells["controlvalue"].Value = txtControlValue.Text;
                currentCell.OwningRow.Cells["Identifier"].Value = "Value:" + txtControlValue.Text;
            }
            switch (dnControls.Text.ToLower())
            {
                case "button":
                case "link":
                case "div":
                case "radiobutton":
                case "checkbox":
                case "image":
                    currentCell.OwningRow.Cells["Visible"].Value = dnVisible.Text;
                    break;
                case "para":
                case "span":
                    currentCell.OwningRow.Cells["IgnorePrefix"].Value = txtIgnorePrefix.Text;
                    currentCell.OwningRow.Cells["IgnoreSuffix"].Value = txtIgnoreSuffix.Text;
                    currentCell.OwningRow.Cells["Visible"].Value = dnVisible.Text;
                    break;
            }

            currentCell.Value = dnControls.Text;
            currentCell.OwningRow.Cells["IsAction"].Value = "N";
            currentCell.OwningRow.Cells["Frameposition"].Value = frame;
            currentCell.OwningRow.Cells["Data"].Value = txtData.Text;
            this.Close();

        }

        private void radioControls_Click(object sender, EventArgs e)
        {
            currentAction = "N";

            label3.Visible = true;

            dnControls.Visible = true;
            //This can be optimized by calling it once

            DataTable dt = BusinessLayer.GetControlList();

            dnControls.DataSource = dt;
            dnControls.DisplayMember = "DataValue";
            if (currentData == null || currentData.Length == 0)
            {
                dnControls.SelectedIndex = 0;
            }
            else
            {
                dnControls.Text = currentData;
            }
            dnSearchBy.SelectedIndex = 0;

            if (tabControl1.TabPages.Contains(tabPageControls) == false)
            {
                tabControl1.TabPages.Add(tabPageControls);
            }

            tabControl1.TabPages.Remove(tabPageActions);
            tabControl1.TabPages.Remove(tabPageLogon);
            tabControl1.TabPages.Remove(tabPageJavaScriptButtons);
        }

        private void radioActions_Click(object sender, EventArgs e)
        {


            label3.Visible = true;

            dnControls.Visible = true;

            currentAction = "Y";
            //This can be optimized by calling it once
            List<SqlParameter> paramList = new List<SqlParameter>(0);
            DataTable dt = DataAccessLayer.GetReturnDataTable("GetActionList", paramList);

            dnControls.DataSource = dt;
            dnControls.DisplayMember = "DataValue";
            dnControls.SelectedIndex = 0;
            if (tabControl1.TabPages.Contains(tabPageActions) == false)
            {
                tabControl1.TabPages.Add(tabPageActions);
            }

            tabControl1.TabPages.Remove(tabPageLogon);
            tabControl1.TabPages.Remove(tabPageControls);
            tabControl1.TabPages.Remove(tabPageJavaScriptButtons);

        }

        private void SelectControlType_Load(object sender, EventArgs e)
        {

        }

        private void radioWindowsLogon_Click(object sender, EventArgs e)
        {

            if (tabControl1.TabPages.Contains(tabPageLogon) == false)
            {
                tabControl1.TabPages.Add(tabPageLogon);
            }
            tabControl1.TabPages.Remove(tabPageActions);
            tabControl1.TabPages.Remove(tabPageControls);
            tabControl1.TabPages.Remove(tabPageJavaScriptButtons);

            dnControls.Visible = false;
            label3.Visible = false;
            currentAction = "Y";
        }

        private void radioWindowsLogon_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpWindowsLogon_Enter(object sender, EventArgs e)
        {

        }

        private void radioControls_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioJavaScript_Click(object sender, EventArgs e)
        {
            dnControls.Visible = false;
            label3.Visible = false;


            tabControl1.TabPages.Remove(tabPageLogon);
            tabControl1.TabPages.Remove(tabPageActions);
            tabControl1.TabPages.Remove(tabPageControls);

            if (tabControl1.TabPages.Contains(tabPageJavaScriptButtons) == false)
            {
                tabControl1.TabPages.Add(tabPageJavaScriptButtons);
            }
        }

        private void btnWindowsLogonOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtUserName.Focus();
                return;
            }
            else if (txtPassword.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtPassword.Focus();
                return;
            }
            currentCell.OwningRow.Cells["Data"].Value = "User name:" + txtUserName.Text + "|" + "Password:" + txtPassword.Text;
            currentCell.Value = "WindowsLogon";
            currentCell.OwningRow.Cells["IsAction"].Value = "Y";
            this.Close();
        }

        private void btnActionsOk_Click(object sender, EventArgs e)
        {
            if (radioActions.Checked == true)
            {
                switch (dnControls.Text.ToLower())
                {
                    case "keyboard":
                    case "fireevent":
                    case "navigateto":
                        txtValue.Visible = true;
                        if (txtValue.Text.Trim().Length == 0)
                        {
                            UIHelper.StopMessage("Please enter the value");
                            txtValue.Focus();
                            return;
                        }

                        break;
                    case "searchwebtablerow":
                        txtValue.Visible = true;
                        if (txtValue.Text.Trim().Length == 0)
                        {
                            UIHelper.StopMessage("Please enter the value");
                            txtValue.Focus();
                            return;
                        }
                        currentCell.OwningRow.Cells["Index"].Value = nupDownIndex.Value;
                        break;
                    default:
                        break;
                }
                if (dnControls.Text.ToLower() == "keyboard")
                {
                    if (txtValue.Text.Trim().Length == 0)
                    {
                        UIHelper.StopMessage("Please enter the value");
                        txtValue.Focus();
                        return;
                    }

                    txtValue.Text = txtValue.Text.Replace("{", ""); //to avoid improper usage of the braces
                    txtValue.Text = txtValue.Text.Replace("}", "");

                    txtValue.Text = "{" + txtValue.Text;

                    txtValue.Text = txtValue.Text + "}";

                    txtValue.Text = txtValue.Text.ToUpper();
                }
                if (dnControls.Text.ToLower() == "wait")
                {

                    int num1;
                    if (int.TryParse(txtValue.Text, out num1) == false)
                    {
                        MessageBox.Show("Please enter a numeric value");
                        txtValue.Focus();
                        return;
                    }

                }
                else if (dnControls.Text.ToLower() == "waitforwebpage")
                {


                    if (txtValue.Text.Length == 0)
                    {
                        MessageBox.Show("Please enter the web page title");
                        txtValue.Focus();
                        return;
                    }

                }


                currentCell.OwningRow.Cells["Data"].Value = txtValue.Text;
                currentCell.Value = dnControls.Text;
                currentCell.OwningRow.Cells["IsAction"].Value = "Y";
                this.Close();
            }
        }

        private void btnJavaScriptsOk_Click(object sender, EventArgs e)
        {
            if (txtWindowTitle.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtWindowTitle.Focus();
                return;
            }
            else if (txtButtonName.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtButtonName.Focus();
                return;
            }
            currentCell.OwningRow.Cells["Data"].Value = "Window Title:" + txtWindowTitle.Text + "|" + "Button:" + txtButtonName.Text;
            currentCell.Value = "JavascriptButton";
            currentCell.OwningRow.Cells["IsAction"].Value = "Y";
            this.Close();
        }

        private void radioActions_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void nupDownIndex_Enter(object sender, EventArgs e)
        {
            if (dnControls.Text.ToLower() == "searchwebtablerow")
            {
                nupDownIndex.ReadOnly = true;
            }
            else
                nupDownIndex.Enabled = false;
        }

        private void nupDownIndex_Leave(object sender, EventArgs e)
        {

            nupDownIndex.Enabled = true;
        }
    }
}
