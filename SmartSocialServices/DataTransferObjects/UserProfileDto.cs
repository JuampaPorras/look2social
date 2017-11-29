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
    
    [DataContract(Name = "UserProfileDto", Namespace = "http://www.SmartSocial.com/dto/" , IsReference = true) ]
    public partial class UserProfileDto
    {
         #region Primitive Properties
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int UserId
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string UserName
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<int> CompanyId
        {
     
    		
            get { return _companyId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_companyId != value)
                    {
                        if (Company != null && Company.IdCompany != value)
                        {
                            Company = null;
                        }
                        _companyId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _companyId;
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<int> LastReportId
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<int> Phone
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string FirstName
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string LastName
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string CountryCode
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<bool> IsActive
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<int> ChargifyCustomerId
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual CompanyDto Company
        {
            get { return _company; }
            set
            {
                if (!ReferenceEquals(_company, value))
                {
                    var previousValue = _company;
                    _company = value;
                    FixupCompany(previousValue);
                }
            }
        }
        private CompanyDto _company;
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual ICollection<SharedReportDto> SharedReports
        {
            get
            {
                if (_sharedReports == null)
                {
                    var newCollection = new FixupCollection<SharedReportDto>();
                    newCollection.CollectionChanged += FixupSharedReports;
                    _sharedReports = newCollection;
                }
                return _sharedReports;
            }
            set
            {
                if (!ReferenceEquals(_sharedReports, value))
                {
                    var previousValue = _sharedReports as FixupCollection<SharedReportDto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSharedReports;
                    }
                    _sharedReports = value;
                    var newValue = value as FixupCollection<SharedReportDto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSharedReports;
                    }
                }
            }
        }
        private ICollection<SharedReportDto> _sharedReports;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupCompany(CompanyDto previousValue)
        {
            if (previousValue != null && previousValue.UserProfiles.Contains(this))
            {
                previousValue.UserProfiles.Remove(this);
            }
    
            if (Company != null)
            {
                if (!Company.UserProfiles.Contains(this))
                {
                    Company.UserProfiles.Add(this);
                }
                if (CompanyId != Company.IdCompany)
                {
                    CompanyId = Company.IdCompany;
                }
            }
            else if (!_settingFK)
            {
                CompanyId = null;
            }
        }
    
        private void FixupSharedReports(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SharedReportDto item in e.NewItems)
                {
                    item.UserProfile = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SharedReportDto item in e.OldItems)
                {
                    if (ReferenceEquals(item.UserProfile, this))
                    {
                        item.UserProfile = null;
                    }
                }
            }
        }

        #endregion

    }
}
