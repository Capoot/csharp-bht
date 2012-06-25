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
    /// Interaktionslogik für AppointmentDialog.xaml
    /// </summary>
    public partial class AppointmentDialog : Window
    {
        private Appointment appointment;

        public AppointmentDialog()
            : this(null)
        {
        }

        public AppointmentDialog(Appointment a)
        {
            appointment = a;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                projectText.IsEnabled = false;
                contactText.IsEnabled = true;
                locationText.IsEnabled = true;
                return;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                projectText.IsEnabled = true;
                contactText.IsEnabled = false;
                locationText.IsEnabled = false;
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.IsEnabled = false;

            // Case of new appointment
            if (appointment == null)
            {
                comboBox1.IsEnabled = true;
                comboBox1.SelectedIndex = 0;
            }

            // existing appointment of type date
            if (appointment is Date)
            {
                comboBox1.SelectedIndex = 0;
                Date date = (Date)appointment;
                titleText.Text = date.Title;
                descriptionText.Text = date.Description;
                timeText.Text = date.Time;
                dateText.Text = date.Date;
                contactText.Text = date.ContactPerson;
                locationText.Text = date.Location;
            }

            // existing appointment of type deadline
            if (appointment is Deadline)
            {
                comboBox1.SelectedIndex = 1;
                Deadline d = (Deadline)appointment;
                titleText.Text = d.Title;
                descriptionText.Text = d.Description;
                timeText.Text = d.Time;
                dateText.Text = d.Date;
                projectText.Text = d.Project;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (appointment == null)
            {
                try
                {
                    createAppointment();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    editAppointment();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            
            Close();
        }

        private void editAppointment()
        {
            if (appointment is Date)
            {
                Date d = (Date)appointment;
                d.Title = titleText.Text;
                d.Description = descriptionText.Text;
                d.Time = timeText.Text;
                d.Date = dateText.Text;
                d.ContactPerson = contactText.Text;
                d.Location = locationText.Text;
                CalenderApp.Instance.InvalidateAppointments();
                return;
            }
            if (appointment is Deadline)
            {
                Deadline d = (Deadline)appointment;
                d.Title = titleText.Text;
                d.Description = descriptionText.Text;
                d.Time = timeText.Text;
                d.Date = dateText.Text;
                d.Project = projectText.Text;
                CalenderApp.Instance.InvalidateAppointments();
            }
        }

        private void createAppointment()
        {
            Appointment a = null;

            if (comboBox1.SelectedIndex == 0)
            {
                a = new Date()
                {
                    Title = titleText.Text,
                    Description = descriptionText.Text,
                    Time = timeText.Text,
                    Date = dateText.Text,
                    ContactPerson = contactText.Text,
                    Location = locationText.Text
                };
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                a = new Deadline()
                {
                    Title = titleText.Text,
                    Description = descriptionText.Text,
                    Time = timeText.Text,
                    Date = dateText.Text,
                    Project = projectText.Text
                };
            }

            CalenderApp app = CalenderApp.Instance;
            app.AddAppointment(a);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                cancelButton_Click(null, null);
                return;
            }
            if (e.Key == Key.Enter)
            {
                okButton_Click(null, null);
            }
        }
    }
}
