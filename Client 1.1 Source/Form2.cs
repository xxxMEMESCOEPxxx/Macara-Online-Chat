using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using ChatClient.Properties;

namespace ChatClient
{
    public partial class Form2 : Form
    {

        bool setvalue;
        //const int prevbrate = Int32.Parse(Settings.Default.connbaudrate);
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = "ChatClient";
        public Form2()
        {
            
            InitializeComponent();
            
        }

        public void Form2_Load(object sender, EventArgs e)
        {

            //textBox1.Text = Settings.Default["isStartupApp"].ToString();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true){
                setvalue = false;
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue("My application", 0);
                //checkBox2.Checked = setvalue;
            }
            if(checkBox2.Checked == false)
            {
                setvalue = true;
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue("My application", Application.ExecutablePath.ToString());
                //checkBox2.Checked = setvalue;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
           
            //Settings.Default["isStartupApp"] = setvalue;
            this.Close();
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
           
        }

        private void setRate_TextChanged(object sender, EventArgs e)
        {
            currentrate.Text = Settings.Default.connbaudrate;
            //comboBox1.Text = comboBox1.SelectedValue.ToString();
            //int x = int.Parse(setRate.Text = Properties.Settings.Default.testrate.ToString());
            if (setRate.Text != null)
            {

                Settings.Default.connbaudrate = setRate.Text;
                Settings.Default.Save();
            }
            else
            { //Value is null }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No update(s) availiable", "No update(s) availiable", 0, MessageBoxIcon.Information);
        }
    }
}
