using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAutomation
{
    public partial class BrowserOptions : Form
    {
        public static string broptions = "";
        public BrowserOptions()
        { 
           
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedItem = "Internet Explorer";
        }

        public void button1_Click(object sender, EventArgs e)
        {

           broptions  = (string)comboBox1.SelectedItem;
           // MessageBox.Show("You need to Specify the browser " + broptions);
           bool correctstring = false;

           for (int i = 0; i < comboBox1.Items.Count; i++)
           {
               if (broptions == comboBox1.Items[i].ToString())
               {
                   correctstring = true;
                   break;
               }
           }

           if (correctstring == false)
            {
                MessageBox.Show("You need to Specify the browser ");
            }
            else
            {

               // MessageBox.Show("You have selected : " + broptions);
            }

           if (correctstring)
            {
                BrowserOptions.ActiveForm.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
