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
using WatiN.Core;
namespace WebAutomation
{
    public partial class Scenarios : System.Windows.Forms.Form
    {
        int waitTimeOut = int.Parse(System.Configuration.ConfigurationManager.AppSettings["waittime"]);
        int frame = -1;
        Dictionary<string, string> uniqueString = new Dictionary<string, string>();
        string currentUniquevalue;

        public Scenarios()
        {
            InitializeComponent();

            DataTable dt = DataAccessLayer.GetReturnDataTable("WebPageGetAll", new List<SqlParameter>(0));
            gdvWebPage.DataSource = dt;
            gdvWebPage.Columns["ID"].Visible = false;
            dt = DataAccessLayer.GetReturnDataTable("GetScenariosAll", new List<SqlParameter>(0));

            gdvScenarios.DataSource = dt;
            gdvScenarios.Visible = true;
            dnActions.SelectedIndex = 0;
            gdvScenarios.Columns["ID"].Visible = false;
        }

        private void txtStep_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Scenarios_Load(object sender, EventArgs e)
        {

        }

        private void gdvWebPage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //  UIHelper.HighLightGridRow(gdvWebPage, e.RowIndex);


                txtWebPageID.Text = gdvWebPage.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                List<SqlParameter> paramList = new List<SqlParameter>(0);
                paramList.Add(new SqlParameter("@webpageid", int.Parse(txtWebPageID.Text)));
                DataTable dt = DataAccessLayer.GetReturnDataTable("GetTestCaseList", paramList);
                gdvTestCases.DataSource = dt;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void gdvTestCases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string testcase = UIHelper.GetGridColumnValue(gdvTestCases, e.RowIndex, "TestCase");
                if (testcase.Length > 0)
                {
                    txtTestCase.Text = testcase;
                }
            }
        }

        private void gdvWebPage_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gdvTestCases_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchScenario_TextChanged(object sender, EventArgs e)
        {

        }

        private void gdvScenarios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            NewScenario frm = new NewScenario();
            frm.ShowDialog();

            DataTable dt = DataAccessLayer.GetReturnDataTable("GetScenariosAll", new List<SqlParameter>(0));
            gdvScenarios.DataSource = dt;
        }


        private void gdvScenarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtScenarioID.Text = gdvScenarios.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            }
        }

        private void btnSaveScenario_Click(object sender, EventArgs e)
        {
            btnSaveScenario.Enabled = false;
            if (txtTestCase.Text.Length == 0 || txtScenarioID.Text.Length == 0 || txtWebPageID.Text.Length == 0)
            {
                UIHelper.StopMessage("Please enter scenario, webpage and testcase");
                return;
            }

            try
            {
                // string testCase = UIHelper.GetGridColumnValue(gdvTestCases,gdvTestCases.SelectedRows[0],"Testcase");
                List<SqlParameter> parammlist = new List<SqlParameter>(0);
                parammlist.Add(new SqlParameter("@ScenarioID", int.Parse(txtScenarioID.Text)));
                parammlist.Add(new SqlParameter("@WebPageID", int.Parse(txtWebPageID.Text)));
                parammlist.Add(new SqlParameter("@TestCase", txtTestCase.Text));
                parammlist.Add(new SqlParameter("@Action", dnActions.Text));
                DataAccessLayer.InsertData("[ScenariosDetailAdd]", parammlist);
                UIHelper.SaveMessage();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                btnSaveScenario.Enabled = true;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            IE ie = null;

            try
            {

                string currentUnqiueName = "";

                List<SqlParameter> parameters = new List<SqlParameter>(0);

                parameters.Add(new SqlParameter("@webpageid", int.Parse(txtWebPageID.Text)));

                DataTable dtWebpage = DataAccessLayer.GetReturnDataTable("WebPageGet", parameters);
                frame = int.Parse(dtWebpage.Rows[0]["frame"].ToString());

                ie = Core.IdentifyWebPage((string)dtWebpage.Rows[0]["Title"].ToString(), (string)dtWebpage.Rows[0]["URL"].ToString());


                parameters.Clear();

                parameters.Add(new SqlParameter("@webpageid", int.Parse(txtWebPageID.Text)));
                parameters.Add(new SqlParameter("@testcase", int.Parse(txtTestCase.Text)));

                DataTable dt = DataAccessLayer.GetReturnDataTable("GetWebPageControlsAndData", parameters);


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string elementType = dt.Rows[i]["Controltype"].ToString();

                    string elementID = dt.Rows[i]["ControlID"].ToString();
                    string elementName = dt.Rows[i]["ControlName"].ToString();
                    string data = dt.Rows[i]["Data"].ToString();


                    string dataName = dt.Rows[i]["DataName"].ToString();

                    if (data.StartsWith("#") && data.EndsWith("#"))
                    {
                        currentUnqiueName = data.Substring(1, data.Length - 1);
                        currentUniquevalue= Guid.NewGuid().ToString().Replace("-", "");
                        uniqueString.Add(currentUnqiueName,currentUniquevalue);
                    }

                    switch (elementType.ToLower())
                    {

                        case "button":
                            var button = Core.GetButton(ie, frame, elementName, elementID, -1);
                            if (data.ToLower() == "c")
                            {
                                button.Click();
                                ie.WaitForComplete(waitTimeOut);
                            }
                            break;
                        case "selectlist":
                            var selectList = Core.GetSelectList(ie, frame, elementName, elementID, -1);
                            var option = selectList.Option(Find.ByText(data));
                            option.Select();
                            break;
                        case "radiobutton":
                            WatiN.Core.RadioButton radioButton = Core.GetRadioButton(ie, frame, elementName, elementID, -1);
                            radioButton.Click();
                            ie.WaitForComplete(waitTimeOut);
                            break;
                        case "textfield":

                            var txt = Core.GetTextField(ie, frame, elementName, elementID, -1);
                            txt.Value = data;
                            txt.Focus();
                            break;
                        case "element]":
                            var ele = ie.Element(Find.ById(elementID));
                            ele.SetAttributeValue("value", data);
                            break;
                        case "link":
                            var link = Core.GetLink(ie, frame, elementName, elementID, -1);
                            link.Click();
                            ie.WaitForComplete(waitTimeOut);
                            break;
                        case "checkbox":
                            var checbox = Core.GetChecKBox(ie, frame, elementName, elementID, -1);
                            checbox.Click();
                            ie.WaitForComplete(waitTimeOut);
                            break;
                        case "div":
                            ie.Div(Find.ByText(elementID)).Blur();
                            break;
                        case "navigateto":
                            ie.GoTo(data);
                            break;
                        case "fireevent":
                            ie.ActiveElement.FireEvent(data);
                            break;
                        case "getuniquestring":
                            uniqueString.TryGetValue(currentUnqiueName, out currentUniquevalue);
                            break;
                        case "SearchWebTableRow":
                          //  uniqueString.TryGetValue(currentUnqiueName, out currentUniquevalue);
                           // Core.FindWebTableRow(currentUniquevalue, ie);
                            break;
                        default:
                            break;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}