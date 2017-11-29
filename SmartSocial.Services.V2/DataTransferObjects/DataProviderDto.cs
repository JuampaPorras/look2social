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
    
    [DataContract(Name = "DataProviderDto", Namespace = "http://www.mavizontech.com/dto/" , IsReference = true) ]
    public partial class DataProviderDto
    {
         #region Primitive Properties
    	
    	[DataMember]
        public virtual int idDataProvider
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual string DataProviderName
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual ICollection<SmartChartDto> SmartCharts
        {
            get
            {
                if (_smartCharts == null)
                {
                    var newCollection = new FixupCollection<SmartChartDto>();
                    newCollection.CollectionChanged += FixupSmartCharts;
                    _smartCharts = newCollection;
                }
                return _smartCharts;
            }
            set
            {
                if (!ReferenceEquals(_smartCharts, value))
                {
                    var previousValue = _smartCharts as FixupCollection<SmartChartDto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSmartCharts;
                    }
                    _smartCharts = value;
                    var newValue = value as FixupCollection<SmartChartDto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSmartCharts;
                    }
                }
            }
        }
        private ICollection<SmartChartDto> _smartCharts;
    
    	[DataMember]
        public virtual ICollection<DataProviderXChartTypeDto> DataProviderXChartTypes
        {
            get
            {
                if (_dataProviderXChartTypes == null)
                {
                    var newCollection = new FixupCollection<DataProviderXChartTypeDto>();
                    newCollection.CollectionChanged += FixupDataProviderXChartTypes;
                    _dataProviderXChartTypes = newCollection;
                }
                return _dataProviderXChartTypes;
            }
            set
            {
                if (!ReferenceEquals(_dataProviderXChartTypes, value))
                {
                    var previousValue = _dataProviderXChartTypes as FixupCollection<DataProviderXChartTypeDto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupDataProviderXChartTypes;
                    }
                    _dataProviderXChartTypes = value;
                    var newValue = value as FixupCollection<DataProviderXChartTypeDto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupDataProviderXChartTypes;
                    }
                }
            }
        }
        private ICollection<DataProviderXChartTypeDto> _dataProviderXChartTypes;

        #endregion

        #region Association Fixup
    
        private void FixupSmartCharts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SmartChartDto item in e.NewItems)
                {
                    item.DataProvider = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SmartChartDto item in e.OldItems)
                {
                    if (ReferenceEquals(item.DataProvider, this))
                    {
                        item.DataProvider = null;
                    }
                }
            }
        }
    
        private void FixupDataProviderXChartTypes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (DataProviderXChartTypeDto item in e.NewItems)
                {
                    item.DataProvider = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DataProviderXChartTypeDto item in e.OldItems)
                {
                    if (ReferenceEquals(item.DataProvider, this))
                    {
                        item.DataProvider = null;
                    }
                }
            }
        }

        #endregion

    }
}