using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_calc
{
    public partial class Form1 : Form
    {
        delegate int CalcDelegate(int x, int y);

        protected string operation = string.Empty;
        protected string previousOperation = string.Empty;
        protected string previousValue = "0";
        protected bool operationParsed = false;
        protected int result = 0;

        private bool clearFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private int Add(int x, int y)
        {
           return  x + y;
        }

        private int Subtract(int x, int y)
        {
            return x - y;
        }

        private int Multiply(int x, int y)
        {
            return x * y;
        }

        private int Divide(int x, int y)
        {
            return x / y;
        }

        private int Calculate(int x, int y, CalcDelegate c)
        {
            return c(x, y);
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (Result.Text.Equals("0") || operationParsed)
            {
                previousValue = Result.Text;
                Result.Clear();
                operationParsed = false;
            }

            
            Button b = (Button)sender;
            Result.Text = Result.Text + b.Text;
        }

        private void button_CE_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
        }

        private void button_Operation_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            operationParsed = true;
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Result.Text) || Result.Text.Equals("0"))
            {
                Result.Text = "0.";
            }
            if (!Result.Text.Contains("."))
            {
                Result.Text = Result.Text + ".";

            }
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    Result.Text = (Double.Parse(Result.Text) + Double.Parse(previousValue)).ToString();
                    break;
                case "-":
                    Result.Text = (Double.Parse(previousValue) - Double.Parse(Result.Text)).ToString();
                    break;
                case "*":
                    Result.Text = (Double.Parse(previousValue) * Double.Parse(Result.Text)).ToString();
                    break;
                case "/":
                    Result.Text = (Double.Parse(previousValue) / Double.Parse(Result.Text)).ToString();
                    break;
                default:
                    break;


            }
            operationParsed = true;




        }
    }
}
