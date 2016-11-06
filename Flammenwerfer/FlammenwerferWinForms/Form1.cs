using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flammenwerfer;

namespace FlammenwerferWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rbFirstName_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruct.Visible = true;
            lblInstruct.Text = "Enter students first name";
        }

        private void rbLastName_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruct.Visible = true;
            lblInstruct.Text = "Enter students last name";
        }

        private void rbID_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruct.Visible = true;
            lblInstruct.Text = "Enter students I.D. #";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text == "debug") { btnTest.Visible = true; tbDisplay.Text = "Debug"; } //debug mode if you want to test something
            else //Normal Help button functionality
            {
                btnTest.Visible = false;
                tbDisplay.Text = "";
                tbDisplay.Text = "To search for a student simply select your search type, then enter in the required information. The students basic information as well as the course information will be displayed, and the course completion information is displayed on the far right.";
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
