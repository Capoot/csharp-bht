﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7C60C3787764E56F0BCDE50612A0C500"
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
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 84 "..\..\Window1.xaml"
        internal System.Windows.Controls.TabControl tabControl1;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBox appointmentsList;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button3;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBox taskList;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button tasknew;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button taskedit;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button taskdelete;
        
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
            System.Uri resourceLocater = new System.Uri("/CalendarUi;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            this.tabControl1 = ((System.Windows.Controls.TabControl)(target));
            return;
            case 2:
            this.appointmentsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\Window1.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\Window1.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button3 = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\Window1.xaml"
            this.button3.Click += new System.Windows.RoutedEventHandler(this.button3_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.taskList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.tasknew = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\Window1.xaml"
            this.tasknew.Click += new System.Windows.RoutedEventHandler(this.tasknew_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.taskedit = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\Window1.xaml"
            this.taskedit.Click += new System.Windows.RoutedEventHandler(this.taskedit_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.taskdelete = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\Window1.xaml"
            this.taskdelete.Click += new System.Windows.RoutedEventHandler(this.taskdelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
