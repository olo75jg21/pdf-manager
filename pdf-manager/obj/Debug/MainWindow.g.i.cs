﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5A936F0C0A6706D3969A2E76CBCFF884DA5488D1944676CD72053D4180911EF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using pdf_manager;


namespace pdf_manager {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 140 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView DirectoryTreeView;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView SelectedItemsList;
        
        #line default
        #line hidden
        
        
        #line 226 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mergeAllButton;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mergeButton;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button passwordHistory;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button encrypt;
        
        #line default
        #line hidden
        
        
        #line 264 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textEncryptPassword;
        
        #line default
        #line hidden
        
        
        #line 277 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button decrypt;
        
        #line default
        #line hidden
        
        
        #line 287 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textDecryptPassword;
        
        #line default
        #line hidden
        
        
        #line 328 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searching_word;
        
        #line default
        #line hidden
        
        
        #line 339 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton_Copy;
        
        #line default
        #line hidden
        
        
        #line 350 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button preview1;
        
        #line default
        #line hidden
        
        
        #line 362 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clear;
        
        #line default
        #line hidden
        
        
        #line 380 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox case_sensitivity;
        
        #line default
        #line hidden
        
        
        #line 387 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox highlight;
        
        #line default
        #line hidden
        
        
        #line 400 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView results;
        
        #line default
        #line hidden
        
        
        #line 435 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userPath;
        
        #line default
        #line hidden
        
        
        #line 446 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password;
        
        #line default
        #line hidden
        
        
        #line 457 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox passwordChecked;
        
        #line default
        #line hidden
        
        
        #line 463 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button savePreview;
        
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
            
            #line 19 "..\..\MainWindow.xaml"
            ((pdf_manager.MainWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            ((pdf_manager.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 78 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddDirectory_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 92 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonRemoveDirectory_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 105 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddSelectedTreeItems_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 118 "..\..\MainWindow.xaml"
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
            this.mergeAllButton = ((System.Windows.Controls.Button)(target));
            
            #line 227 "..\..\MainWindow.xaml"
            this.mergeAllButton.Click += new System.Windows.RoutedEventHandler(this.mergeAllButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.mergeButton = ((System.Windows.Controls.Button)(target));
            
            #line 239 "..\..\MainWindow.xaml"
            this.mergeButton.Click += new System.Windows.RoutedEventHandler(this.mergeButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.passwordHistory = ((System.Windows.Controls.Button)(target));
            
            #line 248 "..\..\MainWindow.xaml"
            this.passwordHistory.Click += new System.Windows.RoutedEventHandler(this.passwordHistory_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.encrypt = ((System.Windows.Controls.Button)(target));
            
            #line 261 "..\..\MainWindow.xaml"
            this.encrypt.Click += new System.Windows.RoutedEventHandler(this.encode_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.textEncryptPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 273 "..\..\MainWindow.xaml"
            this.textEncryptPassword.GotFocus += new System.Windows.RoutedEventHandler(this.textEncryptPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 274 "..\..\MainWindow.xaml"
            this.textEncryptPassword.LostFocus += new System.Windows.RoutedEventHandler(this.textEncryptPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 13:
            this.decrypt = ((System.Windows.Controls.Button)(target));
            
            #line 284 "..\..\MainWindow.xaml"
            this.decrypt.Click += new System.Windows.RoutedEventHandler(this.decrypt_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.textDecryptPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 296 "..\..\MainWindow.xaml"
            this.textDecryptPassword.GotFocus += new System.Windows.RoutedEventHandler(this.textDecryptPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 297 "..\..\MainWindow.xaml"
            this.textDecryptPassword.LostFocus += new System.Windows.RoutedEventHandler(this.textDecryptPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 15:
            this.searching_word = ((System.Windows.Controls.TextBox)(target));
            
            #line 331 "..\..\MainWindow.xaml"
            this.searching_word.GotFocus += new System.Windows.RoutedEventHandler(this.searching_word_GotFocus);
            
            #line default
            #line hidden
            
            #line 334 "..\..\MainWindow.xaml"
            this.searching_word.LostFocus += new System.Windows.RoutedEventHandler(this.searching_word_LostFocus);
            
            #line default
            #line hidden
            return;
            case 16:
            this.searchButton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 340 "..\..\MainWindow.xaml"
            this.searchButton_Copy.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.preview1 = ((System.Windows.Controls.Button)(target));
            
            #line 351 "..\..\MainWindow.xaml"
            this.preview1.Click += new System.Windows.RoutedEventHandler(this.preview_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.clear = ((System.Windows.Controls.Button)(target));
            
            #line 363 "..\..\MainWindow.xaml"
            this.clear.Click += new System.Windows.RoutedEventHandler(this.clear_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.case_sensitivity = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 20:
            this.highlight = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 21:
            this.results = ((System.Windows.Controls.ListView)(target));
            return;
            case 22:
            this.userPath = ((System.Windows.Controls.TextBox)(target));
            
            #line 436 "..\..\MainWindow.xaml"
            this.userPath.GotFocus += new System.Windows.RoutedEventHandler(this.userPath_GotFocus);
            
            #line default
            #line hidden
            
            #line 442 "..\..\MainWindow.xaml"
            this.userPath.LostFocus += new System.Windows.RoutedEventHandler(this.userPath_LostFocus);
            
            #line default
            #line hidden
            return;
            case 23:
            this.password = ((System.Windows.Controls.TextBox)(target));
            
            #line 449 "..\..\MainWindow.xaml"
            this.password.GotFocus += new System.Windows.RoutedEventHandler(this.password_GotFocus);
            
            #line default
            #line hidden
            
            #line 454 "..\..\MainWindow.xaml"
            this.password.LostFocus += new System.Windows.RoutedEventHandler(this.password_LostFocus);
            
            #line default
            #line hidden
            return;
            case 24:
            this.passwordChecked = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 25:
            this.savePreview = ((System.Windows.Controls.Button)(target));
            
            #line 464 "..\..\MainWindow.xaml"
            this.savePreview.Click += new System.Windows.RoutedEventHandler(this.savePreview_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

