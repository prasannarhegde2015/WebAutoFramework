#region Comments
#region 10-Dec
//Added method WebPageDelete
#endregion
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WatiN.Core;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;

namespace WebAutomation
{
    static class BusinessLayer
    {
        private static string _currentUniqueValue;
        public static string propertycurrentUniqueValue
        {
            get { return _currentUniqueValue; }
            set { _currentUniqueValue = value; }
        }
        static string messageFoundControl = "Found  #controltype#  identified by #name# on WebPage: #webpage#";
        static string messageControlNotFound = "Did not find  #controltype#  identified by #name# on WebPage: #webpage#";
        static string messageverifyActionIgnore = "Action is verify but control not selected for verification";
      
        static DataTable dtDynamicValues = new DataTable();
        static DataRow[] drDynamicValues = null;

        public  enum CompareType
        {
            Equals, Contains
        };
        public static DataTable GetWebPageControlsAndData(int webPageID, string testCase, string action)
        {

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>(0);
                parameters.Add(new SqlParameter("@WebpageID", webPageID));
                parameters.Add(new SqlParameter("@Testcase", testCase));
                parameters.Add(new SqlParameter("@AddorVerfiy", action));

                return DataAccessLayer.GetReturnDataTable("GetWebPageControlsAndData", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void ShowWebPageControlsAndData(DataTable dt, DataGridView gdvSelectedControls, string addOrVerify)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    gdvSelectedControls.Rows.Add(1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string columnName = dt.Columns[j].ColumnName;
                        gdvSelectedControls.Rows[i].Cells[columnName].Value = dt.Rows[i][columnName].ToString();
                    }


                    if (addOrVerify.ToLower() == "add")
                    {
                        gdvSelectedControls.Rows[i].Cells["Data"].Value = gdvSelectedControls.Rows[i].Cells["OriginalData"].Value;
                    }
                    else
                    {
                        gdvSelectedControls.Rows[i].Cells["Data"].Value = gdvSelectedControls.Rows[i].Cells["OriginalVerificationData"].Value;
                    }


                    string idAttribute = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlID");

                    string nameAttribute = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlName");
                    string textAttribute = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlText");
                    string valueAttribute = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlValue");

                    if (idAttribute.Length > 0)
                    {
                        gdvSelectedControls.Rows[i].Cells["Identifier"].Value = "ID: " + idAttribute;
                    }
                    else if (nameAttribute.Length > 0)
                    {
                        gdvSelectedControls.Rows[i].Cells["Identifier"].Value = "Name: " + nameAttribute;
                    }
                    else if (textAttribute.Length > 0)
                    {
                        gdvSelectedControls.Rows[i].Cells["Identifier"].Value = "Text: " + textAttribute;
                    }
                    else if (valueAttribute.Length > 0)
                    {
                        gdvSelectedControls.Rows[i].Cells["Identifier"].Value = "Value: " + valueAttribute;
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetControlList()
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter>(0);
                return DataAccessLayer.GetReturnDataTable("GetControlList", paramList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetDynamicParameterList()
        {
            try
            {
                return DataAccessLayer.GetReturnDataTable("[GetDynamicParameterList]", new List<SqlParameter>(0));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetRunData(int scenarioID)
        {

            try
            {
                List<SqlParameter> para = new List<SqlParameter>(0);
                para.Add(new SqlParameter("@ScenarioID", scenarioID));
                return DataAccessLayer.GetReturnDataTable("GetDataForRun", para);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetWebPageIdOnly(int scenarioID)
        {

            try
            {
                List<SqlParameter> para = new List<SqlParameter>(0);
                para.Add(new SqlParameter("@ScenarioID", scenarioID));
                return DataAccessLayer.GetReturnDataTable("GetWebPageIDOnly", para);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetWebPageURLs(int WebPageID)
        {

            try
            {
                List<SqlParameter> para = new List<SqlParameter>(0);
                para.Add(new SqlParameter("@WebPageID", WebPageID));
                return DataAccessLayer.GetReturnDataTable("GetWebPageURL", para);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetWebpages()
        {

            try
            {
                List<SqlParameter> para = new List<SqlParameter>(0);
                return DataAccessLayer.GetReturnDataTable("GetWebPages", para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataTable GetMstDynamicParameters()
        {

            try
            {
                List<SqlParameter> para = new List<SqlParameter>(0);
                return DataAccessLayer.GetReturnDataTable("[GetDynamicParameterList]", para);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RenameTestCase(int currentWebPageID, string oldTestCase, string newTestCase, string action)
        {

            try
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@WebpageID", currentWebPageID));

                DataTable dt = DataAccessLayer.GetReturnDataTable("[GetTestCaseList]", param);
                DataRow[] dr = dt.Select("Testcase='" + newTestCase + "' AND Action='" + action + "'");

                if (dr.Length > 0)
                {
                    UIHelper.StopMessage("This name is already in use, select another name");
                    return;
                }

                List<SqlParameter> update = new List<SqlParameter>();
                update.Add(new SqlParameter("@WebpageID", currentWebPageID));
                update.Add(new SqlParameter("@OldTestCase", oldTestCase));
                update.Add(new SqlParameter("@NewTestCase", newTestCase));
                update.Add(new SqlParameter("@Action", action));
                DataAccessLayer.InsertData("RenameTestCase", update);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void DeleteTestCase(int currentWebPageID, string testCase, string action)
        {

            try
            {

                List<SqlParameter> update = new List<SqlParameter>();
                update.Add(new SqlParameter("@WebpageID", currentWebPageID));
                update.Add(new SqlParameter("@TestCase", testCase));
                update.Add(new SqlParameter("@action", action));
                DataAccessLayer.InsertData("DeleteTestCase", update);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable GetScenariosForWebPageAndTestCase(int currentWebPageID, string testCase, string action)
        {
            try
            {

                List<SqlParameter> update = new List<SqlParameter>();
                update.Add(new SqlParameter("@WebpageID", currentWebPageID));
                update.Add(new SqlParameter("@TestCase", testCase));
                update.Add(new SqlParameter("@action", action));

                return DataAccessLayer.GetReturnDataTable("GetScenariosForWebPageAndTestCase", update);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataTable WebPageGet(int currentPageID)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>(0);
                SqlParameter param = new SqlParameter("@WebpageID", currentPageID);
                parameters.Add(param);
                return DataAccessLayer.GetReturnDataTable("WebPageGet", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void WebPageDelete(int currentPageID)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>(0);
                SqlParameter param = new SqlParameter("@WebpageID", currentPageID);
                parameters.Add(param);
                DataAccessLayer.InsertData("DeleteWebPageRecord", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static DataTable CheckControlUsage(int webPageID, string controlid, string controlname)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>(0);
                parameters.Add(new SqlParameter("@WebPageID", webPageID));
                parameters.Add(new SqlParameter("@controlid", controlid));
                parameters.Add(new SqlParameter("@controlname", controlname));


                return DataAccessLayer.GetReturnDataTable("CheckControlNameUsage", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void LogTofile(string stepNo, string testCase, string controlType, string controlName, string friendlyName, string stxtMsg)
        {
            string logFile = System.Configuration.ConfigurationManager.AppSettings["logpath"];
            char delim = '\u0022';
            string[] ColumnNames = new string[] { "Stepno", "Testcase", "ControlType", "ControlName", "FriendlyName", "Comment" };
            StringBuilder sb = new StringBuilder();
            foreach (string incols in ColumnNames)
            {
                sb.Append(delim + incols + delim);
                sb.Append(",");
            }
            string columnHeader = sb.ToString();
            sb.Clear();
            if (!System.IO.File.Exists(logFile))
            {
                System.IO.File.AppendAllText(logFile, columnHeader + Environment.NewLine);
            }
            string[] ColumnValues = new string[] { stepNo, testCase, controlType, controlName, friendlyName, stxtMsg };
            foreach (string incols in ColumnValues)
            {
                sb.Append(delim + incols + delim);
                sb.Append(",");
            }
            string value = sb.ToString();
            sb.Clear();
            System.IO.File.AppendAllText(logFile, value);
            System.IO.File.AppendAllText(logFile, Environment.NewLine);
           
        }

        public static void AddScenarioMaster(string scenarioName, string notes)
        {

            try
            {
                List<SqlParameter> paramters = new List<SqlParameter>(0);
                paramters.Add(new SqlParameter("@Scenario", scenarioName));
                paramters.Add(new SqlParameter("@Notes", notes));

                DataAccessLayer.InsertData("ScenarioAdd", paramters);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void AddScenarioDetail(int currentScenarioID, int webpageID, string testCase, string action, int sequence)
        {

            try
            {
                List<SqlParameter> parammlist = new List<SqlParameter>(0);

                parammlist.Add(new SqlParameter("@ScenarioID", currentScenarioID));
                parammlist.Add(new SqlParameter("@WebPageID", webpageID));
                parammlist.Add(new SqlParameter("@TestCase", testCase));
                parammlist.Add(new SqlParameter("@Action", action));
                if (sequence > 0)
                {
                    parammlist.Add(new SqlParameter("@sequence", sequence));
                }

                DataAccessLayer.InsertData("[ScenariosDetailAdd]", parammlist);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void ScenariosDeleteTemps()
        {

            try
            {
                List<SqlParameter> paramters = new List<SqlParameter>(0);

                DataAccessLayer.InsertData("ScenariosDeleteTemps", paramters);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static DataTable GetScenarioMasterDetails(string scenarioName)
        {

            try
            {
                List<SqlParameter> paramters = new List<SqlParameter>(0);
                paramters.Add(new SqlParameter("@Scenario", scenarioName));

                return DataAccessLayer.GetReturnDataTable("GetScenarioMasterDetails", paramters);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #region RunScenario
        public static void RunScenario(string br, int scenarioID)
        {

            // Ask user for which Browser to Execute

            switch (br.ToLower())
            {
                case "internet explorer":
                    {

                        # region IE

                        IE ie = null;

                        Table targetTable = null;
                        int frame = -1;
                        Dictionary<string, string> uniqueString = new Dictionary<string, string>();
                        int waitTimeOut = int.Parse(UIHelper.GetConfigurationValue("waittime"));
                        int attempts = int.Parse(UIHelper.GetConfigurationValue("attempts"));
                        int pacing = int.Parse(UIHelper.GetConfigurationValue("pacing"));
                        string targetURL = UIHelper.GetConfigurationValue("targetURL");

                        dtDynamicValues.Rows.Clear();
                        dtDynamicValues.Columns.Clear();
                        dtDynamicValues.Columns.Add("ScenarioID");
                        dtDynamicValues.Columns.Add("DynamicName");
                        dtDynamicValues.Columns.Add("DynamicValue");



                        try
                        {
                            //int scenarioID = -1;

                            //logTofile("Getting scenario ID ");
                            //scenarioID = GetScenarioID(currentNode);
                            BusinessLayer.LogTofile("", "", "", "", "", "Scenario ID is  " + scenarioID.ToString());

                            string currentUniqueName = "";

                            string currentUniquevalue = "";
                            string currentDynamicType = "";
                            string currentDynamicFormat = "";
                            int webPageID = -1;
                            string action = "";
                            int index = -1;
                            string verificationValue = "";

                            BusinessLayer.LogTofile("", "", "", "", "", "Getting the data for Scenario");
                            DataTable dtRun = BusinessLayer.GetRunData(scenarioID);
                            BusinessLayer.LogTofile("", "", "", "", "", "Scenario has total : " + dtRun.Rows.Count.ToString() + " actions");
                            if (dtRun.Rows.Count == 0)
                            {
                                UIHelper.StopMessage("No data to run");
                                return;
                            }
                            string controlType, elementID, elementName, controlText, controlValue, data, testCase, title = "";
                            string ignorePrefix, ignoreSuffix, visible = "";
                            int currentTableRow = -1;

                            List<SqlParameter> paramDynamicParameters = new List<SqlParameter>(0);
                            List<SqlParameter> paramDynamicValues = new List<SqlParameter>(0);


                            //Database call needs to be deleted
                            //List<SqlParameter> paramDelete = new List<SqlParameter>(0);
                            //paramDelete.Add(new SqlParameter("@ScenarioID", scenarioID));
                            //DataAccessLayer.InsertData("DeleteDynamicValues", paramDelete);


                            DataTable dtDynamicParameter = BusinessLayer.GetDynamicParameterList();

                            string scenario = "";
                            string lastTestCase = "";
                            int totalSteps = dtRun.Rows.Count;
                            Boolean isJavaScriptButton = false;
                            for (int i = 0; i < totalSteps; i++)
                            {


                                scenario = dtRun.Rows[i]["Scenario"].ToString();
                                currentUniqueName = "";
                                currentUniquevalue = "";

                                frame = int.Parse(dtRun.Rows[i]["frame"].ToString());

                                controlType = dtRun.Rows[i]["Controltype"].ToString();

                                elementID = dtRun.Rows[i]["ControlID"].ToString();
                                elementName = dtRun.Rows[i]["ControlName"].ToString();
                                controlText = dtRun.Rows[i]["ControlText"].ToString();
                                controlValue = dtRun.Rows[i]["controlValue"].ToString();

                                data = dtRun.Rows[i]["DataValue"].ToString();
                                testCase = dtRun.Rows[i]["TestCase"].ToString();
                                webPageID = int.Parse(dtRun.Rows[i]["WebPageId"].ToString());
                                action = dtRun.Rows[i]["Action"].ToString();
                                title = dtRun.Rows[i]["Title"].ToString();
                                index = int.Parse(dtRun.Rows[i]["Index"].ToString());

                                ignorePrefix = dtRun.Rows[i]["IgnorePrefix"].ToString();
                                ignoreSuffix = dtRun.Rows[i]["IgnoreSuffix"].ToString();
                                visible = dtRun.Rows[i]["Visible"].ToString();

                                if (lastTestCase.Length == 0)
                                {
                                    BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action);

                                    lastTestCase = testCase;
                                }
                                if (testCase != lastTestCase)
                                {
                                    //BusinessLayer.LogTofile(Environment.NewLine);
                                    BusinessLayer.LogTofile("", "", "", "", "", "End step:(" + i.ToString() + ") " + title + ":" + lastTestCase + "  Action:" + action + Environment.NewLine);
                                    //BusinessLayer.LogTofile("=========================" + Environment.NewLine);
                                    BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action + Environment.NewLine);

                                    lastTestCase = testCase;

                                    if (pacing > 0)
                                    {
                                        System.Threading.Thread.Sleep(pacing * 1000);
                                        BusinessLayer.LogTofile("", "", "", "", "", "Waiting for :" + pacing + " seconds" + Environment.NewLine);
                                    }

                                }


                                #region "windowslogon"
                                if (controlType.ToLower() == "windowslogon")
                                {
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Element type is windowslogon, trying to clear cookies and cache");
                                    if (ie != null)
                                    {

                                        ie.ClearCookies();
                                        ie.ClearCache();
                                        ie.Close();
                                        BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Cleared cookies,cache. Trying to close all open sessions of IE");
                                    }
                                    #region Kill all IE instances
                                    System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("IExplore");
                                    foreach (System.Diagnostics.Process process in p)
                                    {
                                        process.Kill();
                                    }
                                    BusinessLayer.LogTofile("", "", "", "", "", "All IE sessions closed. Getting username and password");

                                    #endregion

                                    string userName = UIHelper.GetUserNameAndPassword("u", data);
                                    string password = UIHelper.GetUserNameAndPassword("p", data);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Got username and password");
                                    System.Threading.Thread.Sleep(2000);
                                    UIHelper.WindowsLogon(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString(), userName, password);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Attatching to URL :" + targetURL);


                                    IE.AttachTo<IE>(Find.ByUrl(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString())).WaitForComplete(waitTimeOut);

                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Successfully attached");
                                }
                                #endregion

                                if (controlType.ToLower() != "javascriptbutton" && controlType.ToLower() != "wait" && controlType.ToLower() != "waitforwebpage")
                                {
                                    ie = Core.IdentifyWebPage((string)dtRun.Rows[i]["Title"].ToString(), targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString());
                                }

                                if (controlType.ToLower() == "wait")
                                {
                                    if (data.Length == 0)
                                        data = "1"; //wait for 1 second if wait not provided
                                    {
                                    }
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + data + " )Seconds");
                                    System.Threading.Thread.Sleep(int.Parse(data) * 1000);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");

                                }
                                if (controlType.ToLower() == "waitforwebpage")
                                {

                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + waitTimeOut + " )Seconds");
                                    IE.AttachTo<IE>(Find.ByTitle(data.Trim()), waitTimeOut);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");
                                }

                                verificationValue = dtRun.Rows[i]["VerificationValue"].ToString();

                                if (action.ToLower() == "verify")
                                {
                                    data = verificationValue;
                                }
                                #region Dynamic Data

                                if (data.Contains("~"))
                                {

                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter encountered :" + currentUniqueName);

                                    paramDynamicParameters.Clear();
                                    currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link

                                    int startPos = currentUniqueName.IndexOf("~");
                                    currentUniqueName = currentUniqueName.Substring(startPos, data.IndexOf("~", startPos + 1) - startPos + 1);

                                    DataRow[] dtRows = dtDynamicParameter.Select("DynamicName= '" + currentUniqueName + "'");
                                    currentDynamicType = dtRows[0]["DynamicType"].ToString();
                                    currentDynamicFormat = dtRows[0]["Format"].ToString();

                                    drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);

                                    if (drDynamicValues.Length == 0)
                                    {


                                        if (currentDynamicType.ToLower() != "string")
                                        {
                                            currentUniquevalue = UIHelper.GenerateDynamicValue(currentDynamicType, currentUniqueName, currentDynamicFormat);

                                            if (currentUniquevalue.Length == 0)
                                            {
                                                throw new Exception("Unique value is not generated hence exiting");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter value is :" + currentUniquevalue);

                                        }

                                    }
                                    #region Commented Code for Dynamic Parameters in Database

                                    //paramDynamicValues.Clear();
                                    //paramDynamicValues.Add(new SqlParameter("@ScenarioID", scenarioID));
                                    //paramDynamicValues.Add(new SqlParameter("@DynamicName", currentUniqueName));



                                    // DataTable dtDynamicValues = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                    // DataRow[] drDynamicValues = DynamicValues.Select("DynamicName='" +  currentUniqueName + "' AND " + " ScenarioID=" + scenarioID);

                                    #endregion
                                }
                                #endregion Dynamic Data
                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Current Element Type : " + controlType);

                                switch (controlType.ToLower())
                                {
                                    case "para":

                                        #region PARA
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {


                                            var para = Core.GetPara(ie, frame, elementName, elementID, controlText, -1);
                                            var paraText = "";

                                            if (para != null)
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", controlText).Replace("#webpage#", ie.Title));
                                                paraText = para.Text.Replace(Environment.NewLine, "").Trim();
                                            }
                                            else
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                            #region DeepankarCommented
                                            if (ignorePrefix.Length > 0) // if entire data is not taken but the substrings
                                            {

                                                paraText = paraText.Replace(ignorePrefix, "");

                                            }
                                            if (ignoreSuffix.Length > 0) // if entire data is not taken but the substrings
                                            {

                                                paraText = paraText.Replace(ignoreSuffix, "");

                                            }
                                            if (currentUniqueName.Length != 0) // non-dynamic parameter
                                            {
                                                #region commented code

                                                //Database call
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                //if (dtExists.Rows.Count == 0)
                                                #endregion
                                                if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                {

                                                    AddDynamicValue(currentUniqueName, paraText, scenarioID);
                                                }

                                            }
                                            #endregion

                                         
                                                logResult(controlText+data, paraText, controlType, elementName, "", scenario, testCase, "", CompareType.Contains);
                                           

                                        }

                                        break;
                                        #endregion
                                    case "span":

                                        #region Span
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {


                                            var span = Core.GetSpan(ie, frame, elementName, elementID, index);
                                            var spanText = "";

                                            if (span != null)
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", controlText).Replace("#webpage#", ie.Title));
                                                spanText = span.Text.Replace(Environment.NewLine, "").Trim();
                                                if (data.ToLower() == "c")
                                                {
                                                    span.Click();
                                                }
                                            }

                                            else
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                            spanText = CheckPrefixSuffix(ignorePrefix, ignoreSuffix, spanText);
                                            if (currentUniqueName.Length != 0) // non-dynamic parameter
                                            {
                                                #region commented code

                                                //Database call
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                //if (dtExists.Rows.Count == 0)
                                                #endregion
                                                if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                {

                                                    AddDynamicValue(currentUniqueName, spanText, scenarioID);
                                                }

                                            }
                                            else if (data.Length > 0 && (action.ToLower() == "verify"))
                                            {
                                                logResult(data, spanText, controlType, elementName, "Text", scenario, testCase, "NoName");
                                            }

                                            CheckVisibility(controlType, elementName, testCase, visible, scenario, span);

                                        }

                                        break;
                                        #endregion
                                    case "autocomplete":
                                        #region AutoComplete
                                        if (action.ToLower() == "add")
                                        {
                                            CommonControlCalls.AutoComplete(ie, frame, elementName, elementID, index, data);
                                        }
                                        else if (action.ToLower() == "verify")
                                        {
                                            TextField autoComplete = Core.GetTextField(ie, frame, elementName, elementID, -1);
                                            if (autoComplete != null)
                                            {

                                                logResult(verificationValue, autoComplete.Value, controlType, elementName, "Text", scenario, testCase, "NoName");
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "autocomplete").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }
                                        break;
                                        #endregion AutoComplete
                                    case "image":

                                        #region Image
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {


                                            var img = Core.GetImage(ie, frame, elementName, elementID, index);

                                            if (img != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", img.IdOrName).Replace("#webpage#", ie.Title));

                                                isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    img.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, waiting for page load");
                                                    ie.WaitForComplete(waitTimeOut);

                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    img.ClickNoWait();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, not waiting for page load");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }

                                        break;
                                        #endregion
                                    case "button":

                                        #region Button
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {


                                            var button = Core.GetButton(ie, frame, elementName, elementID, controlValue, index);


                                            if (button != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", button.IdOrName).Replace("#webpage#", ie.Title));

                                                isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    button.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, waiting for page load");
                                                    ie.WaitForComplete(waitTimeOut);

                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    button.ClickNoWait();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, not waiting for page load");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }


                                        #endregion
                                        break;
                                    case "selectlist":

                                        #region SelectList
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {

                                            var selectList = Core.GetSelectList(ie, frame, elementName, elementID, -1);

                                            if (selectList != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", selectList.IdOrName).Replace("#webpage#", ie.Title));
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Searching for option :" + data);



                                                if (action.ToLower() == "add")
                                                {
                                                    var option = selectList.Option(Find.ByText(data));
                                                    if (option != null)
                                                    {

                                                        BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option value: " + data + " found");
                                                        option.Focus();
                                                        try
                                                        {
                                                            option.Select(); // in some cases this method throws error
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option " + data + " not found ");
                                                    }
                                                }
                                                else if (action.ToLower() == "verify")
                                                {

                                                    logResult(verificationValue, selectList.SelectedOption.Text, controlType, elementName, "Text", scenario, testCase, "NoName");

                                                }

                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }


                                        #endregion
                                        break;

                                    case "listitem":
                                        {

                                            
                                            if ((data.ToLower() == "c") )
                                            {
                                              var litem =  Core.GetLIitems(ie, frame, elementName, elementID, index);
                                                if (litem.Exists == true )
                                                {
                                              litem.Click();
                                                }
                                              
                                            }
                                                else
                                             {
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                             }

                                            

                                            break;
                                        }
                                    case "radiobutton":

                                        #region RadioButton
                                        WatiN.Core.RadioButton radioButton = null;

                                        if ((action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {
                                            radioButton = Core.GetRadioButton(ie, frame, elementName, elementID, -1);
                                            if (radioButton != null)
                                            {
                                                if (action.ToLower() == "add" && data.ToLower() == "c")
                                                {
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", radioButton.IdOrName).Replace("#webpage#", ie.Title));
                                                    radioButton.Click();
                                                    ie.WaitForComplete(waitTimeOut);
                                                    break;
                                                }
                                                else if (action.ToLower() == "verify")
                                                {

                                                    logResult(verificationValue, radioButton.Checked.ToString(), controlType, elementName, "State", scenario, testCase, "NoName");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }
                                            System.Threading.Thread.Sleep(1000);

                                        }
                                        #endregion

                                        break;
                                    case "textfield":

                                        #region TextField
                                        TextField txt = null;

                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            txt = Core.GetTextField(ie, frame, elementName, elementID, -1);
                                            if (txt != null)
                                            {
                                                if (txt.Enabled == true)
                                                {
                                                    txt.Focus();

                                                }
                                                BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", txt.IdOrName).Replace("#webpage#", ie.Title));

                                                if (action.ToLower() == "add")
                                                {

                                                    if (currentUniqueName.Length == 0) // non-dynamic parameter
                                                    {
                                                        //txt.Value = data;
                                                        //txt.Change();
                                                        txt.Click();
                                                        System.Windows.Forms.SendKeys.SendWait(data);
                                                    }
                                                    else
                                                    {
                                                        #region commented code

                                                        //Database call
                                                        //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                        //if (dtExists.Rows.Count == 0)
                                                        #endregion
                                                        if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                        {
                                                            txt.Value = currentUniquevalue;
                                                            AddDynamicValue(currentUniqueName, currentUniquevalue, scenarioID);
                                                        }
                                                        else
                                                            txt.Value = drDynamicValues[0]["DynamicValue"].ToString();
                                                    }

                                                }
                                                if (action.ToLower() == "verify")
                                                {
                                                    if (currentUniqueName.Length == 0) // non-dynamic parameter
                                                    {
                                                        logResult(verificationValue, txt.Value, controlType, elementName, "Text", scenario, testCase, "NoName");
                                                    }
                                                    else
                                                    {
                                                        if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                        {

                                                            logResult("Dynamicvaluenotread", txt.Value, controlType, elementName, "Text", scenario, testCase, "NoName");
                                                        }
                                                        else
                                                        {
                                                            logResult(drDynamicValues[0]["DynamicValue"].ToString(), txt.Value, controlType, elementName, "Text", scenario, testCase, "NoName");

                                                        }
                                                    }
                                                }


                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }
                                        }

                                        #endregion
                                        break;
                                    case "element":
                                        var ele = ie.Element(Find.ById(elementID));
                                        ele.SetAttributeValue("value", data);
                                        break;
                                    case "link":  //need to think about dynamic links
                                        Link lnk = null;
                                        isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                        #region Link
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {
                                            currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link
                                            if (currentTableRow >= 0)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Searching link in the web table");
                                                lnk = targetTable.OwnTableRows[currentTableRow].Link(Find.ByText(new Regex(elementName)));
                                                currentTableRow = -1; //reset the rownumber
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Searching link  on the webpage");
                                                lnk = Core.GetLink(ie, frame, elementName, elementID, index);

                                            }

                                            if (lnk != null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name#", lnk.Text).Replace("#webpage#", ie.Title));
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    lnk.Click();
                                                    ie.WaitForComplete(waitTimeOut);
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, waiting for page load");


                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    lnk.ClickNoWait();
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, not waiting for page load");
                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "Link").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                            ie.WaitForComplete(waitTimeOut);
                                        }
                                        #endregion
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageverifyActionIgnore);
                                        }

                                        break;
                                    case "checkbox":
                                        #region CheckBox
                                        WatiN.Core.CheckBox checkbox = null;
                                        checkbox = Core.GetChecKBox(ie, frame, elementName, elementID, -1);
                                        if (checkbox != null)
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", checkbox.IdOrName).Replace("#webpage#", ie.Title));

                                            if (action.ToLower() == "add")
                                            {

                                                checkbox.Click();
                                                ie.WaitForComplete(waitTimeOut);
                                            }
                                            else if (action.ToLower() == "verify")
                                            {

                                                logResult(verificationValue, checkbox.Checked.ToString(), controlType, elementName, "State", scenario, testCase, "NoName");
                                            }

                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        }


                                        #endregion

                                        break;
                                    case "div":
                                        var div = Core.GetDiv(ie, frame, elementName, elementID, -1);
                                        if (div != null)
                                        {
                                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", div.IdOrName).Replace("#webpage#", ie.Title));
                                            div.Click();
                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        }
                                        break;
                                    case "navigateto":
                                        #region navigateto
                                        BusinessLayer.LogTofile("", "", "", "", "", "Action Navigateto");
                                        drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                        if (drDynamicValues.Length > 0)  // for dynamic values
                                        {

                                            BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                            currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                            if (!targetURL.EndsWith("/"))
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));
                                                ie.GoTo(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");

                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data.Replace(currentUniqueName, currentUniquevalue));
                                                ie.GoTo(targetURL + data.Replace(currentUniqueName, currentUniquevalue));

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }

                                        }
                                        else  //for normal urls
                                        {
                                            if (!targetURL.EndsWith("/"))
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data);
                                                ie.GoTo(targetURL + "/" + data);

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data)).WaitForComplete(waitTimeOut);

                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data);
                                                ie.GoTo(targetURL + data);

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + data)).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }
                                        }
                                        ie.WaitForComplete(waitTimeOut);
                                        break;

                                        #endregion
                                    case "fireevent":

                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to fire event name=" + data);
                                            ie.ActiveElement.FireEvent(data);
                                            BusinessLayer.LogTofile("", "", "", "", "", "Event Fired Successfully");
                                        }
                                        break;
                                    case "javascriptbutton":
                                        #region javascriptbutton
                                        System.Threading.Thread.Sleep(2000);
                                        BusinessLayer.LogTofile("", "", "", "", "", "Trying to access Javasript button=" + data);
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            Boolean found = false;
                                            for (int k = 0; k < attempts; k++)
                                            {
                                                System.Threading.Thread.Sleep(2000);
                                                found = UIHelper.JavaScriptButtons(ie, data);
                                                {
                                                    if (found == true)
                                                    {
                                                        BusinessLayer.LogTofile("", "", "", "", "", "Javascript button clicked");
                                                        break;
                                                    }
                                                }

                                            }
                                            if (found == false)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Javascript button not clicked");
                                            }
                                        }
                                        break;
                                        #endregion
                                    case "keyboard":
                                        CommonControlCalls.KeyBoard(ie, frame, elementName, elementID, index, data, waitTimeOut);
                                        break;
                                    case "searchwebtablerow":
                                        #region searchwebtablerow
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable for data: " + data + " " + " value:" + currentUniquevalue);
                                            currentUniquevalue = data;
                                            if (currentUniqueName.Length > 0)  //Need to code for non-dyanmic tables
                                            {
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                                if (drDynamicValues.Length > 0)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                                    currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                                }

                                            }
                                            currentTableRow = -1;

                                            for (int k = 0; k < attempts; k++)
                                            {
                                                targetTable = Core.GetWebTable(ie, frame, currentUniquevalue, index);
                                                if (targetTable != null)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got Webtable for data : " + data);
                                                    //  logTofile("Inner HTML: " + targetTable.InnerHtml);
                                                    break;
                                                }

                                            }
                                            if (targetTable == null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Could not find table, searched with keyword " + data);
                                                throw new Exception("Table not found");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable row for data : " + data);
                                            for (int z = 0; z < attempts; z++)
                                            {
                                                currentTableRow = Core.GetWebTableRow(targetTable, currentUniquevalue);
                                                if (currentTableRow != -1)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got webtable row for data : " + data);
                                                    break;
                                                }
                                                else
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Did not find the web table row for data  : " + data);
                                                    break;
                                                }
                                            }
                                        }

                                        break;
                                        #endregion
                                    case "clicktablerow":
                                        #region clicktablerow
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable for data: " + data + " " + " value:" + currentUniquevalue);
                                            currentUniquevalue = data;
                                            if (currentUniqueName.Length > 0)  //Need to code for non-dyanmic tables
                                            {
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                                if (drDynamicValues.Length > 0)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                                    currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                                }

                                            }
                                            currentTableRow = -1;

                                            for (int k = 0; k < attempts; k++)
                                            {
                                                targetTable = Core.GetWebTable(ie, frame, currentUniquevalue, index);
                                                if (targetTable != null)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got Webtable for data : " + data);
                                                    break;
                                                }

                                            }
                                            if (targetTable == null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Could not find table, searched with keyword " + data);
                                                throw new Exception("Table not found");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable row for data : " + data);
                                            for (int z = 0; z < attempts; z++)
                                            {
                                                currentTableRow = Core.GetWebTableRow(targetTable, currentUniquevalue);
                                                if (currentTableRow != -1)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got webtable row for data : " + data);
                                                    targetTable.OwnTableRows[currentTableRow].Click();

                                                    break;
                                                }
                                                else
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Did not find the web table row for data  : " + data);
                                                    break;
                                                }
                                            }
                                        }

                                        break;
                                        #endregion
                                    case "windowslogon":
                                        BusinessLayer.LogTofile("", "", "", "", "", "Windows logon");  // this is handled above the select clauses
                                        break;
                                    case "webtable":
                                        Table table = null;
                                        if (elementName.Trim().Length > 0)
                                        {
                                            table = Core.GetWebTable(ie, frame, elementName, index);
                                        }
                                        else if (elementID.Trim().Length > 0)
                                        {
                                            table = Core.GetWebTable(ie, frame, elementID, index);
                                        }

                                        if (table != null)
                                        {

                                            //webtableName = elementID.Length > 0 ? elementID : elementName;
                                            //webtableName = webtableName.Replace(" ", "_");
                                            //BusinessLayer.LogTofile(messageFoundControl.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName.Replace("#webpage#", ie.Title)));
                                            List<SqlParameter> paramlst = new List<SqlParameter>(0);

                                            paramlst.Add(new SqlParameter("@TableName", data + "_" + testCase));
                                            DataTable webData = DataAccessLayer.GetReturnDataTable("[GetWebtableData]", paramlst);


                                            for (int tabRows = 0; tabRows < webData.Rows.Count; tabRows++)
                                            {
                                                int rowNo = int.Parse(webData.Rows[tabRows]["Rowno"].ToString());
                                                int columnNo = int.Parse(webData.Rows[tabRows]["ColumnNo"].ToString());
                                                string columnName = webData.Rows[tabRows]["columnName"].ToString();

                                                string expectedValue = webData.Rows[tabRows]["Value"].ToString();

                                                try
                                                {
                                                    string actualValue = table.OwnTableRows[rowNo].OwnTableCells[columnNo].Text;
                                                    logResult(expectedValue, actualValue, controlType, elementName, "ColumnData", scenario, testCase, columnName);
                                                }
                                                catch
                                                {

                                                    logResult(expectedValue, "Valuenotread", controlType, elementName, "ColumnData", scenario, testCase, columnName);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        }
                                        break;
                                    default:
                                        BusinessLayer.LogTofile("", "", "", "", "", "Invalid controltype encountered: " + controlType);
                                        break;
                                }

                            }



                        }

                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            //ie.ClearCookies();
                            //ie.ClearCache();
                            //ie.Close();
                            //System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("IExplore");
                            //foreach (System.Diagnostics.Process process in p)
                            //{
                            //    process.Kill();
                            //}
                        }
                        #endregion
                        break;
                    }

                case "chrome":
                    {
                        #region chrome

                        
                        ChromeDriver chromedriver = null;
                        Dictionary<string, string> uniqueString = new Dictionary<string, string>();
                        int waitTimeOut = int.Parse(UIHelper.GetConfigurationValue("waittime"));
                        int attempts = int.Parse(UIHelper.GetConfigurationValue("attempts"));
                        int pacing = int.Parse(UIHelper.GetConfigurationValue("pacing"));
                        string targetURL = UIHelper.GetConfigurationValue("targeturl");
                        IList<IWebElement> alllinks = null;
                        DataTable dtwebpgid = BusinessLayer.GetWebPageIdOnly(scenarioID);
                        bool linkfound = false;
                       string wpgid = dtwebpgid.Rows[0]["WebPageID"].ToString();

                        DataTable dtwebpageurl = BusinessLayer.GetWebPageURLs(Int32.Parse(wpgid));


                        targetURL = dtwebpageurl.Rows[0]["URL"].ToString();

 
                        /*
                         ChromeDriver chromedriver = new ChromeDriver();
                         chromedriver.Navigate().GoToUrl(targetURL); */
                        Table targetTable = null;
                        int frame = -1;
                        
                        dtDynamicValues.Rows.Clear();
                        dtDynamicValues.Columns.Clear();
                        dtDynamicValues.Columns.Add("ScenarioID");
                        dtDynamicValues.Columns.Add("DynamicName");
                        dtDynamicValues.Columns.Add("DynamicValue");

                        

                        try
                        {
                            //int scenarioID = -1;

                            //logTofile("Getting scenario ID ");
                            //scenarioID = GetScenarioID(currentNode);
                            BusinessLayer.LogTofile("", "", "", "", "", "Scenario ID is  " + scenarioID.ToString());

                            string currentUniqueName = "";

                            string currentUniquevalue = "";
                            string currentDynamicType = "";
                            string currentDynamicFormat = "";
                            int webPageID = -1;
                            string action = "";
                            int index = -1;
                            string verificationValue = "";

                            BusinessLayer.LogTofile("", "", "", "", "", "Getting the data for Scenario");
                            DataTable dtRun = BusinessLayer.GetRunData(scenarioID);
                            BusinessLayer.LogTofile("", "", "", "", "", "Scenario has total : " + dtRun.Rows.Count.ToString() + " actions");
                            if (dtRun.Rows.Count == 0)
                            {
                                UIHelper.StopMessage("No data to run");
                                return;
                            }
                            string controlType, elementID, elementName, controlText, controlValue, data, testCase, title = "";
                            string ignorePrefix, ignoreSuffix, visible = "";
                            int currentTableRow = -1;

                            List<SqlParameter> paramDynamicParameters = new List<SqlParameter>(0);
                            List<SqlParameter> paramDynamicValues = new List<SqlParameter>(0);

                       
                            //Database call needs to be deleted
                            //List<SqlParameter> paramDelete = new List<SqlParameter>(0);
                            //paramDelete.Add(new SqlParameter("@ScenarioID", scenarioID));
                            //DataAccessLayer.InsertData("DeleteDynamicValues", paramDelete);


                            DataTable dtDynamicParameter = BusinessLayer.GetDynamicParameterList();

                            string scenario = "";
                            string lastTestCase = "";
                            int totalSteps = dtRun.Rows.Count;
                            Boolean isJavaScriptButton = false;
                            for (int i = 0; i < totalSteps; i++)
                            {


                                scenario = dtRun.Rows[i]["Scenario"].ToString();
                                currentUniqueName = "";
                                currentUniquevalue = "";

                                frame = int.Parse(dtRun.Rows[i]["frame"].ToString());

                                controlType = dtRun.Rows[i]["Controltype"].ToString();

                                elementID = dtRun.Rows[i]["ControlID"].ToString();
                                elementName = dtRun.Rows[i]["ControlName"].ToString();
                                controlText = dtRun.Rows[i]["ControlText"].ToString();
                                controlValue = dtRun.Rows[i]["controlValue"].ToString();

                                data = dtRun.Rows[i]["DataValue"].ToString();
                                testCase = dtRun.Rows[i]["TestCase"].ToString();
                                webPageID = int.Parse(dtRun.Rows[i]["WebPageId"].ToString());
                                action = dtRun.Rows[i]["Action"].ToString();
                                title = dtRun.Rows[i]["Title"].ToString();
                                index = int.Parse(dtRun.Rows[i]["Index"].ToString());

                                ignorePrefix = dtRun.Rows[i]["IgnorePrefix"].ToString();
                                ignoreSuffix = dtRun.Rows[i]["IgnoreSuffix"].ToString();
                                visible = dtRun.Rows[i]["Visible"].ToString();

                                if (lastTestCase.Length == 0)
                                {
                                    BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action);

                                    lastTestCase = testCase;
                                }
                                if (testCase != lastTestCase)
                                {
                                    //BusinessLayer.LogTofile(Environment.NewLine);
                                    BusinessLayer.LogTofile("", "", "", "", "", "End step:(" + i.ToString() + ") " + title + ":" + lastTestCase + "  Action:" + action + Environment.NewLine);
                                    //BusinessLayer.LogTofile("=========================" + Environment.NewLine);
                                    BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action + Environment.NewLine);

                                    lastTestCase = testCase;

                                    if (pacing > 0)
                                    {
                                        System.Threading.Thread.Sleep(pacing * 1000);
                                        BusinessLayer.LogTofile("", "", "", "", "", "Waiting for :" + pacing + " seconds" + Environment.NewLine);
                                    }

                                }
                           //     UIHelper.LogToFile("Launching chrome driver");
                                if ( targetURL.Contains((string)dtRun.Rows[0]["absolutepath"].ToString()))
                                {
                               //     UIHelper.LogToFile("Launcing for no abs path " + targetURL);
                                    //do not concat abs path
                                chromedriver = Core.IdentifyWebPageChrome(chromedriver, (string)dtRun.Rows[i]["Title"].ToString(), targetURL);         
                                }
                                else
                                {
                                    //else concta abs path
                                    chromedriver = Core.IdentifyWebPageChrome(chromedriver, (string)dtRun.Rows[i]["Title"].ToString(), targetURL + (string)dtRun.Rows[0]["absolutepath"].ToString());         
                                }

                                #region "windowslogon"
                                if (controlType.ToLower() == "windowslogon")
                                {
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Element type is windowslogon, trying to clear cookies and cache");
                                    if (chromedriver != null)
                                    {
                                        chromedriver.Close();
                                        BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Cleared cookies,cache. Trying to close all open sessions of IE");
                                    }
                                    #region Kill all Chrome instances
                                    System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("Chrome");
                                    foreach (System.Diagnostics.Process process in p)
                                    {
                                        process.Kill();
                                    }
                                    BusinessLayer.LogTofile("", "", "", "", "", "All Chrome sessions closed. Getting username and password");

                                    #endregion

                                    string userName = UIHelper.GetUserNameAndPassword("u", data);
                                    string password = UIHelper.GetUserNameAndPassword("p", data);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Got username and password");
                                    System.Threading.Thread.Sleep(2000);
                                    UIHelper.WindowsLogon(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString(), userName, password);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Attatching to URL :" + targetURL);


                                    IE.AttachTo<IE>(Find.ByUrl(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString())).WaitForComplete(waitTimeOut);

                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Successfully attached");
                                }
                                #endregion

                              

                                if (controlType.ToLower() == "wait")
                                {
                                    if (data.Length == 0)
                                        data = "1"; //wait for 1 second if wait not provided
                                    {
                                    }
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + data + " )Seconds");
                                    System.Threading.Thread.Sleep(int.Parse(data) * 1000);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");

                                }
                                if (controlType.ToLower() == "waitforwebpage")
                                {

                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + waitTimeOut + " )Seconds");
                                    IE.AttachTo<IE>(Find.ByTitle(data.Trim()), waitTimeOut);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");
                                }

                                verificationValue = dtRun.Rows[i]["VerificationValue"].ToString();

                                if (action.ToLower() == "verify")
                                {
                                    data = verificationValue;
                                }
                                #region Dynamic Data

                                if (data.Contains("~"))
                                {

                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter encountered :" + currentUniqueName);

                                    paramDynamicParameters.Clear();
                                    currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link

                                    int startPos = currentUniqueName.IndexOf("~");
                                    currentUniqueName = currentUniqueName.Substring(startPos, data.IndexOf("~", startPos + 1) - startPos + 1);

                                    DataRow[] dtRows = dtDynamicParameter.Select("DynamicName= '" + currentUniqueName + "'");
                                    currentDynamicType = dtRows[0]["DynamicType"].ToString();
                                    currentDynamicFormat = dtRows[0]["Format"].ToString();

                                    drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);

                                    if (drDynamicValues.Length == 0)
                                    {


                                        if (currentDynamicType.ToLower() != "string")
                                        {
                                            currentUniquevalue = UIHelper.GenerateDynamicValue(currentDynamicType, currentUniqueName, currentDynamicFormat);

                                            if (currentUniquevalue.Length == 0)
                                            {
                                                throw new Exception("Unique value is not generated hence exiting");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter value is :" + currentUniquevalue);

                                        }

                                    }
                                    #region Commented Code for Dynamic Parameters in Database

                                    //paramDynamicValues.Clear();
                                    //paramDynamicValues.Add(new SqlParameter("@ScenarioID", scenarioID));
                                    //paramDynamicValues.Add(new SqlParameter("@DynamicName", currentUniqueName));



                                    // DataTable dtDynamicValues = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                    // DataRow[] drDynamicValues = DynamicValues.Select("DynamicName='" +  currentUniqueName + "' AND " + " ScenarioID=" + scenarioID);

                                    #endregion
                                }
                                #endregion Dynamic Data
                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Current Element Type : " + controlType);

                                switch (controlType.ToLower())
                                {
                                    case "para":

                                        #region PARA
                                        /*
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {

                                            var para = "";
                                       //     var para = Core.GetPara(ie, frame, elementName, elementID, controlText, -1);
                                            var paraText = "";

                                            if (para != null)
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", controlText).Replace("#webpage#",  chromedriver.Title));
                                              //  paraText = para.Text.Replace(Environment.NewLine, "").Trim();
                                            }
                                            else
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", chromedriver.Title));
                                            }


                                            if (ignorePrefix.Length > 0) // if entire data is not taken but the substrings
                                            {

                                                paraText = paraText.Replace(ignorePrefix, "");

                                            }
                                            if (ignoreSuffix.Length > 0) // if entire data is not taken but the substrings
                                            {

                                                paraText = paraText.Replace(ignoreSuffix, "");

                                            }
                                            if (currentUniqueName.Length != 0) // non-dynamic parameter
                                            {
                                                #region commented code

                                                //Database call
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                //if (dtExists.Rows.Count == 0)
                                                #endregion
                                                if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                {

                                                    AddDynamicValue(currentUniqueName, paraText, scenarioID);
                                                }

                                            }



                                        }

                                        break; */
                                        #endregion
                                    case "span":

                                        #region Span
                                        
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {


                                            var span = Core.getElementSpan(chromedriver, frame, elementID, elementName, data, index);
                                            var spanText = "";

                                          

                                            if (span != null)
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", controlText).Replace("#webpage#", chromedriver.Title));
                                                spanText = span.Text.Replace(Environment.NewLine, "").Trim();
                                                if (data.ToLower() == "c")
                                                {
                                                    span.Click();
                                                }
                                            }
                                            else
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Span").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", chromedriver.Title));
                                            }

                                            spanText = CheckPrefixSuffix(ignorePrefix, ignoreSuffix, spanText);
                                            if (currentUniqueName.Length != 0) // non-dynamic parameter
                                            {
                                                #region commented code

                                                //Database call
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                //if (dtExists.Rows.Count == 0)
                                                #endregion
                                                if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                {

                                                    AddDynamicValue(currentUniqueName, spanText, scenarioID);
                                                }

                                            }
                                            else if (data.Length > 0 && action.ToLower() == "verify")
                                            {
                                                logResult(data, spanText, controlType, elementName, "Text", scenario, testCase, "NoName");
                                            }

                                        //    CheckVisibility(controlType, elementName, testCase, visible, scenario, visible, scenario, span);

                                        }

                                        break; 
                                        #endregion
                                    case "autocomplete":
                                        #region AutoComplete
                                        /*
                                        if (action.ToLower() == "add")
                                        {
                                            CommonControlCalls.AutoComplete(ie, frame, elementName, elementID, index, data);
                                        }
                                        else if (action.ToLower() == "verify")
                                        {
                                            TextField autoComplete = Core.GetTextField(ie, frame, elementName, elementID, -1);
                                            if (autoComplete != null)
                                            {

                                                logResult(verificationValue, autoComplete.Value, controlType, elementName, "Text", scenario, testCase, "NoName");
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "autocomplete").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }
                                        break; */
                                        #endregion AutoComplete
                                    case "image":

                                        #region Image
                                        /*
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {

                                           
                                            var img = Core.GetImage(ie, frame, elementName, elementID, index);

                                            if (img != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", img.IdOrName).Replace("#webpage#", ie.Title));

                                                isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    img.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, waiting for page load");
                                                    ie.WaitForComplete(waitTimeOut);

                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    img.ClickNoWait();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, not waiting for page load");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }

                                        break;*/
                                        #endregion
                                    case "button":

                                        #region Button
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {

             
                                            
                                            var button = Core.getElement(chromedriver, frame, elementID, elementName, controlValue, index);
                                            

                                            if (button != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", button.Text).Replace("#webpage#", chromedriver.Title));

                                                isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    button.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, waiting for page load");
                                                    

                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    button.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, not waiting for page load");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", chromedriver.Title));
                                            }

                                        }


                                        #endregion
                                        break;
                                    case "selectlist":

                                        #region SelectList
                                        
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {

                                            IWebElement selectList = Core.getElement(chromedriver, frame, elementID, elementName, controlValue, index);

                                            if (selectList != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", selectList.Text).Replace("#webpage#", chromedriver.Title));
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Searching for option :" + data);



                                                if (action.ToLower() == "add")
                                                {
                                                   // var option = selectList.Option(Find.ByText(data));

                                                        SelectElement select = new SelectElement(selectList);
                                                        BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option value: " + data + " found");
                                                        try
                                                        {
                                                        select.SelectByText(data);
                                                        }
                                                        catch
                                                        {

                                                        }
                                                   
                                                   
                                                    
                                                       // BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option " + data + " not found ");
                                                    
                                                }
                                                else if (action.ToLower() == "verify")
                                                {

                                                  //  logResult(verificationValue, selectList.SelectedOption.Text, controlType, elementName, "Text", scenario, testCase, "NoName");

                                                }

                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", chromedriver.Title));
                                            }

                                        }

                                        
                                        #endregion
                                        break;
                                    case "radiobutton":

                                        #region RadioButton
                                        /*
                                        WatiN.Core.RadioButton radioButton = null;

                                        if ((action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {
                                            radioButton = Core.GetRadioButton(ie, frame, elementName, elementID, -1);
                                            if (radioButton != null)
                                            {
                                                if (action.ToLower() == "add" && data.ToLower() == "c")
                                                {
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", radioButton.IdOrName).Replace("#webpage#", ie.Title));
                                                    radioButton.Click();
                                                    ie.WaitForComplete(waitTimeOut);
                                                    break;
                                                }
                                                else if (action.ToLower() == "verify")
                                                {

                                                    logResult(verificationValue, radioButton.Checked.ToString(), controlType, elementName, "State", scenario, testCase, "NoName");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }
                                            System.Threading.Thread.Sleep(1000);

                                        }
                                         *  */
                                        #endregion


                                        break;
                                    case "textfield":

                                        #region TextField
                                        IWebElement txt = null;
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            txt = Core.getElement(chromedriver, frame, elementID,elementName,controlValue, index);
                                           // IList<IWebElement> ielelist = txt.FindElements(By.Id("df"));
                                            if (txt != null)
                                            {
                                                if (txt.Enabled == true)
                                                {
                                                    txt.Click();

                                                }
                                                BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", txt.Text
                                                    ).Replace("#webpage#", chromedriver.Title));

                                                if (action.ToLower() == "add")
                                                {

                                                    if (currentUniqueName.Length == 0) // non-dynamic parameter
                                                    {
                                                        txt.Click();
                                                        
                                                            SendKeys.SendWait("{Home}");
                                                            System.Threading.Thread.Sleep(500);
                                                            SendKeys.SendWait("+{End}");
                                                            System.Threading.Thread.Sleep(500);
                                                            SendKeys.SendWait("{Del}");
                                                            System.Threading.Thread.Sleep(500);
                                                            txt.SendKeys(data);
                                                          //  SendKeys.SendWait("{TAB}");
                                                      
                                                        
                                                    }
                                                    else
                                                    {
                                                        #region commented code

                                                        //Database call
                                                        //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                        //if (dtExists.Rows.Count == 0)
                                                        #endregion
                                                        if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                        {
                                                            txt.Click();
                                                            txt.SendKeys(currentUniquevalue);
                                                            BusinessLayer.propertycurrentUniqueValue = currentUniquevalue;
                                                            SendKeys.SendWait("{TAB}");
                                                        }
                                                       // else
                                                           // txt.Value = drDynamicValues[0]["DynamicValue"].ToString();
                                                    }

                                                }
                                                if (action.ToLower() == "verify")
                                                {
                                                    if (currentUniqueName.Length == 0) // non-dynamic parameter
                                                    {
                                                        logResult(verificationValue, txt.Text, controlType, elementName, "Text", scenario, testCase, "NoName");
                                                    }
                                                    else
                                                    {
                                                        if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                        {

                                                            logResult("Dynamicvaluenotread", txt.Text, controlType, elementName, "Text", scenario, testCase, "NoName");
                                                        }
                                                        else
                                                        {
                                                            logResult(drDynamicValues[0]["DynamicValue"].ToString(), txt.Text, controlType, elementName, "Text", scenario, testCase, "NoName");

                                                        }
                                                    }
                                                }


                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", chromedriver.Title));
                                            }
                                        }

                                        #endregion
                                        break;
                                    case "element":
                                        /*
                                        var ele = ie.Element(Find.ById(elementID));
                                        ele.SetAttributeValue("value", data); */
                                        break;
                                    case "link":  //need to think about dynamic links
                                        
                                        IWebElement lnk = null;
                                        isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                        #region Link
                                        if ( (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {
                                            currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link
                                            if (currentTableRow >= 0)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Searching links");
                                                if (elementName.ToLower() != "linkscollection")
                                                {
                                                    lnk = Core.getElementLink(chromedriver, frame, elementID, elementName, controlValue, index);
                                                }
                                                else
                                                {
                                                    for (int z1 =0; z1 < attempts ; z1++)
                                                    {
                                                        alllinks = chromedriver.FindElementsByTagName("a");
                                                        if (alllinks != null )
                                                        {
                                                            break;
                                                            
                                                        }
                                                        System.Threading.Thread.Sleep(1000);
                                                    }
                                                }
                                                currentTableRow = -1; //reset the rownumber
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Searching link  on the webpage");
                                                if (elementName.ToLower() != "linkscollection")
                                                {
                                                    lnk = Core.getElementLink(chromedriver, frame, elementID, elementName, controlValue, index);
                                                }
                                                else
                                                {
                                                    for (int z1 = 0; z1 < attempts; z1++)
                                                    {
                                                        alllinks = chromedriver.FindElementsByTagName("a");
                                                        if (alllinks != null)
                                                        {
                                                            break;

                                                        }
                                                        System.Threading.Thread.Sleep(1000);
                                                    }
                                                }
                                            //    lnk = Core.getElementLink(chromedriver, frame, elementID, elementName, controlValue, index);


                                            }

                                            if (lnk != null || alllinks !=null)
                                            {
                                                
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    try
                                                    {
                                                        lnk.Click();

                                                        BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, waiting for page load");

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        BusinessLayer.LogTofile("", "", "", "", "", "Got Exception while clicking the link: "+ex.Message);
                                                    }

                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    //to do check for java script buttons 
                                                   // lnk.ClickNoWait();
                                                   // BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, not waiting for page load");
                                                }
                                                if (action.ToLower() == "verify")
                                                {
                                                    LogTofile(i.ToString(), testCase, controlType, elementName, "", "Link Verification in Progress");
                                                    if ((data.StartsWith("~")) && (data.EndsWith("~")))
                                                    {

                                                        foreach (IWebElement elen in alllinks)
                                                        {
                                                            if (elen.Text == BusinessLayer.propertycurrentUniqueValue)
                                                            {
                                                                logResult( chromedriver, BusinessLayer.propertycurrentUniqueValue, elen.Text, controlType, elementName, "Link", scenario, testCase, "", CompareType.Equals);
                                                                linkfound = true;
                                                                break;
                                                            }
                                                        }
                                                        if (linkfound == false)
                                                        {
                                                            logResult(chromedriver, BusinessLayer.propertycurrentUniqueValue, "No Link", controlType, elementName, "Link", scenario, testCase, "", CompareType.Equals);
                                                        }
                                                    }
                                                    else
                                                    {

                                                        logResult(data, lnk.Text, controlType, elementName, "Link", scenario, testCase, "");

                                                    }
                                                }

                                               
                                            }
                                            else
                                            {

                                                BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", lnk.Text).Replace("#webpage#", chromedriver.Title));
                                                
                                            }

                                            chromedriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(120.00));
                                        }
                                        
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageverifyActionIgnore);
                                        }
                                        #endregion
                                        
                                        break;
                                    case "checkbox":
                                        #region CheckBox
                                        /*
                                        WatiN.Core.CheckBox checkbox = null;
                                        checkbox = Core.GetChecKBox(ie, frame, elementName, elementID, -1);
                                        if (checkbox != null)
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", checkbox.IdOrName).Replace("#webpage#", ie.Title));

                                            if (action.ToLower() == "add")
                                            {

                                                checkbox.Click();
                                                ie.WaitForComplete(waitTimeOut);
                                            }
                                            else if (action.ToLower() == "verify")
                                            {

                                                logResult(verificationValue, checkbox.Checked.ToString(), controlType, elementName, "State", scenario, testCase, "NoName");
                                            }

                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        }

                                        */
                                        #endregion

                                        break;
                                    case "div":
                                        /*
                                        var div = Core.GetDiv(ie, frame, elementName, elementID, -1);
                                        if (div != null)
                                        {
                                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", div.IdOrName).Replace("#webpage#", ie.Title));
                                            div.Click();
                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        } */
                                        break;
                                    case "navigateto":
                                        #region navigateto
                                        /*
                                        BusinessLayer.LogTofile("", "", "", "", "", "Action Navigateto");
                                        drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                        if (drDynamicValues.Length > 0)  // for dynamic values
                                        {

                                            BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                            currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                            if (!targetURL.EndsWith("/"))
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));
                                                ie.GoTo(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");

                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data.Replace(currentUniqueName, currentUniquevalue));
                                                ie.GoTo(targetURL + data.Replace(currentUniqueName, currentUniquevalue));

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }

                                        }
                                        else  //for normal urls
                                        {
                                            if (!targetURL.EndsWith("/"))
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data);
                                                ie.GoTo(targetURL + "/" + data);

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data)).WaitForComplete(waitTimeOut);

                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data);
                                                ie.GoTo(targetURL + data);

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + data)).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }
                                        }
                                        ie.WaitForComplete(waitTimeOut);
                                        break;
                                        */
                                        #endregion
                                    case "fireevent":
                                        /*
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to fire event name=" + data);
                                            ie.ActiveElement.FireEvent(data);
                                            BusinessLayer.LogTofile("", "", "", "", "", "Event Fired Successfully");
                                        }
                                         * */
                                        break;
                                    case "javascriptbutton":
                                        #region javascriptbutton
                                        {
                                            try
                                            {
                                                while (isAlertPresent(chromedriver) == false)
                                                {
                                                    System.Threading.Thread.Sleep(1000);
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Wating for alert Message");
                                                }
                                                chromedriver.SwitchTo().Alert().Accept();
                                            }
                                            catch (Exception ex)
                                            {
                                                UIHelper.StopMessage("javascriptbutton: " + ex.Message);
                                            }
                                            
                                            break;

                                        }
   
                                        #endregion
                                    case "keyboard":
                                        //hardkoding one shift tab since we send addtional tab for Textfiedsl need to redo logic
                                        //SendKeys.Flush();
                                        //SendKeys.SendWait("+{Tab}");
                                        System.Threading.Thread.Sleep(100);
                                        SendKeys.Flush();
                                           SendKeys.SendWait(data);
                                           System.Threading.Thread.Sleep(100);
                                        break;
                                    case "searchwebtablerow":
                                        #region searchwebtablerow
                                        /*
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable for data: " + data + " " + " value:" + currentUniquevalue);
                                            currentUniquevalue = data;
                                            if (currentUniqueName.Length > 0)  //Need to code for non-dyanmic tables
                                            {
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                                if (drDynamicValues.Length > 0)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                                    currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                                }

                                            }
                                            currentTableRow = -1;

                                            for (int k = 0; k < attempts; k++)
                                            {
                                                targetTable = Core.GetWebTable(ie, frame, currentUniquevalue, index);
                                                if (targetTable != null)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got Webtable for data : " + data);
                                                    //  logTofile("Inner HTML: " + targetTable.InnerHtml);
                                                    break;
                                                }

                                            }
                                            if (targetTable == null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Could not find table, searched with keyword " + data);
                                                throw new Exception("Table not found");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable row for data : " + data);
                                            for (int z = 0; z < attempts; z++)
                                            {
                                                currentTableRow = Core.GetWebTableRow(targetTable, currentUniquevalue);
                                                if (currentTableRow != -1)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got webtable row for data : " + data);
                                                    break;
                                                }
                                                else
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Did not find the web table row for data  : " + data);
                                                    break;
                                                }
                                            }
                                        }
                                        */
                                        break;
                                        #endregion
                                    case "clicktablerow":
                                        #region clicktablerow
                                        /*
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable for data: " + data + " " + " value:" + currentUniquevalue);
                                            currentUniquevalue = data;
                                            if (currentUniqueName.Length > 0)  //Need to code for non-dyanmic tables
                                            {
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                                if (drDynamicValues.Length > 0)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                                    currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                                }

                                            }
                                            currentTableRow = -1;

                                            for (int k = 0; k < attempts; k++)
                                            {
                                                targetTable = Core.GetWebTable(ie, frame, currentUniquevalue, index);
                                                if (targetTable != null)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got Webtable for data : " + data);
                                                    break;
                                                }

                                            }
                                            if (targetTable == null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Could not find table, searched with keyword " + data);
                                                throw new Exception("Table not found");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable row for data : " + data);
                                            for (int z = 0; z < attempts; z++)
                                            {
                                                currentTableRow = Core.GetWebTableRow(targetTable, currentUniquevalue);
                                                if (currentTableRow != -1)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got webtable row for data : " + data);
                                                    targetTable.OwnTableRows[currentTableRow].Click();

                                                    break;
                                                }
                                                else
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Did not find the web table row for data  : " + data);
                                                    break;
                                                }
                                            }
                                        }
                                        */
                                        break;
                                        #endregion
                                    case "windowslogon":
                                        BusinessLayer.LogTofile("", "", "", "", "", "Windows logon");  // this is handled above the select clauses
                                        break;
                                    case "webtable":
                                        /*
                                        Table table = null;
                                        if (elementName.Trim().Length > 0)
                                        {
                                            table = Core.GetWebTable(ie, frame, elementName, index);
                                        }
                                        else if (elementID.Trim().Length > 0)
                                        {
                                            table = Core.GetWebTable(ie, frame, elementID, index);
                                        }

                                        if (table != null)
                                        {

                                            //webtableName = elementID.Length > 0 ? elementID : elementName;
                                            //webtableName = webtableName.Replace(" ", "_");
                                            //BusinessLayer.LogTofile(messageFoundControl.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName.Replace("#webpage#", ie.Title)));
                                            List<SqlParameter> paramlst = new List<SqlParameter>(0);

                                            paramlst.Add(new SqlParameter("@TableName", data + "_" + testCase));
                                            DataTable webData = DataAccessLayer.GetReturnDataTable("[GetWebtableData]", paramlst);


                                            for (int tabRows = 0; tabRows < webData.Rows.Count; tabRows++)
                                            {
                                                int rowNo = int.Parse(webData.Rows[tabRows]["Rowno"].ToString());
                                                int columnNo = int.Parse(webData.Rows[tabRows]["ColumnNo"].ToString());
                                                string columnName = webData.Rows[tabRows]["columnName"].ToString();

                                                string expectedValue = webData.Rows[tabRows]["Value"].ToString();

                                                try
                                                {
                                                    string actualValue = table.OwnTableRows[rowNo].OwnTableCells[columnNo].Text;
                                                    logResult(expectedValue, actualValue, controlType, elementName, "ColumnData", scenario, testCase, columnName);
                                                }
                                                catch
                                                {

                                                    logResult(expectedValue, "Valuenotread", controlType, elementName, "ColumnData", scenario, testCase, columnName);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        }
                                         * */
                                        break;
                                    default:
                                        BusinessLayer.LogTofile("", "", "", "", "", "Invalid controltype encountered: " + controlType);
                                        break;
                                }

                            }



                        }

                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            //ie.ClearCookies();
                            //ie.ClearCache();
                            //ie.Close();
                            //System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("IExplore");
                            //foreach (System.Diagnostics.Process process in p)
                            //{
                            //    process.Kill();
                            //}
                            System.Threading.Thread.Sleep(4000);
                            chromedriver.Quit();
                        }


                        #endregion
                        break;
                    }

                case "firefox":
                    {
                        #region firefox
                        Dictionary<string, string> uniqueString = new Dictionary<string, string>();
                        int waitTimeOut = int.Parse(UIHelper.GetConfigurationValue("waittime"));
                        int attempts = int.Parse(UIHelper.GetConfigurationValue("attempts"));
                        int pacing = int.Parse(UIHelper.GetConfigurationValue("pacing"));
                        string targetURL = UIHelper.GetConfigurationValue("targeturl");
                        string ffbinary = UIHelper.GetConfigurationValue("ffbinary");
                        string authuser = UIHelper.GetConfigurationValue("authuser");
                        string authpwd = UIHelper.GetConfigurationValue("authpwd");
                        IWebDriver ffdriver = null;
                       
                     

                        BusinessLayer.LogTofile(null,"Started and ANviagted",null,null,null,null);
                        Table targetTable = null;
                        int frame = -1;

                        dtDynamicValues.Rows.Clear();
                        dtDynamicValues.Columns.Clear();
                        dtDynamicValues.Columns.Add("ScenarioID");
                        dtDynamicValues.Columns.Add("DynamicName");
                        dtDynamicValues.Columns.Add("DynamicValue");



                        try
                        {
                            //int scenarioID = -1;

                            //logTofile("Getting scenario ID ");
                            //scenarioID = GetScenarioID(currentNode);
                            BusinessLayer.LogTofile("", "", "", "", "", "Scenario ID is  " + scenarioID.ToString());

                            string currentUniqueName = "";

                            string currentUniquevalue = "";
                            string currentDynamicType = "";
                            string currentDynamicFormat = "";
                            int webPageID = -1;
                            string action = "";
                            int index = -1;
                            string verificationValue = "";

                            BusinessLayer.LogTofile("", "", "", "", "", "Getting the data for Scenario");
                            DataTable dtRun = BusinessLayer.GetRunData(scenarioID);
                            BusinessLayer.LogTofile("", "", "", "", "", "Scenario has total : " + dtRun.Rows.Count.ToString() + " actions");
                            if (dtRun.Rows.Count == 0)
                            {
                                UIHelper.StopMessage("No data to run");
                                return;
                            }

                            

                            string controlType, elementID, elementName, controlText, controlValue, data, testCase, title = "";
                            string ignorePrefix, ignoreSuffix, visible = "";
                            int currentTableRow = -1;

                            List<SqlParameter> paramDynamicParameters = new List<SqlParameter>(0);
                            List<SqlParameter> paramDynamicValues = new List<SqlParameter>(0);


                            //Database call needs to be deleted
                            //List<SqlParameter> paramDelete = new List<SqlParameter>(0);
                            //paramDelete.Add(new SqlParameter("@ScenarioID", scenarioID));
                            //DataAccessLayer.InsertData("DeleteDynamicValues", paramDelete);


                            DataTable dtDynamicParameter = BusinessLayer.GetDynamicParameterList();

                            string scenario = "";
                            string lastTestCase = "";
                            int totalSteps = dtRun.Rows.Count;
                            Boolean isJavaScriptButton = false;
                            for (int i = 0; i < totalSteps; i++)
                            {


                                scenario = dtRun.Rows[i]["Scenario"].ToString();
                                currentUniqueName = "";
                                currentUniquevalue = "";

                                frame = int.Parse(dtRun.Rows[i]["frame"].ToString());

                                controlType = dtRun.Rows[i]["Controltype"].ToString();

                                elementID = dtRun.Rows[i]["ControlID"].ToString();
                                elementName = dtRun.Rows[i]["ControlName"].ToString();
                                controlText = dtRun.Rows[i]["ControlText"].ToString();
                                controlValue = dtRun.Rows[i]["controlValue"].ToString();

                                data = dtRun.Rows[i]["DataValue"].ToString();
                                testCase = dtRun.Rows[i]["TestCase"].ToString();
                                webPageID = int.Parse(dtRun.Rows[i]["WebPageId"].ToString());
                                action = dtRun.Rows[i]["Action"].ToString();
                                title = dtRun.Rows[i]["Title"].ToString();
                                index = int.Parse(dtRun.Rows[i]["Index"].ToString());

                                ignorePrefix = dtRun.Rows[i]["IgnorePrefix"].ToString();
                                ignoreSuffix = dtRun.Rows[i]["IgnoreSuffix"].ToString();
                                visible = dtRun.Rows[i]["Visible"].ToString();

                                if (lastTestCase.Length == 0)
                                {
                                    BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action);

                                    lastTestCase = testCase;
                                }
                                if (testCase != lastTestCase)
                                {
                                    //BusinessLayer.LogTofile(Environment.NewLine);
                                    BusinessLayer.LogTofile("", "", "", "", "", "End step:(" + i.ToString() + ") " + title + ":" + lastTestCase + "  Action:" + action + Environment.NewLine);
                                    //BusinessLayer.LogTofile("=========================" + Environment.NewLine);
                                    BusinessLayer.LogTofile("", "", "", "", "", "Start step:(" + i.ToString() + ") " + title + ":" + testCase + "  Action:" + action + Environment.NewLine);

                                    lastTestCase = testCase;

                                    if (pacing > 0)
                                    {
                                        System.Threading.Thread.Sleep(pacing * 1000);
                                        BusinessLayer.LogTofile("", "", "", "", "", "Waiting for :" + pacing + " seconds" + Environment.NewLine);
                                    }

                                }

                                //string userName = UIHelper.GetUserNameAndPassword("u", data);
                                //string password = UIHelper.GetUserNameAndPassword("p", data);
                                //UIHelper.FFWindowsLogon(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString(), userName, password);
                                ffdriver = Core.IdentifyWebPageFirefox(ffdriver , (string)dtRun.Rows[i]["Title"].ToString(), targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString(), authuser, authpwd, ffbinary);
                                #region "windowslogon"
                                
                                if (controlType.ToLower() == "windowslogon")
                                {
                                    

                                    string userName = UIHelper.GetUserNameAndPassword("u", data);
                                    string password = UIHelper.GetUserNameAndPassword("p", data);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Got username and password");
                                    System.Threading.Thread.Sleep(2000);
                                    UIHelper.FFWindowsLogon(targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString(), userName, password);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Attatching to URL :" + targetURL);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Successfully attached");
                                }
                                 
                                #endregion

                                if (controlType.ToLower() != "javascriptbutton" && controlType.ToLower() != "wait" && controlType.ToLower() != "waitforwebpage")
                                {
                                    //  ie = Core.IdentifyWebPage((string)dtRun.Rows[i]["Title"].ToString(), targetURL + (string)dtRun.Rows[i]["absolutepath"].ToString());
                                }

                                if (controlType.ToLower() == "wait")
                                {
                                    if (data.Length == 0)
                                        data = "1"; //wait for 1 second if wait not provided
                                    {
                                    }
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + data + " )Seconds");
                                    System.Threading.Thread.Sleep(int.Parse(data) * 1000);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");

                                }
                                if (controlType.ToLower() == "waitforwebpage")
                                {

                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Waiting for (" + waitTimeOut + " )Seconds");
                                    IE.AttachTo<IE>(Find.ByTitle(data.Trim()), waitTimeOut);
                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Wait over");
                                }

                                verificationValue = dtRun.Rows[i]["VerificationValue"].ToString();

                                if (action.ToLower() == "verify")
                                {
                                    data = verificationValue;
                                }
                                #region Dynamic Data

                                if (data.Contains("~"))
                                {

                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter encountered :" + currentUniqueName);

                                    paramDynamicParameters.Clear();
                                    currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link

                                    int startPos = currentUniqueName.IndexOf("~");
                                    currentUniqueName = currentUniqueName.Substring(startPos, data.IndexOf("~", startPos + 1) - startPos + 1);

                                    DataRow[] dtRows = dtDynamicParameter.Select("DynamicName= '" + currentUniqueName + "'");
                                    currentDynamicType = dtRows[0]["DynamicType"].ToString();
                                    currentDynamicFormat = dtRows[0]["Format"].ToString();

                                    drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);

                                    if (drDynamicValues.Length == 0)
                                    {


                                        if (currentDynamicType.ToLower() != "string")
                                        {
                                            currentUniquevalue = UIHelper.GenerateDynamicValue(currentDynamicType, currentUniqueName, currentDynamicFormat);

                                            if (currentUniquevalue.Length == 0)
                                            {
                                                throw new Exception("Unique value is not generated hence exiting");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Dynamic parameter value is :" + currentUniquevalue);

                                        }

                                    }
                                    #region Commented Code for Dynamic Parameters in Database

                                    //paramDynamicValues.Clear();
                                    //paramDynamicValues.Add(new SqlParameter("@ScenarioID", scenarioID));
                                    //paramDynamicValues.Add(new SqlParameter("@DynamicName", currentUniqueName));



                                    // DataTable dtDynamicValues = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                    // DataRow[] drDynamicValues = DynamicValues.Select("DynamicName='" +  currentUniqueName + "' AND " + " ScenarioID=" + scenarioID);

                                    #endregion
                                }
                                #endregion Dynamic Data
                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Current Element Type : " + controlType);

                                switch (controlType.ToLower())
                                {
                                    case "para":

                                    #region PARA
                                    
                                        
                                    #endregion
                                    case "span":
                                        ffdriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
                                        System.Threading.Thread.Sleep(5000);
                                    #region Span
                                     
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {


                                            var span = Core.getElementFFSpan(ffdriver,  frame, elementID, elementName, data, index);
                                            var spanText = "";

                                            if (span != null)
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", controlText).Replace("#webpage#", ffdriver.Title));
                                                spanText = span.Text.Replace(Environment.NewLine, "").Trim();
                                                if (data.ToLower() == "c")
                                                {
                                                    span.Click();
                                                }
                                            }
                                            else
                                            {
                                                //todo need to handle text in logging
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ffdriver.Title));
                                            }

                                            spanText = CheckPrefixSuffix(ignorePrefix, ignoreSuffix, spanText);
                                            if (currentUniqueName.Length != 0) // non-dynamic parameter
                                            {
                                                #region commented code

                                                //Database call
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                //if (dtExists.Rows.Count == 0)
                                                #endregion
                                                if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                {

                                                    AddDynamicValue(currentUniqueName, spanText, scenarioID);
                                                }

                                            }
                                            else if (data.Length > 0 && action.ToLower() == "verify")
                                            {
                                                logResult(data, spanText, controlType, elementName, "Text", scenario, testCase, "NoName");
                                            }

                                          //  CheckVisibility(controlType, elementName, testCase, visible, scenario, span);

                                        }

                                        break; 
                                    #endregion
                                    case "autocomplete":
                                    #region AutoComplete
                                    /*
                                        if (action.ToLower() == "add")
                                        {
                                            CommonControlCalls.AutoComplete(ie, frame, elementName, elementID, index, data);
                                        }
                                        else if (action.ToLower() == "verify")
                                        {
                                            TextField autoComplete = Core.GetTextField(ie, frame, elementName, elementID, -1);
                                            if (autoComplete != null)
                                            {

                                                logResult(verificationValue, autoComplete.Value, controlType, elementName, "Text", scenario, testCase, "NoName");
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "autocomplete").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }
                                        break; */
                                    #endregion AutoComplete
                                    case "image":

                                    #region Image
                                    /*
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {

                                           
                                            var img = Core.GetImage(ie, frame, elementName, elementID, index);

                                            if (img != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", img.IdOrName).Replace("#webpage#", ie.Title));

                                                isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    img.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, waiting for page load");
                                                    ie.WaitForComplete(waitTimeOut);

                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    img.ClickNoWait();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Image successfully clicked, not waiting for page load");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "Image").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }

                                        }

                                        break;*/
                                    #endregion
                                    case "button":

                                        #region Button
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {


                                            //     var button = Core.GetButton(ie, frame, elementName, elementID, controlValue, index);

                                            var button = Core.getElementFF(ffdriver, frame, elementID, elementName, controlValue, index);


                                            if (button != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", button.Text).Replace("#webpage#", ffdriver.Title));

                                                isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    button.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, waiting for page load");


                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                    button.Click();
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Button successfully clicked, not waiting for page load");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ffdriver.Title));
                                            }

                                        }


                                        #endregion
                                        break;
                                    case "selectlist":

                                        #region SelectList
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            ffdriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120.00));
                                            IWebElement selectList = Core.getElementFF(ffdriver, frame, elementID, elementName, controlValue, index);
                                            //// Tell webdriver to wait
                                            WebDriverWait wait = new WebDriverWait(ffdriver, TimeSpan.FromSeconds(4));

                                            // Test the autocomplete response - Explicit Wait
                                            IWebElement autocomplete = wait.Until(x => selectList);
                                           // IWebElement autocomplete = wait.Until(

                                            //for (int i1 = 0; i1 < attempts; i1++)
                                            //{
                                            //    System.Threading.Thread.Sleep(1000);
                                            //    if (selectList == null)
                                            //    {
                                            //        selectList = Core.getElementFF(ffdriver, frame, elementID, elementName, controlValue, index);
                                            //    }
                                            //    System.Threading.Thread.Sleep(1000);
                                            //    if (selectList != null)
                                            //    {

                                            //        break;
                                            //    }
                                            //    else
                                            //    {
                                            //        MessageBox.Show("Not Got Element");
                                            //    }
                                            //}
                                            if (selectList != null)
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", selectList.Text).Replace("#webpage#", ffdriver.Title));
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Searching for option :" + data);



                                                if (action.ToLower() == "add")
                                                {
                                                    // var option = selectList.Option(Find.ByText(data));

                                                    SelectElement select = new SelectElement(selectList);
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option value: " + data + " found");
                                                    try
                                                    {
                                                       
                                                       select.SelectByText(data);
                                                       while (select.SelectedOption.Text != data)
                                                       {
                                                           BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "Selected Text was", select.SelectedOption.Text);
                                                           selectList.Click();
                                                           selectList.Clear();
                                                           select.SelectByText(data);
                                                           System.Threading.Thread.Sleep(1000);
                                                       }
                                                        
                                                
                                                    }
                                                    catch
                                                    {

                                                    }



                                                    // BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", "Option " + data + " not found ");

                                                }
                                                else if (action.ToLower() == "verify")
                                                {

                                                    //  logResult(verificationValue, selectList.SelectedOption.Text, controlType, elementName, "Text", scenario, testCase, "NoName");

                                                }

                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ffdriver.Title));
                                            }

                                        }

                                        #endregion
                                        break;
                                    case "radiobutton":

                                        #region RadioButton
                                        /*
                                        WatiN.Core.RadioButton radioButton = null;

                                        if ((action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {
                                            radioButton = Core.GetRadioButton(ie, frame, elementName, elementID, -1);
                                            if (radioButton != null)
                                            {
                                                if (action.ToLower() == "add" && data.ToLower() == "c")
                                                {
                                                    BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", radioButton.IdOrName).Replace("#webpage#", ie.Title));
                                                    radioButton.Click();
                                                    ie.WaitForComplete(waitTimeOut);
                                                    break;
                                                }
                                                else if (action.ToLower() == "verify")
                                                {

                                                    logResult(verificationValue, radioButton.Checked.ToString(), controlType, elementName, "State", scenario, testCase, "NoName");

                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                            }
                                            System.Threading.Thread.Sleep(1000);

                                        }
                                         *  */
                                        #endregion


                                        break;
                                    case "textfield":

                                        #region TextField
                                        IWebElement txt = null;

                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            txt = Core.getElementFF(ffdriver, frame, elementID, elementName, controlValue, index);
                                            if (txt != null)
                                            {
                                                if (txt.Enabled == true)
                                                {
                                                    txt.Click();

                                                }
                                                BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", txt.Text
                                                    ).Replace("#webpage#", ffdriver.Title));

                                                if (action.ToLower() == "add")
                                                {

                                                    if (currentUniqueName.Length == 0) // non-dynamic parameter
                                                    {
                                                            SendKeys.SendWait("{Home}");
                                                            System.Threading.Thread.Sleep(500);
                                                            SendKeys.SendWait("+{End}");
                                                            System.Threading.Thread.Sleep(500);
                                                            SendKeys.SendWait("{Del}");
                                                            System.Threading.Thread.Sleep(500);
                                                            txt.SendKeys(data);
                                                        //    SendKeys.SendWait("{TAB}");

                                                    }
                                                    else
                                                    {
                                                        #region commented code

                                                        //Database call
                                                        //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                        //if (dtExists.Rows.Count == 0)
                                                        #endregion
                                                        if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                        {
                                                            txt.SendKeys(currentUniquevalue);
                                                            // AddDynamicValue(currentUniqueName, currentUniquevalue, scenarioID);
                                                        }
                                                        // else
                                                        // txt.Value = drDynamicValues[0]["DynamicValue"].ToString();
                                                    }

                                                }
                                                if (action.ToLower() == "verify")
                                                {
                                                    if (currentUniqueName.Length == 0) // non-dynamic parameter
                                                    {
                                                        logResult(verificationValue, txt.Text, controlType, elementName, "Text", scenario, testCase, "NoName");
                                                    }
                                                    else
                                                    {
                                                        if (drDynamicValues == null || drDynamicValues.Length == 0)
                                                        {

                                                            logResult("Dynamicvaluenotread", txt.Text, controlType, elementName, "Text", scenario, testCase, "NoName");
                                                        }
                                                        else
                                                        {
                                                            logResult(drDynamicValues[0]["DynamicValue"].ToString(), txt.Text, controlType, elementName, "Text", scenario, testCase, "NoName");

                                                        }
                                                    }
                                                }


                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ffdriver.Title));
                                            }
                                        }

                                        #endregion
                                        break;
                                    case "element":
                                        /*
                                        var ele = ie.Element(Find.ById(elementID));
                                        ele.SetAttributeValue("value", data); */
                                        break;
                                    case "link":  //need to think about dynamic links
                                        
                                        IWebElement lnk = null;
                                        isJavaScriptButton = IsJavaScriptButton(dtRun, i);
                                        #region Link
                                        if ((data.ToLower() == "c") && (action.ToLower() == "add" || (action.ToLower() == "verify")))
                                        {
                                            currentUniqueName = data.Length > 0 ? data : elementName;  //data is for link
                                            if (currentTableRow >= 0)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Searching link in the web table");
                                                lnk =  Core.getElementFFLink(ffdriver, frame, elementID, elementName, controlValue, index);
                                                currentTableRow = -1; //reset the rownumber
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Searching link  on the webpage");
                                                lnk = Core.getElementFFLink(ffdriver, frame, elementID, elementName, controlValue, index);

                                            }

                                            if (lnk != null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", lnk.Text).Replace("#webpage#", ffdriver.Title));
                                                if (data.ToLower() == "c" && isJavaScriptButton == false)
                                                {
                                                    lnk.Click();
                                                    
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, waiting for page load");


                                                }
                                                else if (data.ToLower() == "c" && isJavaScriptButton == true)
                                                {
                                                  //  lnk.ClickNoWait();
                                                  //  BusinessLayer.LogTofile("", "", "", "", "", "Link successfully clicked, not waiting for page load");
                                                }
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "Link").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ffdriver.Title));
                                            }

                                            ffdriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(120.00));
                                        }
                                        #endregion
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageverifyActionIgnore);
                                        }
                                        
                                        break;
                                    case "checkbox":
                                        #region CheckBox
                                        /*
                                        WatiN.Core.CheckBox checkbox = null;
                                        checkbox = Core.GetChecKBox(ie, frame, elementName, elementID, -1);
                                        if (checkbox != null)
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", checkbox.IdOrName).Replace("#webpage#", ie.Title));

                                            if (action.ToLower() == "add")
                                            {

                                                checkbox.Click();
                                                ie.WaitForComplete(waitTimeOut);
                                            }
                                            else if (action.ToLower() == "verify")
                                            {

                                                logResult(verificationValue, checkbox.Checked.ToString(), controlType, elementName, "State", scenario, testCase, "NoName");
                                            }

                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", "button").Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        }

                                        */
                                        #endregion

                                        break;
                                    case "div":
                                        /*
                                        var div = Core.GetDiv(ie, frame, elementName, elementID, -1);
                                        if (div != null)
                                        {
                                            BusinessLayer.LogTofile(i.ToString(), testCase, controlType, elementName, "", messageFoundControl.Replace("#controltype", controlType).Replace("#name", div.IdOrName).Replace("#webpage#", ie.Title));
                                            div.Click();
                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        } */
                                        break;
                                    case "navigateto":
                                    #region navigateto
                                    /*
                                        BusinessLayer.LogTofile("", "", "", "", "", "Action Navigateto");
                                        drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                        if (drDynamicValues.Length > 0)  // for dynamic values
                                        {

                                            BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                            currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                            if (!targetURL.EndsWith("/"))
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));
                                                ie.GoTo(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue));

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");

                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data.Replace(currentUniqueName, currentUniquevalue));
                                                ie.GoTo(targetURL + data.Replace(currentUniqueName, currentUniquevalue));

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + data.Replace(currentUniqueName, currentUniquevalue))).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }

                                        }
                                        else  //for normal urls
                                        {
                                            if (!targetURL.EndsWith("/"))
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + "/" + data);
                                                ie.GoTo(targetURL + "/" + data);

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + "/" + data)).WaitForComplete(waitTimeOut);

                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }
                                            else
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "URL:" + targetURL + data);
                                                ie.GoTo(targetURL + data);

                                                IE.AttachTo<IE>(Find.ByUrl(targetURL + data)).WaitForComplete(waitTimeOut);
                                                BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                                            }
                                        }
                                        ie.WaitForComplete(waitTimeOut);
                                        break;
                                        */
                                    #endregion
                                    case "fireevent":
                                        /*
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to fire event name=" + data);
                                            ie.ActiveElement.FireEvent(data);
                                            BusinessLayer.LogTofile("", "", "", "", "", "Event Fired Successfully");
                                        }
                                         * */
                                        break;
                                    case "javascriptbutton":
                                        #region javascriptbutton
                                        {
                                            try
                                            {
                                                while (isAlertPresent(ffdriver) == false)
                                                {
                                                    System.Threading.Thread.Sleep(1000);
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Wating for alert Message");
                                                }
                                                ffdriver.SwitchTo().Alert().Accept();
                                            }
                                            catch (Exception ex)
                                            {
                                                UIHelper.StopMessage("javascriptbutton: " + ex.Message);
                                            }

                                            break;
                                        }
                                    #endregion
                                    case "keyboard":
                                        /*
                                        CommonControlCalls.KeyBoard(ie, frame, elementName, elementID, index, data, waitTimeOut);
                                         * */
                                        //hardkoding one shift tab since we send addtional tab for Textfiedsl need to redo logic
                                      
                                          System.Threading.Thread.Sleep(100);
                                        SendKeys.Flush();
                                           SendKeys.SendWait(data);
                                           System.Threading.Thread.Sleep(100);
                                        break;
                                    case "searchwebtablerow":
                                        #region searchwebtablerow
                                        /*
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable for data: " + data + " " + " value:" + currentUniquevalue);
                                            currentUniquevalue = data;
                                            if (currentUniqueName.Length > 0)  //Need to code for non-dyanmic tables
                                            {
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                                if (drDynamicValues.Length > 0)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                                    currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                                }

                                            }
                                            currentTableRow = -1;

                                            for (int k = 0; k < attempts; k++)
                                            {
                                                targetTable = Core.GetWebTable(ie, frame, currentUniquevalue, index);
                                                if (targetTable != null)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got Webtable for data : " + data);
                                                    //  logTofile("Inner HTML: " + targetTable.InnerHtml);
                                                    break;
                                                }

                                            }
                                            if (targetTable == null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Could not find table, searched with keyword " + data);
                                                throw new Exception("Table not found");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable row for data : " + data);
                                            for (int z = 0; z < attempts; z++)
                                            {
                                                currentTableRow = Core.GetWebTableRow(targetTable, currentUniquevalue);
                                                if (currentTableRow != -1)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got webtable row for data : " + data);
                                                    break;
                                                }
                                                else
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Did not find the web table row for data  : " + data);
                                                    break;
                                                }
                                            }
                                        }
                                        */
                                        break;
                                        #endregion
                                    case "clicktablerow":
                                        #region clicktablerow
                                        /*
                                        if (action.ToLower() == "add" || (action.ToLower() == "verify"))
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable for data: " + data + " " + " value:" + currentUniquevalue);
                                            currentUniquevalue = data;
                                            if (currentUniqueName.Length > 0)  //Need to code for non-dyanmic tables
                                            {
                                                //DataTable dtExists = DataAccessLayer.GetReturnDataTable("[GetDynamicValue]", paramDynamicValues);
                                                drDynamicValues = GetDynamicValue(currentUniqueName, scenarioID);
                                                if (drDynamicValues.Length > 0)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Dynamic value found:" + drDynamicValues[0]["Dynamicvalue"].ToString());
                                                    currentUniquevalue = drDynamicValues[0]["Dynamicvalue"].ToString();
                                                }

                                            }
                                            currentTableRow = -1;

                                            for (int k = 0; k < attempts; k++)
                                            {
                                                targetTable = Core.GetWebTable(ie, frame, currentUniquevalue, index);
                                                if (targetTable != null)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got Webtable for data : " + data);
                                                    break;
                                                }

                                            }
                                            if (targetTable == null)
                                            {
                                                BusinessLayer.LogTofile("", "", "", "", "", "Could not find table, searched with keyword " + data);
                                                throw new Exception("Table not found");
                                            }

                                            BusinessLayer.LogTofile("", "", "", "", "", "Trying to search webtable row for data : " + data);
                                            for (int z = 0; z < attempts; z++)
                                            {
                                                currentTableRow = Core.GetWebTableRow(targetTable, currentUniquevalue);
                                                if (currentTableRow != -1)
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Got webtable row for data : " + data);
                                                    targetTable.OwnTableRows[currentTableRow].Click();

                                                    break;
                                                }
                                                else
                                                {
                                                    BusinessLayer.LogTofile("", "", "", "", "", "Did not find the web table row for data  : " + data);
                                                    break;
                                                }
                                            }
                                        }
                                        */
                                        break;
                                        #endregion
                                    case "windowslogon":
                                        BusinessLayer.LogTofile("", "", "", "", "", "Windows logon");  // this is handled above the select clauses
                                        break;
                                    case "webtable":
                                        /*
                                        Table table = null;
                                        if (elementName.Trim().Length > 0)
                                        {
                                            table = Core.GetWebTable(ie, frame, elementName, index);
                                        }
                                        else if (elementID.Trim().Length > 0)
                                        {
                                            table = Core.GetWebTable(ie, frame, elementID, index);
                                        }

                                        if (table != null)
                                        {

                                            //webtableName = elementID.Length > 0 ? elementID : elementName;
                                            //webtableName = webtableName.Replace(" ", "_");
                                            //BusinessLayer.LogTofile(messageFoundControl.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName.Replace("#webpage#", ie.Title)));
                                            List<SqlParameter> paramlst = new List<SqlParameter>(0);

                                            paramlst.Add(new SqlParameter("@TableName", data + "_" + testCase));
                                            DataTable webData = DataAccessLayer.GetReturnDataTable("[GetWebtableData]", paramlst);


                                            for (int tabRows = 0; tabRows < webData.Rows.Count; tabRows++)
                                            {
                                                int rowNo = int.Parse(webData.Rows[tabRows]["Rowno"].ToString());
                                                int columnNo = int.Parse(webData.Rows[tabRows]["ColumnNo"].ToString());
                                                string columnName = webData.Rows[tabRows]["columnName"].ToString();

                                                string expectedValue = webData.Rows[tabRows]["Value"].ToString();

                                                try
                                                {
                                                    string actualValue = table.OwnTableRows[rowNo].OwnTableCells[columnNo].Text;
                                                    logResult(expectedValue, actualValue, controlType, elementName, "ColumnData", scenario, testCase, columnName);
                                                }
                                                catch
                                                {

                                                    logResult(expectedValue, "Valuenotread", controlType, elementName, "ColumnData", scenario, testCase, columnName);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            BusinessLayer.LogTofile("", "", "", "", "", messageControlNotFound.Replace("#controltype", controlType).Replace("#name", elementID.Length > 0 ? elementID : elementName).Replace("#webpage#", ie.Title));
                                        }
                                         * */
                                        break;
                                    default:
                                        BusinessLayer.LogTofile("", "", "", "", "", "Invalid controltype encountered: " + controlType);
                                        break;
                                }

                            }



                        }

                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            //ie.ClearCookies();
                            //ie.ClearCache();
                            //ie.Close();
                            //System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("IExplore");
                            //foreach (System.Diagnostics.Process process in p)
                            //{
                            //    process.Kill();
                            //}
                        }

                        #endregion
                        break;
                    }
            }

            MessageBox.Show("Test Case Execution has been completed", "Execution Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    

        private static string CheckPrefixSuffix(string ignorePrefix, string ignoreSuffix, string elementText)
        {

            if (ignorePrefix.Length > 0) // if entire data is not taken but the substrings
            {

                elementText = elementText.Replace(ignorePrefix, "");

            }
            if (ignoreSuffix.Length > 0) // if entire data is not taken but the substrings
            {

                elementText = elementText.Replace(ignoreSuffix, "");

            }
            return elementText;
        }

        private static void CheckVisibility(string controlType, string elementName, string testCase, string visible, string scenario, Element element)
        {
            if (visible.ToLower() == "true" || visible.ToLower() == "false")
            {
                var visibility = element.GetAttributeValue("style");
                if (visibility.Contains("display: none"))
                {
                    logResult(visible, "false", controlType, elementName, "Visibile",scenario, testCase, "NoName");
                }
                else
                {
                    logResult(visible, "true", controlType, elementName, "Visible",scenario, testCase, "NoName");
                }

            }
        }
        private static Boolean IsJavaScriptButton(DataTable dt, int rowNo)
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

        private static void AddDynamicValue(string dynamicName, string dynamicValue, int scenarioID)
        {


            try
            {
                DataRow dr = dtDynamicValues.NewRow();

                dr["Dynamicvalue"] = dynamicValue;
                dr["DynamicName"] = dynamicName;
                dr["ScenarioID"] = scenarioID;
                dtDynamicValues.Rows.Add(dr);

                //    List<SqlParameter> para = new List<SqlParameter>(0);
                //    para.Add(new SqlParameter("@DynamicName", dynamicName));
                //    para.Add(new SqlParameter("@DynamicValue", dynamicValue));
                //    para.Add(new SqlParameter("@ScenarioID", scenarioID));
                //    DataAccessLayer.GetReturnDataTable("DynamicValueAdd", para);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void logResult(string expected, string actual, string controlType, string controlName, string attribute,string scenario, string testCase, string friendlyName )
        {
            try
            {
                string resultFile = UIHelper.GetConfigurationValue("resultFile");

                string result = "Pass";
                
                if (expected.ToLower() != actual.ToLower())
                {
                    result = "Fail";
                }

              //  string snaphsotpathname = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string snaphsotpathname = "";
                char deleim = '\u0022';
                string[] arrcolumnheaders = new string[] {"Sceanrio", "Testcase","ControlType","ControlName",
                                                           "FriendlyName","Attribute","Expected","Actual","Result", "Snasphot" };
                StringBuilder sb = new StringBuilder();
                foreach (string col in arrcolumnheaders)
                {
                    sb.Append(deleim + col + deleim + ",");
                }
                string columnHeader = sb.ToString();
                string comparsion = "";
                sb.Clear();
                if (!System.IO.File.Exists(resultFile))
                {
                    System.IO.File.AppendAllText(resultFile, columnHeader + Environment.NewLine);
                }
                string[] arrcolvlas = new string[] { scenario, testCase, controlType, controlName, friendlyName, attribute, expected, actual, result, snaphsotpathname };
                foreach (string col in arrcolvlas)
                {
                    sb.Append(deleim + col + deleim + ",");
                }
                comparsion = sb.ToString();

                System.IO.File.AppendAllText(resultFile, comparsion + Environment.NewLine);

            }
            catch (Exception)
            {

                throw;
            }

        }
        private static void logResult(string expected, string actual, string controlType, string controlName, string attribute, string scenario, string testCase, string friendlyName, CompareType ct)
        {
            try
            {
                string resultFile = UIHelper.GetConfigurationValue("resultFile");

                string result = "Pass";
                if (ct.ToString().ToLower() == "equals")
                {
                    if (expected.ToLower() != actual.ToLower())
                    {
                        result = "Fail";
                    }
                }
                else if (ct.ToString().ToLower() == "contains")
                {
                    if (!actual.Contains(expected))
                    {
                        result = "Fail";
                    }
                }

                string snaphsotpathname = "";
                char deleim = '\u0022';
                string[] arrcolumnheaders = new string[] {"Sceanrio", "Testcase","ControlType","ControlName",
                                                           "FriendlyName","Attribute","Expected","Actual","Result", "Snasphot" };
                StringBuilder sb = new StringBuilder();
                foreach (string col in arrcolumnheaders)
                {
                    sb.Append(deleim + col + deleim + ",");
                }
                string columnHeader = sb.ToString();
                string comparsion = "";
                sb.Clear();
                if (!System.IO.File.Exists(resultFile))
                {
                    System.IO.File.AppendAllText(resultFile, columnHeader + Environment.NewLine);
                }
                string[] arrcolvlas = new string[] { scenario, testCase, controlType, controlName, friendlyName, attribute, expected, actual, result, snaphsotpathname };
                foreach (string col in arrcolvlas)
                {
                    sb.Append(deleim + col + deleim + ",");
                }
                comparsion = sb.ToString();

                System.IO.File.AppendAllText(resultFile, comparsion + Environment.NewLine);

            }
            catch (Exception)
            {

                throw;
            }

        }
        private static void logResult(ChromeDriver drv ,string expected, string actual, string controlType, string controlName, string attribute, string scenario, string testCase, string friendlyName, CompareType ct)
        {
            try
            {
                string resultFile = UIHelper.GetConfigurationValue("resultFile");

                string result = "Pass";
                if (ct.ToString().ToLower() == "equals")
                {
                    if (expected.ToLower() != actual.ToLower())
                    {
                        result = "Fail";
                    }
                }
                else if (ct.ToString().ToLower() == "contains")
                {
                    if (!actual.Contains(expected))
                    {
                        result = "Fail";
                    }
                }

                string snaphsotpathname = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string impath = Core.TakeScreenshot(drv, snaphsotpathname);
                char deleim = '\u0022';
                string[] arrcolumnheaders = new string[] {"Sceanrio", "Testcase","ControlType","ControlName",
                                                           "FriendlyName","Attribute","Expected","Actual","Result", "Snasphot" };
                StringBuilder sb = new StringBuilder();
                foreach (string col in arrcolumnheaders)
                {
                    sb.Append(deleim + col + deleim + ",");
                }
                string columnHeader = sb.ToString();
                string comparsion = "";
                sb.Clear();
                if (!System.IO.File.Exists(resultFile))
                {
                    System.IO.File.AppendAllText(resultFile, columnHeader + Environment.NewLine);
                }
                string[] arrcolvlas = new string[] { scenario, testCase, controlType, controlName, friendlyName, attribute, expected, actual, result, impath };
                foreach (string col in arrcolvlas)
                {
                    sb.Append(deleim + col + deleim + ",");
                }
                comparsion = sb.ToString();

                System.IO.File.AppendAllText(resultFile, comparsion + Environment.NewLine);

            }
            catch (Exception)
            {

                throw;
            }

        }
        private static DataRow[] GetDynamicValue(string dynamicName, int scenarioID)
        {
            try
            {
                return dtDynamicValues.Select("DynamicName='" + dynamicName + "' AND " + " ScenarioID=" + scenarioID);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public static Boolean isAlertPresent(IWebDriver fftdriver)
        {
            
            try
            {
                fftdriver.SwitchTo().Alert();
                return true;
            }//try
            catch (Exception e)
            {
                return false;
            }//catch
        }
        
    }
}
