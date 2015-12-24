using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatiN.Core;
namespace WebAutomation
{
    public partial class Search_Controls : System.Windows.Forms.Form
    {
        public Search_Controls()
        {
            InitializeComponent();
        }

        private void btnGetTargetFrame_Click(object sender, EventArgs e)
        {
            btnGetTargetFrame.Enabled = false;
            IE ie = Core.IdentifyWebPage(txtTitle.Text, "");
            if (ie == null)
            {
                UIHelper.StopMessage("Cannot identify the webpage");
                txtTitle.Focus();
                return;
            }
            int totalFrames = ie.Frames.Count;

            txtPageFrame.Clear();

            if (dnSearchBy.Text.ToLower() == "name")
            {
                var obj = ie.Element(Find.ByName(txtTargetControl.Text));
                if (obj.Exists == true)
                {
                    MessageBox.Show("Found");
                    obj.Flash(2);
                    return;
                }
            }



            if (totalFrames > 1)
            {
                for (int i = 0; i < totalFrames; i++)
                {


                    if (dnSearchBy.Text.ToLower() == "id")
                    {
                        var idObj = ie.Frames[i].Element(Find.ById(txtTargetControl.Text));
                        if (idObj.Exists == true)
                        {
                            txtPageFrame.Text = i.ToString();
                            idObj.Flash(2);
                            break;
                        }
                    }
                    else if (dnSearchBy.Text.ToLower() == "name")
                    {
                        var nameObj = ie.Frames[i].Element(Find.ByName(txtTargetControl.Text));

                        if (nameObj.Exists == true)
                        {
                            txtPageFrame.Text = i.ToString();
                            nameObj.Flash(2);
                            break;
                        }
                    }
                    else if (dnSearchBy.Text.ToLower() == "text")
                    {
                        var txtObj = ie.Frames[i].Element(Find.ByText(txtTargetControl.Text));
                        if (txtObj.Exists == true)
                        {
                            txtPageFrame.Text = i.ToString();
                            txtObj.Flash(2);
                            txtObj.Focus();
                            SendKeys.SendWait("{ENTER}");
                            break;
                        }
                    }
                }

                if (txtPageFrame.Text.Length == 0)
                {

                    UIHelper.StopMessage("Control not found");
                }
                else
                {
                    UIHelper.ShowMessage("Control found on the web page", "Search control");
                }
            }
            else
            {
                Boolean found = false;
                if (dnSearchBy.Text.ToLower() == "id")
                {
                    if (ie.Element(Find.ById(txtTargetControl.Text)).Exists == true)
                    {
                        ie.Element(Find.ById(txtTargetControl.Text)).Flash(2);
                        found = true;

                    }
                }
                else if (dnSearchBy.Text.ToLower() == "name")
                {
                    if (ie.Element(Find.ByName(txtTargetControl.Text)).Exists == true)
                    {

                        ie.Element(Find.ById(txtTargetControl.Text)).Flash(2);
                        found = true;
                    }
                }
                else if (dnSearchBy.Text.ToLower() == "text")
                {
                    if (ie.Element(Find.ByText(txtTargetControl.Text)).Exists == true)
                    {
                        ie.Element(Find.ByText(txtTargetControl.Text)).Flash(2);
                        found = true;
                    }
                }
                if (found == false)
                {
                    UIHelper.StopMessage("Control not found");
                }
                else
                {
                    UIHelper.ShowMessage("Control found on the web page", "Search control");
                }

            }
            btnGetTargetFrame.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }
    }
}
