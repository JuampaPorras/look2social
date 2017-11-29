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
    /// The class representing the dbo.ChartSeries table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.ChartSeries")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.ChartSeries.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdChartSeries")]
    [System.Diagnostics.DebuggerDisplay("IdChartSeries: {IdChartSeries}")]
    public partial class ChartSeries
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="ChartSeries"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static ChartSeries()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartSeries"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public ChartSeries()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _smartChart = default(System.Data.Linq.EntityRef<SmartChart>);
            _seriesValueList = new System.Data.Linq.EntitySet<SeriesValue>(OnSeriesValueListAdd, OnSeriesValueListRemove);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idChartSeries = default(int);

        /// <summary>
        /// Gets the idChartSeries column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idChartSeries", Storage = "_idChartSeries", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdChartSeries
        {
            get { return _idChartSeries; }
            set
            {
                if (_idChartSeries != value)
                {
                    OnIdChartSeriesChanging(value);
                    SendPropertyChanging("IdChartSeries");
                    _idChartSeries = value;
                    SendPropertyChanged("IdChartSeries");
                    OnIdChartSeriesChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<int> _idSmartChart;

        /// <summary>
        /// Gets or sets the idSmartChart column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idSmartChart", Storage = "_idSmartChart", DbType = "int")]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<int> IdSmartChart
        {
            get { return _idSmartChart; }
            set
            {
                if (_idSmartChart != value)
                {
                    if (_smartChart.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnIdSmartChartChanging(value);
                    SendPropertyChanging("IdSmartChart");
                    _idSmartChart = value;
                    SendPropertyChanged("IdSmartChart");
                    OnIdSmartChartChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _seriesName;

        /// <summary>
        /// Gets or sets the SeriesName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "SeriesName", Storage = "_seriesName", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string SeriesName
        {
            get { return _seriesName; }
            set
            {
                if (_seriesName != value)
                {
                    OnSeriesNameChanging(value);
                    SendPropertyChanging("SeriesName");
                    _seriesName = value;
                    SendPropertyChanged("SeriesName");
                    OnSeriesNameChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntityRef<SmartChart> _smartChart;

        /// <summary>
        /// Gets or sets the <see cref="SmartChart"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "SmartChart_ChartSeries", Storage = "_smartChart", ThisKey = "IdSmartChart", OtherKey = "IdSmartChart", IsForeignKey = true, DeleteRule = "CASCADE")]
        [System.Runtime.Serialization.DataMember(Order = 4, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public SmartChart SmartChart
        {
            get { return (serializing && !_smartChart.HasLoadedOrAssignedValue) ? null : _smartChart.Entity; }
            set
            {
                SmartChart previousValue = _smartChart.Entity;
                if (previousValue != value || _smartChart.HasLoadedOrAssignedValue == false)
                {
                    OnSmartChartChanging(value);
                    SendPropertyChanging("SmartChart");
                    if (previousValue != null)
                    {
                        _smartChart.Entity = null;
                        previousValue.ChartSeriesList.Remove(this);
                    }
                    _smartChart.Entity = value;
                    if (value != null)
                    {
                        value.ChartSeriesList.Add(this);
                        _idSmartChart = value.IdSmartChart;
                    }
                    else
                    {
                        _idSmartChart = default(Nullable<int>);
                    }
                    SendPropertyChanged("SmartChart");
                    OnSmartChartChanged();
                }
            }
        }
        
        
        

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntitySet<SeriesValue> _seriesValueList;

        /// <summary>
        /// Gets or sets the <see cref="SeriesValue"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "ChartSeries_SeriesValue", Storage = "_seriesValueList", ThisKey = "IdChartSeries", OtherKey = "IdChartSeries")]
        [System.Runtime.Serialization.DataMember(Order=5, EmitDefaultValue=false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.Data.Linq.EntitySet<SeriesValue> SeriesValueList
        {
            get { return (serializing && !_seriesValueList.HasLoadedOrAssignedValues) ? null : _seriesValueList; }
            set { _seriesValueList.Assign(value); }
        }
        
        

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnSeriesValueListAdd(SeriesValue entity)
        {
            SendPropertyChanging(null);
            entity.ChartSeries = this;
            SendPropertyChanged(null);
        }

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnSeriesValueListRemove(SeriesValue entity)
        {
            SendPropertyChanging(null);
            entity.ChartSeries = null;
            SendPropertyChanged(null);
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
        /// <summary>Called when <see cref="IdChartSeries"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChartSeriesChanging(int value);
        /// <summary>Called after <see cref="IdChartSeries"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChartSeriesChanged();
        /// <summary>Called when <see cref="IdSmartChart"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSmartChartChanging(Nullable<int> value);
        /// <summary>Called after <see cref="IdSmartChart"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSmartChartChanged();
        /// <summary>Called when <see cref="SeriesName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSeriesNameChanging(string value);
        /// <summary>Called after <see cref="SeriesName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSeriesNameChanged();
        /// <summary>Called when <see cref="SmartChart"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSmartChartChanging(SmartChart value);
        /// <summary>Called after <see cref="SmartChart"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSmartChartChanged();

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
        /// Deserializes an instance of <see cref="ChartSeries"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="ChartSeries"/> instance.</param>
        /// <returns>An instance of <see cref="ChartSeries"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static ChartSeries FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ChartSeries));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as ChartSeries;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="ChartSeries"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="ChartSeries"/> instance.</param>
        /// <returns>An instance of <see cref="ChartSeries"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static ChartSeries FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ChartSeries));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as ChartSeries;
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
        public ChartSeries Clone()
        {
            return (ChartSeries)((ICloneable)this).Clone();
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
            _smartChart = Detach(_smartChart);
            _seriesValueList = Detach(_seriesValueList, OnSeriesValueListAdd, OnSeriesValueListRemove);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414