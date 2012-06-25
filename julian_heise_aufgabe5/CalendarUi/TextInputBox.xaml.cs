using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalendarUi
{
    /// <summary>
    /// Interaktionslogik für TextInputBox.xaml
    /// </summary>
    public partial class TextInputBox : Window
    {
        public bool IsOperationCancelled { get; set; }
        public String Text { get; set; }

        public TextInputBox(string message, string title)
        {
            InitializeComponent();
            label1.Content = message;
            this.Title = title;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            IsOperationCancelled = false;
            Text = textBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            IsOperationCancelled = true;
            Close();
        }
    }
}
