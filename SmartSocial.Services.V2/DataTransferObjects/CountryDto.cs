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
    
    [DataContract(Name = "CountryDto", Namespace = "http://www.mavizontech.com/dto/" , IsReference = true) ]
    public partial class CountryDto
    {
         #region Primitive Properties
    	
    	[DataMember]
        public virtual int IdCountry
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string ISO2
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string CountryName
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string LongCountryName
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string ISO3
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string NumCode
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string UNMemberState
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string CallingCode
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string CCTLD
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string FlagImageFilename
        {
            get;
            set;
        }

        #endregion

    }
}
