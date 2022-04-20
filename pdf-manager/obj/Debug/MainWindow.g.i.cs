﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "75B17B87E804A044A49D13276F4F30CFF73DD36679A95E42608CF65D022E85CA"
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
        
        
        #line 252 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reset;
        
        #line default
        #line hidden
        
        
        #line 253 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button change;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button encrypt;
        
        #line default
        #line hidden
        
        
        #line 266 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textEncryptPassword;
        
        #line default
        #line hidden
        
        
        #line 279 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button decrypt;
        
        #line default
        #line hidden
        
        
        #line 289 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textDecryptPassword;
        
        #line default
        #line hidden
        
        
        #line 330 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searching_word;
        
        #line default
        #line hidden
        
        
        #line 341 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton_Copy;
        
        #line default
        #line hidden
        
        
        #line 352 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button preview1;
        
        #line default
        #line hidden
        
        
        #line 364 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clear;
        
        #line default
        #line hidden
        
        
        #line 382 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox case_sensitivity;
        
        #line default
        #line hidden
        
        
        #line 389 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox highlight;
        
        #line default
        #line hidden
        
        
        #line 402 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView results;
        
        #line default
        #line hidden
        
        
        #line 437 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userPath;
        
        #line default
        #line hidden
        
        
        #line 448 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password;
        
        #line default
        #line hidden
        
        
        #line 459 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox passwordChecked;
        
        #line default
        #line hidden
        
        
        #line 465 "..\..\MainWindow.xaml"
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
            this.reset = ((System.Windows.Controls.Button)(target));
            
            #line 252 "..\..\MainWindow.xaml"
            this.reset.Click += new System.Windows.RoutedEventHandler(this.resetPassword);
            
            #line default
            #line hidden
            return;
            case 12:
            this.change = ((System.Windows.Controls.Button)(target));
            
            #line 253 "..\..\MainWindow.xaml"
            this.change.Click += new System.Windows.RoutedEventHandler(this.changePassword);
            
            #line default
            #line hidden
            return;
            case 13:
            this.encrypt = ((System.Windows.Controls.Button)(target));
            
            #line 263 "..\..\MainWindow.xaml"
            this.encrypt.Click += new System.Windows.RoutedEventHandler(this.encode_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.textEncryptPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 275 "..\..\MainWindow.xaml"
            this.textEncryptPassword.GotFocus += new System.Windows.RoutedEventHandler(this.textEncryptPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 276 "..\..\MainWindow.xaml"
            this.textEncryptPassword.LostFocus += new System.Windows.RoutedEventHandler(this.textEncryptPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 15:
            this.decrypt = ((System.Windows.Controls.Button)(target));
            
            #line 286 "..\..\MainWindow.xaml"
            this.decrypt.Click += new System.Windows.RoutedEventHandler(this.decrypt_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.textDecryptPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 298 "..\..\MainWindow.xaml"
            this.textDecryptPassword.GotFocus += new System.Windows.RoutedEventHandler(this.textDecryptPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 299 "..\..\MainWindow.xaml"
            this.textDecryptPassword.LostFocus += new System.Windows.RoutedEventHandler(this.textDecryptPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 17:
            this.searching_word = ((System.Windows.Controls.TextBox)(target));
            
            #line 333 "..\..\MainWindow.xaml"
            this.searching_word.GotFocus += new System.Windows.RoutedEventHandler(this.searching_word_GotFocus);
            
            #line default
            #line hidden
            
            #line 336 "..\..\MainWindow.xaml"
            this.searching_word.LostFocus += new System.Windows.RoutedEventHandler(this.searching_word_LostFocus);
            
            #line default
            #line hidden
            return;
            case 18:
            this.searchButton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 342 "..\..\MainWindow.xaml"
            this.searchButton_Copy.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.preview1 = ((System.Windows.Controls.Button)(target));
            
            #line 353 "..\..\MainWindow.xaml"
            this.preview1.Click += new System.Windows.RoutedEventHandler(this.preview_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.clear = ((System.Windows.Controls.Button)(target));
            
            #line 365 "..\..\MainWindow.xaml"
            this.clear.Click += new System.Windows.RoutedEventHandler(this.clear_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.case_sensitivity = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 22:
            this.highlight = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 23:
            this.results = ((System.Windows.Controls.ListView)(target));
            return;
            case 24:
            this.userPath = ((System.Windows.Controls.TextBox)(target));
            
            #line 438 "..\..\MainWindow.xaml"
            this.userPath.GotFocus += new System.Windows.RoutedEventHandler(this.userPath_GotFocus);
            
            #line default
            #line hidden
            
            #line 444 "..\..\MainWindow.xaml"
            this.userPath.LostFocus += new System.Windows.RoutedEventHandler(this.userPath_LostFocus);
            
            #line default
            #line hidden
            return;
            case 25:
            this.password = ((System.Windows.Controls.TextBox)(target));
            
            #line 451 "..\..\MainWindow.xaml"
            this.password.GotFocus += new System.Windows.RoutedEventHandler(this.password_GotFocus);
            
            #line default
            #line hidden
            
            #line 456 "..\..\MainWindow.xaml"
            this.password.LostFocus += new System.Windows.RoutedEventHandler(this.password_LostFocus);
            
            #line default
            #line hidden
            return;
            case 26:
            this.passwordChecked = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 27:
            this.savePreview = ((System.Windows.Controls.Button)(target));
            
            #line 466 "..\..\MainWindow.xaml"
            this.savePreview.Click += new System.Windows.RoutedEventHandler(this.savePreview_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

