#region Comments
#region 11-Dec
//1. Added additional parameters to constructor
//2. Getting web page details from Pagemaster instead of database hit
#endregion
#region 12-Dec
//1. Added Code to handle change in controlname
#endregion
#region 16-Dec
//1. Commented code to allow change of control name
#endregion

#region 2-Jan-2015
// Identifying the controls by looping through the frames collection. 
#endregion
#region 4-Feb-2015
// Added method BusinessLayer.ScenariosDeleteTemps();
#endregion
#endregion

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
using System.Diagnostics;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebAutomation
{
    public partial class PageDetails : System.Windows.Forms.Form
    {
        IE ie;
       
        int currentRow = -1;
        string DataMode = "I";
        string originaltestCase = "";

        int frame = -1;
        int waitTimeOut = 1000;
        int currentPageID = -1;
        string targetURL = "";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageID"> PageID of the webpage</param>
        /// <param name="loadWebPage">True=Load the corresponding Webpage. False= Just open the Form</param>

        public PageDetails(int pageID, Boolean loadWebPage, string url, string absolutePath, string title)
        {
            InitializeComponent();
            waitTimeOut = int.Parse(targetURL = UIHelper.GetConfigurationValue("waittime"));
            targetURL = UIHelper.GetConfigurationValue("targeturl");



            if (targetURL.EndsWith(@"/"))
            {
                targetURL = targetURL.Substring(0, (targetURL.Length - 1));
            }
            currentPageID = pageID;

            #region Set URL AND Title of the web page


            DataMode = "I";

            txtTitle.Text = title;
            if (targetURL.Length == 0 && absolutePath.Length == 1)
            {
                txtURL.Text = url;
            }
            else if (targetURL.Length > 0 && absolutePath.Length > 0)
            {
                txtURL.Text = targetURL + absolutePath;
            }
            txtWebPageId.Text = pageID.ToString();


            //DataTable dt = BusinessLayer.WebPageGet(currentPageID);

            //if (dt.Rows.Count > 0)
            //{
            //    txtTitle.Text = dt.Rows[0]["Title"].ToString();
            //    txtURL.Text = targetURL + dt.Rows[0]["Absolutepath"].ToString();
            //    txtWebPageId.Text = pageID.ToString();
            //    frame = int.Parse(dt.Rows[0]["Frame"].ToString());
            //}
            #endregion

            #region Get Test Case list
            GetTestCaseList();

            #endregion

            dnDynamicData.SelectedIndex = 0;


            if (loadWebPage == true)
            {
                Core.IdentifyWebPage(txtTitle.Text, txtURL.Text);
            }

            gdvSelectedControls.Columns["OrdinalPosition"].Visible = false;
            gdvSelectedControls.Columns["PageControlID"].Visible = false;
            gdvSelectedControls.Columns["DataName"].Visible = false;
            gdvSelectedControls.Columns["OriginalControlID"].Visible = false;
            gdvSelectedControls.Columns["OriginalControlName"].Visible = false;
            gdvSelectedControls.Rows.Add();
            dnAddVerify.SelectedIndex = 0;




        }
        DataTable dtGlobal = new DataTable();
        DataTable dtSelectedControls = new DataTable();

        //private void btnLoad_Click(object sender, EventArgs e)
        //{

        //    IdentifyWebPage();



        //    try
        //    {


        //        dtGlobal.Rows.Clear();
        //        dtGlobal.Columns.Clear();
        //        txtURL.BackColor = Color.White;
        //        btnLoad.Enabled = false;

        //        dtGlobal.Columns.Add("ControlType");
        //        dtGlobal.Columns.Add("Name");
        //        dtGlobal.Columns.Add("ID");
        //        dtGlobal.Columns.Add("Index");
        //        dtGlobal.Columns.Add("Hidden");


        //        try
        //        {

        //            if (ie == null)
        //            {
        //                ie = new IE(txtURL.Text);
        //                ie.WaitForComplete(waitTimeOut);
        //            }


        //        }
        //        catch (Exception)
        //        {

        //            txtURL.Focus();
        //            txtURL.BackColor = Color.Red;
        //            btnLoad.Enabled = true;
        //            return;
        //        }
        //        txtURL.BackColor = Color.LightGreen;
        //        ElementCollection ecCol = ie.Elements;


        //        btnLoad.Text = "Loading please wait...";

        //        for (int i = 0; i < ecCol.Count; i++)
        //        {

        //            string name = ecCol[i].Name == null  "NoName" : ecCol[i].Name;

        //            lstAllControls.Items.Add(GetControlType(ecCol[i].GetType().ToString() + name));

        //            for (int j = 0; j < lstControlSelected.Items.Count; j++)
        //            {


        //                if (lstControlSelected.Items[j].ToString().ToLower() == GetControlType(ecCol[i].GetType().ToString()).ToLower())
        //                {
        //                    DataRow dr = dtGlobal.NewRow();

        //                    dr["ControlType"] = GetControlType(ecCol[i].GetType().ToString());

        //                    var value = GetAttribute(dr["ControlType"].ToString(), ecCol[i], "name");

        //                    dr["Name"] = value == null ? "" : value;

        //                    dr["ID"] = ecCol[i].Id == null ? "" : ecCol[i].Id;
        //                    dr["Hidden"] = GetAttributeValue(ecCol[i]);


        //                    if (lstControlSelected.Items[j].ToString().ToLower() != "element]") //found in web pages like bing.
        //                    {

        //                        // if (ecCol[i].Name == null && ecCol[i].Id == null && ecCol[i].Text == null) // this is for adding the index numbers
        //                        if (value == null && ecCol[i].Id == null && ecCol[i].Text == null) // this is for adding the index numbers
        //                        {
        //                            string filter = "ControlType='" + GetControlType(ecCol[i].GetType().ToString()) + "' AND  LEN(NAME)=0 AND LEN(ID)=0";
        //                            DataRow[] rows = dtGlobal.Select(filter);
        //                            dr["Index"] = rows.Length;
        //                        }

        //                        if (ecCol[i].GetAttributeValue("Style") != null && dr["Hidden"].ToString() != "Y")
        //                        {
        //                            dr["Hidden"] = ecCol[i].GetAttributeValue("Style").ToLower() == "display: none;" ? "Y" : "N";
        //                        }



        //                        dtGlobal.Rows.Add(dr);
        //                    }
        //                    else
        //                    {
        //                        if (ecCol[i].Name != null || ecCol[i].Id != null)
        //                        {
        //                            dtGlobal.Rows.Add(dr);
        //                        }
        //                    }

        //                    break;

        //                }
        //            }
        //        }
        //        btnLoad.Enabled = true;
        //        btnLoad.Text = "Load";
        //        //gdvControls.DataSource = dtGlobal;

        //        FilterHidden();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}



        private void gdvControls_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            #region Commented Code as all controls is on hold

            //int flashTime = int.Parse(upDownFlash.Value.ToString());

            //var findBy = gdvControls.Columns[e.ColumnIndex].Name;


            //// if (e.RowIndex >= 0 && gdvControls.CurrentCell.OwningColumn.Name.ToLower() != "data")
            //string elementType = gdvControls.Rows[e.RowIndex].Cells["controltype"].Value.ToString();


            //if (e.RowIndex >= 0 && (findBy.ToLower() == "name" || findBy.ToLower() == "id"))
            //{
            //    var findByValue = gdvControls.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            //    if (elementType.ToLower() == "selectlist") //SHow the details for combobox type
            //    {

            //        ControlDetails(elementType, findByValue);
            //        //   return;
            //    }

            //    switch (findBy.ToLower())
            //    {
            //        case "id":
            //            ie.Element(Find.ById(findByValue)).Flash(flashTime);
            //            break;
            //        case "name":
            //            if (elementType.ToLower() == "link")
            //                ie.Element(Find.ByText(findByValue)).Flash(flashTime);
            //            else
            //                ie.Element(Find.ByName(findByValue)).Flash(flashTime);
            //            break;
            //        default:
            //            break;
            //    } 
            #endregion


            #region Not needed as controls can be found by element node
            //switch (elementType.ToLower())
            //{

            //    case "button":
            //        ie.Button(Find.ById(findBy)).Flash(flashTime);
            //        break;
            //    case "selectlist":
            //        ie.SelectList(Find.ById(findByValue)).Flash(flashTime);
            //        break;
            //    case "radiobutton":
            //        ie.RadioButton(Find.ById(findByValue)).Flash(flashTime);
            //        break;
            //    case "textfield":
            //        var txt = ie.TextField(Find.ById(findByValue));
            //        txt.Flash(flashTime);
            //        break;
            //    case "checkbox":
            //        ie.CheckBox(Find.ById(findByValue)).Flash(flashTime);
            //        break;
            //    case "element]":
            //        var ele = ie.Element(Find.ById(findByValue));
            //        ele.Flash(flashTime);
            //        break;
            //    case "link":
            //        ie.Link(Find.ByText(findByValue)).Flash(flashTime);
            //        break;
            //    case "image":
            //        if (findBy.Length > 0)
            //            ie.Image(Find.ById(findByValue)).Flash(flashTime);
            //        break;
            //    default:
            //        break;
            //}
            #endregion




        }



        //private void btnRight_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        MoveControls(lstControlTypes, lstControlSelected);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private void btnLeft_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        MoveControls(lstControlSelected, lstControlTypes);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        private void chkHidden_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnData_Click(object sender, EventArgs e)
        {

        }
        private void MoveControls(ListBox from, ListBox to)
        {
            try
            {
                ListBox.SelectedObjectCollection selectCol = from.SelectedItems;

                for (int i = 0; i < selectCol.Count; i++)
                {
                    to.Items.Add(selectCol[i]);

                }

                for (int i = 0; i < to.Items.Count; i++)
                {
                    from.Items.Remove(to.Items[i]);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        private string GetAttributeValue(Element currentElement)
        {
            try
            {
                if (currentElement.GetAttributeValue("Type") == null)
                {
                    return "N";
                }
                else
                {
                    return currentElement.GetAttributeValue("Type").ToLower() == "hidden" ? "Y" : "N";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCloseDetails_Click(object sender, EventArgs e)
        {

        }

        private void ControlDetails(string controlType, string elementID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            try
            {
                switch (controlType.ToLower())
                {
                    case "selectlist":
                        #region commentedcode for getting option values
                        //SelectList list = ie.SelectList(Find.ById(elementID));
                        //foreach (var option in list.Options)
                        //{
                        //    DataRow dr = dt.NewRow();
                        //    dr["Name"] = option.Name;
                        //    dr["Value"] = option.Value;
                        //    dt.Rows.Add(dr);

                        //}
                        //gdvControlDetails.DataSource = dt;
                        #endregion
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAllControls_Click(object sender, EventArgs e)
        {


        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = BusinessLayer.GetDynamicParameterList();
            //DataTable dtcontrolUsage = null;

            if (txtTestCases.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Mention test case");
                txtTestCases.Focus();
                return;

            }
            #region ValidateDynamicParameters
            string searchValue = "";
            for (int i = 0; i < gdvSelectedControls.Rows.Count; i++)
            {
                string data = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Data");
                if (data.StartsWith("~") || data.EndsWith("~"))
                {
                    int startPos = data.IndexOf("~");
                    searchValue = data.Substring(startPos, data.IndexOf("~", startPos + 1) - startPos + 1);
                    if (dt.Select("DynamicName='" + searchValue + "'").Length == 0)
                    {
                        gdvSelectedControls.Rows[i].Cells["Data"].Selected = true;
                        UIHelper.StopMessage("Invalid dynamic parameter name");
                        return;
                    }
                }

            }
            #endregion

            #region CheckControlNameAndIDChanges - Commented
            //Boolean foundControl = false;
            //for (int i = 0; i < gdvSelectedControls.Rows.Count; i++)
            //{

            //    if (

            //        UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlID") != UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Originalcontrolid")
            //        ||
            //        UIHelper.GetGridColumnValue(gdvSelectedControls, i, "controlname") != UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Originalcontrolname")

            //        )
            //    {
            //        dtcontrolUsage = BusinessLayer.CheckControlUsage(int.Parse(txtWebPageId.Text),
            //                               UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlID"),
            //                                UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlName"));
            //        DataRow[] usageRows = dtcontrolUsage.Select("webpageid =" + int.Parse(txtWebPageId.Text) + " AND testcase <>'" + txtTestCases.Text + "'");

            //        if (usageRows.Length > 0)
            //        {

            //            foundControl = true;
            //            break;
            //        }
            //    }
            //}
            //if (foundControl = true && UIHelper.ConfirmMessage("Controlname shared by other test cases, do you want to rename?", "Confirm") == DialogResult.No)
            //{

            //    return;
            //}
            #endregion

            if (txtTestCases.Text.Trim() != originaltestCase)
            {
                if (UIHelper.ConfirmMessage("New test case", "Confirmation") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                else
                    DataMode = "I";
            }
            else if (UIHelper.ConfirmMessage("Save data", "Confirmation") == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            btnSave.Enabled = false;
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["con"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            int rowCount = gdvSelectedControls.Rows.Count;
            try
            {
                int rowNo = 1;
                for (int i = 0; i < rowCount; i++)
                {

                    if (gdvSelectedControls.Rows[i].Cells["ControlType"].Value != null) //&& gdvSelectedControls.Rows[i].Cells["Data"].Value != null
                    {
                        string verificationValue = "";

                        string controlType = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlType");
                        string fieldName = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "UserFriendlyName");
                        string identifier = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Identifier");
                        string controlName = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "COntrolName");
                        string controlID = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlID");
                        string controlText = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlText");
                        string controlValue = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlValue");
                        string visible = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "visible");


                        string dataValue = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Data");
                        string originalData = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "OriginalData");
                        string action = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "IsAction");
                        int Index = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Index").Length == 0 ? 0 :
                             int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Index"));
                        int framePosition = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "framePosition").Length == 0 ? 0 :
                             int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, i, "framePosition"));

                        string ignorePrefix = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ignorePrefix");

                        string ignoreSuffix = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ignoreSuffix");

                        if (dnAddVerify.Text.ToLower() == "verify")
                        {
                            verificationValue = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Data");
                            dataValue = "";
                        }



                        int pageControlId = gdvSelectedControls.Rows[i].Cells["pageControlId"].Value == null ? -1 :
                          int.Parse(gdvSelectedControls.Rows[i].Cells["pageControlId"].Value.ToString());

                        int pagedataID = gdvSelectedControls.Rows[i].Cells["PageDataID"].Value == null ? -1 :
                            int.Parse(gdvSelectedControls.Rows[i].Cells["PageDataID"].Value.ToString());



                        string deleteRow = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "DeleteRow");
                        if (DataMode == "I")  // This changes when the user changes the test case number in the test case textbox 
                        {
                            originalData = "";
                            pageControlId = -1;
                        }

                        List<SqlParameter> parameters = new List<SqlParameter>(0);

                        parameters.Add(new SqlParameter("@WebPageID", txtWebPageId.Text));
                        parameters.Add(new SqlParameter("@PageControlID", pageControlId));
                        parameters.Add(new SqlParameter("@FieldName", fieldName));
                        parameters.Add(new SqlParameter("@pagedataid", pagedataID));
                        parameters.Add(new SqlParameter("@ControlType", controlType));
                        parameters.Add(new SqlParameter("@COntrolName", controlName));
                        parameters.Add(new SqlParameter("@ControlID", controlID));
                        parameters.Add(new SqlParameter("@ControlText", controlText));
                        parameters.Add(new SqlParameter("@ControlValue", controlValue));
                        parameters.Add(new SqlParameter("@ControlIndex", Index));
                        parameters.Add(new SqlParameter("@Testcase", txtTestCases.Text));
                        parameters.Add(new SqlParameter("@DataValue", dataValue));
                        parameters.Add(new SqlParameter("@OriginalData", originalData));
                        parameters.Add(new SqlParameter("@RowNo", rowNo));
                        parameters.Add(new SqlParameter("@Mode", DataMode));
                        parameters.Add(new SqlParameter("@DeleteRow", deleteRow));
                        parameters.Add(new SqlParameter("@IsAction", action));
                        parameters.Add(new SqlParameter("@VerificationValue", verificationValue));
                        parameters.Add(new SqlParameter("@Frame", framePosition));
                        parameters.Add(new SqlParameter("@IgnorePrefix", ignorePrefix));
                        parameters.Add(new SqlParameter("@IgnoreSuffix", ignoreSuffix));
                        parameters.Add(new SqlParameter("@Visible", visible));
                        parameters.Add(new SqlParameter("@AddOrVerify", dnAddVerify.Text));


                        DataAccessLayer.InsertData(con, trans, "PageControlsAdd", parameters);
                        rowNo++;
                    }
                }
                trans.Commit();
                UIHelper.SaveMessage();
                gdvSelectedControls.Enabled = false;
                gdvSelectedControls.Rows.Clear();
                txtTestCases.Clear();
                GetTestCaseList();
                if (gdvSelectedControls.Rows.Count == 0)
                    gdvSelectedControls.Rows.Add();
                //  DataMode = "U";
            }
            catch (Exception)
            {
                trans.Rollback();

                throw;
            }
            finally
            {
                btnSave.Enabled = true;
                gdvSelectedControls.Enabled = true;
                con.Close();
                con.Dispose();
            }

        }

        private void btnSelectControls_Click(object sender, EventArgs e)
        {
            #region All Controls not needed
            //try
            //{
            //    dtSelectedControls.Rows.Clear();
            //    dtSelectedControls.Columns.Clear();

            //    btnSelectControls.Enabled = false;

            //    dtSelectedControls.Columns.Add("WebPageID");
            //    dtSelectedControls.Columns.Add("ControlType");
            //    dtSelectedControls.Columns.Add("ControlName");
            //    dtSelectedControls.Columns.Add("ControlID");
            //    dtSelectedControls.Columns.Add("DataName");
            //    dtSelectedControls.Columns.Add("OrdinalPosition");


            //    for (int j = 0; j < gdvControls.Rows.Count; j++)
            //    {


            //        if (gdvControls.Rows[j].Cells[0].Value != null && gdvControls.Rows[j].Cells[0].Value.ToString().ToLower() == "true")
            //        {
            //            DataRow dr = dtSelectedControls.NewRow();

            //            dr["WebPageID"] = 1;
            //            dr["ControlType"] = gdvControls.Rows[j].Cells["ControlType"].Value.ToString();
            //            dr["ControlName"] = gdvControls.Rows[j].Cells["Name"].Value.ToString();
            //            dr["ControlID"] = gdvControls.Rows[j].Cells["ID"].Value.ToString();
            //            dr["OrdinalPosition"] = j;
            //            dtSelectedControls.Rows.Add(dr);
            //        }
            //    }
            //    btnSelectControls.Enabled = true;
            //    gdvSelectedControls.DataSource = dtSelectedControls;
            //    MessageBox.Show(dtSelectedControls.Rows.Count.ToString());
            //}
            //catch (Exception)
            //{

            //    throw;
            //} 
            #endregion

        }

        private void gdvSelectedControls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chkIdentifyControls.Checked == false)
            {


                return;
            }

            try
            {
                ie = Core.IdentifyWebPage(txtTitle.Text, txtURL.Text);
                string controlType = "";

                if (e.RowIndex >= 0)
                {
                    currentRow = e.RowIndex;

                    if (gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "identifier") //Add only when user clicks the field 
                    {

                        if (gdvSelectedControls.Rows[e.RowIndex].Cells["controltype"].Value != null)
                        {
                            if (UIHelper.ConfirmMessage("Overwrite Data", "Confirmation") == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                        }

                        WatiN.Core.Element watinControl = null;

                        watinControl = FindControls(ie.Frames.Count, ie);

                        //if (frame == -1)
                        //{

                        //    watinControl = ie.ActiveElement;
                        //}
                        //else
                        //    watinControl = ie.Frames[frame].ActiveElement;


                        if (watinControl != null)
                        {
                            controlType = GetControlType(watinControl.GetType().ToString());

                            string nameAttribute = GetAttribute(controlType, watinControl, "name");
                            string idAttribute = GetAttribute(controlType, watinControl, "id");
                            string valueAttribute = GetAttribute(controlType, watinControl, "value");

                            //if (IsControlAdded(e.RowIndex, controlType, nameAttribute, idAttribute) == false)
                            //{
                            gdvSelectedControls.Rows[e.RowIndex].Cells["controltype"].Value = GetControlType(watinControl.GetType().ToString());
                            gdvSelectedControls.Rows[e.RowIndex].Cells["controlname"].Value = nameAttribute;
                            gdvSelectedControls.Rows[e.RowIndex].Cells["controlID"].Value = idAttribute;
                            gdvSelectedControls.Rows[e.RowIndex].Cells["IsAction"].Value = "N";
                            gdvSelectedControls.Rows[e.RowIndex].Cells["FramePosition"].Value = frame;

                            if (idAttribute != null && idAttribute.Length > 0)
                            {
                                gdvSelectedControls.Rows[e.RowIndex].Cells["Identifier"].Value = "ID: " + idAttribute;
                            }
                            else if (nameAttribute != null && nameAttribute.Length > 0)
                            {
                                gdvSelectedControls.Rows[e.RowIndex].Cells["Identifier"].Value = "Name: " + nameAttribute;
                            }
                            //todo
                            gdvSelectedControls.Rows[e.RowIndex].ReadOnly = true;
                            //  }
                            //else
                            //{
                            //    UIHelper.StopMessage(controlType + ":" + nameAttribute + ":" + idAttribute + Environment.NewLine + "Control already added");
                            //    return;
                            //}

                            #region Get Value for the Combobox
                            if (controlType.ToLower() == "selectlist")
                            {
                                SelectList lst = Core.GetSelectList(ie, frame, nameAttribute, idAttribute, -1);

                                if (lst != null)
                                {
                                    if (lst.SelectedOption != null)
                                    {
                                        gdvSelectedControls.Rows[e.RowIndex].Cells["Data"].Value = lst.SelectedOption.Text;
                                    }
                                }

                            }
                            #endregion Get Value for the Combobox

                            #region SETClickVALUE FOR Buttons, Links etc
                            if (controlType.ToLower() == "button" || controlType.ToLower() == "link" || controlType.ToLower() == "radiobutton"
                                || controlType.ToLower() == "div" || controlType.ToLower() == "checkbox" || controlType.ToLower() == "image")
                            {
                                gdvSelectedControls.Rows[e.RowIndex].Cells["Data"].Value = "C";
                            }
                            #endregion
                        }
                    }


                    if (e.RowIndex == gdvSelectedControls.Rows.Count - 1)
                        gdvSelectedControls.Rows.Add();
                }
            }
            catch
            {

                MessageBox.Show("Could not identify controls");
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {

            gdvSelectedControls.Rows.Add(1);

        }

        private void CreateSelectControlsStruct()
        {

            // dtSelectedControls.Columns.Add("WebPageID");
            dtSelectedControls.Columns.Add("ControlType");
            dtSelectedControls.Columns.Add("ControlName");
            dtSelectedControls.Columns.Add("ControlID");
            dtSelectedControls.Columns.Add("DataName");
            dtSelectedControls.Columns.Add("OrdinalPosition");
            dtSelectedControls.Columns.Add("Data");
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
        private string GetAttribute(string tagName, Element element, string attributeName)
        {
            try
            {
                var returnValue = "";
                switch (tagName.ToLower())
                {
                    case "link":
                        if (attributeName.ToLower() == "name")
                            returnValue = element.Text;
                        else if (attributeName.ToLower() == "id")
                            returnValue = element.Id;
                        else if (attributeName.ToLower() == "value")
                            returnValue = element.GetAttributeValue("value");
                        break;
                    default:
                        if (attributeName.ToLower() == "name")
                            returnValue = element.Name;
                        else if (attributeName.ToLower() == "id")
                            returnValue = element.Id;
                        break;
                }
                return returnValue;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void gdvSelectedControls_MouseClick(object sender, MouseEventArgs e)
        {
            #region not required
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mnuGridOperations.Top = gdvSelectedControls.Top;
                mnuGridOperations.Left = gdvSelectedControls.Left;
                mnuGridOperations.Show();


            }
            #endregion
        }

        private void mnuGridOperations_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //private void SelectControlsOnHOld()
        //{
        //    try
        //    {
        //        dtSelectedControls.Rows.Clear();
        //        dtSelectedControls.Columns.Clear();

        //        btnSelectControls.Enabled = false;

        //        dtSelectedControls.Columns.Add("WebPageID");
        //        dtSelectedControls.Columns.Add("ControlType");
        //        dtSelectedControls.Columns.Add("ControlName");
        //        dtSelectedControls.Columns.Add("ControlID");
        //        dtSelectedControls.Columns.Add("DataName");
        //        dtSelectedControls.Columns.Add("OrdinalPosition");


        //        for (int j = 0; j < gdvControls.Rows.Count; j++)
        //        {


        //            if (gdvControls.Rows[j].Cells[0].Value != null && gdvControls.Rows[j].Cells[0].Value.ToString().ToLower() == "true")
        //            {
        //                DataRow dr = dtSelectedControls.NewRow();

        //                dr["WebPageID"] = 1;
        //                dr["ControlType"] = gdvControls.Rows[j].Cells["ControlType"].Value.ToString();
        //                dr["ControlName"] = gdvControls.Rows[j].Cells["Name"].Value.ToString();
        //                dr["ControlID"] = gdvControls.Rows[j].Cells["ID"].Value.ToString();
        //                dr["OrdinalPosition"] = j;
        //                dtSelectedControls.Rows.Add(dr);
        //            }
        //        }
        //        btnSelectControls.Enabled = true;
        //        gdvSelectedControls.DataSource = dtSelectedControls;
        //        MessageBox.Show(dtSelectedControls.Rows.Count.ToString());
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        private void gdvTestCaseList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                gdvSelectedControls.Enabled = false;

                DataMode = "U";
                string testCase = UIHelper.GetGridColumnValue(gdvTestCaseList, e.RowIndex, "TestCase");// gdvTestCaseList.Rows[e.RowIndex].Cells["Testcase"].Value.ToString();
                string addOrVerify = UIHelper.GetGridColumnValue(gdvTestCaseList, e.RowIndex, "Action");
                originaltestCase = testCase;
                dnAddVerify.Text = UIHelper.GetGridColumnValue(gdvTestCaseList, e.RowIndex, "Action");
                txtTestCases.Text = testCase;
                if (dnAddVerify.Text.ToLower() == "add")
                {
                    btnRun.Visible = true;
                }
                else
                {
                    btnRun.Visible = false;
                }


                btnAddVerification.Visible = true;

                for (int k = 0; k < gdvTestCaseList.Rows.Count; k++)
                {
                    if (UIHelper.GetGridColumnValue(gdvTestCaseList, k, "Action").ToLower() == "verify" &&
                        UIHelper.GetGridColumnValue(gdvTestCaseList, k, "Testcase").ToLower() == txtTestCases.Text.ToLower())
                    {
                        btnAddVerification.Visible = false;
                        break;
                    }
                }


                DataTable dt = BusinessLayer.GetWebPageControlsAndData(int.Parse(txtWebPageId.Text), testCase, UIHelper.GetGridColumnValue(gdvTestCaseList, e.RowIndex, "Action"));
                gdvSelectedControls.Rows.Clear();

                dnAddVerify.Text = UIHelper.GetGridColumnValue(gdvTestCaseList, e.RowIndex, "Action");

                if (addOrVerify.ToLower() == "add")
                {
                    gdvSelectedControls.Columns["OriginalData"].Visible = false;   //todo need to check if this code is reqd
                    gdvSelectedControls.Columns["OriginalVerificationData"].Visible = false;
                }
                else
                {
                    gdvSelectedControls.Columns["OriginalData"].Visible = false; //todo need to check if this code is reqd
                    gdvSelectedControls.Columns["OriginalVerificationData"].Visible = false;
                }

                dnAddVerify.Enabled = false;
                BusinessLayer.ShowWebPageControlsAndData(dt, gdvSelectedControls, addOrVerify);

            }

            gdvSelectedControls.Enabled = true;
            if (gdvSelectedControls.Rows.Count == 0)
                gdvSelectedControls.Rows.Add();

        }

        private void toolStripInsert_Click(object sender, EventArgs e)
        {
            if (currentRow >= 0)
            {
                Core.GetChecKBox(ie, int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, currentRow, "Frameposition")),
                    UIHelper.GetGridColumnValue(gdvSelectedControls, currentRow, "ControlName"),
                    UIHelper.GetGridColumnValue(gdvSelectedControls, currentRow, "ControlID"),
                    int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, currentRow, "Index"))).Flash(3);

                //   gdvSelectedControls.Rows.Insert(currentRow, 1);
            }
        }

        private Boolean IsControlAdded(int currentRow, string controlType, string controlName, string controlID)
        {

            for (int i = 0; i < gdvSelectedControls.Rows.Count; i++)
            {
                if (i != currentRow)
                {
                    if (gdvSelectedControls.Rows[i].Cells["ControlType"].Value != null)
                    {
                        if (
                           UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlType") == controlType
                            //gdvSelectedControls.Rows[i].Cells["ControlType"].Value.ToString() == controlType
                            &&
                            (
                               UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlName") == controlName
                            //  gdvSelectedControls.Rows[i].Cells["ControlName"].Value.ToString() == controlName
                                ||
                                 UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlID") == controlID
                            //  gdvSelectedControls.Rows[i].Cells["ControlID"].Value.ToString() == controlID
                            )
                            )
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (currentRow >= 0)
            {

                if (UIHelper.GetGridColumnValue(gdvSelectedControls, currentRow, "PageControlId").Length > 0)
                {
                    gdvSelectedControls.Rows[currentRow].Cells["DeleteRow"].Value = "Y";
                    gdvSelectedControls.Rows[currentRow].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                    gdvSelectedControls.Rows.RemoveAt(currentRow);
            }
        }

        private void chkAllControls_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void gdvSelectedControls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (chkIdentifyControls.Checked == true)
            {
                Core.IdentifyWebPage(txtTitle.Text, txtURL.Text);
            }
            try
            {
                if (e.RowIndex >= 0)
                {
                    currentRow = e.RowIndex;

                    if (gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "controltype") //Add only when user clicks the field 
                    {
                        gdvSelectedControls.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.YellowGreen;

                        SelectControlType form = new SelectControlType(gdvSelectedControls.CurrentCell);
                        form.ShowDialog();
                        gdvSelectedControls.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "windowslogon") //Add only when user clicks the field 
                    {
                        WindowsLogon form = new WindowsLogon(gdvSelectedControls.CurrentCell);
                        form.ShowDialog();

                    }
                    else if (gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "data") //Add only when user clicks the field 
                    {
                        if (gdvSelectedControls.CurrentCell.OwningRow.Cells["ControlType"].Value.ToString().ToLower() == "webtable")
                        {
                            if (txtTestCases.Text.Trim().Length == 0)
                            {
                                UIHelper.StopMessage("Test case name mandatory for webtables");
                                return;
                            }

                            WebTableDefinition form = new WebTableDefinition(gdvSelectedControls.CurrentCell, txtTitle.Text,
                                                                            txtURL.Text,
                                                                           UIHelper.GetGridColumnValue(gdvSelectedControls, e.RowIndex, "controlid"),
                                                                           UIHelper.GetGridColumnValue(gdvSelectedControls, e.RowIndex, "controlname"),
                                                                           int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, e.RowIndex, "Index")),
                                                                           txtTestCases.Text,
                                                                           int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, e.RowIndex, "Frameposition")),
                                                                           UIHelper.GetGridColumnValue(gdvSelectedControls, e.RowIndex, "Data")
                                                                           );
                            form.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void gdvSelectedControls_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gdvSelectedControls.CurrentCell.ReadOnly = false;

            if (
                gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "controltype"
                || gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "originaldata"
               // || gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "identifier"
                )
            {
                gdvSelectedControls.CurrentCell.ReadOnly = false;
            }
            if (

                UIHelper.GetGridColumnValue(gdvSelectedControls, e.RowIndex, "ControlType").ToLower() == "webtable"
               && gdvSelectedControls.CurrentCell.OwningColumn.Name.ToLower() == "data"
               )
            {
                gdvSelectedControls.CurrentCell.ReadOnly = false;
            }


        }

        private void GetTestCaseList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>(0);
            SqlParameter param = new SqlParameter("@WebpageID", currentPageID);
            parameters.Add(param);
            DataTable dt = DataAccessLayer.GetReturnDataTable("[GetTestCaseList]", parameters);



            gdvTestCaseList.Columns.Clear();
            gdvTestCaseList.DataSource = dt;
            gdvTestCaseList.Visible = true;


            gdvTestCaseList.Columns["URL"].Visible = false;
            gdvTestCaseList.Columns["Title"].Visible = false;
            gdvTestCaseList.Columns["Uniquename"].Visible = false;
            gdvTestCaseList.Columns["WebpageID"].Visible = false;
            gdvTestCaseList.Columns["ID"].Visible = false;
        }

        private void PageDetails_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void upDownOrdinalPosition_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerateData_Click(object sender, EventArgs e)
        {
            btnGenerateData.Enabled = false;


            string runValue = "";

            try
            {

                for (int i = 0; i < gdvSelectedControls.Rows.Count; i++)
                {
                    runValue = "";

                    if (chkAllControls.Checked == true)
                    {
                        if (dnDynamicData.Text.ToLower() == "guid")
                        {
                            Guid guid = Guid.NewGuid();
                            runValue = guid.ToString().Replace("-", "");
                        }
                    }


                    if (gdvSelectedControls.Rows[i].Cells["Controltype"].Value != null)
                    {
                        string elementType = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Controltype");

                        string elementID = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlID");
                        string elementName = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlName");

                        string originalData = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "OriginalData");
                        runValue = runValue.Length == 0 ? UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Data") : runValue;


                        switch (elementType.ToLower())
                        {

                            case "button":
                                gdvSelectedControls.Rows[i].Cells["Data"].Value = "C";
                                break;
                            case "selectlist":
                                var selectList = Core.GetSelectList(ie, frame, elementName, elementID, -1);
                                var position = int.Parse(upDownOrdinalPosition.Value.ToString());
                                var itemCount = selectList.Options.Count;

                                if (position > 0)
                                {
                                    if (position > itemCount - 1)
                                    {
                                        position = itemCount - 1;
                                    }
                                }
                                if (itemCount - 1 >= position)
                                {
                                    selectList.Options[position].Select();
                                    ie.WaitForComplete(waitTimeOut);
                                    gdvSelectedControls.Rows[i].Cells["Data"].Value = selectList.Options[position].Text;
                                }

                                break;
                            case "radiobutton":
                                gdvSelectedControls.Rows[i].Cells["Data"].Value = "C";
                                break;
                            case "textfield":
                                string val = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Data");
                                if (val.StartsWith("~") && val.EndsWith("~"))
                                {

                                }
                                else
                                {
                                    gdvSelectedControls.Rows[i].Cells["Data"].Value = runValue;
                                }
                                break;
                            case "element]":
                                gdvSelectedControls.Rows[i].Cells["Data"].Value = runValue;
                                break;
                            case "link":
                                gdvSelectedControls.Rows[i].Cells["Data"].Value = "C";
                                break;
                            case "checkbox":
                                gdvSelectedControls.Rows[i].Cells["Data"].Value = "C";
                                break;
                            case "div":
                                gdvSelectedControls.Rows[i].Cells["Data"].Value = "C";
                                break;
                            default:
                                break;
                        }

                    }
                }
                chkAllControls.Checked = false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                btnGenerateData.Enabled = true;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            BrowserOptions form = new BrowserOptions();
            form.ShowDialog();
            string browserSelected = BrowserOptions.broptions;
            if (browserSelected == "" || browserSelected == null)
            {
               // MessageBox.Show("Browser was not specified hence aborting");
                return;
            }
            if (browserSelected.ToLower() == "internet explorer")
            {
                Core.IdentifyWebPage(txtTitle.Text, txtURL.Text);
            }

            #region Working from common code written for scenarios
            Guid g = Guid.NewGuid();

            BusinessLayer.AddScenarioMaster(g.ToString().Replace("-", ""), "This is for run purpose only");

            DataTable dtMaster = BusinessLayer.GetScenarioMasterDetails(g.ToString().Replace("-", ""));
            int scenarioMasterID = int.Parse(dtMaster.Rows[0]["ID"].ToString());

            BusinessLayer.AddScenarioDetail(scenarioMasterID, int.Parse(txtWebPageId.Text), txtTestCases.Text, dnAddVerify.Text, 0);
            #endregion

            btnRun.Enabled = false;

            try
            {
                BusinessLayer.RunScenario(browserSelected , scenarioMasterID);
                BusinessLayer.ScenariosDeleteTemps();
            }
            catch (Exception ex)
            {

                UIHelper.StopMessage(ex.Message);
            }
            finally
            {
                btnRun.Enabled = true;
                

            }

            #region Commented code as running from businesslayer
            //Table table = null;
            //int currentTableRow = -1;

            //try
            //{

            //    for (int i = 0; i < gdvSelectedControls.Rows.Count; i++)
            //    {


            //        if (gdvSelectedControls.Rows[i].Cells["Controltype"].Value != null)
            //        {
            //            string elementType = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Controltype");

            //            string elementID = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlID");
            //            string elementName = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlName");
            //            string elementText = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "ControlText");
            //            string data = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Data");
            //            string dataName = UIHelper.GetGridColumnValue(gdvSelectedControls, i, "DataName");
            //            frame = int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Frameposition"));
            //            if (UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Index").Trim().Length == 0)
            //            {
            //                gdvSelectedControls.Rows[i].Cells["index"].Value = "0";
            //            }

            //            int index = int.Parse(UIHelper.GetGridColumnValue(gdvSelectedControls, i, "Index"));
            //            switch (elementType.ToLower())
            //            {


            //                case "para":
            //                    var para = Core.GetPara(ie, frame, elementName, elementID, elementText, index);
            //                    break;

            //                case "keyboard":

            //                    CommonControlCalls.KeyBoard(ie, frame, elementName, elementID, index, data, waitTimeOut);
            //                    break;
            //                case "tablecell":

            //                    var tableCell = Core.GetTableCell(ie, frame, elementName, elementID, -1);
            //                    tableCell.Click();
            //                    break;
            //                case "image":

            //                    var img = Core.GetImage(ie, frame, elementName, elementID, -1);
            //                    img.Click();
            //                    break;
            //                case "autocomplete":
            //                    CommonControlCalls.AutoComplete(ie, frame, elementName, elementID, index, data);
            //                    break;
            //                case "button":
            //                    var button = Core.GetButton(ie, frame, elementName, elementID, -1);
            //                    if (data.ToLower() == "c")
            //                    {
            //                        button.Click();
            //                        ie.WaitForComplete(waitTimeOut);
            //                    }
            //                    break;
            //                case "selectlist":
            //                    var selectList = Core.GetSelectList(ie, frame, elementName, elementID, -1);
            //                    var option = selectList.Option(Find.ByText(data));
            //                    option.Select();
            //                    break;
            //                case "radiobutton":
            //                    WatiN.Core.RadioButton radioButton = Core.GetRadioButton(ie, frame, elementName, elementID, -1);
            //                    radioButton.Click();
            //                    ie.WaitForComplete(waitTimeOut);
            //                    break;
            //                case "textfield":
            //                    var txt = Core.GetTextField(ie, frame, elementName, elementID, -1);
            //                    txt.Value = data;
            //                    txt.Focus();
            //                    txt.KeyDown();
            //                    break;
            //                case "element]":
            //                    var ele = ie.Element(Find.ById(elementID));
            //                    ele.SetAttributeValue("value", data);
            //                    break;
            //                case "link":
            //                    Link lnk = null;
            //                    if (currentTableRow >= 0)
            //                    {
            //                        lnk = table.OwnTableRows[currentTableRow].Link(Find.ByText(new Regex(elementID)));

            //                    }
            //                    else
            //                    {
            //                        lnk = Core.GetLink(ie, frame, elementName, elementID, index);
            //                    }
            //                    lnk.Click();
            //                    ie.WaitForComplete(waitTimeOut);
            //                    break;
            //                case "checkbox":
            //                    var checbox = Core.GetChecKBox(ie, frame, elementName, elementID, -1);
            //                    checbox.Click();
            //                    ie.WaitForComplete(waitTimeOut);
            //                    break;
            //                case "div":
            //                    var div = Core.GetDiv(ie, frame, elementName, elementID, -1);
            //                    div.Click();
            //                    break;
            //                case "navigateto":
            //                    ie.GoTo(data);
            //                    break;
            //                case "fireevent":
            //                    ie.ActiveElement.FireEvent(data);
            //                    break;
            //                case "webtable":
            //                    table = GetWebTable(elementID);
            //                    break;
            //                case "fileupload":
            //                    Core.GetFileUpload(ie, frame, elementName, elementID, -1).ClickNoWait();
            //                    System.Threading.Thread.Sleep(4000);
            //                    SendKeys.SendWait(data);
            //                    System.Threading.Thread.Sleep(2000);
            //                    SendKeys.SendWait("{ENTER}");
            //                    break;
            //                case "searchwebtablerow":
            //                    var dynamicValue = "";
            //                    if (elementName.Trim().Length > 0)
            //                    {
            //                        if (elementName.StartsWith("~") && elementName.EndsWith("~"))
            //                        {
            //                            dynamicValue = GetDynamicValue(elementName);
            //                            table = GetWebTable(dynamicValue);
            //                        }
            //                        else
            //                            table = GetWebTable(elementName);

            //                    }
            //                    else if (elementID.Trim().Length > 0)
            //                    {
            //                        if (elementID.StartsWith("~") && elementID.EndsWith("~"))
            //                        {
            //                            dynamicValue = GetDynamicValue(elementID);
            //                            table = GetWebTable(dynamicValue);
            //                        }
            //                        else
            //                            table = GetWebTable(elementID);
            //                    }
            //                    if (dynamicValue.Length > 0)
            //                    {
            //                        currentTableRow = SearchWebTableRow(table, dynamicValue);
            //                    }
            //                    else
            //                    {
            //                        currentTableRow = SearchWebTableRow(table, data);
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }

            //        }
            //    } 
            #endregion
            chkAllControls.Checked = false;

        }

        private void gdvSelectedControls_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;
        }

        private Table GetWebTable(string searchValue)
        {
            Table table = null;

            try
            {
                TableCollection tables = ie.Tables;
                for (int i = tables.Count - 1; i >= 0; i--)
                {
                    if (tables[i].InnerHtml.Contains(searchValue))
                    {
                        table = tables[i];
                        break;
                    }
                }

                return table;
                //for (int j = 0; j < table.OwnTableRows.Count; j++)
                //{
                //    if (table.OwnTableRows[j].InnerHtml.Contains(searchValue))
                //    {
                //        table.TableRows[j].Link(Find.ByText("Assign Project Number")).Click();
                //    }
                //}

            }

            catch
            {
                throw;
            }

        }

        private int SearchWebTableRow(Table table, string searchValue)
        {
            int tableRow = -1;
            try
            {


                for (int j = 0; j < table.OwnTableRows.Count; j++)
                {
                    if (table.OwnTableRows[j].InnerHtml.Contains(searchValue))
                    {
                        tableRow = j;
                    }
                }
                return tableRow;
            }


            catch
            {
                throw;
            }

        }

        private void gdvTestCaseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string GetDynamicValue(string dynamicName)
        {
            List<SqlParameter> parameters = new List<SqlParameter>(0);

            parameters.Add(new SqlParameter("@dynamicname", dynamicName));

            DataTable dt = DataAccessLayer.GetReturnDataTable("GetDynamicValue", parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["DynamicValue"].ToString();
            }
            else
            {
                throw new Exception("Dynamic parameter does not exist");
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTestCases.Clear();
            gdvSelectedControls.Rows.Clear();
            gdvSelectedControls.Rows.Add();
            dnAddVerify.Enabled = true;
        }

        private void PageDetails_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gdvSelectedControls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().ToLower() == "delete")
            {
                if (currentRow >= 0)
                {
                    if (UIHelper.ConfirmMessage("Do you want to delete", "Confirmation") == DialogResult.Yes)
                    {
                        if (UIHelper.GetGridColumnValue(gdvSelectedControls, currentRow, "PageControlId").Length > 0)
                        {
                            gdvSelectedControls.Rows[currentRow].Cells["DeleteRow"].Value = "Y";
                            gdvSelectedControls.Rows[currentRow].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                            gdvSelectedControls.Rows.RemoveAt(currentRow);
                    }
                }
            }
            else if (e.KeyCode.ToString().ToLower() == "insert")
            {
                if (currentRow >= 0)
                {
                    gdvSelectedControls.Rows.Insert(currentRow, 1);
                }
            }
        }

        private void btnAddVerification_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> para = new List<SqlParameter>(0);
                para.Add(new SqlParameter("@webpageid", int.Parse(txtWebPageId.Text)));
                para.Add(new SqlParameter("@testcase", txtTestCases.Text));
                DataAccessLayer.InsertData("CreateVerification", para);
                UIHelper.SaveMessage();
                GetTestCaseList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (txtTestCases.Text.Trim().Length == 0)
            {
                UIHelper.StopMessage("Please select the test case");
                return;
            }

            try
            {
                RenameTestCase frm = new RenameTestCase(int.Parse(txtWebPageId.Text), txtTestCases.Text, dnAddVerify.Text);
                frm.ShowDialog();
                GetTestCaseList();
            }
            catch (Exception ex)
            {

                UIHelper.ShowMessage(ex.Message, "Message");
            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTestCases.Text.Length == 0)
                {
                    UIHelper.StopMessage("Select the textcase to be deleted from the grid");
                    return;
                }


                if (UIHelper.ConfirmMessage("Do you want to delete the test case", "confirm") == DialogResult.Yes)
                {

                    if (BusinessLayer.GetScenariosForWebPageAndTestCase(currentPageID, txtTestCases.Text, dnAddVerify.Text).Rows.Count > 0)
                    {
                        UIHelper.StopMessage("The test case is being used in scenarios, cannot delete");
                        return;
                    }

                    BusinessLayer.DeleteTestCase(currentPageID, txtTestCases.Text, dnAddVerify.Text);
                    UIHelper.SaveMessage();
                    GetTestCaseList();
                    txtTestCases.Clear();
                    gdvSelectedControls.Rows.Clear();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void mnuGridOperations_Opening(object sender, CancelEventArgs e)
        {

        }

        private Element FindControls(int totalFrames, IE ie)
        {
            Element watinControl = null;

            watinControl = ie.ActiveElement;

            if (watinControl.TagName.ToLower() != "body" && watinControl.TagName.ToLower() != "iframe")
            {
                frame = -1;
                return watinControl;
            }
            try
            {

                for (int i = 0; i < totalFrames; i++)
                {

                    watinControl = ie.Frames[i].ActiveElement;
                    if (watinControl.TagName.ToLower() != "body")
                    {
                        frame = i;
                        break;
                    }
                }
                return watinControl;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {

        }

        private void gdvSelectedControls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
