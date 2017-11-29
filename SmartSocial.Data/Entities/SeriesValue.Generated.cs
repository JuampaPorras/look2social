﻿#pragma warning disable 1591
#pragma warning disable 0414        
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Linq;

namespace SmartSocial.Data
{
    /// <summary>
    /// The class representing the dbo.SeriesValue table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.SeriesValue")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.SeriesValue.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdSeriesValue")]
    [System.Diagnostics.DebuggerDisplay("IdSeriesValue: {IdSeriesValue}")]
    public partial class SeriesValue
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="SeriesValue"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static SeriesValue()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesValue"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public SeriesValue()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _chartSeries = default(System.Data.Linq.EntityRef<ChartSeries>);
            _dataType = default(System.Data.Linq.EntityRef<DataType>);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idSeriesValue = default(int);

        /// <summary>
        /// Gets the idSeriesValue column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idSeriesValue", Storage = "_idSeriesValue", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdSeriesValue
        {
            get { return _idSeriesValue; }
            set
            {
                if (_idSeriesValue != value)
                {
                    OnIdSeriesValueChanging(value);
                    SendPropertyChanging("IdSeriesValue");
                    _idSeriesValue = value;
                    SendPropertyChanged("IdSeriesValue");
                    OnIdSeriesValueChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<int> _idChartSeries;

        /// <summary>
        /// Gets or sets the idChartSeries column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idChartSeries", Storage = "_idChartSeries", DbType = "int")]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<int> IdChartSeries
        {
            get { return _idChartSeries; }
            set
            {
                if (_idChartSeries != value)
                {
                    if (_chartSeries.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnIdChartSeriesChanging(value);
                    SendPropertyChanging("IdChartSeries");
                    _idChartSeries = value;
                    SendPropertyChanged("IdChartSeries");
                    OnIdChartSeriesChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<int> _idDataType;

        /// <summary>
        /// Gets or sets the idDataType column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idDataType", Storage = "_idDataType", DbType = "int")]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<int> IdDataType
        {
            get { return _idDataType; }
            set
            {
                if (_idDataType != value)
                {
                    if (_dataType.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnIdDataTypeChanging(value);
                    SendPropertyChanging("IdDataType");
                    _idDataType = value;
                    SendPropertyChanged("IdDataType");
                    OnIdDataTypeChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _value;

        /// <summary>
        /// Gets or sets the Value column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Value", Storage = "_value", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    OnValueChanging(value);
                    SendPropertyChanging("Value");
                    _value = value;
                    SendPropertyChanged("Value");
                    OnValueChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<int> _rowPosition;

        /// <summary>
        /// Gets or sets the RowPosition column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "RowPosition", Storage = "_rowPosition", DbType = "int")]
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<int> RowPosition
        {
            get { return _rowPosition; }
            set
            {
                if (_rowPosition != value)
                {
                    OnRowPositionChanging(value);
                    SendPropertyChanging("RowPosition");
                    _rowPosition = value;
                    SendPropertyChanged("RowPosition");
                    OnRowPositionChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntityRef<ChartSeries> _chartSeries;

        /// <summary>
        /// Gets or sets the <see cref="ChartSeries"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "ChartSeries_SeriesValue", Storage = "_chartSeries", ThisKey = "IdChartSeries", OtherKey = "IdChartSeries", IsForeignKey = true, DeleteRule = "CASCADE")]
        [System.Runtime.Serialization.DataMember(Order = 6, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public ChartSeries ChartSeries
        {
            get { return (serializing && !_chartSeries.HasLoadedOrAssignedValue) ? null : _chartSeries.Entity; }
            set
            {
                ChartSeries previousValue = _chartSeries.Entity;
                if (previousValue != value || _chartSeries.HasLoadedOrAssignedValue == false)
                {
                    OnChartSeriesChanging(value);
                    SendPropertyChanging("ChartSeries");
                    if (previousValue != null)
                    {
                        _chartSeries.Entity = null;
                        previousValue.SeriesValueList.Remove(this);
                    }
                    _chartSeries.Entity = value;
                    if (value != null)
                    {
                        value.SeriesValueList.Add(this);
                        _idChartSeries = value.IdChartSeries;
                    }
                    else
                    {
                        _idChartSeries = default(Nullable<int>);
                    }
                    SendPropertyChanged("ChartSeries");
                    OnChartSeriesChanged();
                }
            }
        }
        
        
        

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntityRef<DataType> _dataType;

        /// <summary>
        /// Gets or sets the <see cref="DataType"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "DataType_SeriesValue", Storage = "_dataType", ThisKey = "IdDataType", OtherKey = "IdDataType", IsForeignKey = true)]
        [System.Runtime.Serialization.DataMember(Order = 7, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public DataType DataType
        {
            get { return (serializing && !_dataType.HasLoadedOrAssignedValue) ? null : _dataType.Entity; }
            set
            {
                DataType previousValue = _dataType.Entity;
                if (previousValue != value || _dataType.HasLoadedOrAssignedValue == false)
                {
                    OnDataTypeChanging(value);
                    SendPropertyChanging("DataType");
                    if (previousValue != null)
                    {
                        _dataType.Entity = null;
                        previousValue.SeriesValueList.Remove(this);
                    }
                    _dataType.Entity = value;
                    if (value != null)
                    {
                        value.SeriesValueList.Add(this);
                        _idDataType = value.IdDataType;
                    }
                    else
                    {
                        _idDataType = default(Nullable<int>);
                    }
                    SendPropertyChanged("DataType");
                    OnDataTypeChanged();
                }
            }
        }
        
        
        
        #endregion

        #region Extensibility Method Definitions
        /// <summary>Called by the static constructor to add shared rules.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static partial void AddSharedRules();
        /// <summary>Called when this instance is loaded.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCreated();
        /// <summary>Called when <see cref="IdSeriesValue"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSeriesValueChanging(int value);
        /// <summary>Called after <see cref="IdSeriesValue"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSeriesValueChanged();
        /// <summary>Called when <see cref="IdChartSeries"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChartSeriesChanging(Nullable<int> value);
        /// <summary>Called after <see cref="IdChartSeries"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChartSeriesChanged();
        /// <summary>Called when <see cref="IdDataType"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdDataTypeChanging(Nullable<int> value);
        /// <summary>Called after <see cref="IdDataType"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdDataTypeChanged();
        /// <summary>Called when <see cref="Value"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnValueChanging(string value);
        /// <summary>Called after <see cref="Value"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnValueChanged();
        /// <summary>Called when <see cref="RowPosition"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnRowPositionChanging(Nullable<int> value);
        /// <summary>Called after <see cref="RowPosition"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnRowPositionChanged();
        /// <summary>Called when <see cref="ChartSeries"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnChartSeriesChanging(ChartSeries value);
        /// <summary>Called after <see cref="ChartSeries"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnChartSeriesChanged();
        /// <summary>Called when <see cref="DataType"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDataTypeChanging(DataType value);
        /// <summary>Called after <see cref="DataType"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDataTypeChanged();

        #endregion

        #region Serialization
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private bool serializing;

        /// <summary>
        /// Called when serializing.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        [System.Runtime.Serialization.OnSerializing]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public void OnSerializing(System.Runtime.Serialization.StreamingContext context) {
            serializing = true;
        }

        /// <summary>
        /// Called when serialized.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        [System.Runtime.Serialization.OnSerialized]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public void OnSerialized(System.Runtime.Serialization.StreamingContext context) {
            serializing = false;
        }

        /// <summary>
        /// Called when deserializing.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        [System.Runtime.Serialization.OnDeserializing]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public void OnDeserializing(System.Runtime.Serialization.StreamingContext context) {
            Initialize();
        }

        /// <summary>
        /// Deserializes an instance of <see cref="SeriesValue"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="SeriesValue"/> instance.</param>
        /// <returns>An instance of <see cref="SeriesValue"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SeriesValue FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SeriesValue));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as SeriesValue;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="SeriesValue"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="SeriesValue"/> instance.</param>
        /// <returns>An instance of <see cref="SeriesValue"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SeriesValue FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SeriesValue));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as SeriesValue;
            }
        }
        
        #endregion

        #region Clone
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        object ICloneable.Clone()
        {
            var serializer = new System.Runtime.Serialization.DataContractSerializer(GetType());
            using (var ms = new System.IO.MemoryStream())
            {
                serializer.WriteObject(ms, this);
                ms.Position = 0;
                return serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <remarks>
        /// Only loaded <see cref="T:System.Data.Linq.EntityRef`1"/> and <see cref="T:System.Data.Linq.EntitySet`1" /> child accessions will be cloned.
        /// </remarks>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public SeriesValue Clone()
        {
            return (SeriesValue)((ICloneable)this).Clone();
        }
        #endregion

        #region Detach Methods
        /// <summary>
        /// Detach this instance from the <see cref="System.Data.Linq.DataContext"/>.
        /// </summary>
        /// <remarks>
        /// Detaching the entity will stop all lazy loading and allow it to be added to another <see cref="System.Data.Linq.DataContext"/>.
        /// </remarks>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public override void Detach()
        {
            if (!IsAttached())
                return;

            base.Detach();
            _chartSeries = Detach(_chartSeries);
            _dataType = Detach(_dataType);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
