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
    /// The class representing the dbo.AspNetUserClaims table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.AspNetUserClaims")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.AspNetUserClaims.Metadata))]
    [System.Data.Services.Common.DataServiceKey("Id")]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}")]
    public partial class AspNetUserClaims
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="AspNetUserClaims"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static AspNetUserClaims()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetUserClaims"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public AspNetUserClaims()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _userAspNetUsers = default(System.Data.Linq.EntityRef<AspNetUsers>);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _id = default(int);

        /// <summary>
        /// Gets the Id column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Id", Storage = "_id", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    OnIdChanging(value);
                    SendPropertyChanging("Id");
                    _id = value;
                    SendPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _userId;

        /// <summary>
        /// Gets or sets the UserId column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "UserId", Storage = "_userId", DbType = "nvarchar(128) NOT NULL", CanBeNull = false)]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    if (_userAspNetUsers.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnUserIdChanging(value);
                    SendPropertyChanging("UserId");
                    _userId = value;
                    SendPropertyChanged("UserId");
                    OnUserIdChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _claimType;

        /// <summary>
        /// Gets or sets the ClaimType column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "ClaimType", Storage = "_claimType", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string ClaimType
        {
            get { return _claimType; }
            set
            {
                if (_claimType != value)
                {
                    OnClaimTypeChanging(value);
                    SendPropertyChanging("ClaimType");
                    _claimType = value;
                    SendPropertyChanged("ClaimType");
                    OnClaimTypeChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _claimValue;

        /// <summary>
        /// Gets or sets the ClaimValue column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "ClaimValue", Storage = "_claimValue", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string ClaimValue
        {
            get { return _claimValue; }
            set
            {
                if (_claimValue != value)
                {
                    OnClaimValueChanging(value);
                    SendPropertyChanging("ClaimValue");
                    _claimValue = value;
                    SendPropertyChanged("ClaimValue");
                    OnClaimValueChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntityRef<AspNetUsers> _userAspNetUsers;

        /// <summary>
        /// Gets or sets the <see cref="AspNetUsers"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "AspNetUsers_AspNetUserClaims", Storage = "_userAspNetUsers", ThisKey = "UserId", OtherKey = "Id", IsForeignKey = true, DeleteRule = "CASCADE")]
        [System.Runtime.Serialization.DataMember(Order = 5, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public AspNetUsers UserAspNetUsers
        {
            get { return (serializing && !_userAspNetUsers.HasLoadedOrAssignedValue) ? null : _userAspNetUsers.Entity; }
            set
            {
                AspNetUsers previousValue = _userAspNetUsers.Entity;
                if (previousValue != value || _userAspNetUsers.HasLoadedOrAssignedValue == false)
                {
                    OnUserAspNetUsersChanging(value);
                    SendPropertyChanging("UserAspNetUsers");
                    if (previousValue != null)
                    {
                        _userAspNetUsers.Entity = null;
                        previousValue.UserAspNetUserClaimsList.Remove(this);
                    }
                    _userAspNetUsers.Entity = value;
                    if (value != null)
                    {
                        value.UserAspNetUserClaimsList.Add(this);
                        _userId = value.Id;
                    }
                    else
                    {
                        _userId = default(string);
                    }
                    SendPropertyChanged("UserAspNetUsers");
                    OnUserAspNetUsersChanged();
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
        /// <summary>Called when <see cref="Id"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChanging(int value);
        /// <summary>Called after <see cref="Id"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdChanged();
        /// <summary>Called when <see cref="UserId"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnUserIdChanging(string value);
        /// <summary>Called after <see cref="UserId"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnUserIdChanged();
        /// <summary>Called when <see cref="ClaimType"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnClaimTypeChanging(string value);
        /// <summary>Called after <see cref="ClaimType"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnClaimTypeChanged();
        /// <summary>Called when <see cref="ClaimValue"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnClaimValueChanging(string value);
        /// <summary>Called after <see cref="ClaimValue"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnClaimValueChanged();
        /// <summary>Called when <see cref="UserAspNetUsers"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnUserAspNetUsersChanging(AspNetUsers value);
        /// <summary>Called after <see cref="UserAspNetUsers"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnUserAspNetUsersChanged();

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
        /// Deserializes an instance of <see cref="AspNetUserClaims"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="AspNetUserClaims"/> instance.</param>
        /// <returns>An instance of <see cref="AspNetUserClaims"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static AspNetUserClaims FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AspNetUserClaims));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as AspNetUserClaims;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="AspNetUserClaims"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="AspNetUserClaims"/> instance.</param>
        /// <returns>An instance of <see cref="AspNetUserClaims"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static AspNetUserClaims FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AspNetUserClaims));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as AspNetUserClaims;
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
        public AspNetUserClaims Clone()
        {
            return (AspNetUserClaims)((ICloneable)this).Clone();
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
            _userAspNetUsers = Detach(_userAspNetUsers);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
