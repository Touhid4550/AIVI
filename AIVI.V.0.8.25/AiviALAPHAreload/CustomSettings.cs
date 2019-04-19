using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Speech.Synthesis;
using System.Threading.Tasks;
using AiviALAPHAreload.Properties;

namespace AiviALAPHAreload
{
    public partial class CustomSettings : Form
    {
        SpeechSynthesizer computer = new SpeechSynthesizer();
        string userName = Environment.UserName;
        string scpath = Settings.Default.ShellC.ToString();
        string srpath = Settings.Default.ShellR.ToString();
        string slpath = Settings.Default.ShellL.ToString();
        string webcpath = Settings.Default.WebC.ToString();
        string webrpath = Settings.Default.WebR.ToString();
        string weblpath = Settings.Default.WebL.ToString();
        string socpath = Settings.Default.SocC.ToString();
        string sorpath = Settings.Default.SocR.ToString();
        StreamReader sr;
        public CustomSettings()
        {
            InitializeComponent();
            try
            {
                sr = new StreamReader(scpath); txtShellCommands.Text = sr.ReadToEnd(); sr.Close();
                sr = new StreamReader(srpath); txtShellResponse.Text = sr.ReadToEnd(); sr.Close();
                sr = new StreamReader(slpath); txtShellLocation.Text = sr.ReadToEnd(); sr.Close();
                sr = new StreamReader(webcpath); txtWebCommands.Text = sr.ReadToEnd(); sr.Close();
                sr = new StreamReader(webrpath); txtWebResponse.Text = sr.ReadToEnd(); sr.Close();
                sr = new StreamReader(weblpath); txtWebURL.Text = sr.ReadToEnd(); sr.Close();
                sr = new StreamReader(socpath); txtSocialCommands.Text = sr.ReadToEnd(); sr.Close();
                sr = new StreamReader(sorpath); txtSocialResponse.Text = sr.ReadToEnd(); sr.Close();

                txtName.Text = Settings.Default.User.ToString(); txtWOEID.Text = Settings.Default.WOEID.ToString();
                if (Settings.Default.Temperature.ToString() == "f")
                { rbFahrenheit.Checked = true; }
                else if (Settings.Default.Temperature.ToString() == "c")
                { rbCelsius.Checked = true; }
            }
            
            catch (Exception)
            {

                computer.SpeakAsync("Please plug in your micrphone before setting get work");
                MessageBox.Show("Please plug in your micrphone before setting get work");
            }
           
        }





        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(scpath))
                { sw.Write(txtShellCommands.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(srpath))
                { sw.Write(txtShellResponse.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(slpath))
                { sw.Write(txtShellLocation.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(webcpath))
                { sw.Write(txtWebCommands.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(webrpath))
                { sw.Write(txtWebResponse.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(weblpath))
                { sw.Write(txtWebURL.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(socpath))
                { sw.Write(txtSocialCommands.Text); sw.Close(); }
                using (StreamWriter sw = File.CreateText(sorpath))
                { sw.Write(txtSocialResponse.Text); sw.Close(); }
                if (txtName.Text == String.Empty)
                { Settings.Default.User = userName; txtName.Text = userName; }
                else { Settings.Default.User = txtName.Text; }

                if (txtWOEID.Text == String.Empty)
                { Settings.Default.WOEID = "1915035"; txtWOEID.Text = "1915035"; }
                else { Settings.Default.WOEID = txtWOEID.Text; }
                if (rbFahrenheit.Checked == true)
                { Settings.Default.Temperature = "f"; }
                else if (rbCelsius.Checked == true)
                { Settings.Default.Temperature = "c"; }
                Settings.Default.GmailUser = txtGmail.Text;
                Settings.Default.GmailPassword = txtPassword.Text;
                Settings.Default.Save();
            }
            catch (Exception)
            {
                computer.SpeakAsync("Commands are not saved. Please plug in your microphone");
                MessageBox.Show("Commands are not saved. Please plug in your microphone");

            }

            
        }


        private void txtWOEIDSearch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://woeid.rosselliot.co.nz/");
        }

        private void socialcmdbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void shellcmdbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void webcmdbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void prflbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = oFDSelectFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(slpath))
                { sw.Write(txtShellLocation.Text); sw.Write(oFDSelectFile.FileName); sw.Close(); }
                sr = new StreamReader(slpath);
                txtShellLocation.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void txtShellLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWebURL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
