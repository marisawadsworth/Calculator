using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    public sealed partial class MainPage : Page
    {
        Double result = 0;
        String operation = "";
        bool enter_value = false;
        String firstNum, secondNum;

        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Hamburger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalculatorListboxItem.IsSelected)
            { ResultTextBlock.Text = "Heart"; }

            else if (HistoryListboxItem.IsSelected)
            { ResultTextBlock.Text = "Star"; }
        }

        /// <summary>
        /// Calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numbersOnly(object sender, RoutedEventArgs e)
        {
            //Shows numbers that have been pressed into the textbox above.
            Button b = (Button)sender;
            if ((TextDisplay.Text == "0") || (enter_value))
                   TextDisplay.Text = "";
            enter_value = false;

            //Lets you add a "." in the textbox and lets you enter numbers after "." has been pressed.
            //NOT WORKING ////////////////////////////////////////
            if (b.Content.ToString() == ".")
            {
                if (!TextDisplay .Text .Contains("."))
                    TextDisplay.Text = TextDisplay.Text + b.Content.ToString();
            }
            else
                TextDisplay.Text = TextDisplay.Text + b.Content.ToString();
        }

        /// <summary>
        /// Operators
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operatorsOnly(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            // Gets the equation and equals it together.
            // NOT WORKING ///////////////////////////////////////
            if (result != 0)
            {
                //btnEquals.Loaded();
                //.PerformClick
                enter_value = true;
                operation = b.Content.ToString();
            }
            else
            {
                operation = b.Content.ToString();
                result = Double.Parse(TextDisplay.Text);
                TextDisplay.Text = "";
                ShowOps.Text = System.Convert.ToString(result) + " " + operation;
            }

            firstNum = ShowOps.Text;
        }

        /// <summary>
        /// Shows numbers in textbox above
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            // Shows the text above and coverts the numbers and symbols to a string.
            ShowOps.Text = "";
            switch(operation)
            {
                case "+":
                    TextDisplay.Text = (result + Double.Parse(TextDisplay.Text)).ToString();
                    break;
                case "-":
                    TextDisplay.Text = (result + Double.Parse(TextDisplay.Text)).ToString();
                    break;
                case "*":
                    TextDisplay.Text = (result + Double.Parse(TextDisplay.Text)).ToString();
                    break;
                case "/":
                    TextDisplay.Text = (result + Double.Parse(TextDisplay.Text)).ToString();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Restart the calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restart(object sender, RoutedEventArgs e)
        {
            // Sets the number back to 0.
            TextDisplay.Text = "0";
            result = 0;
        }

        /// <summary>
        /// Backspace a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Backspace(object sender, RoutedEventArgs e)
        {
            //Backspaces a number
            if (TextDisplay.Text.Length > 0)
            {
                TextDisplay.Text = TextDisplay.Text.Remove(TextDisplay.Text.Length - 1, 1);
            }

            if (TextDisplay.Text == "")
            {
                TextDisplay.Text = "0";
            }
        }
    }
}