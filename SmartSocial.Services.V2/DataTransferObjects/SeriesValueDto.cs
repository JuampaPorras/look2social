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
    
    [DataContract(Name = "SeriesValueDto", Namespace = "http://www.mavizontech.com/dto/" , IsReference = true) ]
    public partial class SeriesValueDto
    {
         #region Primitive Properties
    	
    	[DataMember]
        public virtual int idSeriesValue
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual Nullable<int> idChartSeries
        {
     
    		
            get { return _idChartSeries; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_idChartSeries != value)
                    {
                        if (ChartSery != null && ChartSery.idChartSeries != value)
                        {
                            ChartSery = null;
                        }
                        _idChartSeries = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _idChartSeries;
    	
    	[DataMember]
        public virtual Nullable<int> idDataType
        {
     
    		
            get { return _idDataType; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_idDataType != value)
                    {
                        if (DataType != null && DataType.idDataType != value)
                        {
                            DataType = null;
                        }
                        _idDataType = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _idDataType;
    	
    	[DataMember]
        public virtual string Value
        {
            get;
            set;
        }
    	
    	[DataMember]
        public virtual Nullable<int> RowPosition
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	[DataMember]
        public virtual DataTypeDto DataType
        {
            get { return _dataType; }
            set
            {
                if (!ReferenceEquals(_dataType, value))
                {
                    var previousValue = _dataType;
                    _dataType = value;
                    FixupDataType(previousValue);
                }
            }
        }
        private DataTypeDto _dataType;
    
    	[DataMember]
        public virtual ChartSeryDto ChartSery
        {
            get { return _chartSery; }
            set
            {
                if (!ReferenceEquals(_chartSery, value))
                {
                    var previousValue = _chartSery;
                    _chartSery = value;
                    FixupChartSery(previousValue);
                }
            }
        }
        private ChartSeryDto _chartSery;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupDataType(DataTypeDto previousValue)
        {
            if (previousValue != null && previousValue.SeriesValues.Contains(this))
            {
                previousValue.SeriesValues.Remove(this);
            }
    
            if (DataType != null)
            {
                if (!DataType.SeriesValues.Contains(this))
                {
                    DataType.SeriesValues.Add(this);
                }
                if (idDataType != DataType.idDataType)
                {
                    idDataType = DataType.idDataType;
                }
            }
            else if (!_settingFK)
            {
                idDataType = null;
            }
        }
    
        private void FixupChartSery(ChartSeryDto previousValue)
        {
            if (previousValue != null && previousValue.SeriesValues.Contains(this))
            {
                previousValue.SeriesValues.Remove(this);
            }
    
            if (ChartSery != null)
            {
                if (!ChartSery.SeriesValues.Contains(this))
                {
                    ChartSery.SeriesValues.Add(this);
                }
                if (idChartSeries != ChartSery.idChartSeries)
                {
                    idChartSeries = ChartSery.idChartSeries;
                }
            }
            else if (!_settingFK)
            {
                idChartSeries = null;
            }
        }

        #endregion

    }
}
