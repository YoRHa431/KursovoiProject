#pragma checksum "..\..\..\Forms\RegistrationForANeeds.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2F5F7DFD9360488A570F2431B867A3D63AC001A1"
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
    /// RegistrationForANeedsWindow
    /// </summary>
    public partial class RegistrationForANeedsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Forms\RegistrationForANeeds.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox plannedDate;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Forms\RegistrationForANeeds.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox applicationDate;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Forms\RegistrationForANeeds.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox actualDate;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Forms\RegistrationForANeeds.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox registrationDate;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Forms\RegistrationForANeeds.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WpfApplicationEntity;component/forms/registrationforaneeds.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\RegistrationForANeeds.xaml"
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
            
            #line 8 "..\..\..\Forms\RegistrationForANeeds.xaml"
            ((WpfApplicationEntity.Forms.RegistrationForANeedsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.plannedDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.applicationDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.actualDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.registrationDate = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ButtonAddEditGroup = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Forms\RegistrationForANeeds.xaml"
            this.ButtonAddEditGroup.Click += new System.Windows.RoutedEventHandler(this.ButtonAddEditRegistrationForANeeds_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

