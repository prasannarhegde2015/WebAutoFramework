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
using System.Data.SqlClient;
namespace WebAutomation
{
    public partial class WebTableDefinition : System.Windows.Forms.Form
    {
        IE ie = null;
        Table targetTable = null;

        DataTable dt = new DataTable();
        DataGridViewCell selectedCell;
        public WebTableDefinition(DataGridViewCell currentCell, string title, string url, string webTableControlID, string webTableControlName, int tableInstance, string testCase, int frame,string webTableName)
        {
            InitializeComponent();
            txtName.Text = webTableName;

            if (txtName.Text.Length > 0)
            {
                txtName.Enabled = false;
            }

            try
            {
                selectedCell = currentCell;
                txtTestCase.Text = testCase.Replace(" ", "_").Replace("-","_");

                if (title.Trim().Length > 0)
                {
                    ie = Core.IdentifyWebPage(title.Trim(), "");
                }
                else if (url.Trim().Length > 0)
                {
                    ie = Core.IdentifyWebPage(url.Trim(), "");
                }
                else
                {
                    UIHelper.StopMessage("Pass title or url for webpage identification");
                    return;
                }

                if (webTableControlID.Trim().Length > 0)
                {
                    targetTable = Core.GetWebTable(ie, frame, webTableControlID.Trim(), 0);
                }
                else if (webTableControlName.Trim().Length > 0)
                {
                    targetTable = Core.GetWebTable(ie, frame, webTableControlName.Trim(), 0);
                }
                else
                {
                    UIHelper.StopMessage("Pass ID/Name for table identification");
                    return;
                }

                if (targetTable != null)
                {
                    txtRowCount.Text = targetTable.OwnTableRows.Count.ToString();
                    ElementCollection elem = targetTable.OwnTableRows[0].Children();
                    txtColumnCount.Text = elem.Count.ToString();

                    for (int i = 0; i < elem.Count; i++)
                    {

                        if (elem[i].Text != null)
                        {
                            dt.Columns.Add(elem[i].Text);
                            lstColumns.Items.Add(elem[i].Text);
                        }
                    }

                    for (int j = 1; j < targetTable.OwnTableRows.Count; j++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int k = 0; k < elem.Count; k++)
                        {

                            if (targetTable.OwnTableRows[j].OwnTableCells.Count >= k + 1) // for non-uniform tables where the table is not exactly a matrix of rows and columns 
                            {

                                dr[lstColumns.Items[k].ToString()] = targetTable.OwnTableRows[j].OwnTableCells[k].ToString();
                            }
                        }
                        dt.Rows.Add(dr);
                    }

                }
                gdvWebtable.DataSource = dt;

            }
            catch (Exception)
            {

                throw new Exception("Error loading the web table"); ;
            }
        }


        private string GetControlType(string controlType)
        {
            try
            {
                string[] values = controlType.Split('.');
                return values[values.Length - 1];
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTestCase.Text.Trim().Length == 0 || txtName.Text.Trim().Length == 0)
                {
                    UIHelper.StopMessage("Please mention the Webtable name and test case");
                    return;
                }


                if (gdvWebtable.SelectedRows.Count == 0 || lstColumns.CheckedItems.Count == 0)
                {

                    UIHelper.StopMessage("Please select the row and column for verification");
                    return;
                }

                List<SqlParameter> param = new List<SqlParameter>(0);
                param.Add(new SqlParameter("@TableName", txtName.Text + "_" + txtTestCase.Text));
                DataAccessLayer.InsertData("CreateWebtable", param);



                #region AllRowsAndColumns
                string connectionString = System.Configuration.ConfigurationManager.AppSettings["con"];
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
              
                try
                {


                    int rowCount = gdvWebtable.Rows.Count;
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (gdvWebtable.Rows[i].Selected == true)
                        {

                            for (int j = 0; j < lstColumns.Items.Count; j++)
                            {
                                if (lstColumns.GetItemChecked(j) == true)
                                {
                                 
                                    List<SqlParameter> para = new List<SqlParameter>(0);
                                    para.Add(new SqlParameter("@TableName", txtName.Text + "_" + txtTestCase.Text));
                                    para.Add(new SqlParameter("@Rowno", i+1));
                                    para.Add(new SqlParameter("@Columnno", j));
                                    para.Add(new SqlParameter("@ColumnName", lstColumns.GetItemText(lstColumns.Items[j])));
                                    para.Add(new SqlParameter("@Value", gdvWebtable.Rows[i].Cells[lstColumns.GetItemText(lstColumns.Items[j])].Value));
                                    DataAccessLayer.InsertData("[CreateWebtable]", para);
                                }

                            }
                        }

                    }
                    trans.Commit();
                    UIHelper.SaveMessage();
                    selectedCell.OwningRow.Cells["Data"].Value = txtTestCase.Text;
                    selectedCell.OwningRow.Cells["Index"].Value = "0";
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    UIHelper.StopMessage(ex.Message);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                #endregion


            }
            catch (Exception ex)
            {

                UIHelper.StopMessage(ex.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < lstColumns.Items.Count; i++)
            {
                lstColumns.SetItemChecked(i, chkAll.Checked);
            }

        }

        private void chkAllRows_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gdvWebtable.Rows.Count; i++)
            {
                gdvWebtable.Rows[i].Selected = chkAllRows.Checked;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
