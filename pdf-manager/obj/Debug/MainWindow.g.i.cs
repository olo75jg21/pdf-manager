﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7E2F411A7D07EE8728F824254D701CF8B088442B2852289263717DE3224D9050"
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;
using pdf_manager;


namespace pdf_manager {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 101 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView DirectoryTreeView;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView SelectedItemsList;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mergeButton;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mergeAllButton;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox highlight;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button encrypt;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textEncodePassword;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveSettingsButton;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button preview;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searching_word;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox case_sensitivity;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clear;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button savePreview;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userPath;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox passwordChecked;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton_Copy;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.CheckListBox results;
        
        #line default
        #line hidden
        
        
        #line 263 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button preview1;
        
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
            System.Uri resourceLocater = new System.Uri("/pdf-manager;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 10 "..\..\MainWindow.xaml"
            ((pdf_manager.MainWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 58 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddDirectory_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 66 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonRemoveDirectory_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 75 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddSelectedTreeItems_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 84 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonRemoveSelectedTreeItems_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DirectoryTreeView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 7:
            this.SelectedItemsList = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            
            #line 160 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddSelectedTreeItems_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.mergeButton = ((System.Windows.Controls.Button)(target));
            
            #line 200 "..\..\MainWindow.xaml"
            this.mergeButton.Click += new System.Windows.RoutedEventHandler(this.mergeButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.mergeAllButton = ((System.Windows.Controls.Button)(target));
            
            #line 212 "..\..\MainWindow.xaml"
            this.mergeAllButton.Click += new System.Windows.RoutedEventHandler(this.mergeAllButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.highlight = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 12:
            this.encrypt = ((System.Windows.Controls.Button)(target));
            
            #line 217 "..\..\MainWindow.xaml"
            this.encrypt.Click += new System.Windows.RoutedEventHandler(this.encode_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.textEncodePassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.saveSettingsButton = ((System.Windows.Controls.Button)(target));
            
            #line 230 "..\..\MainWindow.xaml"
            this.saveSettingsButton.Click += new System.Windows.RoutedEventHandler(this.SaveSettingsButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.preview = ((System.Windows.Controls.Button)(target));
            
            #line 235 "..\..\MainWindow.xaml"
            this.preview.Click += new System.Windows.RoutedEventHandler(this.preview_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.searching_word = ((System.Windows.Controls.TextBox)(target));
            
            #line 236 "..\..\MainWindow.xaml"
            this.searching_word.GotFocus += new System.Windows.RoutedEventHandler(this.searching_word_GotFocus);
            
            #line default
            #line hidden
            return;
            case 17:
            this.case_sensitivity = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 18:
            this.clear = ((System.Windows.Controls.Button)(target));
            
            #line 238 "..\..\MainWindow.xaml"
            this.clear.Click += new System.Windows.RoutedEventHandler(this.clear_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.savePreview = ((System.Windows.Controls.Button)(target));
            
            #line 248 "..\..\MainWindow.xaml"
            this.savePreview.Click += new System.Windows.RoutedEventHandler(this.savePreview_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.userPath = ((System.Windows.Controls.TextBox)(target));
            
            #line 249 "..\..\MainWindow.xaml"
            this.userPath.GotFocus += new System.Windows.RoutedEventHandler(this.userPath_GotFocus);
            
            #line default
            #line hidden
            return;
            case 21:
            this.password = ((System.Windows.Controls.TextBox)(target));
            
            #line 250 "..\..\MainWindow.xaml"
            this.password.GotFocus += new System.Windows.RoutedEventHandler(this.password_GotFocus);
            
            #line default
            #line hidden
            return;
            case 22:
            this.passwordChecked = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 23:
            this.searchButton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 252 "..\..\MainWindow.xaml"
            this.searchButton_Copy.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            this.results = ((Xceed.Wpf.Toolkit.CheckListBox)(target));
            return;
            case 25:
            this.preview1 = ((System.Windows.Controls.Button)(target));
            
            #line 263 "..\..\MainWindow.xaml"
            this.preview1.Click += new System.Windows.RoutedEventHandler(this.preview_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

