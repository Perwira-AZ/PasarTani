﻿#pragma checksum "..\..\..\..\..\MVVM\View\BuyItemView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A89704E86DFAB03C2D9089895385C476127DF8F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PasarTani.MVVM.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace PasarTani.MVVM.View {
    
    
    /// <summary>
    /// BuyItemView
    /// </summary>
    public partial class BuyItemView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DisplayImgPhoto;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox detailItemName;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox detailItemPrice;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox detailItemStock;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock detailItemDesc;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox buyQuantity;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotalPrice;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBuy;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PasarTani;component/mvvm/view/buyitemview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DisplayImgPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.detailItemName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.detailItemPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.detailItemStock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.detailItemDesc = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.buyQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TotalPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnBuy = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\..\..\MVVM\View\BuyItemView.xaml"
            this.btnBuy.Click += new System.Windows.RoutedEventHandler(this.btnBuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

