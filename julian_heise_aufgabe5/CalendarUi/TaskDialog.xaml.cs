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
using CalendarLib;

namespace CalendarUi
{
    /// <summary>
    /// Interaktionslogik für TaskDialog.xaml
    /// </summary>
    public partial class TaskDialog : Window
    {

        private Task task;

        public TaskDialog(Task t)
        {
            InitializeComponent();
            task = t;
        }

        public TaskDialog() : this(null)
        {
            
        }

        private void typeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeCombo.SelectedIndex == 0)
            {
                companyText.IsEnabled = false;
                contactText.IsEnabled = false;
                return;
            }
            if (typeCombo.SelectedIndex == 1)
            {
                companyText.IsEnabled = true;
                contactText.IsEnabled = true;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                create();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Close();
        }

        private void create()
        {
            Priority prio;
            try
            {
                prio = (Priority)int.Parse(priorityText.Text);
            }
            catch (Exception e)
            {
                throw new Exception("Die Priorität bitte von 0 (niedrig) - 2 (hoch) angeben", e);
            }
            Task t = null;

            if (typeCombo.SelectedIndex == 0)
            {

                t = new PrivateTask(dueText.Text, titleText.Text, prio, descrText.Text);
            }
            if (typeCombo.SelectedIndex == 1)
            {
                t = new BusinessTask(titleText.Text, descrText.Text, dueText.Text, prio, companyText.Text, contactText.Text);
            }
            CalenderApp.Instance.AddTask(t);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (task == null)
            {
                typeCombo.SelectedIndex = 0;
                return;
            }

            dueText.Text = task.Due;
            descrText.Text = task.Description;
            titleText.Text = task.Title;
            priorityText.Text = task.Priority.ToString();
            typeCombo.SelectedIndex = 0;

            if (task is BusinessTask)
            {
                BusinessTask b = (BusinessTask)task;
                companyText.Text = b.Company;
                contactText.Text = b.ContactPerson;
                typeCombo.SelectedIndex = 1;
            }

            typeCombo.IsEnabled = false;
        }
    }
}
