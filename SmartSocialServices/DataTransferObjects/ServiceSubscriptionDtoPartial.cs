using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace SmartSocialServices.DataTransferObjects
{
    public partial class ServiceSubscriptionDto
    {
        public string BusinessType { get; set; }
        public string SubscriptionRoleName { get; set; }
    }
}
