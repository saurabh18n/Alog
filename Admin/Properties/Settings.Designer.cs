﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AManager.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Verdana, 8.25pt")]
        public global::System.Drawing.Font defaultFont {
            get {
                return ((global::System.Drawing.Font)(this["defaultFont"]));
            }
            set {
                this["defaultFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Microsoft Tai Le, 8.25pt")]
        public global::System.Drawing.Font fontData {
            get {
                return ((global::System.Drawing.Font)(this["fontData"]));
            }
            set {
                this["fontData"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int refreshInterval {
            get {
                return ((int)(this["refreshInterval"]));
            }
            set {
                this["refreshInterval"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int gatewayPriority {
            get {
                return ((int)(this["gatewayPriority"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int Setting {
            get {
                return ((int)(this["Setting"]));
            }
            set {
                this["Setting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Verdana, 8.25pt")]
        public global::System.Drawing.Font BtnFont {
            get {
                return ((global::System.Drawing.Font)(this["BtnFont"]));
            }
            set {
                this["BtnFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No")]
        public global::System.Windows.Forms.RightToLeft TextRighttoLeft {
            get {
                return ((global::System.Windows.Forms.RightToLeft)(this["TextRighttoLeft"]));
            }
            set {
                this["TextRighttoLeft"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("01/27/2020 08:01:00")]
        public global::System.DateTime checkinStart {
            get {
                return ((global::System.DateTime)(this["checkinStart"]));
            }
            set {
                this["checkinStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("01/27/2020 09:01:00")]
        public global::System.DateTime checkinEnd {
            get {
                return ((global::System.DateTime)(this["checkinEnd"]));
            }
            set {
                this["checkinEnd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("01/27/2020 14:01:00")]
        public global::System.DateTime checkoutStart {
            get {
                return ((global::System.DateTime)(this["checkoutStart"]));
            }
            set {
                this["checkoutStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("01/27/2020 12:01:00")]
        public global::System.DateTime checkoutEnd {
            get {
                return ((global::System.DateTime)(this["checkoutEnd"]));
            }
            set {
                this["checkoutEnd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("01/27/2020 23:01:00")]
        public global::System.DateTime autoCheckOut {
            get {
                return ((global::System.DateTime)(this["autoCheckOut"]));
            }
            set {
                this["autoCheckOut"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool setupcomplete {
            get {
                return ((bool)(this["setupcomplete"]));
            }
            set {
                this["setupcomplete"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Greetings {ParentName},Your Child {StudentName} Reached School on {Date} at {Time" +
            "}Thanks")]
        public string smsTemplet {
            get {
                return ((string)(this["smsTemplet"]));
            }
            set {
                this["smsTemplet"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("01/01/2020 02:00:00")]
        public global::System.DateTime sms_defaultValidFor {
            get {
                return ((global::System.DateTime)(this["sms_defaultValidFor"]));
            }
            set {
                this["sms_defaultValidFor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Verdana, 8pt")]
        public global::System.Drawing.Font labelFont {
            get {
                return ((global::System.Drawing.Font)(this["labelFont"]));
            }
            set {
                this["labelFont"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=NPS-PC\\SQLEXPRESS;Initial Catalog=amDB;Integrated Security=True")]
        public string connection {
            get {
                return ((string)(this["connection"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Verdana, 8.25pt")]
        public global::System.Drawing.Font GVFont {
            get {
                return ((global::System.Drawing.Font)(this["GVFont"]));
            }
            set {
                this["GVFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point Loc_RG_student {
            get {
                return ((global::System.Drawing.Point)(this["Loc_RG_student"]));
            }
            set {
                this["Loc_RG_student"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point Loc_pann_service {
            get {
                return ((global::System.Drawing.Point)(this["Loc_pann_service"]));
            }
            set {
                this["Loc_pann_service"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Display_RG_student {
            get {
                return ((bool)(this["Display_RG_student"]));
            }
            set {
                this["Display_RG_student"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Display_Pann_service {
            get {
                return ((bool)(this["Display_Pann_service"]));
            }
            set {
                this["Display_Pann_service"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point loc_classwisechart {
            get {
                return ((global::System.Drawing.Point)(this["loc_classwisechart"]));
            }
            set {
                this["loc_classwisechart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Display_classwisechart {
            get {
                return ((bool)(this["Display_classwisechart"]));
            }
            set {
                this["Display_classwisechart"] = value;
            }
        }
    }
}