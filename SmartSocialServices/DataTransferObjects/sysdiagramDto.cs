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
    
    [DataContract(Name = "sysdiagramDto", Namespace = "http://www.SmartSocial.com/dto/" , IsReference = true) ]
    public partial class sysdiagramDto
    {
         #region Primitive Properties
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string name
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int principal_id
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int diagram_id
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual Nullable<int> version
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual byte[] definition
        {
            get;
            set;
        }

        #endregion

    }
}
