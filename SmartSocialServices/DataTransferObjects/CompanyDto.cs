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
    
    [DataContract(Name = "CompanyDto", Namespace = "http://www.SmartSocial.com/dto/" , IsReference = true) ]
    public partial class CompanyDto
    {
         #region Primitive Properties
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int IdCompany
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string CompanyName
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string LogoFileName
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual ICollection<UserProfileDto> UserProfiles
        {
            get
            {
                if (_userProfiles == null)
                {
                    var newCollection = new FixupCollection<UserProfileDto>();
                    newCollection.CollectionChanged += FixupUserProfiles;
                    _userProfiles = newCollection;
                }
                return _userProfiles;
            }
            set
            {
                if (!ReferenceEquals(_userProfiles, value))
                {
                    var previousValue = _userProfiles as FixupCollection<UserProfileDto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUserProfiles;
                    }
                    _userProfiles = value;
                    var newValue = value as FixupCollection<UserProfileDto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUserProfiles;
                    }
                }
            }
        }
        private ICollection<UserProfileDto> _userProfiles;

        #endregion

        #region Association Fixup
    
        private void FixupUserProfiles(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserProfileDto item in e.NewItems)
                {
                    item.Company = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserProfileDto item in e.OldItems)
                {
                    if (ReferenceEquals(item.Company, this))
                    {
                        item.Company = null;
                    }
                }
            }
        }

        #endregion

    }
}