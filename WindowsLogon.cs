using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAutomation
{
    public partial class WindowsLogon : Form
    {
        DataGridViewCell activeCell = null;
        public WindowsLogon(DataGridViewCell currentCell)
        {
            activeCell = currentCell;
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, EventArgs e)
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
             activeCell.OwningRow.Cells["Data"].Value = "User name:"+ txtUserName + "Password:" +txtPassword.Text;
        }
    }
}
