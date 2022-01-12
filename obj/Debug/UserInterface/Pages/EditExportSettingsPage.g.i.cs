﻿#pragma checksum "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79C16CAFF39B4EA74C3684197A1380399DD44D5092DFAC1DAFED2675970AF019"
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
using Xem;


namespace Xem {
    
    
    /// <summary>
    /// EditExportSettingsPage
    /// </summary>
    public partial class EditExportSettingsPage : Xem.BasePage<Xem.EditExportSettingsPageViewModel>, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshButton;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RulesPrescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddParameterButton;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbOne;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SetList;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ExportingProfileList;
        
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
            System.Uri resourceLocater = new System.Uri("/First Plugin;component/userinterface/pages/editexportsettingspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.ApplyButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.ResetButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
            this.ResetButton.Click += new System.Windows.RoutedEventHandler(this.ResetButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RefreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
            this.RefreshButton.Click += new System.Windows.RoutedEventHandler(this.RefreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RulesPrescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddParameterButton = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
            this.AddParameterButton.Click += new System.Windows.RoutedEventHandler(this.AddParameterButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbOne = ((System.Windows.Controls.ListBox)(target));
            
            #line 69 "..\..\..\..\UserInterface\Pages\EditExportSettingsPage.xaml"
            this.lbOne.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ListBox_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SetList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.ExportingProfileList = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

