//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartSocial.Data.V2
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataType
    {
        public DataType()
        {
            this.SeriesValues = new HashSet<SeriesValue>();
        }
    
        public int idDataType { get; set; }
        public string DataTypeName { get; set; }
    
        public virtual ICollection<SeriesValue> SeriesValues { get; set; }
    }
}
