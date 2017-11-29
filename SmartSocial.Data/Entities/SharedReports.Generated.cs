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
    /// The class representing the dbo.SharedReports table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.SharedReports")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.SharedReports.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdSharedReports")]
    [System.Diagnostics.DebuggerDisplay("IdSharedReports: {IdSharedReports}")]
    public partial class SharedReports
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="SharedReports"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static SharedReports()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SharedReports"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public SharedReports()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _smartReport = default(System.Data.Linq.EntityRef<SmartReport>);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idSharedReports = default(int);

        /// <summary>
        /// Gets the IdSharedReports column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IdSharedReports", Storage = "_idSharedReports", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdSharedReports
        {
            get { return _idSharedReports; }
            set
            {
                if (_idSharedReports != value)
                {
                    OnIdSharedReportsChanging(value);
                    SendPropertyChanging("IdSharedReports");
                    _idSharedReports = value;
                    SendPropertyChanged("IdSharedReports");
                    OnIdSharedReportsChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _createdBy;

        /// <summary>
        /// Gets or sets the CreatedBy column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "CreatedBy", Storage = "_createdBy", DbType = "int NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int CreatedBy
        {
            get { return _createdBy; }
            set
            {
                if (_createdBy != value)
                {
                    OnCreatedByChanging(value);
                    SendPropertyChanging("CreatedBy");
                    _createdBy = value;
                    SendPropertyChanged("CreatedBy");
                    OnCreatedByChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _smartReportId;

        /// <summary>
        /// Gets or sets the SmartReportId column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "SmartReportId", Storage = "_smartReportId", DbType = "int NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int SmartReportId
        {
            get { return _smartReportId; }
            set
            {
                if (_smartReportId != value)
                {
                    if (_smartReport.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnSmartReportIdChanging(value);
                    SendPropertyChanging("SmartReportId");
                    _smartReportId = value;
                    SendPropertyChanged("SmartReportId");
                    OnSmartReportIdChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<int> _sharedWith;

        /// <summary>
        /// Gets or sets the SharedWith column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "SharedWith", Storage = "_sharedWith", DbType = "int")]
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<int> SharedWith
        {
            get { return _sharedWith; }
            set
            {
                if (_sharedWith != value)
                {
                    OnSharedWithChanging(value);
                    SendPropertyChanging("SharedWith");
                    _sharedWith = value;
                    SendPropertyChanged("SharedWith");
                    OnSharedWithChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _url;

        /// <summary>
        /// Gets or sets the URL column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "URL", Storage = "_url", DbType = "varchar(200)")]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    OnUrlChanging(value);
                    SendPropertyChanging("Url");
                    _url = value;
                    SendPropertyChanged("Url");
                    OnUrlChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _tinyUrl;

        /// <summary>
        /// Gets or sets the TinyUrl column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "TinyUrl", Storage = "_tinyUrl", DbType = "varchar(100)")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string TinyUrl
        {
            get { return _tinyUrl; }
            set
            {
                if (_tinyUrl != value)
                {
                    OnTinyUrlChanging(value);
                    SendPropertyChanging("TinyUrl");
                    _tinyUrl = value;
                    SendPropertyChanged("TinyUrl");
                    OnTinyUrlChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _comments;

        /// <summary>
        /// Gets or sets the Comments column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Comments", Storage = "_comments", DbType = "varchar(250)")]
        [System.ComponentModel.DataAnnotations.StringLength(250)]
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    OnCommentsChanging(value);
                    SendPropertyChanging("Comments");
                    _comments = value;
                    SendPropertyChanged("Comments");
                    OnCommentsChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _token;

        /// <summary>
        /// Gets or sets the Token column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Token", Storage = "_token", DbType = "varchar(50)")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Token
        {
            get { return _token; }
            set
            {
                if (_token != value)
                {
                    OnTokenChanging(value);
                    SendPropertyChanging("Token");
                    _token = value;
                    SendPropertyChanged("Token");
                    OnTokenChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime _createdDate;

        /// <summary>
        /// Gets or sets the CreatedDate column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "CreatedDate", Storage = "_createdDate", DbType = "datetime NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 9)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                if (_createdDate != value)
                {
                    OnCreatedDateChanging(value);
                    SendPropertyChanging("CreatedDate");
                    _createdDate = value;
                    SendPropertyChanged("CreatedDate");
                    OnCreatedDateChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime _expiredDate;

        /// <summary>
        /// Gets or sets the ExpiredDate column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "ExpiredDate", Storage = "_expiredDate", DbType = "datetime NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 10)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.DateTime ExpiredDate
        {
            get { return _expiredDate; }
            set
            {
                if (_expiredDate != value)
                {
                    OnExpiredDateChanging(value);
                    SendPropertyChanging("ExpiredDate");
                    _expiredDate = value;
                    SendPropertyChanged("ExpiredDate");
                    OnExpiredDateChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private bool _isActive;

        /// <summary>
        /// Gets or sets the IsActive column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IsActive", Storage = "_isActive", DbType = "bit NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 11)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    OnIsActiveChanging(value);
                    SendPropertyChanging("IsActive");
                    _isActive = value;
                    SendPropertyChanged("IsActive");
                    OnIsActiveChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntityRef<SmartReport> _smartReport;

        /// <summary>
        /// Gets or sets the <see cref="SmartReport"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "SmartReport_SharedReports", Storage = "_smartReport", ThisKey = "SmartReportId", OtherKey = "IdSmartReport", IsForeignKey = true)]
        [System.Runtime.Serialization.DataMember(Order = 12, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public SmartReport SmartReport
        {
            get { return (serializing && !_smartReport.HasLoadedOrAssignedValue) ? null : _smartReport.Entity; }
            set
            {
                SmartReport previousValue = _smartReport.Entity;
                if (previousValue != value || _smartReport.HasLoadedOrAssignedValue == false)
                {
                    OnSmartReportChanging(value);
                    SendPropertyChanging("SmartReport");
                    if (previousValue != null)
                    {
                        _smartReport.Entity = null;
                        previousValue.SharedReportsList.Remove(this);
                    }
                    _smartReport.Entity = value;
                    if (value != null)
                    {
                        value.SharedReportsList.Add(this);
                        _smartReportId = value.IdSmartReport;
                    }
                    else
                    {
                        _smartReportId = default(int);
                    }
                    SendPropertyChanged("SmartReport");
                    OnSmartReportChanged();
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
        /// <summary>Called when <see cref="IdSharedReports"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSharedReportsChanging(int value);
        /// <summary>Called after <see cref="IdSharedReports"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSharedReportsChanged();
        /// <summary>Called when <see cref="CreatedBy"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCreatedByChanging(int value);
        /// <summary>Called after <see cref="CreatedBy"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCreatedByChanged();
        /// <summary>Called when <see cref="SmartReportId"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSmartReportIdChanging(int value);
        /// <summary>Called after <see cref="SmartReportId"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSmartReportIdChanged();
        /// <summary>Called when <see cref="SharedWith"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSharedWithChanging(Nullable<int> value);
        /// <summary>Called after <see cref="SharedWith"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSharedWithChanged();
        /// <summary>Called when <see cref="Url"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnUrlChanging(string value);
        /// <summary>Called after <see cref="Url"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnUrlChanged();
        /// <summary>Called when <see cref="TinyUrl"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTinyUrlChanging(string value);
        /// <summary>Called after <see cref="TinyUrl"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTinyUrlChanged();
        /// <summary>Called when <see cref="Comments"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCommentsChanging(string value);
        /// <summary>Called after <see cref="Comments"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCommentsChanged();
        /// <summary>Called when <see cref="Token"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTokenChanging(string value);
        /// <summary>Called after <see cref="Token"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTokenChanged();
        /// <summary>Called when <see cref="CreatedDate"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCreatedDateChanging(System.DateTime value);
        /// <summary>Called after <see cref="CreatedDate"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCreatedDateChanged();
        /// <summary>Called when <see cref="ExpiredDate"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnExpiredDateChanging(System.DateTime value);
        /// <summary>Called after <see cref="ExpiredDate"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnExpiredDateChanged();
        /// <summary>Called when <see cref="IsActive"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsActiveChanging(bool value);
        /// <summary>Called after <see cref="IsActive"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsActiveChanged();
        /// <summary>Called when <see cref="SmartReport"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSmartReportChanging(SmartReport value);
        /// <summary>Called after <see cref="SmartReport"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSmartReportChanged();

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
        /// Deserializes an instance of <see cref="SharedReports"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="SharedReports"/> instance.</param>
        /// <returns>An instance of <see cref="SharedReports"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SharedReports FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SharedReports));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as SharedReports;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="SharedReports"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="SharedReports"/> instance.</param>
        /// <returns>An instance of <see cref="SharedReports"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SharedReports FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SharedReports));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as SharedReports;
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
        public SharedReports Clone()
        {
            return (SharedReports)((ICloneable)this).Clone();
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
            _smartReport = Detach(_smartReport);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
