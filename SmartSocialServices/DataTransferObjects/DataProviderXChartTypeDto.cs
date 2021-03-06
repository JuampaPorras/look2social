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
    
    [DataContract(Name = "DataProviderXChartTypeDto", Namespace = "http://www.SmartSocial.com/dto/" , IsReference = true) ]
    public partial class DataProviderXChartTypeDto
    {
         #region Primitive Properties
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int idDataProvider
        {
     
    		
            get { return _idDataProvider; }
            set
            {
                if (_idDataProvider != value)
                {
                    if (DataProvider != null && DataProvider.idDataProvider != value)
                    {
                        DataProvider = null;
                    }
                    _idDataProvider = value;
                }
            }
        }
        private int _idDataProvider;
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual int idChartType
        {
     
    		
            get { return _idChartType; }
            set
            {
                if (_idChartType != value)
                {
                    if (ChartType != null && ChartType.idChartType != value)
                    {
                        ChartType = null;
                    }
                    _idChartType = value;
                }
            }
        }
        private int _idChartType;
    	
    	[DataMember(EmitDefaultValue = false)]
        public virtual string FileLoadFunctionName
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual ChartTypeDto ChartType
        {
            get { return _chartType; }
            set
            {
                if (!ReferenceEquals(_chartType, value))
                {
                    var previousValue = _chartType;
                    _chartType = value;
                    FixupChartType(previousValue);
                }
            }
        }
        private ChartTypeDto _chartType;
    
    	[DataMember(EmitDefaultValue = false)]
        public virtual DataProviderDto DataProvider
        {
            get { return _dataProvider; }
            set
            {
                if (!ReferenceEquals(_dataProvider, value))
                {
                    var previousValue = _dataProvider;
                    _dataProvider = value;
                    FixupDataProvider(previousValue);
                }
            }
        }
        private DataProviderDto _dataProvider;

        #endregion

        #region Association Fixup
    
        private void FixupChartType(ChartTypeDto previousValue)
        {
            if (previousValue != null && previousValue.DataProviderXChartTypes.Contains(this))
            {
                previousValue.DataProviderXChartTypes.Remove(this);
            }
    
            if (ChartType != null)
            {
                if (!ChartType.DataProviderXChartTypes.Contains(this))
                {
                    ChartType.DataProviderXChartTypes.Add(this);
                }
                if (idChartType != ChartType.idChartType)
                {
                    idChartType = ChartType.idChartType;
                }
            }
        }
    
        private void FixupDataProvider(DataProviderDto previousValue)
        {
            if (previousValue != null && previousValue.DataProviderXChartTypes.Contains(this))
            {
                previousValue.DataProviderXChartTypes.Remove(this);
            }
    
            if (DataProvider != null)
            {
                if (!DataProvider.DataProviderXChartTypes.Contains(this))
                {
                    DataProvider.DataProviderXChartTypes.Add(this);
                }
                if (idDataProvider != DataProvider.idDataProvider)
                {
                    idDataProvider = DataProvider.idDataProvider;
                }
            }
        }

        #endregion

    }
}
