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
    
    [DataContract(Name = "DataTypeDto", Namespace = "http://www.SmartSocial.com/dto/" , IsReference = true) ]
    public partial class DataTypeDto
    {
         #region Primitive Properties
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int idDataType
        {
            get;
            set;
        }
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string DataTypeName
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual ICollection<SeriesValueDto> SeriesValues
        {
            get
            {
                if (_seriesValues == null)
                {
                    var newCollection = new FixupCollection<SeriesValueDto>();
                    newCollection.CollectionChanged += FixupSeriesValues;
                    _seriesValues = newCollection;
                }
                return _seriesValues;
            }
            set
            {
                if (!ReferenceEquals(_seriesValues, value))
                {
                    var previousValue = _seriesValues as FixupCollection<SeriesValueDto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSeriesValues;
                    }
                    _seriesValues = value;
                    var newValue = value as FixupCollection<SeriesValueDto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSeriesValues;
                    }
                }
            }
        }
        private ICollection<SeriesValueDto> _seriesValues;

        #endregion

        #region Association Fixup
    
        private void FixupSeriesValues(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SeriesValueDto item in e.NewItems)
                {
                    item.DataType = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SeriesValueDto item in e.OldItems)
                {
                    if (ReferenceEquals(item.DataType, this))
                    {
                        item.DataType = null;
                    }
                }
            }
        }

        #endregion

    }
}
