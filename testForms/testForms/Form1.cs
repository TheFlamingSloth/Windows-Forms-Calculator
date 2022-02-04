namespace testForms
{
    public static class StringExt
    {
        public static string? Truncate(this string? value, int maxLength)
        {
            return value?.Length > maxLength
                ? value.Substring(0, maxLength)
                : value;
        }
    }
    public partial class Calculator : Form
    {
        public string operation, buffer;
        public double num1, num2;
        public char operationChar = 'a';
        public bool operationPresent;
        public Calculator() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumberPress(object sender, EventArgs e)
        {
            string s = ((Button)sender).Text;
            label1.Text = label1.Text + s;
        }

        private void SymbolPress(object sender, EventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            operation = (sender as Button).Text;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (label1.Text.Contains("-") || label1.Text.Contains("+") || label1.Text.Contains("*") || label1.Text.Contains("/"))
            {
                label1.Text = label1.Text.Replace("+", operation);
                label1.Text = label1.Text.Replace("-", operation);
                label1.Text = label1.Text.Replace("*", operation);
                label1.Text = label1.Text.Replace("/", operation);
            }

            else
            {
                label1.Text = label1.Text + operation;
            }
        }

        private void EnterPress(object sender, EventArgs e)
        {
            operationPresent = false;
            try
            {
                operationChar = operation.ToCharArray()[0];
            }
            catch (Exception)
            {
                return;
            }
            foreach (char c in label1.Text)
            {
                if (c == operationChar)
                {
                    num1 = Double.Parse(buffer);
                    buffer = "";
                    operationPresent = true;
                    continue;
                }
                buffer = buffer + c;
            }
            try
            {
                num2 = Double.Parse(buffer);
            }
            catch(Exception)
            {
                return;
            }

            if (operationPresent == false)
            {
                return;
            }

            if (operation == "+")
            {
                label1.Text = (num1 + num2).ToString();
            }
            else if (operation == "-")
            {
                label1.Text = (num1 - num2).ToString();
            }
            else if (operation == "*")
            {
                label1.Text = (num1 * num2).ToString();
            }
            else if (operation == "/")
            {
                if (num2 == 0)
                {
                    label1.Text = "Invalid";
                }
                else
                {
                    label1.Text = (num1 / num2).ToString();
                }
            }

            if (label1.Text.Length > 10)
            {
                label1.Text = label1.Text.Truncate(10);
            }

            buffer = "";
        }

        private void Clear(object sender, EventArgs e)
        {
            label1.Text = "";
            operation = "";
            buffer = "";
            num1 = 0;
            num2 = 0;
        }
    }
}