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
    public partial class RenameTestCase : Form
    {
        int currentWebPageID = -1;
        string oldTestCase = "";
        string currentAction = "";
        public RenameTestCase(int webPageID, string testCase,string action)
        {
            InitializeComponent();
            currentWebPageID = webPageID;
            oldTestCase = testCase;
            currentAction = action;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTestCase.Text.Trim().Length == 0)
                {
                    UIHelper.StopMessage("Enter the test case name");
                    txtTestCase.Focus();
                    return;
                }

                if (txtTestCase.Text.Trim().ToLower() == oldTestCase.ToLower())
                {
                    UIHelper.StopMessage("Enter a new test case name");
                    txtTestCase.Focus();
                    return;
                }


                BusinessLayer.RenameTestCase(currentWebPageID, oldTestCase, txtTestCase.Text,currentAction);
                UIHelper.SaveMessage();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
