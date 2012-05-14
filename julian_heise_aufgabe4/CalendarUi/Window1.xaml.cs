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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalendarLib;

namespace CalendarUi
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CalenderApp app = CalenderApp.Instance;
            app.AppointmentsChanged += new CalenderApp.AppointmentsChangedHandler(OnAppointmentsChanged);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDialog wnd = new AppointmentDialog();
            wnd.Title = "Neuen Termin anlegen";
            wnd.ShowDialog();
        }

        private void OnAppointmentsChanged(object sender, EventArgs args)
        {
            appointmentsList.Items.Clear();
            foreach (Appointment a in CalenderApp.Instance.Appointments)
            {
                appointmentsList.Items.Add(a.ToString());
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsList.SelectedIndex == -1)
            {
                return;
            }
            Appointment a = CalenderApp.Instance.Appointments[appointmentsList.SelectedIndex];
            CalenderApp.Instance.RemoveAppointment(a);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsList.SelectedIndex == -1)
            {
                return;
            }
            Appointment a = CalenderApp.Instance.Appointments[appointmentsList.SelectedIndex];
            AppointmentDialog wnd = new AppointmentDialog(a);
            wnd.Title = "Termin bearbeiten";
            wnd.ShowDialog();
        }
    }
}
