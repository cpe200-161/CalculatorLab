using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string text = null;

        private double result=0;

        private bool check_op = false;
        private bool check_plus = false;
        private bool check_minus = false;
        private bool check_time = false;
        private bool check_divide = false;

        private bool text_is_Max = false;
        private int text_Max_Limit = 8;

        private bool already_dot = false;

		private bool already_press_zero_at_start = false;

        private bool is_text_max(string TEXT) {
            if (TEXT.Length == text_Max_Limit)
                return true;
            else
                return false;
        }

        private void reset_text_max()
        {
            text_Max_Limit = 8; 
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (!text_is_Max) {
                text += 1;
            }
            text_is_Max = is_text_max(text);

            lblDisplay.Text = text;
        }

        

        private void btn2_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 2;
            }
            text_is_Max = is_text_max(text);

            lblDisplay.Text = text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 3;
            }
            text_is_Max = is_text_max(text);

            lblDisplay.Text = text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 4;
            }
            text_is_Max = is_text_max(text);

            lblDisplay.Text = text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 5;
            }
            text_is_Max = is_text_max(text);

            lblDisplay.Text = text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 6;
            }
            text_is_Max = is_text_max(text);

            lblDisplay.Text = text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 7;
            }
            text_is_Max = is_text_max(text);
            lblDisplay.Text = text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 8;
            }
            text_is_Max = is_text_max(text);
            lblDisplay.Text = text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (!text_is_Max)
            {
                text += 9;
            }
            text_is_Max = is_text_max(text);
            lblDisplay.Text = text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(text))
            {
                if (!text_is_Max)
                {
                    text += 0;
                }
                text_is_Max = is_text_max(text);

                lblDisplay.Text = text;
            }
            else if(!already_press_zero_at_start)
            {
                text = "0";
                lblDisplay.Text = text;
				already_press_zero_at_start = true;
                //text = string.Empty;
            }
            
            
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (check_op) AddToResult();
            else {
                result += Convert.ToDouble(text);
            }
            text = string.Empty;
            text_is_Max = is_text_max(text);
            reset_text_max();

            check_op = true;
            check_plus = true;

            check_minus = false;
            check_time = false;
            check_divide = false;

            already_dot = false;

			already_press_zero_at_start = false;
		}

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (check_op) AddToResult();
            else
            {
                result += Convert.ToDouble(text);
            }
            text = string.Empty;
            text_is_Max = is_text_max(text);
            reset_text_max();

            check_op = true;
            check_minus = true;

            check_plus = false;
            check_time = false;
            check_divide = false;

            already_dot = false;

			already_press_zero_at_start = false;
		}

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (check_op) AddToResult();
            else
            {
                result += Convert.ToDouble(text);
            }
            text = string.Empty;
            text_is_Max = is_text_max(text);
            reset_text_max();

            check_op = true;
            check_time = true;

            check_plus = false;
            check_minus = false;
            check_divide = false;

            already_dot = false;

			already_press_zero_at_start = false;
		}

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (check_op) AddToResult();
            else
            {
                result += Convert.ToDouble(text);
            }
            text = string.Empty;
            text_is_Max = is_text_max(text);
            reset_text_max();

            check_op = true;
            check_divide = true;

            check_plus = false;
            check_time = false;
            check_minus = false;

            already_dot = false;

			already_press_zero_at_start = false;
		}

        private void btnPercent_Click(object sender, EventArgs e)
        {
			result += result * Convert.ToDouble(text) / 100;
            
			text = string.Empty;
            text_is_Max = is_text_max(text);
            reset_text_max();

            check_op = true;

            check_plus = false;
            check_time = false;
            check_minus = false;
            check_divide = false;

            already_dot = false;

			already_press_zero_at_start = false;
		}

        private void AddToResult() {
            if (check_plus)
            {
                result += Convert.ToDouble(text);
            }
            else if (check_minus)
            {
                result -= Convert.ToDouble(text);
            }
            else if (check_time)
            {
                result *= Convert.ToDouble(text);
            }
            else if (check_divide)
            {
                result /= Convert.ToDouble(text);
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            AddToResult();
			if (Convert.ToString(result).Length > text_Max_Limit)
			{
				text = Convert.ToString(result).Substring(0, text_Max_Limit);
				result = Convert.ToDouble(text);
			}
			text = "0";
            text_is_Max = is_text_max(text);
            reset_text_max();
			
            lblDisplay.Text = Convert.ToString(result);
     
            check_op = false;
            check_plus = false;
            check_minus = false;
            check_time = false;
            check_divide = false;

            already_dot = false;

			already_press_zero_at_start = false;
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
            text = string.Empty;
            text_is_Max = is_text_max(text);
            reset_text_max();
            result = 0;
            lblDisplay.Text = Convert.ToString(result);

            check_op = false;
            check_plus = false;
            check_minus = false;
            check_time = false;
            check_divide = false;

            already_dot = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!already_dot)
            {
                text += '.';
                text_Max_Limit += 1;
                already_dot = true;
            }
            
            lblDisplay.Text = text;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text)) {
                text += '-';
                text_Max_Limit += 1;
            }
            else
            {
                text = Convert.ToString((-1) * Convert.ToDouble(text));
            }
            
            lblDisplay.Text = text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            text = text.Substring(0, text.Length-1);
            lblDisplay.Text = text;
        }
        
    }
}
