using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result_value = 0;
        String operation_performed="";
        bool operationIsPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_clicked(object sender, EventArgs e)
        {
            if (result.Text == "0" || operationIsPerformed)
                result.Clear();
            Button instance = (Button)sender;
            if (instance.Text==".")
            {
                if(!result.Text.Contains("."))
                {
                    result.Text = result.Text + instance.Text;
                }
            }
            else
            {
                result.Text = result.Text + instance.Text;
            }
            operationIsPerformed = false;
        }

        private void operation_clicked(object sender, EventArgs e)
        {
            Button instance = (Button)sender;

            if(result_value!=0)
            {
                button16.PerformClick();
                operation_performed = instance.Text;
                label_current_operation.Text = result_value + " " + operation_performed;
                operationIsPerformed = true;
            }
            else
            {
                operation_performed = instance.Text;
                result_value = Double.Parse(result.Text);
                label_current_operation.Text = result_value + " " + operation_performed;
                operationIsPerformed = true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            result_value = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (operation_performed)
            {
                case "+":
                    result.Text = (result_value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (result_value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (result_value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (result_value / Double.Parse(result.Text)).ToString();
                    break;
                case "%":
                    result.Text = (result_value % Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            }
            result_value = Double.Parse(result.Text);
            label_current_operation.Text = "";
        }
    }
}
