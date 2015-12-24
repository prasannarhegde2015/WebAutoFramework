#region Comments
#region 11-Dec
//1. Added method GetConfigurationValue
#endregion
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Automation;
using System.Windows;
using WatiN.Core;
namespace WebAutomation
{
    static class UIHelper
    {
        static string logFile = System.Configuration.ConfigurationManager.AppSettings["logpath"];


        public static DialogResult ConfirmMessage(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        public static void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void SaveMessage()
        {
            MessageBox.Show("Data saved successfully", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void StopMessage(string message)
        {
            MessageBox.Show(message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void HighLightGridRow(DataGridView grid, int row)
        {

            for (int i = 0; i < grid.RowCount; i++)
            {
                if (i == row)
                    grid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                else
                    grid.Rows[i].DefaultCellStyle.BackColor = Color.White; ;
            }
        }

        public static string GetGridColumnValue(DataGridView grid, int rowNo, string columnName)
        {
            return grid.Rows[rowNo].Cells[columnName].Value == null ? "" : grid.Rows[rowNo].Cells[columnName].Value.ToString();
        }
        public static string GenerateDynamicValue(string dynamicType, string dynamicParameter, string format)
        {
            if (dynamicType.ToLower() == "guid")
            {
                return Guid.NewGuid().ToString().Replace("-", "");
            }
            
            else if (dynamicType.ToLower() == "uniquenumber")
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else if (dynamicType.ToLower() == "currentdate")
            {
                DateTime currentDate = DateTime.Now;
                int numberPart = 0;
                if (dynamicParameter.Contains("+"))
                {
                    string[] splitData = dynamicParameter.Split('+');
                    numberPart = int.Parse(splitData[1]);

                }
                if (format.ToUpper() == "MM/DD/YYYY")
                {
                    if (numberPart > 0)
                    {
                        currentDate = DateTime.Now.AddDays(numberPart);
                    }
                    return currentDate.ToString("MM/dd/yyyy");
                }
                else if (format.ToUpper() == "DD/MM/YYYY")
                {
                    return DateTime.Now.ToString("dd/mm/yyyy");
                }
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }

            else
            {
                return "";
            }
        }

        public static void WindowsLogon(string url, string userName, string password)
        {


            try
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.Start("IExplore", url);

                while (p.MainWindowTitle.Length == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    p.Refresh();
                }
                System.Threading.Thread.Sleep(2000);


                AutomationElement logon = null;

                while (logon == null)
                {
                    logon = AutomationElement.RootElement.FindFirst(TreeScope.Descendants,
                       new AndCondition(
                       new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                       new PropertyCondition(AutomationElement.NameProperty, "Windows Security")));
                    System.Threading.Thread.Sleep(1000);
                }



                AutomationElement usernameElement = logon.FindFirst(TreeScope.Descendants,
                    new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit),
                new PropertyCondition(AutomationElement.NameProperty, "User name")));

                AutomationElement pwd = logon.FindFirst(TreeScope.Descendants,
                    new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit),
                new PropertyCondition(AutomationElement.NameProperty, "Password")));

                AutomationElement ok = logon.FindFirst(TreeScope.Descendants,
                   new AndCondition(
                   new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
               new PropertyCondition(AutomationElement.NameProperty, "OK")));

                ValuePattern pat = (ValuePattern)usernameElement.GetCurrentPattern(ValuePattern.Pattern);
                pat.SetValue(userName);

                pat = (ValuePattern)pwd.GetCurrentPattern(ValuePattern.Pattern);

                pat.SetValue(password);
                InvokePattern inv = (InvokePattern)ok.GetCurrentPattern(InvokePattern.Pattern);

                inv.Invoke();
                LogToFile("Successfully logged in UserName: " + userName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void FFWindowsLogon(string url, string userName, string password)
        {


            try
            {
                //System.Diagnostics.Process p = System.Diagnostics.Process.Start("IExplore", url);

                //while (p.MainWindowTitle.Length == 0)
                //{
                //    System.Threading.Thread.Sleep(1000);
                //    p.Refresh();
                //}
                //System.Threading.Thread.Sleep(2000);
              //  MessageBox.Show("Inside Firefiox Auth");
              //  MessageBox.Show("Progress", "Inside Auth fucntion");
                AutomationElement logon = null;
                for (int i = 0; i < 20; i++)
                {
                    
                        logon = AutomationElement.RootElement.FindFirst(TreeScope.Descendants,
                           new AndCondition(
                           new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                           new PropertyCondition(AutomationElement.NameProperty, "Authentication Required")));
                        System.Threading.Thread.Sleep(1000);
                //        MessageBox.Show("Progress", "Waiting");
                        if (logon != null)
                        {
                            break;
                        }

                }

                if (logon == null)
                {
                  //  MessageBox.Show("Got ", "Window not found ");
                    return;
                }
                logon.SetFocus();
                AutomationElement usernameElement = logon.FindFirst(TreeScope.Descendants,
                    new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit),
                new PropertyCondition(AutomationElement.NameProperty, "User Name:")));

                AutomationElement pwd = logon.FindFirst(TreeScope.Descendants,
                    new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit),
                new PropertyCondition(AutomationElement.NameProperty, "Password:")));

                AutomationElement ok = logon.FindFirst(TreeScope.Descendants,
                   new AndCondition(
                   new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
               new PropertyCondition(AutomationElement.NameProperty, "OK")));

          
                //ValuePattern pat = (ValuePattern)usernameElement.GetCurrentPattern(ValuePattern.Pattern);
                //pat.SetValue(userName);

                //pat = (ValuePattern)pwd.GetCurrentPattern(ValuePattern.Pattern);

                //pat.SetValue(password);

                InvokePattern inv = (InvokePattern)ok.GetCurrentPattern(InvokePattern.Pattern);

                inv.Invoke();
                LogToFile("Successfully logged in UserName: " + userName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Boolean JavaScriptButtons(IE ie, string data)
        {


            string[] words = data.Split('|');


            string[] windowTitle = words[0].Split(':');
            string[] buttonName = words[1].Split(':');
            System.Threading.Thread.Sleep(1000);
            try
            {
                AutomationElement dialog = GetUIAutomationWindow(windowTitle[1]);

                if (dialog != null)
                {
                    AutomationElement button = dialog.FindFirst(TreeScope.Descendants,
                        new AndCondition(
                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                    new PropertyCondition(AutomationElement.NameProperty, buttonName[1], PropertyConditionFlags.IgnoreCase)));


                    LogToFile("Button Name:" + button.Current.Name);

                    InvokePattern inv = (InvokePattern)button.GetCurrentPattern(InvokePattern.Pattern);

                    inv.Invoke();

                    LogToFile("Enter case sent");
                    return true;
                }
                else
                {

                } return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static void LogToFile(string stxtMsg)
        {

            System.IO.File.AppendAllText(logFile, System.DateTime.Now + ":" + stxtMsg + Environment.NewLine);

            try
            {
                Console.WriteLine(stxtMsg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }



        public static void GetUIAutomationControl(IE ie, string windowTitle, string controlType, string searchBy, string searchValue, string data)
        {
            try
            {

                AutomationElement dialog = GetUIAutomationWindow(windowTitle);

                LogToFile("Control to be searched: " + controlType);
                if (controlType.ToLower() == "link")
                {
                    if (searchBy.ToLower() == "id")
                    {
                        LogToFile("Searching by ID");

                        AutomationElement button = dialog.FindFirst(TreeScope.Descendants,
                          new AndCondition(
                          new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Hyperlink),
                      new PropertyCondition(AutomationElement.AutomationIdProperty, searchValue, PropertyConditionFlags.IgnoreCase)));
                        LogToFile("Link found ID:" + button.Current.AutomationId);
                    }
                    else if (searchBy.ToLower() == "name")
                    {
                        LogToFile("Searching by Name");

                        AutomationElement button = dialog.FindFirst(TreeScope.Descendants,
                          new AndCondition(
                          new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Hyperlink),
                      new PropertyCondition(AutomationElement.NameProperty, searchValue, PropertyConditionFlags.IgnoreCase)));
                        LogToFile("Link found Name :" + button.Current.Name);
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        private static AutomationElement GetUIAutomationWindow(string title)
        {
            try
            {
                LogToFile("Finding Window");
                AutomationElement dialog = AutomationElement.RootElement.FindFirst(TreeScope.Descendants,
                       new AndCondition(
                       new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                       new PropertyCondition(AutomationElement.NameProperty, title, PropertyConditionFlags.IgnoreCase)));


                LogToFile("Window found :" + dialog.Current.Name);
                return dialog;
            }
            catch (NullReferenceException)
            {
                LogToFile("Window not found: Title:= " + title);
                throw;
            }

        }
        public static string GetUserNameAndPassword(string type, string data)
        {
            string userNamePassword = data;
            string[] words = userNamePassword.Split('|');

            string[] values = null;
            if (type == "u")
            {
                values = words[0].Split(':');
            }
            else if (type == "p")
            {
                values = words[1].Split(':');
            }
            return values[1];
        }

        public static Boolean IsNumber(string value)
        {
            try
            {
                int.Parse(value);
                return true;
            }
            catch
            {

                return false;
            }

        }
        public static string GetConfigurationValue(string keyName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[keyName];
        }

        public static void fn_BalloonToolTip(string str_tooltiptitle, string str_tooltiptext)
        {
            string icon_Path = @"C:\Program Files (x86)\Weatherford\WellFlo\App.ico";
            System.Drawing.Icon oIcon = new System.Drawing.Icon(icon_Path);
            NotifyIcon oNtfy = new NotifyIcon();
            oNtfy.Icon = oIcon;
            oNtfy.Visible = true;
            oNtfy.Text = "UIAutomationInfo";
            oNtfy.BalloonTipTitle = str_tooltiptitle;
            oNtfy.BalloonTipText = str_tooltiptext;
            oNtfy.ShowBalloonTip(0);


        }

    }
}
