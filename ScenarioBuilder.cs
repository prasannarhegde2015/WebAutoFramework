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
using System.Collections.Specialized;
using WatiN.Core;
using System.Text.RegularExpressions;
using Helper;
using System.IO;
namespace WebAutomation
{

    public partial class ScenarioBuilder : System.Windows.Forms.Form
    {
        ListDictionary lstScenarios = new ListDictionary();
        TreeNode currentNode = null;
        int currentRowForSelectedScenario = -1;
        string logFile = "";
        string resultFile = "";
        int currentScenarioID = -1;
        //DataTable dtDynamicValues = new DataTable(); //THis holds all the dynamicvalues created during this session 
        string targetURL = "";
        //DataRow[] drDynamicValues = null;  // THis holds the filtered value from the dynamic table


        DataTable testCaseList; //Global datatable for holding the test caselist
        DataTable scenarios; //Gloabal datatable for holding the scenarios 
        int pacing = int.Parse(System.Configuration.ConfigurationManager.AppSettings["pacing"]);


        public ScenarioBuilder()
        {
            InitializeComponent();

            LoadScenarios("N"); //Load only the scenarios which are in-complete
            targetURL = System.Configuration.ConfigurationManager.AppSettings["targeturl"];
            if (targetURL.EndsWith(@"/"))
            {
                targetURL = targetURL.Substring(0, (targetURL.Length - 1));
            }


            //dtDynamicValues.Columns.Add("ScenarioID");
            //dtDynamicValues.Columns.Add("DynamicName");
            //dtDynamicValues.Columns.Add("DynamicValue");

            resultFile = System.Configuration.ConfigurationManager.AppSettings["resultFile"];
            gdvSteps.Rows.Add();
            DataTable dt = BusinessLayer.GetWebpages();
            dnWebpages.DataSource = dt;
            dnWebpages.DisplayMember = "UniqueName";
            dnWebpages.ValueMember = "UniqueName";
            dnWebpages.SelectedIndex = 0;
        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            NewScenario frm = new NewScenario();
            frm.ShowDialog();
            LoadScenarios("N");

        }

        private void LoadScenarios(string all)
        {

            lstScenarios.Clear();
            tvwScenarios.Nodes.Clear();

            List<SqlParameter> para = new List<SqlParameter>(0);

            if (all.ToLower() == "y")
            {
                para.Add(new SqlParameter("@All", "Y"));
            }

            scenarios = DataAccessLayer.GetReturnDataTable("GetScenariosAll", para);

            for (int i = 0; i < scenarios.Rows.Count; i++)
            {
                lstScenarios.Add(scenarios.Rows[i]["Scenario"].ToString(), scenarios.Rows[i]["ID"].ToString());
                tvwScenarios.Nodes.Add(scenarios.Rows[i]["ID"].ToString(), scenarios.Rows[i]["Scenario"].ToString());

            }
        }

        private void tvwScenarios_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(tvwScenarios, tvwScenarios.Left, tvwScenarios.Top);


                currentNode = e.Node;
                if (currentNode != null)
                {
                    if (currentNode.Parent == null) //Main Node
                    {
                        lblCurrentParentNode.Text = "Current Node: " + currentNode.Text;
                        currentScenarioID = int.Parse(lstScenarios[currentNode.Text].ToString());

                        contextMenuStrip1.Items["showSteps"].Visible = true;

                        contextMenuStrip1.Items["run"].Visible = true; ;
                        contextMenuStrip1.Items["showDetailsToolStripMenuItem"].Visible = false; ;
                    }
                    else //Child Node
                    {
                        contextMenuStrip1.Items["showSteps"].Visible = false;

                        contextMenuStrip1.Items["run"].Visible = false; ;

                        contextMenuStrip1.Items["showDetailsToolStripMenuItem"].Visible = true;
                    }
                }
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                currentNode = e.Node;
                if (currentNode != null)
                {

                    if (gdvSelectedControls.Visible == true && currentNode.Tag != null)
                    {

                        ShowDetails(int.Parse(currentNode.Tag.ToString()));
                    }

                    if (currentNode.Parent == null)
                    {
                        lblCurrentParentNode.Text = "Current Node: " + currentNode.Text;
                    }
                }
            }



        }

        private void GetTestCaseList()
        {
            gdvSteps.ReadOnly = true;


            if (currentNode.Parent == null)
            {

                testCaseList = DataAccessLayer.GetReturnDataTable("[GetTestCaseList]", new List<SqlParameter>(0));
                if (testCaseList.Rows.Count > 0)
                {
                    gdvSteps.Columns.Clear();
                    gdvSteps.DataSource = testCaseList;
                    gdvSteps.Visible = true;
                    gdvSteps.Columns["WebpageID"].Visible = false;
                    gdvSteps.Columns["URL"].Visible = false;
                    gdvSteps.Columns["ID"].Visible = false;
                    gdvSteps.Columns["Notes"].Visible = false;
                }
                //string name = "";
                //string testcase = "";
                //for (int i = 0; i < gdvSteps.Rows.Count; i++)
                //{
                //    name = UIHelper.GetGridColumnValue(gdvSteps, i, "Uniquename");
                //    testcase = UIHelper.GetGridColumnValue(gdvSteps, i, "Testcase");
                //    //if (currentNode.Nodes.Find(name + ":" + testcase, false).Length > 0)
                //    //{
                //    //    gdvSteps.Rows[i].ReadOnly = true;
                //    //}

                //}

            }
        }



        private void gdvSteps_DragLeave(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void gdvSteps_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }






        private void ScenarioBuilder_Load(object sender, EventArgs e)
        {

        }

        private void mnuItemSteps_Click(object sender, EventArgs e)
        {

            if (currentNode != null)
            {

                GetScenarioDetails(currentNode);
                if (gdvSteps.Rows.Count == 1 && gdvSteps.Rows[0].Cells[0].Value == null) //since first row is blank by default
                {
                    GetTestCaseList();
                }
            }
        }



        private Boolean IsStepAdded(TreeNode mainNode, string testCase, string uniqueName, int webPageID, string action)
        {


            for (int i = 0; i < mainNode.Nodes.Count; i++)
            {
                string val = uniqueName + ":" + testCase + ":" + action;


                if (mainNode.Nodes[i].Text == val)
                {
                    return true;
                }
            }

            return false;
        }


        //private void RunScenario(int scenarioID)
        //{
        //    IE ie = null;

        //    Table targetTable = null;
        //    int frame = -1;
        //    Dictionary<string, string> uniqueString = new Dictionary<string, string>();
        //    int waitTimeOut = int.Parse(System.Configuration.ConfigurationManager.AppSettings["waittime"]);
        //    int attempts = int.Parse(System.Configuration.ConfigurationManager.AppSettings["attempts"]);




        //    try
        //    {
        //        //int scenarioID = -1;

        //        //logTofile("Getting scenario ID ");
        //        //scenarioID = GetScenarioID(currentNode);
        //        BusinessLayer.LogTofile("", "", "", "", "", "Scenario ID is  " + scenarioID.ToString());

        //        string currentUniqueName = "";

        //        string currentUniquevalue = "";
        //        string currentDynamicType = "";
        //        string currentDynamicFormat = "";
        //        int webPageID = -1;
        //        string action = "";
        //        int index = -1;
        //        string verificationValue = "";

        //        BusinessLayer.LogTofile("", "", "", "", "", "Getting the data for Scenario");
        //        DataTable dtRun = BusinessLayer.GetRunData(scenarioID);
        //        BusinessLayer.LogTofile("", "", "", "", "", "Scenario has total : " + dtRun.Rows.Count.ToString() + " actions");
        //        if (dtRun.Rows.Count == 0)
        //        {
        //            UIHelper.StopMessage("No data to run");
        //            return;
        //        }
        //        string controlType, elementID, elementName, controlText, data, testCase, title = "";
        //        int startFrom, EndOn = -1;
        //        int currentTableRow = -1;

        //        List<SqlParameter> paramDynamicParameters = new List<SqlParameter>(0);
        //        List<SqlParameter> paramDynamicValues = new List<SqlParameter>(0);


        //        //Database call needs to be deleted
        //        //List<SqlParameter> paramDelete = new List<SqlParameter>(0);
        //        //paramDelete.Add(new SqlParameter("@ScenarioID", scenarioID));
        //        //DataAccessLayer.InsertData("DeleteDynamicValues", paramDelete);


        //        DataTable dtDynamicParameter = BusinessLayer.GetDynamicParameterList();

        //        string scenario = "";
        //        string lastTestCase = "";
        //        int totalSteps = dtRun.Rows.Count;
        //        Boolean isJavaScriptButton = false;
        //        for (int i = 0; i < totalSteps; i++)
        //        {


        //            scenario = dtRun.Rows[i]["Scenario"].ToString();
        //            currentUniqueName = "";
        //            currentUniquevalue = "";

        //            frame = int.Parse(dtRun.Rows[i]["frame"].ToString());

        //            controlType = dtRun.Rows[i]["Controltype"].ToString();

        //            elementID = dtRun.Rows[i]["ControlID"].ToString();
        //            elementName = dtRun.Rows[i]["ControlName"].ToString();
        //            controlText = dtRun.Rows[i]["ControlText"].ToString();
        //            data = dtRun.Rows[i]["DataValue"].ToString();
        //            testCase = dtRun.Rows[i]["TestCase"].ToString();
        //            webPageID = int.Parse(dtRun.Rows[i]["WebPageId"].ToString());
        //            action = dtRun.Rows[i]["Action"].ToString();
        //            title = dtRun.Rows[i]["Title"].ToString();
        //            index = int.Parse(dtRun.Rows[i]["Index"].ToString());

        //            startFrom = int.Parse(dtRun.Rows[i]["StartFrom"].ToString());
        //            EndOn = int.Parse(dtRun.Rows[i]["EndOn"].ToString());


        //            //BusinessLayer.LogTofile("", "", "", "", "", Environment.NewLine);
        //            //BusinessLayer.LogTofile("", "", "", "", "", Environment.NewLine);

        //            if (lastTestCase.Length == 0)
        //            {
        //                BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action);

        //                lastTestCase = testCase;
        //            }
        //            if (testCase != lastTestCase)
        //            {
        //                //BusinessLayer.LogTofile(Environment.NewLine);
        //                BusinessLayer.LogTofile("", "", "", "", "", "End step:(" + i.ToString() + ") " + title + ":" + lastTestCase + "  Action:" + action + Environment.NewLine);
        //                //BusinessLayer.LogTofile("=========================" + Environment.NewLine);
        //                BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action + Environment.NewLine);

        //                lastTestCase = testCase;

        //                if (pacing > 0)
        //                {
        //                    System.Threading.Thread.Sleep(pacing * 1000);
        //                    BusinessLayer.LogTofile("", "", "", "", "", "Waiting for :" + pacing + " seconds" + Environment.NewLine);
        //                }

        //            }


        //            #region "windowslogon"
        //            if (controlType.ToLower() == "windowslogon")
        //            {
        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Element type is windowslogon, trying to clear cookies and cache");
        //                if (ie != null)
        //                {

        //                    ie.ClearCookies();
        //                    ie.ClearCache();
        //                    ie.Close();
        //                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Cleared cookies,cache. Trying to close all open sessions of IE");
        //                }
        //                #region Kill all IE instances
        //                System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("IExplore");
        //                foreach (System.Diagnostics.Process process in p)
        //                {
        //                    process.Kill();
        //                }
        //                BusinessLayer.LogTofile("", "", "", "", "", "All IE sessions closed. Getting username and password");

        //                #endregion

        //                string userName = UIHelper.GetUserNameAndPassword("u", data);
        //                string password = UIHelper.GetUserNameAndPassword("p", data);
        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Got username and password");
        //                System.Threading.Thread.Sleep(2000);
        //                UIHelper.WindowsLogon(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString(), userName, password);
        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Attatching to URL :" + targetURL);


        //                IE.AttachTo<IE>(Find.ByUrl(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString())).WaitForComplete(waitTimeOut);

        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Successfully attached");
        //            }
        //            #endregion

        //            if (controlType.ToLower() != "javascriptbutton" && controlType.ToLower() != "wait" && controlType.ToLower() != "waitforwebpage")
        //            {
        //                ie = Core.IdentifyWebPage((string)dtRun.Rows[i]["Title"].ToString(), targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString());
        //            }

        //            if (controlType.ToLower() == "wait")
        //            {
        //                if (data.Length == 0)
        //                    data = "1"; //wait for 1 second if wait not provided
        //                {
        //                }
        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + data + " )Seconds");
        //                System.Threading.Thread.Sleep(int.Parse(data) * 1000);
        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");

        //            }
        //            if (controlType.ToLower() == "waitforwebpage")
        //            {

        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + waitTimeOut + " )Seconds");
        //                IE.AttachTo<IE>(Find.ByTitle(data.Trim()), waitTimeOut);
        //                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");
        //            }

        //            verificationValue = dtRun.Rows[i]["VerificationValue"].ToString();

        //            if (action.ToLower() == "verify")
        //            {
        //                data = verificationValue;
        //            }
        //            #region Dynamic Data

        //            if (data.Contains("~"))
        //            {

        //                BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter encountered :" + currentUniqueName);

        //                paramDynamicParameters.Clear();
        //                currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link

        //                int startPos = currentUniqueName.IndexOf("~");
        //                currentUniqueName = currentUniqueName.Substring(startPos, data.IndexOf("~", startPos + 1) - startPos + 1);

        //                DataRow[] dtRows = dtDynamicParameter.Select("DynamicName= '" + currentUniqueName + "'");
        //                currentDynamicType = dtRows[0]["DynamicType"].ToString();
        //                currentDynamicFormat = dtRows[0]["Format"].ToString();

        //                drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);

        //                if (drDynamicValues.Length == 0)
        //                {


        //                    if (currentDynamicType.ToLower()!="string")
        //                    {
        //                        currentUniquevalue = UIHelper.GenerateDynamicValue(currentDynamicType, currentUniqueName, currentDynamicFormat);

        //                        if (currentUniquevalue.Length == 0)
        //                        {
        //                            throw new Exception("Unique value is not generated hence exiting");
        //                        }

        //                        BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter value is :" + currentUniquevalue);

        //                    }

        //                }
        //                #region Commented Code for Dynamic Parameters in Database

        //                //paramDynamicValues.Clear();
        //                //paramDynamicValues.Add(new SqlParameter("@ScenarioID", scenarioID));
        //                //paramDynamicValues.Add(new SqlParameter("@DynamicName", currentUniqueName));



        //                // DataTable dtDynamicValues = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
        //                // DataRow[] drDynamicValues = DynamicValues.Select("DynamicName='" +  currentUniqueName + "' AND " + " ScenarioID=" + scenarioID);

        //                #endregion
        //            }
        //            #endregion Dynamic Data
        //            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Current Element Type : " + controlType);

        //            switch (controlType.ToLower())
        //            {
        //                case "para":

        //                    #region PARA
        //                    if (action.ToLower() == "add" || (action.ToLower() == "verify"))
        //                    {


        //                        var para = Core.GetPara(ie, frame, elementName, elementID, controlText, -1);


        //                        if (para != null)
        //                        {
        //                            //todo need to handle text in logging
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", controlText).Replace("#webpage#", ie.Title));
        //                            data = para.Text;
        //                        }
        //                        else
        //                        {
        //                            //todo need to handle text in logging
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }


        //                        if (startFrom != -1 && EndOn != -1) // if entire data is not taken but the substrings
        //                        {
        //                            if (EndOn == -1) // take the entire data starting from the StartFrom
        //                            {
        //                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Extracting all characters from :" + startFrom.ToString() + " position");

        //                                data = data.Substring(startFrom);

        //                            }
        //                            else
        //                            {
        //                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Extracting: " + EndOn.ToString() + " characters from :" + startFrom.ToString() + " position");
        //                                data = data.Substring(startFrom, EndOn);

        //                            }
        //                        }
        //                        if (currentUniqueName.Length != 0) // non-dynamic parameter
        //                        {
        //                            #region commented code

        //                            //Database call
        //                            //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
        //                            //if (dtExists.Rows.Count == 0)
        //                            #endregion
        //                            if (drDynamicValues == null || drDynamicValues.Length == 0)
        //                            {

        //                                AddDynamicValue(currentUniqueName, data, scenarioID);
        //                            }

        //                        }




        //                    }

        //                    break;
        //                    #endregion
        //                case "autocomplete":
        //                    #region AutoComplete
        //                    if (action.ToLower() == "add")
        //                    {
        //                        CommonControlCalls.AutoComplete(ie, frame, elementName, elementID, index, data);
        //                    }
        //                    else if (action.ToLower() == "verify")
        //                    {
        //                        TextField autoComplete = Core.GetTextField(ie, frame, elementName, elementID, -1);
        //                        if (autoComplete != null)
        //                        {

        //                            logResult(verificationValue, autoComplete.Value, controlType, elementName, scenario, testCase, "NoName");
        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "autocomplete").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }

        //                    }
        //                    break;
        //                    #endregion AutoComplete
        //                case "image":

        //                    #region Image
        //                    if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
        //                    {


        //                        var img = Core.GetImage(ie, frame, elementName, elementID, index);

        //                        if (img != null)
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", img.IdOrName).Replace("#webpage#", ie.Title));

        //                            isJavaScriptButton = IsJavaScriptButton(dtRun, i);
        //                            if (data.ToLower() == "c" && isJavaScriptButton == false)
        //                            {
        //                                img.Click();
        //                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, waiting for page load");
        //                                ie.WaitForComplete(waitTimeOut);

        //                            }
        //                            else if (data.ToLower() == "c" && isJavaScriptButton == true)
        //                            {
        //                                img.ClickNoWait();
        //                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, not waiting for page load");

        //                            }
        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }

        //                    }

        //                    break;
        //                    #endregion
        //                case "button":

        //                    #region Button
        //                    if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
        //                    {


        //                        var button = Core.GetButton(ie, frame, elementName, elementID, -1);


        //                        if (button != null)
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", button.IdOrName).Replace("#webpage#", ie.Title));

        //                            isJavaScriptButton = IsJavaScriptButton(dtRun, i);
        //                            if (data.ToLower() == "c" && isJavaScriptButton == false)
        //                            {
        //                                button.Click();
        //                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, waiting for page load");
        //                                ie.WaitForComplete(waitTimeOut);

        //                            }
        //                            else if (data.ToLower() == "c" && isJavaScriptButton == true)
        //                            {
        //                                button.ClickNoWait();
        //                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, not waiting for page load");

        //                            }
        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }

        //                    }


        //                    #endregion
        //                    break;
        //                case "selectlist":

        //                    #region SelectList
        //                    if (action.ToLower() == "add" || (action.ToLower() == "verify"))
        //                    {

        //                        var selectList = Core.GetSelectList(ie, frame, elementName, elementID, -1);

        //                        if (selectList != null)
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", selectList.IdOrName).Replace("#webpage#", ie.Title));
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Searching for option :" + data);



        //                            if (action.ToLower() == "add")
        //                            {
        //                                var option = selectList.Option(Find.ByText(data));
        //                                if (option != null)
        //                                {
        //                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option value: " + data + " found");
        //                                    option.Select();
        //                                }
        //                                else
        //                                {
        //                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option " + data + " not found ");
        //                                }
        //                            }
        //                            else if (action.ToLower() == "verify")
        //                            {

        //                                logResult(verificationValue, selectList.SelectedOption.Text, controlType, elementName, scenario, testCase, "NoName");

        //                            }

        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }

        //                    }


        //                    #endregion
        //                    break;
        //                case "radiobutton":

        //                    #region RadioButton
        //                    WatiN.Core.RadioButton radioButton = null;

        //                    if ((action.ToLower() == "add" || (action.ToLower() == "verify")))
        //                    {
        //                        radioButton = Core.GetRadioButton(ie, frame, elementName, elementID, -1);
        //                        if (radioButton != null)
        //                        {
        //                            if (action.ToLower() == "add" && data.ToLower() == "c")
        //                            {
        //                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", radioButton.IdOrName).Replace("#webpage#", ie.Title));
        //                                radioButton.Click();
        //                                ie.WaitForComplete(waitTimeOut);
        //                                break;
        //                            }
        //                            else if (action.ToLower() == "verify")
        //                            {

        //                                logResult(verificationValue, radioButton.Checked.ToString(), controlType, elementName, scenario, testCase, "NoName");

        //                            }
        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }
        //                        System.Threading.Thread.Sleep(1000);

        //                    }
        //                    #endregion

        //                    break;
        //                case "textfield":

        //                    #region TextField
        //                    TextField txt = null;

        //                    if (action.ToLower() == "add" || (action.ToLower() == "verify"))
        //                    {
        //                        txt = Core.GetTextField(ie, frame, elementName, elementID, -1);
        //                        if (txt != null)
        //                        {
        //                            if (txt.Enabled == true)
        //                            {
        //                                txt.Focus();
        //                            }
        //                            BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", txt.IdOrName).Replace("#webpage#", ie.Title));

        //                            if (action.ToLower() == "add")
        //                            {

        //                                if (currentUniqueName.Length == 0) // non-dynamic parameter
        //                                {
        //                                    txt.Value = data;
        //                                }
        //                                else
        //                                {
        //                                    #region commented code

        //                                    //Database call
        //                                    //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
        //                                    //if (dtExists.Rows.Count == 0)
        //                                    #endregion
        //                                    if (drDynamicValues == null || drDynamicValues.Length == 0)
        //                                    {
        //                                        txt.Value = currentUniquevalue;
        //                                        AddDynamicValue(currentUniqueName, currentUniquevalue, scenarioID);
        //                                    }
        //                                    else
        //                                        txt.Value = drDynamicValues[0]["DynamicValue"].ToString();
        //                                }

        //                            }
        //                            if (action.ToLower() == "verify")
        //                            {
        //                                if (currentUniqueName.Length == 0) // non-dynamic parameter
        //                                {
        //                                    logResult(verificationValue, txt.Value, controlType, elementName, scenario, testCase, "NoName");
        //                                }
        //                                else
        //                                {
        //                                    if (drDynamicValues == null || drDynamicValues.Length == 0)
        //                                    {

        //                                        logResult("Dynamicvaluenotread", txt.Value, controlType, elementName, scenario, testCase, "NoName");
        //                                    }
        //                                    else
        //                                    {
        //                                        logResult(drDynamicValues[0]["DynamicValue"].ToString(), txt.Value, controlType, elementName, scenario, testCase, "NoName");

        //                                    }
        //                                }
        //                            }


        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }
        //                    }

        //                    #endregion
        //                    break;
        //                case "element]":
        //                    var ele = ie.Element(Find.ById(elementID));
        //                    ele.SetAttributeValue("value", data);
        //                    break;
        //                case "link":  //need to think about dynamic links
        //                    Link lnk = null;
        //                    isJavaScriptButton = IsJavaScriptButton(dtRun, i);
        //                    #region Link
        //                    if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
        //                    {
        //                        currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link
        //                        if (currentTableRow >= 0)
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", "Searching link in the web table");
        //                            lnk = targetTable.OwnTableRows[currentTableRow].Link(Find.ByText(new Regex(elementName)));
        //                            currentTableRow = -1; //reset the rownumber
        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", "Searching link  on the webpage");
        //                            lnk = Core.GetLink(ie, frame, elementName, elementID, index);

        //                        }

        //                        if (lnk != null)
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", lnk.Text).Replace("#webpage#", ie.Title));
        //                            if (data.ToLower() == "c" && isJavaScriptButton == false)
        //                            {
        //                                lnk.Click();
        //                                BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, waiting for page load");
        //                                ie.WaitForComplete(waitTimeOut);

        //                            }
        //                            else if (data.ToLower() == "c" && isJavaScriptButton == true)
        //                            {
        //                                lnk.ClickNoWait();
        //                                BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, not waiting for page load");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "Link").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                        }

        //                        ie.WaitForComplete(waitTimeOut);
        //                    }
        //                    #endregion
        //                    else
        //                    {
        //                        BusinessLayer.LogTofile("", "", "", "", "", messageverifyActionIgnore);
        //                    }

        //                    break;
        //                case "checkbox":
        //                    #region CheckBox
        //                    WatiN.Core.CheckBox checkbox = null;
        //                    checkbox = Core.GetChecKBox(ie, frame, elementName, elementID, -1);
        //                    if (checkbox != null)
        //                    {
        //                        BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", checkbox.IdOrName).Replace("#webpage#", ie.Title));

        //                        if (action.ToLower() == "add")
        //                        {

        //                            checkbox.Click();
        //                            ie.WaitForComplete(waitTimeOut);
        //                        }
        //                        else if (action.ToLower() == "verify")
        //                        {

        //                            logResult(verificationValue, checkbox.Checked.ToString(), controlType, elementName, scenario, testCase, "NoName");
        //                        }

        //                    }
        //                    else
        //                    {
        //                        BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                    }


        //                    #endregion

        //                    break;
        //                case "div":
        //                    var div = Core.GetDiv(ie, frame, elementName, elementID, -1);
        //                    div.Click();
        //                    break;
        //                case "navigateto":
        //                    #region navigateto
        //                    BusinessLayer.LogTofile("", "", "", "", "", "Action Navigateto");
        //                    drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
        //                    if (drDynamicValues.Length > 0)  // for dynamic values
        //                    {

        //                        BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
        //                        currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
        //                        if (!targetURL.EndsWith("/"))
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));
        //                            ie.GoTo(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));

        //                            IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
        //                            BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");

        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data.Replace(currentUniqueName, currentUniquevalue));
        //                            ie.GoTo(targetURL + data.Replace(currentUniqueName, currentUniquevalue));

        //                            IE.AttachTo<IE>(Find.ByUrl(targetURL + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
        //                            BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
        //                        }

        //                    }
        //                    else  //for normal urls
        //                    {
        //                        if (!targetURL.EndsWith("/"))
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data);
        //                            ie.GoTo(targetURL + "/" + data);

        //                            IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data)).WaitForComplete(waitTimeOut);

        //                            BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
        //                        }
        //                        else
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data);
        //                            ie.GoTo(targetURL + data);

        //                            IE.AttachTo<IE>(Find.ByUrl(targetURL + data)).WaitForComplete(waitTimeOut);
        //                            BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
        //                        }
        //                    }
        //                    ie.WaitForComplete(waitTimeOut);
        //                    break;

        //                    #endregion
        //                case "fireevent":

        //                    if (action.ToLower() == "add" || (action.ToLower() == "verify"))
        //                    {
        //                        BusinessLayer.LogTofile("", "", "", "", "", "Trying to fire event name=" + data);
        //                        ie.ActiveElement.FireEvent(data);
        //                        BusinessLayer.LogTofile("", "", "", "", "", "Event Fired Successfully");
        //                    }
        //                    break;
        //                case "javascriptbutton":
        //                    #region javascriptbutton
        //                    System.Threading.Thread.Sleep(2000);
        //                    BusinessLayer.LogTofile("", "", "", "", "", "Trying to access Javasript button=" + data);
        //                    if (action.ToLower() == "add" || (action.ToLower() == "verify"))
        //                    {
        //                        Boolean found = false;
        //                        for (int k = 0; k < attempts; k++)
        //                        {
        //                            System.Threading.Thread.Sleep(2000);
        //                            found = UIHelper.JavaScriptButtons(ie, data);
        //                            {
        //                                if (found == true)
        //                                {
        //                                    BusinessLayer.LogTofile("", "", "", "", "", "Javascript button clicked");
        //                                    break;
        //                                }
        //                            }

        //                        }
        //                        if (found == false)
        //                        {
        //                            BusinessLayer.LogTofile("", "", "", "", "", "Javascript button not clicked");
        //                        }
        //                    }
        //                    break;
        //                    #endregion
        //                case "keyboard":
        //                    CommonControlCalls.KeyBoard(ie, frame, elementName, elementID, index, data, waitTimeOut);
        //                    break;
        //                case "searchwebtablerow":
        //                    #region searchwebtablerow
        //                    if (action.ToLower() == "add" || (action.ToLower() == "verify"))
        //                    {
        //                        BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable for data: " + data + " " + " value:" + currentUniquevalue);
        //                        currentUniquevalue = data;
        //                        if (currentUniqueName.Length > 0)  //Need to code for non-dyanmic tables
        //                        {
        //                            //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
        //                            drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
        //                            if (drDynamicValues.Length > 0)
        //                            {
        //                                BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
        //                                currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
        //                            }

        //                        }
        //                        currentTableRow = -1;

        //                        for (int k = 0; k < attempts; k++)
        //                        {
        //                            targetTable = Core.GetWebTable(ie, frame, currentUniquevalue, index);
        //                            if (targetTable != null)
        //                            {
        //                                BusinessLayer.LogTofile("", "", "", "", "", "Got Webtable for data : " + data);
        //                                //  logTofile("Inner HTML: " + targetTable.InnerHtml);
        //                                break;
        //                            }

        //                        }
        //                        BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable row for data : " + data);
        //                        for (int z = 0; z < attempts; z++)
        //                        {
        //                            currentTableRow = Core.GetWebTableRow(targetTable, currentUniquevalue);
        //                            if (currentTableRow != -1)
        //                            {
        //                                BusinessLayer.LogTofile("", "", "", "", "", "Got webtable row for data : " + data);
        //                                break;
        //                            }
        //                            else
        //                            {
        //                                BusinessLayer.LogTofile("", "", "", "", "", "Did not find the web table row for data  : " + data);
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    break;
        //                    #endregion
        //                case "windowslogon":
        //                    BusinessLayer.LogTofile("", "", "", "", "", "Windows logon");  // this is handled above the select clauses
        //                    break;
        //                case "webtable":
        //                    Table table = null;
        //                    if (elementName.Trim().Length > 0)
        //                    {
        //                        table = Core.GetWebTable(ie, frame, elementName, index);
        //                    }
        //                    else if (elementID.Trim().Length > 0)
        //                    {
        //                        table = Core.GetWebTable(ie, frame, elementID, index);
        //                    }

        //                    if (table != null)
        //                    {

        //                        //webtableName = elementID.Length > 0 ? elementID : elementName;
        //                        //webtableName = webtableName.Replace(" ", "_");
        //                        //BusinessLayer.LogTofile(messageFoundControl.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName.Replace("#webpage#", ie.Title)));
        //                        List<SqlParameter> paramlst = new List<SqlParameter>(0);

        //                        paramlst.Add(new SqlParameter("@TableName", data + "_" + testCase));
        //                        DataTable webData = DataAccessLayer.GetReturnDataTable("[GetWebtableData]", paramlst);


        //                        for (int tabRows = 0; tabRows < webData.Rows.Count; tabRows++)
        //                        {
        //                            int rowNo = int.Parse(webData.Rows[tabRows]["Rowno"].ToString());
        //                            int columnNo = int.Parse(webData.Rows[tabRows]["ColumnNo"].ToString());
        //                            string columnName = webData.Rows[tabRows]["columnName"].ToString();

        //                            string expectedValue = webData.Rows[tabRows]["Value"].ToString();

        //                            try
        //                            {
        //                                string actualValue = table.OwnTableRows[rowNo].OwnTableCells[columnNo].Text;
        //                                logResult(expectedValue, actualValue, controlType, elementName, scenario, testCase, columnName);
        //                            }
        //                            catch
        //                            {

        //                                logResult(expectedValue, "Valuenotread", controlType, elementName, scenario, testCase, columnName);
        //                            }
        //                        }

        //                    }
        //                    else
        //                    {
        //                        BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
        //                    }
        //                    break;
        //                default:
        //                    BusinessLayer.LogTofile("", "", "", "", "", "Invalid controltype encountered: " + controlType);
        //                    break;
        //            }

        //        }



        //    }

        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        ie.ClearCookies();
        //        ie.ClearCache();
        //        ie.Close();
        //        System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("IExplore");
        //        foreach (System.Diagnostics.Process process in p)
        //        {
        //            process.Kill();
        //        }
        //    }
        //}

        private int GetScenarioID(TreeNode node)
        {
            if (node.Parent != null) //The child node has been checked so need to reset the node to parent
            {
                node = node.Parent;
            }
            int scenarioID = int.Parse(lstScenarios[node.Text].ToString());
            return scenarioID;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (File.Exists(resultFile))
                {

                    File.Delete(resultFile);
                }

                if (File.Exists(logFile))
                {
                    File.Delete(logFile);
                }

                contextMenuStrip1.Items["run"].Enabled = false;
                if (currentNode != null)
                {
                    showBrowserOptionForm();
                    BusinessLayer.RunScenario( BrowserOptions.broptions, GetScenarioID(currentNode));
                    BusinessLayer.LogTofile("", "", "", "", "", "Scenario :" + currentNode.Text + " executed successfully");
                }
                else
                {
                    UIHelper.StopMessage("Select the scenario");
                }
                contextMenuStrip1.Items["run"].Enabled = true;
            }

            catch (Exception ex)
            {
                contextMenuStrip1.Items["run"].Enabled = true;
                BusinessLayer.LogTofile("", "", "", "", "", "Exception occured: " + ex.Message);
            }
        }

        //private void AddDynamicValue(string dynamicName, string dynamicValue, int scenarioID)
        //{


        //    try
        //    {
        //        DataRow dr = dtDynamicValues.NewRow();

        //        dr["Dynamicvalue"] = dynamicValue;
        //        dr["DynamicName"] = dynamicName;
        //        dr["ScenarioID"] = scenarioID;
        //        dtDynamicValues.Rows.Add(dr);

        //        //    List<SqlParameter> para = new List<SqlParameter>(0);
        //        //    para.Add(new SqlParameter("@DynamicName", dynamicName));
        //        //    para.Add(new SqlParameter("@DynamicValue", dynamicValue));
        //        //    para.Add(new SqlParameter("@ScenarioID", scenarioID));
        //        //    DataAccessLayer.GetReturnDataTable("DynamicValueAdd", para);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private DataRow[] GetDynamicValue(string dynamicName, int scenarioID)
        //{
        //    try
        //    {
        //        return dtDynamicValues.Select("DynamicName='" + dynamicName + "' AND " + " ScenarioID=" + scenarioID);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        private void gdvSelectedScenarios_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gdvSelectedScenarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().ToLower() == "delete")
            {
                gdvSelectedScenarios.Rows.RemoveAt(currentRowForSelectedScenario);
            }
        }

        private void gdvSelectedScenarios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowForSelectedScenario = e.RowIndex;

        }

        public void logResult(string expected, string actual, string controlType, string controlName, string scenario, string testCase, string friendlyName)
        {
            try
            {


                string result = "Pass";
                if (expected.ToLower() != actual.ToLower())
                {
                    result = "Fail";
                }

                string columnHeader = '\u0022' + "Scenario" + '\u0022' + "," + '\u0022' + "Testcase" + '\u0022' + "," + '\u0022' + "ControlType" + '\u0022' + ","
                                   + '\u0022' + "ControlName" + '\u0022' + "," + "FriendlyName" + '\u0022' + "," + '\u0022' + "Expected" + '\u0022' + "," + '\u0022' + "Actual" + '\u0022' + "," + '\u0022' + "Result" + '\u0022' + ",";
                string comparsion = "";

                if (!System.IO.File.Exists(resultFile))
                {
                    System.IO.File.AppendAllText(resultFile, columnHeader + Environment.NewLine);
                }

                comparsion = '\u0022' + scenario + '\u0022' + "," + '\u0022' + testCase + '\u0022' + "," + '\u0022' + controlType + '\u0022' + ","
                              + '\u0022' + controlName + '\u0022' + "," + friendlyName + '\u0022' + "," + expected + '\u0022' + "," + '\u0022' + actual + '\u0022' + "," + '\u0022' + result + '\u0022' + ",";

                System.IO.File.AppendAllText(resultFile, comparsion + Environment.NewLine);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void deleteStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode lastSelectedParentNode = null;

            if (UIHelper.ConfirmMessage("Do you want to delete", "Delete confirmation") == DialogResult.No)
            {
                return;
            }
            if (currentNode == null)
            {

                UIHelper.ShowMessage("Please select the node to delete", "Message");
                return;
            }
            try
            {

                List<SqlParameter> param = new List<SqlParameter>(0);

                if (currentNode != null && currentNode.Parent != null) //only when steps are selected
                {
                    lastSelectedParentNode = currentNode.Parent;
                    int scenarioID = GetScenarioID(currentNode);

                    int scenarioDetailID = int.Parse(currentNode.Tag.ToString());
                    param.Add(new SqlParameter("@ScenarioID", scenarioID));
                    param.Add(new SqlParameter("@ScenarioDetailID", scenarioDetailID));
                    param.Add(new SqlParameter("@Sequence", currentNode.Index + 1));

                    DataAccessLayer.InsertData("[ScenariosDetailDelete]", param);
                    UIHelper.SaveMessage();

                    GetScenarioDetails(currentNode.Parent);
                    currentNode = lastSelectedParentNode;

                }

                else if (currentNode != null && currentNode.Parent == null) //When the main node is deleted
                {
                    lastSelectedParentNode = currentNode;
                    int scenarioID = GetScenarioID(currentNode);

                    param.Add(new SqlParameter("@ScenarioID", scenarioID));

                    DataAccessLayer.InsertData("[ScenariosMasterDelete]", param);
                    UIHelper.SaveMessage();
                    currentNode.Remove();

                    if (tvwScenarios.Nodes.Count > 0)
                    {
                        currentNode = tvwScenarios.Nodes[lastSelectedParentNode.Index - 1];
                        currentNode.Expand();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nupdnPosition_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkRunAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnRunAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(resultFile))
                {
                    File.Delete(resultFile);
                }

                if (File.Exists(logFile))
                {
                    File.Delete(logFile);
                }

                if (UIHelper.ConfirmMessage("Do you want to run all scenarios", "Confirm") == DialogResult.Yes)
                {
                    //dtDynamicValues.Rows.Clear();
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@ALL", "Y"));

                    DataTable dt = DataAccessLayer.GetReturnDataTable("[GetScenariosAll]", param);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BusinessLayer.RunScenario(BrowserOptions.broptions, int.Parse(dt.Rows[i]["ID"].ToString()));
                        BusinessLayer.LogTofile("", "", "", "", "", "Scenario :" + dt.Rows[i]["ID"].ToString() + " executed successfully");
                    }

                }
                BusinessLayer.LogTofile("", "", "", "", "", "All scenarios executed successfully");


                MessageBox.Show("Completed successfully");
            }
            catch (Exception ex)
            {

                BusinessLayer.LogTofile("", "", "", "", "", "Error occured" + ex.Message);

                MessageBox.Show("Completed with error");
            }
        }




        private void GetScenarioDetails(TreeNode currentNode)
        {


            if (currentNode != null && currentNode.Parent == null)
            {

                int sequenceId = GetScenarioID(currentNode);

                List<SqlParameter> para = new List<SqlParameter>(0);
                para.Add(new SqlParameter("@ScenarioID", sequenceId));
                DataTable dt = DataAccessLayer.GetReturnDataTable("[GetScenarioSteps]", para);
                currentNode.Nodes.Clear();
                int k = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    k = i + 1;

                    TreeNode newNode = currentNode.Nodes.Add(k.ToString() + "-" + dt.Rows[i]["UniqueName"].ToString() + ":" + dt.Rows[i]["TestCase"].ToString() +
                        ":" + dt.Rows[i]["Action"].ToString());
                    newNode.Tag = dt.Rows[i]["ScenarioDetailID"].ToString();
                }

            }

            else
            {
                UIHelper.ShowMessage("Please select the scenario", "Message");
            }
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (currentNode.Tag == null)
            {
                return;
            }
            else

                ShowDetails(int.Parse(currentNode.Tag.ToString()));
        }

        private void ShowDetails(int scenarioID)
        {
            int scenarioDetailID = scenarioID;

            List<SqlParameter> parameters = new List<SqlParameter>(0);
            parameters.Add(new SqlParameter("@ScenarioDetailID", scenarioDetailID));

            DataTable dt = DataAccessLayer.GetReturnDataTable("GetDataFromScenarioDetail", parameters);

            if (dt.Rows.Count > 0)
            {

                DataTable dtControls = BusinessLayer.GetWebPageControlsAndData(int.Parse(dt.Rows[0]["WebPageId"].ToString()),
                     dt.Rows[0]["TestCase"].ToString(), dt.Rows[0]["Action"].ToString());

                gdvSelectedControls.Visible = true;
                gdvSteps.Visible = false;
                gdvSelectedControls.Rows.Clear();
                BusinessLayer.ShowWebPageControlsAndData(dtControls, gdvSelectedControls, dt.Rows[0]["Action"].ToString());
                gdvSelectedControls.Columns["PageDataID"].Visible = false;
                gdvSelectedControls.Columns["OriginalDATA"].Visible = false;
                gdvSelectedControls.Columns["originalVerificationData"].Visible = false;
                gdvSelectedControls.Columns["DataName"].Visible = false;


            }
        }

        private void gdvSelectedControls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gdvSelectedControls_DoubleClick(object sender, EventArgs e)
        {
            gdvSelectedControls.Visible = false;
            gdvSteps.Visible = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (testCaseList == null)
            {
                UIHelper.StopMessage("Please get the test case list first");
                return;
            }
            DataRow[] drCol = testCaseList.Select("UNiqueName='" + dnWebpages.Text + "'");

            if (drCol.Length > 0)
            {

                gdvSteps.DataSource = null;
                DataTable dt = new DataTable();

                for (int i = 0; i < drCol[0].Table.Columns.Count; i++)
                {
                    dt.Columns.Add(drCol[0].Table.Columns[i].ColumnName);
                }


                foreach (DataRow dr in drCol)
                {
                    dt.ImportRow(dr);
                }

                gdvSteps.DataSource = dt;
                gdvSteps.Columns["WebpageID"].Visible = false;
                gdvSteps.Columns["URL"].Visible = false;
                gdvSteps.Columns["ID"].Visible = false;
                gdvSteps.Columns["Notes"].Visible = false;
            }
            else
            {
                UIHelper.ShowMessage("No steps found", "Message");
            }
        }

        private void chkAllScenarios_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllScenarios.Checked == true)
            {
                LoadScenarios("Y");
            }
            else
            {
                LoadScenarios("N");
            }

        }

        private Boolean IsJavaScriptButton(DataTable dt, int rowNo)
        {

            rowNo = rowNo + 1;

            BusinessLayer.LogTofile("", "", "", "", "", "Checking for Javascript button. Row no is : " + rowNo.ToString());
            BusinessLayer.LogTofile("", "", "", "", "", "Filter criteria is :" + "rowno >" + rowNo + " AND controltype <>'wait'");
            DataRow[] dr = dt.Select("rowno >" + rowNo + " AND controltype <>'wait'");

            if (dr.Length == 0) // no rows found
            {
                BusinessLayer.LogTofile("", "", "", "", "", "Reached EOF");
                return false;
            }
            if (dr[0]["controltype"].ToString().ToLower() == "javascriptbutton") //check only the first row
            {
                BusinessLayer.LogTofile("", "", "", "", "", "Found Javascript Button");
                return true;
            }
            else
            {
                BusinessLayer.LogTofile("", "", "", "", "", "No Javascript Button, control type is :" + dr[0]["controltype"].ToString());

                return false;
            }
        }

        private void gdvSteps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gdvSteps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                TreeNode node = currentNode;
                if (node == null)
                {
                    UIHelper.StopMessage("Please select the scenario");
                    return;
                }

                if (currentNode.Parent != null) //if child node is selected then select its parent node
                {
                    node = currentNode.Parent;

                }
                currentScenarioID = int.Parse(lstScenarios[node.Text].ToString());

                DataRow[] dr = scenarios.Select("ID=" + currentScenarioID);
                if (dr[0]["Closed"].ToString().ToLower() == "y")
                {
                    UIHelper.StopMessage("This scenario is closed cannot add");
                    return;
                }



                string uniqueName = UIHelper.GetGridColumnValue(gdvSteps, e.RowIndex, "UniqueName");
                string testCase = UIHelper.GetGridColumnValue(gdvSteps, e.RowIndex, "TestCase");
                int webpageID = int.Parse(UIHelper.GetGridColumnValue(gdvSteps, e.RowIndex, "WebPageID"));
                string action = UIHelper.GetGridColumnValue(gdvSteps, e.RowIndex, "Action");

                BusinessLayer.AddScenarioDetail(currentScenarioID, webpageID, testCase, action, int.Parse(nUpDownPosition.Value.ToString()));
                UIHelper.SaveMessage();
                currentNode.Nodes.Add(uniqueName + ":" + testCase, uniqueName + ":" + testCase + ":" + action);
                GetScenarioDetails(node);
            }
            catch (Exception ex)
            {

                UIHelper.StopMessage(ex.Message);
            }

        }

        private void nUpDownPosition_ValueChanged(object sender, EventArgs e)
        {
            TreeNode node = currentNode; ;

            if (currentNode.Parent != null) //if child node is selected then select its parent node
            {
                node = currentNode.Parent;

            }

            if (int.Parse(nUpDownPosition.Value.ToString()) > node.Nodes.Count + 1)
            {
                nUpDownPosition.Value--;
            }
        }
        public void showBrowserOptionForm()
        {
            BrowserOptions form = new BrowserOptions();
            form.ShowDialog();
            string browserSelected = BrowserOptions.broptions;
            if (browserSelected == "" || browserSelected == null)
            {
                // MessageBox.Show("Browser was not specified hence aborting");
                return;
            }
        }
    }
}
