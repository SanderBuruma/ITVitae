﻿#pragma checksum "..\..\Data.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AEC49F4A09FC2E13C66C7A759A4FD4EBB7C8F1345F3FDBDE48A29E737BB92C66"
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


namespace _6Camping {
    
    
    /// <summary>
    /// Data
    /// </summary>
    public partial class Data : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridXML;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTransportItemButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button VerwijderTransportItemButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NaamHuurderBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlaatsBreedteM3;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker BeginHuurDatePicker;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EindeHuurDatePicker;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AutoCheckBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HondCheckBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AantalPersonenBox;
        
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
            System.Uri resourceLocater = new System.Uri("/6Camping;component/data.xaml", System.UriKind.Relative);
            
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
            this.AddTransportItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Data.xaml"
            this.AddTransportItemButton.Click += new System.Windows.RoutedEventHandler(this.AddReserveringButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.VerwijderTransportItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Data.xaml"
            this.VerwijderTransportItemButton.Click += new System.Windows.RoutedEventHandler(this.VerwijderReserveringButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NaamHuurderBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\Data.xaml"
            this.NaamHuurderBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NaamHuurderBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PlaatsBreedteM3 = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\Data.xaml"
            this.PlaatsBreedteM3.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PlaatsBreedteM3_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BeginHuurDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 29 "..\..\Data.xaml"
            this.BeginHuurDatePicker.CalendarClosed += new System.Windows.RoutedEventHandler(this.BeginHuurDatePicker_CalendarClosed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EindeHuurDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 31 "..\..\Data.xaml"
            this.EindeHuurDatePicker.CalendarClosed += new System.Windows.RoutedEventHandler(this.EindeHuurDatePicker_CalendarClosed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AutoCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.HondCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.AantalPersonenBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\Data.xaml"
            this.AantalPersonenBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.AantalPersonenBox_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

