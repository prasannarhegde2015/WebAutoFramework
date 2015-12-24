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
    public partial class DynamicValues : Form
    {
        public DynamicValues()
        {
            InitializeComponent();
            dnType.SelectedIndex = 0;

            gdvDynamicParameters.DataSource = BusinessLayer.GetDynamicParameterList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text.Length == 0)
            {
                UIHelper.StopMessage("Please enter the name");
                txtName.Focus();
                return;
            }
            try
            {

                btnSave.Enabled = false;
                txtName.Text = txtName.Text.Replace("~", ""); // to avoid incorrect usage of #

                txtName.Text = "~" + txtName.Text;

                txtName.Text = txtName.Text + "~";

                List<SqlParameter> paramters = new List<SqlParameter>(0);
                paramters.Add(new SqlParameter("@DynamicName", txtName.Text));
                paramters.Add(new SqlParameter("@DynamicType", dnType.Text));
                paramters.Add(new SqlParameter("@Length", int.Parse(nupLength.Text)));
                paramters.Add(new SqlParameter("@Format", dnFormat.Text));

                DataAccessLayer.InsertData("[DynamicParametersAdd]", paramters);
                UIHelper.ShowMessage("Data saved successfully", "Message");
                txtName.Clear();
                btnSave.Enabled = true;
            }
            catch (SqlException ex)
            {
                if (ex.Message.ToLower().Contains("unique"))
                {
                    UIHelper.StopMessage("Parameter {" + txtName.Text + "} already present");
                    btnSave.Enabled = true;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
