// Updated by XamlIntelliSenseFileGenerator 2022-03-22 15:49:18
#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "821477E732D3732DFD6C2E4B894014E6237E7F85F34E6C1293758ADA58D04FDE"
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


namespace pdf_manager
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 95 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView Drzewko;

#line default
#line hidden


#line 108 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel SelectedItemsList;

#line default
#line hidden


#line 134 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button preview;

#line default
#line hidden


#line 135 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searching_word;

#line default
#line hidden


#line 136 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox case_sensitivity;

#line default
#line hidden


#line 137 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clear;

#line default
#line hidden


#line 147 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.CheckListBox results;

#line default
#line hidden


#line 148 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button savePreview;

#line default
#line hidden


#line 149 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password;

#line default
#line hidden


#line 150 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox passwordChecked;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 10 "..\..\MainWindow.xaml"
                    ((pdf_manager.MainWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);

#line default
#line hidden
                    return;
                case 2:

#line 51 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddDirectory_Click);

#line default
#line hidden
                    return;
                case 3:

#line 59 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);

#line default
#line hidden
                    return;
                case 4:

#line 68 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddDirectory_Click);

#line default
#line hidden
                    return;
                case 5:

#line 77 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);

#line default
#line hidden
                    return;
                case 6:
                    this.Drzewko = ((System.Windows.Controls.TreeView)(target));
                    return;
                case 7:
                    this.SelectedItemsList = ((System.Windows.Controls.WrapPanel)(target));
                    return;
                case 8:

#line 116 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddSelectedTreeItems_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.button = ((System.Windows.Controls.Button)(target));

#line 133 "..\..\MainWindow.xaml"
                    this.button.Click += new System.Windows.RoutedEventHandler(this.button_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.preview = ((System.Windows.Controls.Button)(target));

#line 134 "..\..\MainWindow.xaml"
                    this.preview.Click += new System.Windows.RoutedEventHandler(this.preview_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.searching_word = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 12:
                    this.case_sensitivity = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 13:
                    this.clear = ((System.Windows.Controls.Button)(target));

#line 137 "..\..\MainWindow.xaml"
                    this.clear.Click += new System.Windows.RoutedEventHandler(this.clear_Click);

#line default
#line hidden
                    return;
                case 14:
                    this.results = ((Xceed.Wpf.Toolkit.CheckListBox)(target));
                    return;
                case 15:
                    this.savePreview = ((System.Windows.Controls.Button)(target));

#line 148 "..\..\MainWindow.xaml"
                    this.savePreview.Click += new System.Windows.RoutedEventHandler(this.savePreview_Click);

#line default
#line hidden
                    return;
                case 16:
                    this.password = ((System.Windows.Controls.TextBox)(target));

#line 149 "..\..\MainWindow.xaml"
                    this.password.GotFocus += new System.Windows.RoutedEventHandler(this.password_GotFocus);

#line default
#line hidden
                    return;
                case 17:
                    this.passwordChecked = ((System.Windows.Controls.CheckBox)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button searchButton;
    }
}

