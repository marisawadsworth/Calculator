using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
    public sealed partial class Calculator : Page
    {
        public Calculator()
        {
            this.InitializeComponent();

            // Button Clear
            result.Text = 0.ToString();
        }

        /// <summary>
        ///  Add a number to the result
        /// </summary>
        /// <param name="number"></param>
        private void AddNumberToResult(double number)
        {
            if (char.IsNumber(result.Text.Last()))
            {
                if (result.Text.Length == 1 && result.Text == "0")
                {
                    result.Text = string.Empty;
                }
                result.Text += number;
            }
            else
            {
                if (number != 0)
                {
                    result.Text += number;
                }
            }
        }

        /// <summary>
        /// Operation Define
        /// </summary>
        /// 

        #region Operation
        enum Operation { PLUS = 1, MINUS = 2, TIMES = 3, DIVIDE = 4, NUMBER = 5 }
        private void AddOperationToResult(Operation operation)
        {
            if (result.Text.Length == 1 && result.Text == "0")
                return;

            if (!char.IsNumber(result.Text.Last()))
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }
            switch (operation)
            {
                case Operation.PLUS: result.Text += "+"; break;
                case Operation.MINUS: result.Text += "-"; break;
                case Operation.TIMES: result.Text += "x"; break;
                case Operation.DIVIDE: result.Text += "÷"; break;
            }
        }

        #endregion Operation

        /// <summary>
        /// Assign Numbers and Operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        #region Numbers
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNumberToResult(0);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The 0 button is not working." + exc.Message);
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNumberToResult(1);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The 1 button is not working." + exc.Message);
            }
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNumberToResult(2);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The 2 button is not working." + exc.Message);
            }
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(3);
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(4);
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(5);
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(6);
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(7);
        }
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(8);
        }
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(9);
        }

        #endregion Numbers

        #region Operation
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddOperationToResult(Operation.PLUS);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The Plus button is not working." + exc.Message);
            }
        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddOperationToResult(Operation.MINUS);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The Minus button is not working." + exc.Message);
            }
        }
        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddOperationToResult(Operation.TIMES);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The Times button is not working." + exc.Message);
            }
        }
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddOperationToResult(Operation.DIVIDE);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The Divide button is not working." + exc.Message);
            }
        }
        #endregion Operation


        /// <summary>
        /// Clear and Equals Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        #region Clear 


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result.Text = 0.ToString();
            }
            catch (Exception exc)
            {
                Debug.WriteLine("The Clear button is not working." + exc.Message);
            }
        }
        #endregion Clear

        #region Equals
        private class Operand
        {
            public Operation operation = Operation.NUMBER; //default
            public double value = 0;

            public Operand left = null;
            public Operand right = null;
        }

        //Get expression from result.Text and build a tree with it.
        private Operand BuildTreeOperand()
        {
            Operand tree = null;

            string expression = result.Text;
            if (!char.IsNumber(expression.Last()))
            {
                expression = expression.Substring(0, expression.Length - 1);
            }

            string numberStr = string.Empty;
            foreach (char c in expression.ToCharArray())
            {
                if (char.IsNumber(c) || c == '.' || numberStr == string.Empty && c == '-')
                {
                    numberStr += c;
                }
                else
                {
                    AddOperandToTree(ref tree, new Operand() { value = double.Parse(numberStr) });
                    numberStr = string.Empty;

                    Operation op = Operation.MINUS; //default
                    switch (c)
                    {
                        case '+': op = Operation.PLUS; break;
                        case '-': op = Operation.MINUS; break;
                        case 'x': op = Operation.TIMES; break;
                        case '÷': op = Operation.DIVIDE; break;
                    }
                    AddOperandToTree(ref tree, new Operand() { operation = op });
                }
            }
            //Last Number
            AddOperandToTree(ref tree, new Operand() { value = double.Parse(numberStr) });

            return tree;
        }

        private void AddOperandToTree(ref Operand tree, Operand elem)
        {
            if (tree == null)
            {
                tree = elem;
            }
            else
            {
                if (elem.operation < tree.operation)
                {
                    Operand auxTree = tree;
                    tree = elem;
                    elem.left = auxTree;
                }
                else
                {
                    AddOperandToTree(ref tree.right, elem); //recursive
                }
            }
        }

        private double Calc(Operand tree)
        {
            if (tree.left == null && tree.right == null) //it's a number
            {
                return tree.value;
            }
            else //it's a operation (+, -, *, /)
            {
                double subResult = 0;
                switch (tree.operation)
                {
                    case Operation.PLUS: subResult = Calc(tree.left) + Calc(tree.right); break; //recursive
                    case Operation.MINUS: subResult = Calc(tree.left) - Calc(tree.right); break;
                    case Operation.TIMES: subResult = Calc(tree.left) * Calc(tree.right); break;
                    case Operation.DIVIDE: subResult = Calc(tree.left) / Calc(tree.right); break;
                }
                return subResult;
            }

        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            //Gate
            if (string.IsNullOrEmpty(result.Text))
                return;

            Operand tree = BuildTreeOperand(); //from string in result.Text

            double value = Calc(tree); //evaluate tree to calculate finall result

            result.Text = value.ToString();
        }

        #endregion Equals
    }

}
