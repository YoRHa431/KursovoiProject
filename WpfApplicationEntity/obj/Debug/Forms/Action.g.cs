#pragma checksum "..\..\..\Forms\Action.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7F3802065987B90D3217B3805E1119BD3EA5C0AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApplicationEntity.Forms;


namespace WpfApplicationEntity.Forms {
    
    
    /// <summary>
    /// ActionWindow
    /// </summary>
    public partial class ActionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Starttime;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Endtime;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Dateofthe;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Numberofvolunteer;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Numberofneedy;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBlockAddEditActionForTheNeedy;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBlockAddEditTypeAction;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Forms\Action.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddEditGroup;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplicationEntity;component/forms/action.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\Action.xaml"
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
            
            #line 8 "..\..\..\Forms\Action.xaml"
            ((WpfApplicationEntity.Forms.ActionWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Starttime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Endtime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Dateofthe = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Numberofvolunteer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Numberofneedy = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.comboBlockAddEditActionForTheNeedy = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.comboBlockAddEditTypeAction = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.ButtonAddEditGroup = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Forms\Action.xaml"
            this.ButtonAddEditGroup.Click += new System.Windows.RoutedEventHandler(this.ButtonAddEditAction_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

