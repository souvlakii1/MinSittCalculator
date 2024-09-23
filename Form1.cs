namespace CalculatorReal
{
    public partial class Form1 : Form
    {
        bool success = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate(object sender, EventArgs e)
        {
            
            if(string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) ||
               comboBox1.SelectedItem == null ||
               comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Error!\nPlease input values or the operators in all fields.", "Message");
            }
            else
            {
                
                string op1 = comboBox1.SelectedItem.ToString();
                string op2 = comboBox2.SelectedItem.ToString();
                if (checkdouble(textBox1.Text) && checkdouble(textBox2.Text) && checkdouble(textBox3.Text))
                {
                    double num1 = double.Parse(textBox1.Text);
                    double num2 = double.Parse(textBox2.Text);
                    double num3 = double.Parse(textBox3.Text);
                    double result = thecalc(num1, op1, num2, op2, num3);
                    textBox4.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Error!\nPlease enter a valid input!", "Message");
                }
                

            }
        }
        private double thecalc(double a, string opr1, double b, string opr2, double c)
        {
            double hello;
            switch(opr1)
            {
                case "*":
                case "/":
                    {
                        hello = calculation(a, opr1, b);
                        return calculation(hello, opr2, c);
                        
                    }
                case "+":
                case "-":
                    {
                        switch (opr2)
                        {
                            case "*":
                            case "/":
                                {
                                    hello = calculation(b, opr2, c);
                                    return calculation(a, opr1, hello);
                                    
                                }
                            case "+":
                            case "-":
                                {
                                    hello = calculation(a, opr1, b);
                                    return calculation(hello, opr2, c);
                                    
                                }
                            default:
                                {
                                    return 0;
                                }
                        }
                        
                    }
                default:
                    {
                        return 0;
                    }


                       
            }
                
        }
        private double calculation(double first,string op, double second)
        {
            switch(op)
            {
                case "+":
                    {
                        return first + second;
                        
                    }
                case "-":
                    {
                        return first - second;
                        
                    }
                case "*":
                    {
                        return first * second;
                        
                    }
                case "/":
                    {
                        if (second != 0)
                        {
                            return first / second;
                        }
                        else
                        {
                            MessageBox.Show("Error!\nCannot be divided by zero.", "Message");
                            return 0;
                        }
                        
                    }
                default:
                    {
                        return 0;
                    }


            }
        }
        private bool checkdouble(String x)
        {
            return double.TryParse(x, out _);
        }

        private void Reset(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
    }
}
