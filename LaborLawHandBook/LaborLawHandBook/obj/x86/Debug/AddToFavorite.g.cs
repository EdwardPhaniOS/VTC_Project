﻿#pragma checksum "C:\Computer Science\04. Universal Windows Platform\Project\Universal App\LaborLawHandBook\LaborLawHandBook\LaborLawHandBook\AddToFavorite.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "44211D3A38EE86A91B3BA5F35EA6BDCC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaborLawHandBook
{
    partial class AddToFavorite : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.txtThuTu = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 2:
                {
                    this.btLuu = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 34 "..\..\..\AddToFavorite.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btLuu).Click += this.btLuu_ClickAsync;
                    #line default
                }
                break;
            case 3:
                {
                    this.btBack = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 36 "..\..\..\AddToFavorite.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btBack).Click += this.btBack_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

