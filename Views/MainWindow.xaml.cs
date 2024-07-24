﻿using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using DiceWorks.ViewModel;

namespace DiceWorks.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>s
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM mainWVM = new();
            this.DataContext = mainWVM;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex re = new(@"^[0-9]*$");
            e.Handled = !re.IsMatch(e.Text);
        }

        private void NumericTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextNumeric(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool IsTextNumeric(string text)
        {
            Regex regex = new(@"^[0-9]*$");
            return regex.IsMatch(text);
        }

        private void SignedNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex re = new(@"^[+-]?[0-9]*$");
            e.Handled = !re.IsMatch(e.Text);
        }

        private void SignedNumericTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsSignedTextNumeric(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool IsSignedTextNumeric(string text)
        {
            Regex regex = new(@"^[+-]?[0-9]*$");
            return regex.IsMatch(text);
        }
    }
}