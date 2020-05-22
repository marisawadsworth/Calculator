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
        char iOperation;

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
            if (HeartListboxItem.IsSelected)
            { ResultTextBlock.Text = "Heart"; }

            else if (StarListboxItem.IsSelected)
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
            operation = b.Content.ToString();
            result = Double.Parse(TextDisplay.Text);
            TextDisplay.Text = "";
            ShowOps.Text = System.Convert.ToString(result) + " " + operation;
        }
    }
}