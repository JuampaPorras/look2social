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
    public partial class spGetSubscriptionDeliveries_Result
    {
        #region Primitive Properties
    
        public int idServiceDelivery
        {
            get;
            set;
        }
    
        public Nullable<System.DateTime> DateDelivered
        {
            get;
            set;
        }
    
        public Nullable<int> IdServiceSubscription
        {
            get;
            set;
        }
    
        public string Insights
        {
            get;
            set;
        }

        #endregion

    }
}
