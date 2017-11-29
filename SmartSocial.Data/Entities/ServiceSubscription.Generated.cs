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
    /// The class representing the dbo.ServiceSubscription table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.ServiceSubscription")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.ServiceSubscription.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdServiceSubscription")]
    [System.Diagnostics.DebuggerDisplay("IdServiceSubscription: {IdServiceSubscription}")]
    public partial class ServiceSubscription
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="ServiceSubscription"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static ServiceSubscription()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSubscription"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public ServiceSubscription()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _serviceDeliveryList = new System.Data.Linq.EntitySet<ServiceDelivery>(OnServiceDeliveryListAdd, OnServiceDeliveryListRemove);
            _idSubscriptionUsersXSubscriptionList = new System.Data.Linq.EntitySet<UsersXSubscription>(OnIdSubscriptionUsersXSubscriptionListAdd, OnIdSubscriptionUsersXSubscriptionListRemove);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idServiceSubscription = default(int);

        /// <summary>
        /// Gets the idServiceSubscription column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idServiceSubscription", Storage = "_idServiceSubscription", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdServiceSubscription
        {
            get { return _idServiceSubscription; }
            set
            {
                if (_idServiceSubscription != value)
                {
                    OnIdServiceSubscriptionChanging(value);
                    SendPropertyChanging("IdServiceSubscription");
                    _idServiceSubscription = value;
                    SendPropertyChanged("IdServiceSubscription");
                    OnIdServiceSubscriptionChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _subscriptionName;

        /// <summary>
        /// Gets or sets the SubscriptionName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "SubscriptionName", Storage = "_subscriptionName", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string SubscriptionName
        {
            get { return _subscriptionName; }
            set
            {
                if (_subscriptionName != value)
                {
                    OnSubscriptionNameChanging(value);
                    SendPropertyChanging("SubscriptionName");
                    _subscriptionName = value;
                    SendPropertyChanged("SubscriptionName");
                    OnSubscriptionNameChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<System.DateTime> _startDate;

        /// <summary>
        /// Gets or sets the StartDate column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "StartDate", Storage = "_startDate", DbType = "datetime")]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<System.DateTime> StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    OnStartDateChanging(value);
                    SendPropertyChanging("StartDate");
                    _startDate = value;
                    SendPropertyChanged("StartDate");
                    OnStartDateChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<System.DateTime> _endDate;

        /// <summary>
        /// Gets or sets the EndDate column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "EndDate", Storage = "_endDate", DbType = "datetime")]
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<System.DateTime> EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    OnEndDateChanging(value);
                    SendPropertyChanging("EndDate");
                    _endDate = value;
                    SendPropertyChanged("EndDate");
                    OnEndDateChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<bool> _isActive;

        /// <summary>
        /// Gets or sets the IsActive column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IsActive", Storage = "_isActive", DbType = "bit")]
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<bool> IsActive
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
        private System.Data.Linq.EntitySet<ServiceDelivery> _serviceDeliveryList;

        /// <summary>
        /// Gets or sets the <see cref="ServiceDelivery"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "ServiceSubscription_ServiceDelivery", Storage = "_serviceDeliveryList", ThisKey = "IdServiceSubscription", OtherKey = "IdServiceSubscription")]
        [System.Runtime.Serialization.DataMember(Order=6, EmitDefaultValue=false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.Data.Linq.EntitySet<ServiceDelivery> ServiceDeliveryList
        {
            get { return (serializing && !_serviceDeliveryList.HasLoadedOrAssignedValues) ? null : _serviceDeliveryList; }
            set { _serviceDeliveryList.Assign(value); }
        }
        
        

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnServiceDeliveryListAdd(ServiceDelivery entity)
        {
            SendPropertyChanging(null);
            entity.ServiceSubscription = this;
            SendPropertyChanged(null);
        }

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnServiceDeliveryListRemove(ServiceDelivery entity)
        {
            SendPropertyChanging(null);
            entity.ServiceSubscription = null;
            SendPropertyChanged(null);
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntitySet<UsersXSubscription> _idSubscriptionUsersXSubscriptionList;

        /// <summary>
        /// Gets or sets the <see cref="UsersXSubscription"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "ServiceSubscription_UsersXSubscription", Storage = "_idSubscriptionUsersXSubscriptionList", ThisKey = "IdServiceSubscription", OtherKey = "IdSubscription")]
        [System.Runtime.Serialization.DataMember(Order=7, EmitDefaultValue=false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.Data.Linq.EntitySet<UsersXSubscription> IdSubscriptionUsersXSubscriptionList
        {
            get { return (serializing && !_idSubscriptionUsersXSubscriptionList.HasLoadedOrAssignedValues) ? null : _idSubscriptionUsersXSubscriptionList; }
            set { _idSubscriptionUsersXSubscriptionList.Assign(value); }
        }
        
        

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnIdSubscriptionUsersXSubscriptionListAdd(UsersXSubscription entity)
        {
            SendPropertyChanging(null);
            entity.IdSubscriptionServiceSubscription = this;
            SendPropertyChanged(null);
        }

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnIdSubscriptionUsersXSubscriptionListRemove(UsersXSubscription entity)
        {
            SendPropertyChanging(null);
            entity.IdSubscriptionServiceSubscription = null;
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
        /// <summary>Called when <see cref="IdServiceSubscription"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdServiceSubscriptionChanging(int value);
        /// <summary>Called after <see cref="IdServiceSubscription"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdServiceSubscriptionChanged();
        /// <summary>Called when <see cref="SubscriptionName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSubscriptionNameChanging(string value);
        /// <summary>Called after <see cref="SubscriptionName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnSubscriptionNameChanged();
        /// <summary>Called when <see cref="StartDate"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnStartDateChanging(Nullable<System.DateTime> value);
        /// <summary>Called after <see cref="StartDate"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnStartDateChanged();
        /// <summary>Called when <see cref="EndDate"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnEndDateChanging(Nullable<System.DateTime> value);
        /// <summary>Called after <see cref="EndDate"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnEndDateChanged();
        /// <summary>Called when <see cref="IsActive"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsActiveChanging(Nullable<bool> value);
        /// <summary>Called after <see cref="IsActive"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsActiveChanged();

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
        /// Deserializes an instance of <see cref="ServiceSubscription"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="ServiceSubscription"/> instance.</param>
        /// <returns>An instance of <see cref="ServiceSubscription"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static ServiceSubscription FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ServiceSubscription));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as ServiceSubscription;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="ServiceSubscription"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="ServiceSubscription"/> instance.</param>
        /// <returns>An instance of <see cref="ServiceSubscription"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static ServiceSubscription FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ServiceSubscription));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as ServiceSubscription;
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
        public ServiceSubscription Clone()
        {
            return (ServiceSubscription)((ICloneable)this).Clone();
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
            _serviceDeliveryList = Detach(_serviceDeliveryList, OnServiceDeliveryListAdd, OnServiceDeliveryListRemove);
            _idSubscriptionUsersXSubscriptionList = Detach(_idSubscriptionUsersXSubscriptionList, OnIdSubscriptionUsersXSubscriptionListAdd, OnIdSubscriptionUsersXSubscriptionListRemove);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
