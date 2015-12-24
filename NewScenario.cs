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
    public partial class NewScenario : Form
    {
        public NewScenario()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtScenario.Text.Length == 0)
            {
                UIHelper.StopMessage("Please enter the scenario name");
                txtScenario.Focus();
                return;
            }
            try
            {
                BusinessLayer.AddScenarioMaster(txtScenario.Text, txtNotes.Text);
                UIHelper.ShowMessage("Data saved successfully", "Message");
                txtScenario.Clear();
                txtNotes.Clear();
            }
            catch (Exception ex)
            {
                UIHelper.StopMessage(ex.Message);
                
            }
        }
    }
}
