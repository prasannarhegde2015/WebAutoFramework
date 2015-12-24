using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
namespace WebAutomation
{
    public static class Core
    {


        public static TextField GetTextField(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.TextField(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.TextField(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].TextField(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].TextField(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Button GetButton(IE ie, int frame, string controName, string controlID, string controlValue, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.Button(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Button(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        else if (controlValue.Length > 0)
                            return ie.Button(Find.ByValue(new Regex(controlValue, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].Button(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].Button(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static SelectList GetSelectList(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.SelectList(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.SelectList(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].SelectList(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].SelectList(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static RadioButton GetRadioButton(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.RadioButton(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.RadioButton(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].RadioButton(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].RadioButton(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static Link GetLink(IE ie, int frame, string controlName, string controlID, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:

                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Link(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                if (controlName.Contains("#_#"))
                                {
                                    return ie.Link(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)));
                                }
                                else
                                {
                                    return ie.Link(Find.ByText(new Regex("^"+controlName+"$", RegexOptions.IgnoreCase)));
                                }
                            break;
                        }
                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Links.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];

                            else if (controlName.Length > 0)
                               // return ie.Links.Filter(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            return ie.Link(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)));
                            break;
                        }
                    default:
                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Link(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Link(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)));
                            break;
                        }

                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Links.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Links.Filter(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            break;
                        }


                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static Para GetPara(IE ie, int frame, string controlName, string controlID, string controlText, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:

                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Para(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                return ie.Para(Find.ByName(new Regex(controlName, RegexOptions.IgnoreCase)));
                              //  return ie.Para(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)));
                            else if (controlText.Length > 0)
                                return ie.Para(Find.ByText(new Regex(controlText, RegexOptions.IgnoreCase)));
                            break;
                        }
                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Paras.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];

                            else if (controlName.Length > 0)
                                return ie.Paras.Filter(Find.ByName(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            else if (controlText.Length > 0)
                                return ie.Paras.Filter(Find.ByText(new Regex(controlText, RegexOptions.IgnoreCase)))[index];
                            break;
                        }
                    default:
                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Para(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Para(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)));
                            break;
                        }

                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Paras.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Paras.Filter(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            break;
                        }


                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static Image GetImage(IE ie, int frame, string controlName, string controlID, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:

                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Image(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                return ie.Image(Find.ByName(new Regex(controlName, RegexOptions.IgnoreCase)));
                            break;
                        }
                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Images.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];

                            else if (controlName.Length > 0)
                                return ie.Images.Filter(Find.ByName(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            break;
                        }
                    default:
                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Image(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Image(Find.ByName(new Regex(controlName, RegexOptions.IgnoreCase)));
                            break;
                        }

                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Images.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Images.Filter(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            break;
                        }


                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static CheckBox GetChecKBox(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {


                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.CheckBox(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.CheckBox(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].CheckBox(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].CheckBox(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static Div GetDiv(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {


                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.Div(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Div(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].Div(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].Div(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static Span GetSpan(IE ie, int frame, string controlName, string controlID, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:

                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Span(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                return ie.Span(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)));
                            break;
                        }
                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Spans.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];

                            else if (controlName.Length > 0)
                                return ie.Spans.Filter(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            break;
                        }
                    default:
                        if (index <= 0)
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Span(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Span(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)));
                            break;
                        }

                        else
                        {
                            if (controlID.Length > 0)
                                return ie.Frames[frame].Spans.Filter(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)))[index];
                            else if (controlName.Length > 0)
                                return ie.Frames[frame].Spans.Filter(Find.ByText(new Regex(controlName, RegexOptions.IgnoreCase)))[index];
                            break;
                        }

                
                }
            
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static TableCell GetTableCell(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {


                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.TableCell(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.TableCell(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].TableCell(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].TableCell(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static ListItem GetLIitems(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {
                switch (frame)
                {
                    case -1:
                        {
                            return ie.ListItem(Find.ByText(new Regex("^" + controName + "$")));
                            //break;
                        }
                    default:
                        {
                            return ie.ListItem(Find.ByText(new Regex("^" + controName + "$")));
                           // break;
                        }

                }
               
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }

        public static FileUpload GetFileUpload(IE ie, int frame, string controName, string controlID, int index)
        {
            try
            {


                switch (frame)
                {
                    case -1:
                        if (controlID.Length > 0)
                            return ie.FileUpload(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.FileUpload(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;
                    default:
                        if (controlID.Length > 0)
                            return ie.Frames[frame].FileUpload(Find.ById(new Regex(controlID, RegexOptions.IgnoreCase)));
                        else if (controName.Length > 0)
                            return ie.Frames[frame].FileUpload(Find.ByName(new Regex(controName, RegexOptions.IgnoreCase)));
                        break;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static IE IdentifyWebPage(string title, string url)
        {
            IE ie = null;

            int waitTimeOut = int.Parse(System.Configuration.ConfigurationManager.AppSettings["waittime"]);
            try
            {

                if (title.Length > 0)
                {

                    ie = IE.AttachTo<IE>(Find.ByTitle(title.Trim()), 1);
                    if (ie != null)
                    {
                        url = ie.Uri.AbsolutePath;
                    }
                }
                else if (url.Length > 0)
                {
                    ie = IE.AttachTo<IE>(Find.ByUrl(url.Trim()), 1);

                }

            }
            catch (Exception ex)
            {


            }


            try
            {
                if (ie == null)
                {
                    ie = new IE(url);
                    ie.WaitForComplete(waitTimeOut);
                    System.Threading.Thread.Sleep(2000);
                }

            }

            catch (Exception ex)
            {
            }
            if (ie != null)
            {
                ie.ShowWindow(WatiN.Core.Native.Windows.NativeMethods.WindowShowStyle.Maximize);
            }
            return ie;

        }

        public static ChromeDriver IdentifyWebPageChrome(ChromeDriver chromedriver, string title, string url)
        {

            var driver = chromedriver;
            if (driver == null)
            {
                driver = new ChromeDriver();
                if (url.Length > 0)
                {
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(url);
                }

            }
            else
            {
                if (title.Length > 0)
                {
                    if (title != driver.Title)
                    {
                        var allhandles = driver.WindowHandles;
                        string handle = "";
                        for (int i = 0; i < driver.WindowHandles.Count; i++)
                        {
                            if (driver.SwitchTo().Window(driver.WindowHandles[i].ToString()).Title == title)
                            {
                                driver.SwitchTo().Window(driver.WindowHandles[i].ToString());
                              //   Screenshot ss = ((ITakesScreenshot) driver).GetScreenshot();
                              //  break;
                            }
                        }


                       // driver.SwitchTo().Window(handle);
                    }
                }
            }

            return driver;

        }

        public static IWebDriver IdentifyWebPageFirefox(IWebDriver ffdriver, string title, string url, string usr, string passwd, string ffbin)
        {
            
            var driverff = ffdriver;
            if (driverff == null)
            {
                FirefoxBinary binary = new FirefoxBinary(ffbin);
                FirefoxProfile profile = new FirefoxProfile();
                 ffdriver = new FirefoxDriver(binary, profile);
                 #region HTTPheaderhandle
                 AutoItX3Lib.AutoItX3 AutoIT = new AutoItX3Lib.AutoItX3();

                 //Set Selenium page load timeout to 2 seconds so it doesn't wait forever
                 ffdriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(2));

                 //Ingore the error
                 try
                 {
                     ffdriver.Url = url;
                 }
                 catch
                 {
                     // return;
                 }

                 //Wait for the authentication window to appear, then send username and password


                 for (int ik = 0; ik < 15; ik++)
                 {
                     if (AutoIT.WinExists("Authentication Required") == 1)
                     {
                         AutoIT.WinWait("Authentication Required");
                         AutoIT.WinActivate("Authentication Required");
                         AutoIT.Send(usr);
                         AutoIT.Send("{TAB}");
                         AutoIT.Send(passwd);
                         AutoIT.Send("{ENTER}");
                         break;
                     }
                     System.Threading.Thread.Sleep(300);
                 }
                 System.Threading.Thread.Sleep(1000);

                 //Return Selenium page timeout to infinity again
                 ffdriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(-1));
               //   <IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driverff, TimeSpan.FromSeconds(30.00));
                 ffdriver.Manage().Window.Maximize();
                 ffdriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));

               //  wait.Until(driver1 => ((IJavaScriptExecutor)driverff).ExecuteScript("return document.readyState").Equals("complete"));
                 #endregion
            }
            else
            {
                if (title.Length > 0)
                {
                    if (title != ffdriver.Title)
                    {
                        var allhandles = ffdriver.WindowHandles;
                        string handle = "";
                        for (int i = 0; i < ffdriver.WindowHandles.Count; i++)
                        {
                            if (ffdriver.SwitchTo().Window(ffdriver.WindowHandles[i].ToString()).Title == title)
                            {
                                ffdriver.SwitchTo().Window(ffdriver.WindowHandles[i].ToString());
                                break;
                            }
                        }


                       // driver.SwitchTo().Window(handle);
                    }
                }
            }
            // We need to check if HTTP Authorizarion is requested by Website or Proxy server
            

            return ffdriver;
            // ffdriver.Manage().Timeouts().ImplicitlyWait(
            //  ffdriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(120));
            // System.Threading.Thread.Sleep(10000); */
        }

        public static int GetWebTableRow(Table table, string searchValue)
        {
            try
            {
                int row = -1;
                for (int j = 0; j < table.OwnTableRows.Count; j++)
                {
                    if (table.OwnTableRows[j].InnerHtml.Contains(searchValue.Trim()))
                    {
                        row = j;
                        break;

                    }
                }
                return row;
            }

            catch
            {
                throw;
            }

        }


        public static Table GetWebTable(IE ie, int frame, string searchValue, int index)
        {
            try
            {
                TableCollection tables = null;
                Table table = null;
                int tableInstance = 0;
                switch (frame)
                {

                    case -1:
                        tables = ie.Tables;
                        break;
                    default:
                        tables = ie.Frames[frame].Tables;
                        break;
                }

                for (int i = tables.Count - 1; i >= 0; i--)
                {
                    if (tables[i].InnerHtml.ToLower().Contains(searchValue.ToLower().Trim()))
                    {
                        if (tableInstance == index)
                        {
                            table = tables[i];
                            tableInstance++;
                            break;
                        }
                    }
                }
                return table;

            }
            catch
            {
                throw;
            }

        }

        public static IWebElement getElement(ChromeDriver driver, int frame, string controlid, string controlname, string controlvalue, int index)
        {
            IWebElement elem = null;
            try
            {
                if (frame == -1)
                {
                    if (controlname.Length > 0)
                    {
                        elem = driver.FindElement(By.Name(controlname));

                                          }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }
                else
                {
                    if (controlname.Length > 0)
                    {
                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Name(controlname));

                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }

                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return elem;
        }
        public static IWebElement getElementSpan(ChromeDriver driver, int frame, string controlid, string controlname, string controlvalue, int index)
        {
            IWebElement elem = null;
            try
            {
                if (frame == -1)
                {
                    if (controlname.Length > 0)
                    {

                        BusinessLayer.LogTofile("", "", "", "", "", "Finding span from collection");
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elemcol = driver.FindElements(By.TagName("span"));

                        foreach (IWebElement inelem in elemcol)
                        {
                            if (inelem.Text.Contains(controlname))
                            {
                                elem = inelem;
                                break;
                            }
                        }


                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }
                else
                {
                    if (controlname.Length > 0)
                    {
                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Name(controlname));

                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }

                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return elem;
        }
        public static IWebElement getElementFF(IWebDriver driver, int frame, string controlid, string controlname, string controlvalue, int index)
        {
            IWebElement elem = null;
            try
            {
                if (frame == -1)
                {
                    if (controlname.Length > 0)
                    {
                        elem = driver.FindElement(By.Name(controlname));
                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }
                else
                {
                    if (controlname.Length > 0)
                    {
                        
                        //var el1 = (IWebDriver)driver.SwitchTo().Frame(frame);
                        //if (el1 == null)
                        //{
                        //   // el1.FindElements(By.XPath("//*[@value='Control Design Team']"))[0].Click();
                        //    el1.FindElement(By.Name(controlname));
                        //}
                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Name(controlid));
                        //.FindElement(By.Name(controlname));
                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }

                }



            }
            catch (Exception ex)
            {
                elem = driver.FindElement(By.Name(controlname));
                throw new Exception(ex.Message);
            }
            return elem;
        }
        public static IWebElement getElementFFSpan(IWebDriver driver, int frame, string controlid, string controlname, string controlvalue, int index)
        {
            IWebElement elem = null;
            //****** sample Webdrive wait usage:
           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
           // {
          //      return d.FindElement(By.Id("someDynamicElement"));
          //  });

            try
            {
                if (frame == -1)
                {
                    if (controlname.Length > 0)
                    {
                        for (int it = 0; it < 100; it++) //  attempts loop attempts count = 100 this can be infinity theorotically
                        {
                            BusinessLayer.LogTofile("", "", "", "", "", "Finding span from collection");
                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elemcol = driver.FindElements(By.TagName("span"));

                            foreach (IWebElement inelem in elemcol)
                            {
                                if (inelem.Text.Contains(controlname))
                                {
                                    elem = inelem;
                                    break;
                                }
                            }
                            System.Threading.Thread.Sleep(1000);
                            if (elem != null) // we find the required element and exit the attempts loop 
                            {
                                break;
                            }
                        }
                        
                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }
                else
                {
                    if (controlname.Length > 0)
                    {
                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Name(controlname));

                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }

                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return elem;
        }
        public static IWebElement getElementLink(ChromeDriver driver, int frame, string controlid, string controlname, string controlvalue, int index)
        {
            IWebElement elem = null;
            try
            {
                if (frame == -1)
                {
                    if (controlname.Trim().Length > 0)
                    {
                        elem = driver.FindElement(By.LinkText(controlname));

                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }
                else
                {
                    if (controlname.Length > 0)
                    {
                        elem = driver.SwitchTo().Frame(frame).FindElement(By.LinkText(controlname));

                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return elem;
        }
        public static IWebElement getElementFFLink(IWebDriver driver, int frame, string controlid, string controlname, string controlvalue, int index)
        {
            IWebElement elem = null;

            try
            {
                if (frame == -1)
                {
                    if (controlname.Trim().Length > 0)
                    {
                        elem = driver.FindElement(By.LinkText(controlname));
                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }
                else
                {
                    if (controlname.Length > 0)
                    {
                        elem = driver.SwitchTo().Frame(frame).FindElement(By.LinkText(controlname));
                    }
                    else if (controlid.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.Id(controlid));
                    }
                    else if (controlvalue.Length > 0)
                    {

                        elem = driver.SwitchTo().Frame(frame).FindElement(By.XPath("//*[@value='" + controlvalue + "']"));
                    }
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return elem;
        }

        public void TakeScreenshot(IWebDriver _driver, string saveLocation)
        {
            var location =  saveLocation + ".png";
            var ssdriver = _driver as ITakesScreenshot;
            var screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(location, System.Drawing.Imaging.ImageFormat.Png);
        }

    }
}

