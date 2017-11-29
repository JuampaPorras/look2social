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

namespace SmartSocial.Services.V2.DataTransferObjects
{
    
    [DataContract(Name = "AspNetRoleDto", Namespace = "http://www.mavizontech.com/dto/" , IsReference = true) ]
    public partial class AspNetRoleDto
    {
         #region Primitive Properties
    	
    	[DataMember]
        public virtual string Id
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string Name
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual ICollection<AspNetUserDto> AspNetUsers
        {
            get
            {
                if (_aspNetUsers == null)
                {
                    var newCollection = new FixupCollection<AspNetUserDto>();
                    newCollection.CollectionChanged += FixupAspNetUsers;
                    _aspNetUsers = newCollection;
                }
                return _aspNetUsers;
            }
            set
            {
                if (!ReferenceEquals(_aspNetUsers, value))
                {
                    var previousValue = _aspNetUsers as FixupCollection<AspNetUserDto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAspNetUsers;
                    }
                    _aspNetUsers = value;
                    var newValue = value as FixupCollection<AspNetUserDto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAspNetUsers;
                    }
                }
            }
        }
        private ICollection<AspNetUserDto> _aspNetUsers;

        #endregion

        #region Association Fixup
    
        private void FixupAspNetUsers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (AspNetUserDto item in e.NewItems)
                {
                    if (!item.AspNetRoles.Contains(this))
                    {
                        item.AspNetRoles.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (AspNetUserDto item in e.OldItems)
                {
                    if (item.AspNetRoles.Contains(this))
                    {
                        item.AspNetRoles.Remove(this);
                    }
                }
            }
        }

        #endregion

    }
}