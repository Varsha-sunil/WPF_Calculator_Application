using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for numeric buttons
        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (txtDisplay.Text == "0")
                txtDisplay.Text = button.Content.ToString();
            else
                txtDisplay.Text += button.Content.ToString();
        }

        // Event handler for operator buttons
        //private void OperatorButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = (Button)sender;
        //    txtDisplay.Text += button.Content.ToString();
        //}

        // Event handler for clear button
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
        }

        // Event handler for delete button
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
            if (txtDisplay.Text.Length == 0)
                txtDisplay.Text = "0";
        }

        // Event handler for equals button
        //private void EqualsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        // Evaluating the expression
        //        var result = new DataTable().Compute(txtDisplay.Text, null);
        //        txtDisplay.Text = result.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handling any exceptions (e.g., invalid expressions)
        //        txtDisplay.Text = "Error";
        //    }
        //    // txtDisplay.Text = "0";
        //}

        // Event handler for decimal button
        //private void DecimalButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!txtDisplay.Text.Contains("."))
        //        txtDisplay.Text += ".";
        //}

        // Event handler for operator buttons
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = (Button)sender;
                // Get the last character in the display text
                char lastChar = txtDisplay.Text.Length > 0 ? txtDisplay.Text[txtDisplay.Text.Length - 1] : ' ';

                // Check if the last character is an operator
                if (lastChar != '+' && lastChar != '-' && lastChar != '*' && lastChar != '/')
                {
                    txtDisplay.Text += button.Content.ToString();
                }
            }
            catch(Exception ex)
            {
                txtDisplay.Text = $"{ex.Message}";
            }
            
        }

        // Event handler for equals button
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Evaluating the expression
                var expression = txtDisplay.Text.Trim();

                // Check if the expression ends with an operator
                char lastChar = expression[expression.Length - 1];
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // If it ends with an operator, remove it
                    expression = expression.Remove(expression.Length - 1);
                }

                var result = new DataTable().Compute(expression, null);
                //txtDisplay.Text = result.ToString();
                string res = result.ToString();
                if(res == "∞")
                {
                    txtDisplay.Text = "Invalid, the result is not defined / ∞";
                }
                else
                {
                    txtDisplay.Text = res;
                }
            }
            catch (Exception ex)
            {
                // Handling any exceptions (e.g., invalid expressions)
                txtDisplay.Text = $"{ex.Message}";
            }
        }

        // Event handler for decimal button
        //private void DecimalButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!txtDisplay.Text.EndsWith(".") && !txtDisplay.Text.EndsWith("."))
        //    {
        //        txtDisplay.Text += ".";
        //    }
        //}

        /// <summary>
        /// This method allows only one decimal point per operand 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if there is no decimal point already present in the text
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
            else
            {
                // Split the text by operators to identify operands
                string[] operands = txtDisplay.Text.Split('+', '-', '*', '/', '%');

                // Check if the current operand already contains a decimal point
                if (operands.Length > 0 && operands[operands.Length - 1].Contains("."))
                {
                    // Do nothing if the current operand already has a decimal point
                    return;
                }
                else
                {
                    // Add a decimal point to the current operand
                    txtDisplay.Text += ".";
                }
            }
        }


        // Event handler for double zero button

        private void DoubleZeroButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            txtDisplay.Text += button.Content.ToString();
        }

        // Event handler for mod button
        private void ModButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            // Get the last character in the display text
            char lastChar = txtDisplay.Text.Length > 0 ? txtDisplay.Text[txtDisplay.Text.Length - 1] : ' ';

            // Check if the last character is an operator
            if (lastChar != '+' && lastChar != '-' && lastChar != '*' && lastChar != '/' && lastChar != '%')
            {
                txtDisplay.Text += button.Content.ToString();
            }
        }
    }
}
