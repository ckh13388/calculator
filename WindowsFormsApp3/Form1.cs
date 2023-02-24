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
        public string InputText = "0";

        // keep track of a computed value(but in string for easy handling) before clearing
        public string RunningValue;

        // memory storage
        public double MemoryValue;

        // display of the whole equation 
        public List<string> DisplayEquation = new List<string>();

        // Compute using DataTable 
        static string Calculate(List<string> InputList)
        {
            DataTable table = new DataTable();
            string Result = Convert.ToString(table.Compute(
                string.Join("", InputList), string.Empty));
            return Result;
        }

        

        // check if a string is able to form a valid number
        static (bool,double) IsNumberCheck(string Str)
        {
            // check user input whether it is making a correct number
            bool Result = double.TryParse(Str, out double Value);
            return (Result, Value);

        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            // first check if the input can form a valid number
            if (IsNumberCheck(InputText).Item1)
            {
                DisplayEquation.Add(InputText);
                RunningValue = Calculate(DisplayEquation);
                label1.Text = RunningValue.ToString();
            }
            // if not, check if it is the first input 
            else if (DisplayEquation.Count > 1)
            {
                // if the input ends with one of "+-*/", remove it to prevent redundancy
                DisplayEquation.RemoveAt(DisplayEquation.Count - 1);
            }
            DisplayEquation.Add("+");
            InputText = "";
            label2.Text = String.Join(" ", DisplayEquation);
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            if (IsNumberCheck(InputText).Item1)
            {
                DisplayEquation.Add(InputText);
                RunningValue = Calculate(DisplayEquation);
                label1.Text = RunningValue.ToString();
            }
            else if (DisplayEquation.Count > 1)
            {
                DisplayEquation.RemoveAt(DisplayEquation.Count - 1);
            }
            DisplayEquation.Add("-");
            InputText = "";
            label2.Text = String.Join(" ", DisplayEquation);
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            if (IsNumberCheck(InputText).Item1)
            {
                DisplayEquation.Add(InputText);
                RunningValue = Calculate(DisplayEquation);
                label1.Text = RunningValue.ToString();
            }
            else if (DisplayEquation.Count > 1)
            {
                DisplayEquation.RemoveAt(DisplayEquation.Count - 1);
            }

            DisplayEquation.Add("*");
            InputText = "";
            label2.Text = String.Join(" ", DisplayEquation);
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            if (IsNumberCheck(InputText).Item1)
            {
                DisplayEquation.Add(InputText);
                RunningValue = Calculate(DisplayEquation);
                label1.Text = RunningValue.ToString();
            }
            else if (DisplayEquation.Count > 1)
            {
                DisplayEquation.RemoveAt(DisplayEquation.Count - 1);
            }

            DisplayEquation.Add("/");
            InputText = "";
            label2.Text = String.Join(" ", DisplayEquation);
        }

        private void BtnEq_Click(object sender, EventArgs e)
        {
            if (IsNumberCheck(InputText).Item1)
            {
                DisplayEquation.Add(InputText);
                RunningValue = Calculate(DisplayEquation);
                label1.Text = RunningValue.ToString();
                InputText = RunningValue.ToString();
            }
            else if (DisplayEquation.Count > 1)
            {
                DisplayEquation.RemoveAt(DisplayEquation.Count - 1);
            }



            label2.Text = String.Join(" ", DisplayEquation) + " = " + RunningValue.ToString();
            DisplayEquation.Clear();
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
            InputText = "0";
            RunningValue = "";
            label1.Text = "";
            label2.Text = "";
            DisplayEquation.Clear();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            InputText = "0";
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
            if (InputText != "0")
            {
                InputText += "0";
                label1.Text = InputText;
            }
        }

        private void Numpad1_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "1";
            }
            else
            {
                InputText = "1";
            }
            label1.Text = InputText;
        }

        private void Numpad2_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "2";
            }
            else
            {
                InputText = "2";
            }
            label1.Text = InputText;

        }

        private void Numpad3_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "3";
            }
            else
            {
                InputText = "3";
            }
            label1.Text = InputText;
        }

        private void Numpad4_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "4";
            }
            else
            {
                InputText = "4";
            }
            label1.Text = InputText;
        }

        private void Numpad5_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "5";
            }
            else
            {
                InputText = "5";
            }
            label1.Text = InputText;

        }

        private void Numpad6_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "6";
            }
            else
            {
                InputText = "6";
            }
            label1.Text = InputText;
        }

        private void Numpad7_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "7";
            }
            else
            {
                InputText = "7";
            }
            label1.Text = InputText;
        }

        private void Numpad8_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "8";
            }
            else
            {
                InputText = "8";
            }
            label1.Text = InputText;
        }

        private void Numpad9_Click(object sender, EventArgs e)
        {
            if (InputText != "0")
            {
                InputText += "9";
            }
            else
            {
                InputText = "9";
            }
            label1.Text = InputText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Memory recall
            label1.Text = MemoryValue.ToString();
            InputText = MemoryValue.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // M+
            MemoryValue += IsNumberCheck(InputText).Item2;
            InputText = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // M-
            MemoryValue -= IsNumberCheck(InputText).Item2;
            InputText = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Memory Store
            MemoryValue = IsNumberCheck(InputText).Item2;
            InputText = MemoryValue.ToString();
        }
    }
}
