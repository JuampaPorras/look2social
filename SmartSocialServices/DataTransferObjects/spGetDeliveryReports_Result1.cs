//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace SmartSocialServices.DataTransferObjects
{
    public partial class spGetDeliveryReports_Result1
    {
        #region Primitive Properties
    
        public int idSmartReport
        {
            get;
            set;
        }
    
        public Nullable<int> idServiceDelivery
        {
            get;
            set;
        }
    
        public string ReportName
        {
            get;
            set;
        }
    
        public string Insights
        {
            get;
            set;
        }
    
        public Nullable<System.DateTime> DateCreated
        {
            get;
            set;
        }
    
        public Nullable<bool> isTemplate
        {
            get;
            set;
        }

        #endregion

    }
}
