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
    
    [DataContract(Name = "ServiceDeliveryDto", Namespace = "http://www.SmartSocial.com/dto/" , IsReference = true) ]
    public partial class ServiceDeliveryDto
    {
         #region Primitive Properties
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int idServiceDelivery
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<System.DateTime> DateDelivered
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<System.DateTime> DeliveryDateTo
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<int> IdServiceSubscription
        {
     
    		
            get { return _idServiceSubscription; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_idServiceSubscription != value)
                    {
                        if (ServiceSubscription != null && ServiceSubscription.idServiceSubscription != value)
                        {
                            ServiceSubscription = null;
                        }
                        _idServiceSubscription = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _idServiceSubscription;
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string Insights
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual ICollection<SmartReportDto> SmartReports
        {
            get
            {
                if (_smartReports == null)
                {
                    var newCollection = new FixupCollection<SmartReportDto>();
                    newCollection.CollectionChanged += FixupSmartReports;
                    _smartReports = newCollection;
                }
                return _smartReports;
            }
            set
            {
                if (!ReferenceEquals(_smartReports, value))
                {
                    var previousValue = _smartReports as FixupCollection<SmartReportDto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSmartReports;
                    }
                    _smartReports = value;
                    var newValue = value as FixupCollection<SmartReportDto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSmartReports;
                    }
                }
            }
        }
        private ICollection<SmartReportDto> _smartReports;
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual ServiceSubscriptionDto ServiceSubscription
        {
            get { return _serviceSubscription; }
            set
            {
                if (!ReferenceEquals(_serviceSubscription, value))
                {
                    var previousValue = _serviceSubscription;
                    _serviceSubscription = value;
                    FixupServiceSubscription(previousValue);
                }
            }
        }
        private ServiceSubscriptionDto _serviceSubscription;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupServiceSubscription(ServiceSubscriptionDto previousValue)
        {
            if (previousValue != null && previousValue.ServiceDeliveries.Contains(this))
            {
                previousValue.ServiceDeliveries.Remove(this);
            }
    
            if (ServiceSubscription != null)
            {
                if (!ServiceSubscription.ServiceDeliveries.Contains(this))
                {
                    ServiceSubscription.ServiceDeliveries.Add(this);
                }
                if (IdServiceSubscription != ServiceSubscription.idServiceSubscription)
                {
                    IdServiceSubscription = ServiceSubscription.idServiceSubscription;
                }
            }
            else if (!_settingFK)
            {
                IdServiceSubscription = null;
            }
        }
    
        private void FixupSmartReports(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SmartReportDto item in e.NewItems)
                {
                    item.ServiceDelivery = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SmartReportDto item in e.OldItems)
                {
                    if (ReferenceEquals(item.ServiceDelivery, this))
                    {
                        item.ServiceDelivery = null;
                    }
                }
            }
        }

        #endregion

    }
}
