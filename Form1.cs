//Author: kirochii

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bin2Dec
{
    public partial class Bin2Dec_Window : Form
    {
        public Bin2Dec_Window()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            calc_btn.Left = (this.ClientSize.Width - calc_btn.Width) / 2;
            calc_btn.Top = (this.ClientSize.Height - calc_btn.Height) - 50;

            BinaryInput.GotFocus += binaryInput_GotFocus;
            BinaryInput.LostFocus += binaryInput_LostFocus;

        }

        private void binaryInput_GotFocus(object sender, EventArgs e)
        {
            if (BinaryInput.Text == "Input Binary Digits")
            {
                BinaryInput.Text = "";
                BinaryInput.ForeColor = Color.Black;
            }
        }
        private void binaryInput_LostFocus(object sender, EventArgs e)
        {
            if (BinaryInput.Text == "")
            {
                BinaryInput.Text = "Input Binary Digits";
                BinaryInput.ForeColor = Color.Silver; ;
            }
        }


        private void calc_btn_Click(object sender, EventArgs e)
        {
            if (BinaryInput.Text == "Input Binary Digits")
            {
                notice.Text = "Input Required!";
            }

            else if (Regex.IsMatch(BinaryInput.Text, @"^[0-1]+$")){
                int total = 0;
                int counter = 0;

                for (int n = BinaryInput.Text.Length - 1; n >= 0; n--)
                {
                    int digit = BinaryInput.Text[n] - '0';
                    total += digit * (int)Math.Pow(2, counter);
                    counter++;
                }

                DecimalOutput.Text = total.ToString();

                notice.Text = "";
            }

            else
            {
                notice.Text = "Only \"0\" or \"1\" can be entered!";
            }
        }

        private void Bin2Dec_Window_Load(object sender, EventArgs e)
        {
            BinaryInput.Text = "Input Binary Digits";
            BinaryInput.ForeColor = Color.Silver;
        }

        private void Bin2Dec_Window_Click(object sender, EventArgs e)
        {
            BinaryInput.Enabled = false;       //disable the textbox
            binaryInput_LostFocus(sender, e);  //call lost focus event
            BinaryInput.Enabled = true;
        }
    }
}
