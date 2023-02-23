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
        public string InputText; 

        // to store all user input before clearing
        public List<string> History = new List<string>();

        // check if a string is able to form a valid number
        static (bool,double) IsNumberCheck(string Str)
        {
            // check user input whether it is making a correct number
            bool Result = double.TryParse(Str, out double Value);
            return (Result, Value);

        }

        // check and prevent multiple input of symbols "+-/*"
        static void SymbolCheck(string Str, string symbol, List<string> Hist)
        {
            
            try
            {
                // check if it is a valid number
                if (IsNumberCheck(Str).Item1)
                {
                    Hist.Add(Str);
                }

                // check if the last input is one of "+-*/", replace if suitable
                char c = Hist.Last()[Hist.Last().Length - 1];
                if ((Char.IsDigit(c)) || (c == '.'))
                {
                    Hist.Add(symbol);
                }

                else
                {
                    Hist.RemoveAt(Hist.Count - 1);
                    Hist.Add(symbol);
                }
            }
            catch
            {
                return;
            }
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            SymbolCheck(InputText, "+", History);
            label1.Text = InputText;
            InputText = "";
            label2.Text = string.Join(" ", History);
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            SymbolCheck(InputText, "-", History);
            label1.Text = InputText;
            InputText = "";
            label2.Text = string.Join(" ", History);
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            SymbolCheck(InputText, "*", History);
            label1.Text = InputText;
            InputText = "";
            label2.Text = string.Join(" ", History);
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            SymbolCheck(InputText, "/", History);
            label1.Text = InputText;
            InputText = "";
            label2.Text = string.Join(" ", History);
        }

        private void BtnEq_Click(object sender, EventArgs e)
        {
            // 
            if (History.Count > 1)
            {
                if (IsNumberCheck(InputText).Item1)
                {
                    History.Add(InputText); 

                    DataTable table = new DataTable();

                    // DataTable.Compute will work on "*/" in prior to "+-"
                    double Result = Convert.ToDouble(table.Compute(string.Join("", History), string.Empty));
                    label1.Text = Result.ToString();
                    label2.Text = string.Join(" ", History) + " = " + Result.ToString();
                    InputText = "";
                    History.Clear();
                }
            }
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(InputText))
            {
                InputText = "0."; 
            }
            else
            {
                string s = InputText + "."; 
                if (IsNumberCheck(s).Item1)
                {
                    InputText = s;
                }
            }

            label1.Text = InputText;
        }

        private void BtnAllClear_Click(object sender, EventArgs e)
        {
            InputText = "";
            label1.Text = "";
            label2.Text = "";
            History.Clear();

        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            InputText = "";
            label1.Text = "";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputText))
            {
                InputText = InputText.Substring(0, InputText.Length - 1); 
            }
            
            label1.Text = InputText;
        }

        private void BtnPN_Click(object sender, EventArgs e)
        {
            if (IsNumberCheck(InputText).Item1)
            {

                if (IsNumberCheck(InputText).Item2 > 0)
                {
                    InputText = "-" + InputText; 
                }
                else if (IsNumberCheck(InputText).Item2 < 0)
                {
                    InputText = InputText.Trim('-');
                }
                label1.Text = InputText;
            }
            

        }
        private void Numpad0_Click(object sender, EventArgs e)
        {

            InputText += "0";
            label1.Text = InputText;
            
        }

        private void Numpad1_Click(object sender, EventArgs e)
        {
            InputText += "1";
            label1.Text = InputText;
        }

        private void Numpad2_Click(object sender, EventArgs e)
        {
            InputText += "2";
            label1.Text = InputText;
        }

        private void Numpad3_Click(object sender, EventArgs e)
        {
            InputText += "3";
            label1.Text = InputText;
        }

        private void Numpad4_Click(object sender, EventArgs e)
        {
            InputText += "4";
            label1.Text = InputText;
        }

        private void Numpad5_Click(object sender, EventArgs e)
        {
            InputText += "5";
            label1.Text = InputText;
        }

        private void Numpad6_Click(object sender, EventArgs e)
        {
            InputText += "6";   
            label1.Text = InputText;
        }

        private void Numpad7_Click(object sender, EventArgs e)
        {
            InputText += "7";
            label1.Text = InputText;
        }

        private void Numpad8_Click(object sender, EventArgs e)
        {
            InputText += "8";
            label1.Text = InputText;
        }

        private void Numpad9_Click(object sender, EventArgs e)
        {
            InputText += "9";
            label1.Text = InputText;
        }

    }
}
