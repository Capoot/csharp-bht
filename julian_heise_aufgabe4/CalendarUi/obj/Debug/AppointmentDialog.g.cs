﻿#pragma checksum "..\..\AppointmentDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9CD4216C56E61BCD53E87F054E64C0B9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:2.0.50727.4971
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using CalendarUi;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CalendarUi {
    
    
    /// <summary>
    /// AppointmentDialog
    /// </summary>
    public partial class AppointmentDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.TextBox dateText;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.TextBox timeText;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.TextBox titleText;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.TextBox descriptionText;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label4;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.ComboBox comboBox1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label5;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label6;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label7;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.TextBox locationText;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.TextBox contactText;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.Label label8;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AppointmentDialog.xaml"
        internal System.Windows.Controls.TextBox projectText;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CalendarUi;component/appointmentdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AppointmentDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\AppointmentDialog.xaml"
            ((CalendarUi.AppointmentDialog)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\AppointmentDialog.xaml"
            ((CalendarUi.AppointmentDialog)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dateText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.timeText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.titleText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.descriptionText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\AppointmentDialog.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.cancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\AppointmentDialog.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.okButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.label4 = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.comboBox1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\AppointmentDialog.xaml"
            this.comboBox1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBox1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.label5 = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.label6 = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.label7 = ((System.Windows.Controls.Label)(target));
            return;
            case 16:
            this.locationText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.contactText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.label8 = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.projectText = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
