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
    /// The class representing the dbo.Company table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.Company")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.Company.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdCompany")]
    [System.Diagnostics.DebuggerDisplay("IdCompany: {IdCompany}")]
    public partial class Company
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="Company"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static Company()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Company()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _aspNetUsersList = new System.Data.Linq.EntitySet<AspNetUsers>(OnAspNetUsersListAdd, OnAspNetUsersListRemove);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idCompany = default(int);

        /// <summary>
        /// Gets the IdCompany column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IdCompany", Storage = "_idCompany", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdCompany
        {
            get { return _idCompany; }
            set
            {
                if (_idCompany != value)
                {
                    OnIdCompanyChanging(value);
                    SendPropertyChanging("IdCompany");
                    _idCompany = value;
                    SendPropertyChanged("IdCompany");
                    OnIdCompanyChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _companyName;

        /// <summary>
        /// Gets or sets the CompanyName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "CompanyName", Storage = "_companyName", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    OnCompanyNameChanging(value);
                    SendPropertyChanging("CompanyName");
                    _companyName = value;
                    SendPropertyChanged("CompanyName");
                    OnCompanyNameChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _logoFileName;

        /// <summary>
        /// Gets or sets the LogoFileName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "LogoFileName", Storage = "_logoFileName", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string LogoFileName
        {
            get { return _logoFileName; }
            set
            {
                if (_logoFileName != value)
                {
                    OnLogoFileNameChanging(value);
                    SendPropertyChanging("LogoFileName");
                    _logoFileName = value;
                    SendPropertyChanged("LogoFileName");
                    OnLogoFileNameChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Data.Linq.EntitySet<AspNetUsers> _aspNetUsersList;

        /// <summary>
        /// Gets or sets the <see cref="AspNetUsers"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "Company_AspNetUsers", Storage = "_aspNetUsersList", ThisKey = "IdCompany", OtherKey = "IdCompany")]
        [System.Runtime.Serialization.DataMember(Order=4, EmitDefaultValue=false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.Data.Linq.EntitySet<AspNetUsers> AspNetUsersList
        {
            get { return (serializing && !_aspNetUsersList.HasLoadedOrAssignedValues) ? null : _aspNetUsersList; }
            set { _aspNetUsersList.Assign(value); }
        }
        
        

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnAspNetUsersListAdd(AspNetUsers entity)
        {
            SendPropertyChanging(null);
            entity.Company1 = this;
            SendPropertyChanged(null);
        }

        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void OnAspNetUsersListRemove(AspNetUsers entity)
        {
            SendPropertyChanging(null);
            entity.Company1 = null;
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
        /// <summary>Called when <see cref="IdCompany"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdCompanyChanging(int value);
        /// <summary>Called after <see cref="IdCompany"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdCompanyChanged();
        /// <summary>Called when <see cref="CompanyName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCompanyNameChanging(string value);
        /// <summary>Called after <see cref="CompanyName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCompanyNameChanged();
        /// <summary>Called when <see cref="LogoFileName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnLogoFileNameChanging(string value);
        /// <summary>Called after <see cref="LogoFileName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnLogoFileNameChanged();

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
        /// Deserializes an instance of <see cref="Company"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Company"/> instance.</param>
        /// <returns>An instance of <see cref="Company"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Company FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Company));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as Company;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Company"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Company"/> instance.</param>
        /// <returns>An instance of <see cref="Company"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Company FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Company));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as Company;
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
        public Company Clone()
        {
            return (Company)((ICloneable)this).Clone();
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
            _aspNetUsersList = Detach(_aspNetUsersList, OnAspNetUsersListAdd, OnAspNetUsersListRemove);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
