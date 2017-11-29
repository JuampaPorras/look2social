using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using SmartSocialServices.Objects;

namespace SmartSocialServices.DataTransferObjects
{
    public partial class UserProfileDto
    {
        public string SubscriptionRoleName { get; set; }
        public string BusinessType { get; set; }
        public int Order { get; set; }
        public List<RoleActive> RolesInSubscription { get; set; }

        public UserProfileDto(){
            this.RolesInSubscription = new List<RoleActive>();
            this.SubscriptionRoleName = "";
            this.BusinessType = "";
            this.Order = 0;
        }
        //UserProfileDto() { 
        //}
    }
}
