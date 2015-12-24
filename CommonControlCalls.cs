using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Helper;
using System.IO;
namespace WebAutomation
{
    class CommonControlCalls
    {

        public static void AutoComplete(IE ie, int frame, string elementName, string elementID, int index, string data)
        {
            try
            {
                var test = Core.GetTextField(ie, frame, elementName, elementID, index);

                test.TypeText(data);
                System.Threading.Thread.Sleep(10000);

                test.KeyDown();
                System.Threading.Thread.Sleep(1000);
                SendKeys.Flush();
                SendKeys.SendWait("{DOWN}");
                SendKeys.Flush();
                SendKeys.SendWait("{TAB}");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void KeyBoard(IE ie, int frame, string elementName, string elementID, int index, string data, int waitTimeOut)
        {
            try
            {


                System.Threading.Thread.Sleep(1);
                BusinessLayer.LogTofile("", "", "", "", "", "Trying to send keystrokes keystroke= " + data);
                if (data.ToLower() == "{f5}")
                {
                    ie.GoTo(ie.Url);
                    IE.AttachTo<IE>(Find.ByUrl(ie.Url)).WaitForComplete(waitTimeOut);
                    BusinessLayer.LogTofile("", "", "", "", "", "Sucessfully attached:");
                }
                else
                {
                    SendKeys.Flush();
                    SendKeys.SendWait(data);
                }
                System.Threading.Thread.Sleep(1);
                BusinessLayer.LogTofile("", "", "", "", "", "Key stroke sent successfully");
            }


            catch (Exception)
            {

                throw;
            }
        }

    }
}
