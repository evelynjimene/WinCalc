using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            mathOperator = string.Empty;
            leftOperand = 0.0;
            startMathOperation = false;
        }
        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }

        private void numBtn_Click(object sender, EventArgs e)
        {
            if (display.Text == "0" || display.Text == "∞")
            {
                display.Text = "";
            }
            display.Text = display.Text + ((Button)sender).Text;
        }

        private void posNegBtn_Click(object sender, EventArgs e)
        {
            // grab the text in the display, convert to a number
            // reverse the sign, back to a string
            display.Text = (-double.Parse(display.Text)).ToString();

        }

        private void decimalPtBtn_Click(object sender, EventArgs e)
        {
            if(!display.Text.Contains("."))
            {
                display.Text = display.Text + ".";

            }
        }


        private void backSpaceBtn_Click(object sender, EventArgs e)
        {
            if (display.Text.Length > 1)
            {
                // nominal case
                // if there is something in the string, then take the substring of it 
                // from the beginning to one short of the end
                display.Text = display.Text.Substring(0, display.Text.Length - 1);

                // handle the case where the char deleted was next to the dec point
                if (display.Text[display.Text.Length - 1] == '.')
                {
                    display.Text = display.Text.Substring(0, display.Text.Length - 1);
                }
            }
            else
            {
                // nothing left in the string, just keep resetting to zero
                display.Text = "0";
            }
        }
        private void equalBtn_Click(object sender, EventArgs e)
        {
            // exeute the actual math operation here when user clicks
            // the equals btn
            // match operator with the original operation button clicked
            switch (mathOperator)
            {
                case "+":
                    display.Text = (leftOperand + double.Parse(display.Text)).ToString();
                    break;
                case "-":
                    display.Text = (leftOperand - double.Parse(display.Text)).ToString();
                    break;
                case "x":
                    display.Text = (leftOperand * double.Parse(display.Text)).ToString();
                    break;
                case "/":
                    display.Text = (leftOperand / double.Parse(display.Text)).ToString();
                    if (display.Text == "∞")
                    {
                        display.Text = "Cannot Divide by 0";
                    }
                    break;
                default:
                    // should be unreachable
                    MessageBox.Show("Error: Something went wrong. Close the calc and re-start");
                    break;
            }
        }

        private bool startMathOperation = false;
        private string mathOperator = string.Empty;
        private double leftOperand = 0.0;
        private void mathOpBtn_Click(object sender, EventArgs e)
        {
            // 1 - notify calc that it is now doing math
            startMathOperation = true;

           // 2 - get the operator from the text of what is on the button clicked
            mathOperator = ((Button)sender).Text;

            // 3 - save the current (left) operand from the display
            leftOperand = double.Parse(display.Text);

            // 4 - clear the display - prepare it for the 2nd operand
            display.Clear();


        }
    }
}
