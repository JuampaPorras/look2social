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
    /// The class representing the dbo.DataProviderXChartType table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.DataProviderXChartType")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.DataProviderXChartType.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdDataProvider", "IdChartType")]
    [System.Diagnostics.DebuggerDisplay("IdDataProvider: {IdDataProvider}, IdChartType: {IdChartType}")]
    public partial class DataProviderXChartType
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="DataProviderXChartType"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static DataProviderXChartType()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DataProviderXChartType"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public DataProviderXChartType()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _chartType = default(System.Data.Linq.EntityRef<ChartType>);
            _dataProvider = default(System.Data.Linq.EntityRef<DataProvider>);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idDataProvider;

        /// <summary>
        /// Gets or sets the idDataProvider column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idDataProvider", Storage = "_idDataProvider", DbType = "int NOT NULL", IsPrimaryKey = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdDataProvider
        {
            get { return _idDataProvider; }
            set
            {
                if (_idDataProvider != value)
                {
                    if (_dataProvider.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnIdDataProviderChanging(value);
                    SendPropertyChanging("IdDataProvider");
                    _idDataProvider = value;
                    SendPropertyChanged("IdDataProvider");
                    OnIdDataProviderChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idChartType;

        /// <summary>
        /// Gets or sets the idChartType column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idChartType", Storage = "_idChartType", DbType = "int NOT NULL", IsPrimaryKey = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdChartType
        {
            get { return _idChartType; }
            set
            {
                if (_idChartType != value)
                {
                    if (_chartType.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnIdChartTypeChanging(value);
                    SendPropertyChanging("IdChartType");
                    _idChartType = value;
                    SendPropertyChanged("IdChartType");
                    OnIdChartTypeChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _fileLoadFunctionName;

        /// <summary>
        /// Gets or sets the FileLoadFunctionName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "FileLoadFunctionName", Storage = "_fileLoadFunctionName", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string FileLoadFunctionName
        {
            get { return _fileLoadFunctionName; }
            set
            {
                if (_fileLoadFunctionName != value)
                {
                    OnFileLoadFunctionNameChanging(value);
                    SendPropertyChanging("FileLoadFunctionName");
                    _fileLoadFunctionName = value;
                    SendPropertyChanged("FileLoadFunctionName");
                    OnFileLoadFunctionNameChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntityRef<ChartType> _chartType;

        /// <summary>
        /// Gets or sets the <see cref="ChartType"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "ChartType_DataProviderXChartType", Storage = "_chartType", ThisKey = "IdChartType", OtherKey = "IdChartType", IsForeignKey = true)]
        [System.Runtime.Serialization.DataMember(Order = 4, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public ChartType ChartType
        {
            get { return (serializing && !_chartType.HasLoadedOrAssignedValue) ? null : _chartType.Entity; }
            set
            {
                ChartType previousValue = _chartType.Entity;
                if (previousValue != value || _chartType.HasLoadedOrAssignedValue == false)
                {
                    OnChartTypeChanging(value);
                    SendPropertyChanging("ChartType");
                    if (previousValue != null)
                    {
                        _chartType.Entity = null;
                        previousValue.DataProviderXChartTypeList.Remove(this);
                    }
                    _chartType.Entity = value;
                    if (value != null)
                    {
                        value.DataProviderXChartTypeList.Add(this);
                        _idChartType = value.IdChartType;
                    }
                    else
                    {
                        _idChartType = default(int);
                    }
                    SendPropertyChanged("ChartType");
                    OnChartTypeChanged();
                }
            }
        }
        
        
        

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntityRef<DataProvider> _dataProvider;

        /// <summary>
        /// Gets or sets the <see cref="DataProvider"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "DataProvider_DataProviderXChartType", Storage = "_dataProvider", ThisKey = "IdDataProvider", OtherKey = "IdDataProvider", IsForeignKey = true)]
        [System.Runtime.Serialization.DataMember(Order = 5, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public DataProvider DataProvider
        {
            get { return (serializing && !_dataProvider.HasLoadedOrAssignedValue) ? null : _dataProvider.Entity; }
            set
            {
                DataProvider previousValue = _dataProvider.Entity;
                if (previousValue != value || _dataProvider.HasLoadedOrAssignedValue == false)
                {
                    OnDataProviderChanging(value);
                    SendPropertyChanging("DataProvider");
                    if (previousValue != null)
                    {
                        _dataProvider.Entity = null;
                        previousValue.DataProviderXChartTypeList.Remove(this);
                    }
                    _dataProvider.Entity = value;
                    if (value != null)
                    {
                        value.DataProviderXChartTypeList.Add(this);
                        _idDataProvider = value.IdDataProvider;
                    }
                    else
                    {
                        _idDataProvider = default(int);
                    }
                    SendPropertyChanged("DataProvider");
                    OnDataProviderChanged();
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
        /// <summary>Called when <see cref="IdDataProvider"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdDataProviderChanging(int value);
        /// <summary>Called after <see cref="IdDataProvider"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdDataProviderChanged();
        /// <summary>Called when <see cref="IdChartType"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChartTypeChanging(int value);
        /// <summary>Called after <see cref="IdChartType"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChartTypeChanged();
        /// <summary>Called when <see cref="FileLoadFunctionName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnFileLoadFunctionNameChanging(string value);
        /// <summary>Called after <see cref="FileLoadFunctionName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnFileLoadFunctionNameChanged();
        /// <summary>Called when <see cref="ChartType"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnChartTypeChanging(ChartType value);
        /// <summary>Called after <see cref="ChartType"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnChartTypeChanged();
        /// <summary>Called when <see cref="DataProvider"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDataProviderChanging(DataProvider value);
        /// <summary>Called after <see cref="DataProvider"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDataProviderChanged();

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
        /// Deserializes an instance of <see cref="DataProviderXChartType"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="DataProviderXChartType"/> instance.</param>
        /// <returns>An instance of <see cref="DataProviderXChartType"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static DataProviderXChartType FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(DataProviderXChartType));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as DataProviderXChartType;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="DataProviderXChartType"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="DataProviderXChartType"/> instance.</param>
        /// <returns>An instance of <see cref="DataProviderXChartType"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static DataProviderXChartType FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(DataProviderXChartType));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as DataProviderXChartType;
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
        public DataProviderXChartType Clone()
        {
            return (DataProviderXChartType)((ICloneable)this).Clone();
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
            _chartType = Detach(_chartType);
            _dataProvider = Detach(_dataProvider);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
