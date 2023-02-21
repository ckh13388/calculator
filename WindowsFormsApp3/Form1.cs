using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // text upon user input for further checking before displaying
        public string checkText; 

        // to store all user input before clearing
        public List<string> history = new List<string>();


        static (bool,double) Check(string s)
        {
            // check user input whether it is making a correct number
            bool result = double.TryParse(s, out double value);
            return (result, value);

        }

        static void helper(string s, string symbol, List<string> l)
        {
            
            try
            {
                // check if it is a valid number
                if (Check(s).Item1)
                {
                    l.Add(s);
                    //s = "";
                }

                // check if the last input is one of "+-*/", replace if suitable
                char c = l.Last()[l.Last().Length - 1];
                if ((Char.IsDigit(c)) || (c == '.'))
                {
                    l.Add(symbol);
                }

                else
                {
                    l.RemoveAt(l.Count - 1);
                    l.Add(symbol);
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            helper(checkText, "+", history);
            label1.Text = checkText;
            checkText = "";
            label2.Text = string.Join(" ", history);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            helper(checkText, "-", history);
            label1.Text = checkText;
            checkText = "";
            label2.Text = string.Join(" ", history);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            helper(checkText, "*", history);
            label1.Text = checkText;
            checkText = "";
            label2.Text = string.Join(" ", history);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            helper(checkText, "/", history);
            label1.Text = checkText;
            checkText = "";
            label2.Text = string.Join(" ", history);
        }

        private void btnEq_Click(object sender, EventArgs e)
        {
            // check if input is a valid number
            if (history.Count > 1)
            {
                if (Check(checkText).Item1)
                {
                    history.Add(checkText); 

                    DataTable table = new DataTable();

                    // DataTable.Compute will work on "*/" in prior to "+-"
                    double result = Convert.ToDouble(table.Compute(string.Join("", history), string.Empty));
                    label1.Text = result.ToString();
                    label2.Text = string.Join(" ", history) + " = " + result.ToString();
                    checkText = "";
                    history.Clear();
                }
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(checkText))
            {
                checkText = "0."; 
            }
            else
            {
                string s = checkText + "."; 
                if (Check(s).Item1)
                {
                    checkText = s;
                }
            }

            label1.Text = checkText;
        }

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            checkText = "";
            label1.Text = "";
            label2.Text = "";
            history.Clear();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            checkText = "";
            label1.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(checkText))
            {
                checkText = checkText.Substring(0, checkText.Length - 1); 
            }
            
            label1.Text = checkText;
        }

        private void btnPN_Click(object sender, EventArgs e)
        {
            if (Check(checkText).Item1)
            {

                if (Check(checkText).Item2 > 0)
                {
                    checkText = "-" + checkText; 
                }
                else if (Check(checkText).Item2 < 0)
                {
                    checkText = checkText.Trim('-');
                }
                label1.Text = checkText;
            }
            

        }
        private void numpad0_Click(object sender, EventArgs e)
        {

            checkText += "0";
            label1.Text = checkText;
            
        }

        private void numpad1_Click(object sender, EventArgs e)
        {
            checkText += "1";
            label1.Text = checkText;
        }

        private void numpad2_Click(object sender, EventArgs e)
        {
            checkText += "2";
            label1.Text = checkText;
        }

        private void numpad3_Click(object sender, EventArgs e)
        {
            checkText += "3";
            label1.Text = checkText;
        }

        private void numpad4_Click(object sender, EventArgs e)
        {
            checkText += "4";
            label1.Text = checkText;
        }

        private void numpad5_Click(object sender, EventArgs e)
        {
            checkText += "5";
            label1.Text = checkText;
        }

        private void numpad6_Click(object sender, EventArgs e)
        {
            checkText += "6";
            label1.Text = checkText;
        }

        private void numpad7_Click(object sender, EventArgs e)
        {
            checkText += "7";
            label1.Text = checkText;
        }

        private void numpad8_Click(object sender, EventArgs e)
        {
            checkText += "8";
            label1.Text = checkText;
        }

        private void numpad9_Click(object sender, EventArgs e)
        {
            checkText += "9";
            label1.Text = checkText;
        }

    }
}
