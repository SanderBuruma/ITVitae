﻿#pragma checksum "..\..\Data.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7E9B3A40D0A5BDB99DFA0EBB6390A3483D33E2D2AAB78CD52BAC6C435C7D2B38"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using System.Windows.Shell;
using _5KinderBijslag;


namespace _5KinderBijslag {
    
    
    /// <summary>
    /// Data
    /// </summary>
    public partial class Data : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridXML;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KindVoornaamBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KindFamilienaamBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker KindGeboortedatumBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddKindButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PeildatumBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/5KinderBijslag;component/data.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Data.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DataGridXML = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.KindVoornaamBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.KindFamilienaamBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.KindGeboortedatumBox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.AddKindButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Data.xaml"
            this.AddKindButton.Click += new System.Windows.RoutedEventHandler(this.AddKindButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PeildatumBox = ((System.Windows.Controls.DatePicker)(target));
            
            #line 35 "..\..\Data.xaml"
            this.PeildatumBox.CalendarClosed += new System.Windows.RoutedEventHandler(this.PeildatumBox_CalendarClosed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

