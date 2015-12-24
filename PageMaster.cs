#region comments
#region 11-Dec
//1. Added additional parameters  while loading the pagedetails form
//2. Getting web page details from Pagemaster instead of database hit
    #endregion
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WatiN.Core;
using System.Windows;
using System.Windows.Automation;
namespace WebAutomation
{
    public partial class PageMaster : System.Windows.Forms.Form
    {
        
        IE ie;
        string mode = "I";

        
        public PageMaster()
        {
            InitializeComponent();
            gdvWebPages.Rows.Add();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtURL.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtURL.Focus();
                return;
            }

            else if (txtTitle.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtTitle.Focus();
                return;
            }

            else if (txtUniqueName.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please enter the value");
                txtUniqueName.Focus();
                return;
            }
         
            btnSave.Enabled = false;
            
            int ID = 0;
             
            if (txtID.Text.Length > 0)
            {
                DialogResult dres = System.Windows.Forms.MessageBox.Show("Do you Want to Edit and Overwrite row selected ?", "Edit Warning", MessageBoxButtons.YesNo);
                if (dres == DialogResult.Yes)
                {
                    ID = int.Parse(txtID.Text);
                }
            }


            try
            {

                List<SqlParameter> parameters = new List<SqlParameter>(0);
                parameters.Add(new SqlParameter("@title", txtTitle.Text));
                parameters.Add(new SqlParameter("@url", txtURL.Text));
                parameters.Add(new SqlParameter("@absolutepath", txtAbsoluteURL.Text));
                parameters.Add(new SqlParameter("@uniquename", txtUniqueName.Text));
                parameters.Add(new SqlParameter("@notes", txtNotes.Text));
                parameters.Add(new SqlParameter("@ID", ID));

                DataAccessLayer.InsertData("WebpageAdd", parameters);
                gdvWebPages.Columns.Clear();
                ShowAllWebPages();
                mode = "I";

            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate"))
                {
                    UIHelper.StopMessage("Record already exists");
                }
                else
                {
                    UIHelper.StopMessage(ex.Message);
                }
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void PageMaster_Load(object sender, EventArgs e)
        {

        }
      
        private void btnGet_Click(object sender, EventArgs e)
        {


            txtUniqueName.Clear();
            txtNotes.Clear();
            btnGet.Enabled = false;
            try
            {
                if (txtURL.Text.Length > 0)
                {
                    try
                    {
                        ie = IE.AttachTo<IE>(Find.ByUrl(txtURL.Text.Trim()), 1);
                        if (ie == null)
                        {
                            ie = IE.AttachTo<IE>(Find.ByTitle(txtTitle.Text.Trim()), 1);
                        }
                        
                    }
                    catch
                    {
                        UIHelper.StopMessage(" did not attach");
                    }
                }

                else if (txtTitle.Text.Length > 0)
                {
                    
                    ie = IE.AttachTo<IE>(Find.ByTitle(new Regex(txtTitle.Text.Trim())));
                    txtTitle.Text = ie.Url;

                }

                txtUniqueName.Text = txtTitle.Text;

                txtTitle.Text = ie.Title;
                txtURL.Text = ie.Url;
                txtAbsoluteURL.Text = ie.Uri.AbsolutePath;
            }
            catch (Exception)
            {

                txtURL.Focus();
                txtURL.BackColor = Color.Red;
                UIHelper.StopMessage("Enter URL or Title for the webpage");
                return;
            }
            finally
            {
                btnGet.Enabled = true;
            }
            txtURL.BackColor = Color.LightGreen;
        }



        private void btnExistingPages_Click(object sender, EventArgs e)
        {
            gdvWebPages.Columns.Clear();
            btnExistingPages.Enabled = false;
            ShowAllWebPages();
          
            btnExistingPages.Enabled = true;
            txtID.Text = "0";
        }


        private void ShowAllWebPages()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>(0);
                gdvWebPages.DataSource = DataAccessLayer.GetReturnDataTable("webpagegetall", parameters);
                gdvWebPages.Columns["ID"].Visible = false;
                //  gdvWebPages.Columns["URL"].Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gdvWebPages_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtURL.Text = UIHelper.GetGridColumnValue(gdvWebPages, e.RowIndex, "URL");
            txtTitle.Text = UIHelper.GetGridColumnValue(gdvWebPages, e.RowIndex, "Title");
         
            txtUniqueName.Text = UIHelper.GetGridColumnValue(gdvWebPages, e.RowIndex, "UNiqueName");
            if (IsColumnPresent(gdvWebPages, "Notes"))
            {
                txtNotes.Text = UIHelper.GetGridColumnValue(gdvWebPages, e.RowIndex, "Notes");
            }
            else
            {
                txtNotes.Text = "NA";
            }
            txtID.Text = UIHelper.GetGridColumnValue(gdvWebPages, e.RowIndex, "ID");
            txtAbsoluteURL.Text = UIHelper.GetGridColumnValue(gdvWebPages, e.RowIndex, "AbsolutePath");

        }

        private void btnScenarios_Click(object sender, EventArgs e)
        {
            btnScenarios.Enabled = false;
            ScenarioBuilder frm = new ScenarioBuilder();
            frm.ShowDialog();
            btnScenarios.Enabled = true;
        }

        private void gdvWebPages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {

                    if (UIHelper.GetConfigurationValue("targeturl").Length == 0 && gdvWebPages["Absolutepath", e.RowIndex].Value.ToString() != @"/")
                    {
                        UIHelper.StopMessage("Please specify the target url in the configuration file");
                        return;
                    }
                    else if (UIHelper.GetConfigurationValue("targeturl").Length > 0 && gdvWebPages["Absolutepath", e.RowIndex].Value.ToString() == @"/")
                    {
                        UIHelper.StopMessage("Absolute URL is missing. Please provide one or check the target URL in configuration file");
                        return;
                    }
                    else
                    {
                        lblLoading.Visible = true;
                        PageDetails frm = new PageDetails(int.Parse(gdvWebPages["ID", e.RowIndex].Value.ToString()),
                                                             chkLoadWebPage.Checked,
                                                             gdvWebPages["URL", e.RowIndex].Value.ToString(),
                                                             gdvWebPages["Absolutepath", e.RowIndex].Value.ToString(),
                                                             gdvWebPages["Title", e.RowIndex].Value.ToString()

                                                             );
                        frm.ShowDialog();
                        lblLoading.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    UIHelper.StopMessage("Please Click on Load Pages before you double click any cell");
                }
            }
        }

        private void btnDynamicParameter_Click(object sender, EventArgs e)
        {
            DynamicValues form = new DynamicValues();
            form.ShowDialog();
        }

        private void btnGetTargetFrame_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPageFrame_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFrames_Click(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
        }

        private void pnlFrames_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFrames_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnSearchControl_Click(object sender, EventArgs e)
        {
            Search_Controls form = new Search_Controls();

            form.ShowDialog();
        }

        private void gdvWebPages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtID.Text) == 0)
                {
                    UIHelper.StopMessage("Select the webpage to be deleted from the grid");
                    return;
                }

                if (UIHelper.ConfirmMessage("Delete this entry", "Confirm") == DialogResult.Yes)
                {


                    BusinessLayer.WebPageDelete(int.Parse(txtID.Text));
                    UIHelper.SaveMessage();
                    ShowAllWebPages();

                }
            }
            catch (Exception ex)
            {

                UIHelper.StopMessage(ex.Message);
            }
        }

        private bool IsColumnPresent(DataGridView dt, string columnname)
    {
        string colnames = "";
           for(int i=0; i <dt.Columns.Count; i++)
           {
               colnames = colnames + dt.Columns[i].ToString() + ";";
           }
           return colnames.Contains(columnname) ? true : false;
    }

    }
}
