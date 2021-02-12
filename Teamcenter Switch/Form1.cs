using System;
using System.IO;
using System.Windows.Forms;

namespace Teamcenter_Switch
{
    public partial class Form1 : Form
    {
        private const string StartGeneric = @"C:\Siemens\Teamcenter11\UAT\rac\start_nxmanager.bat";
        private const string Start1872 = @"C:\Siemens\Teamcenter11\UAT\rac\start_nxmanager1872.bat";
        private const string Start10 = @"C:\Siemens\Teamcenter11\UAT\rac\start_nxmanager10.bat";

        private const string Error = "Error";
        private const string NoGeneric = "Cannot find start_nxmanager.bat, exiting application";
        private const string NoSwitch =
            "Cannot find start_nxmanager10.bat or start_nxmanager1872.bat. Please make sure one of these files is present.";

        public Form1() => InitializeComponent();

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (File.Exists(Start10))
                {
                    if (File.Exists(StartGeneric))
                    {
                        File.Move(StartGeneric, Start1872);
                        File.Move(Start10, StartGeneric);
                    }
                    else
                    {
                        _ = MessageBox.Show(NoGeneric, Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!File.Exists(Start1872))
                {
                    _ = MessageBox.Show(NoSwitch, Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (File.Exists(Start1872))
                {
                    if (File.Exists(StartGeneric))
                    {
                        File.Move(StartGeneric, Start10);
                        File.Move(Start1872, StartGeneric);
                    }
                    else
                    {
                        _ = MessageBox.Show(NoGeneric, Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!File.Exists(Start10))
                {
                    _ = MessageBox.Show(NoSwitch, Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
