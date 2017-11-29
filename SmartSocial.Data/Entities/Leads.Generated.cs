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
    /// The class representing the dbo.Leads table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.Leads")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.Leads.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdLead")]
    [System.Diagnostics.DebuggerDisplay("IdLead: {IdLead}")]
    public partial class Leads
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="Leads"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static Leads()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Leads"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Leads()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idLead = default(int);

        /// <summary>
        /// Gets the idLead column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "idLead", Storage = "_idLead", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdLead
        {
            get { return _idLead; }
            set
            {
                if (_idLead != value)
                {
                    OnIdLeadChanging(value);
                    SendPropertyChanging("IdLead");
                    _idLead = value;
                    SendPropertyChanged("IdLead");
                    OnIdLeadChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _firstName;

        /// <summary>
        /// Gets or sets the FirstName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "FirstName", Storage = "_firstName", DbType = "varchar(50) NOT NULL", CanBeNull = false)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    OnFirstNameChanging(value);
                    SendPropertyChanging("FirstName");
                    _firstName = value;
                    SendPropertyChanged("FirstName");
                    OnFirstNameChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _lastName;

        /// <summary>
        /// Gets or sets the LastName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "LastName", Storage = "_lastName", DbType = "varchar(50) NOT NULL", CanBeNull = false)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    OnLastNameChanging(value);
                    SendPropertyChanging("LastName");
                    _lastName = value;
                    SendPropertyChanged("LastName");
                    OnLastNameChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _email;

        /// <summary>
        /// Gets or sets the Email column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Email", Storage = "_email", DbType = "varchar(100) NOT NULL", CanBeNull = false)]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    OnEmailChanging(value);
                    SendPropertyChanging("Email");
                    _email = value;
                    SendPropertyChanged("Email");
                    OnEmailChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _phoneNumber;

        /// <summary>
        /// Gets or sets the PhoneNumber column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "PhoneNumber", Storage = "_phoneNumber", DbType = "varchar(15)")]
        [System.ComponentModel.DataAnnotations.StringLength(15)]
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    OnPhoneNumberChanging(value);
                    SendPropertyChanging("PhoneNumber");
                    _phoneNumber = value;
                    SendPropertyChanged("PhoneNumber");
                    OnPhoneNumberChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _companyName;

        /// <summary>
        /// Gets or sets the CompanyName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "CompanyName", Storage = "_companyName", DbType = "varchar(50)")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.Runtime.Serialization.DataMember(Order = 6)]
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
        private string _servicesDescription;

        /// <summary>
        /// Gets or sets the ServicesDescription column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "ServicesDescription", Storage = "_servicesDescription", DbType = "varchar(300)")]
        [System.ComponentModel.DataAnnotations.StringLength(300)]
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string ServicesDescription
        {
            get { return _servicesDescription; }
            set
            {
                if (_servicesDescription != value)
                {
                    OnServicesDescriptionChanging(value);
                    SendPropertyChanging("ServicesDescription");
                    _servicesDescription = value;
                    SendPropertyChanged("ServicesDescription");
                    OnServicesDescriptionChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _keywords;

        /// <summary>
        /// Gets or sets the Keywords column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Keywords", Storage = "_keywords", DbType = "varchar(250)")]
        [System.ComponentModel.DataAnnotations.StringLength(250)]
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Keywords
        {
            get { return _keywords; }
            set
            {
                if (_keywords != value)
                {
                    OnKeywordsChanging(value);
                    SendPropertyChanging("Keywords");
                    _keywords = value;
                    SendPropertyChanged("Keywords");
                    OnKeywordsChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _mainCompetitors;

        /// <summary>
        /// Gets or sets the MainCompetitors column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "MainCompetitors", Storage = "_mainCompetitors", DbType = "varchar(300)")]
        [System.ComponentModel.DataAnnotations.StringLength(300)]
        [System.Runtime.Serialization.DataMember(Order = 9)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string MainCompetitors
        {
            get { return _mainCompetitors; }
            set
            {
                if (_mainCompetitors != value)
                {
                    OnMainCompetitorsChanging(value);
                    SendPropertyChanging("MainCompetitors");
                    _mainCompetitors = value;
                    SendPropertyChanged("MainCompetitors");
                    OnMainCompetitorsChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _nickname;

        /// <summary>
        /// Gets or sets the Nickname column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Nickname", Storage = "_nickname", DbType = "varchar(50)")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [System.Runtime.Serialization.DataMember(Order = 10)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Nickname
        {
            get { return _nickname; }
            set
            {
                if (_nickname != value)
                {
                    OnNicknameChanging(value);
                    SendPropertyChanging("Nickname");
                    _nickname = value;
                    SendPropertyChanged("Nickname");
                    OnNicknameChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _marketPlaceName;

        /// <summary>
        /// Gets or sets the MarketPlaceName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "MarketPlaceName", Storage = "_marketPlaceName", DbType = "varchar(100)")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.Runtime.Serialization.DataMember(Order = 11)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string MarketPlaceName
        {
            get { return _marketPlaceName; }
            set
            {
                if (_marketPlaceName != value)
                {
                    OnMarketPlaceNameChanging(value);
                    SendPropertyChanging("MarketPlaceName");
                    _marketPlaceName = value;
                    SendPropertyChanged("MarketPlaceName");
                    OnMarketPlaceNameChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _desireReportName;

        /// <summary>
        /// Gets or sets the DesireReportName column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "DesireReportName", Storage = "_desireReportName", DbType = "varchar(100)")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.Runtime.Serialization.DataMember(Order = 12)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string DesireReportName
        {
            get { return _desireReportName; }
            set
            {
                if (_desireReportName != value)
                {
                    OnDesireReportNameChanging(value);
                    SendPropertyChanging("DesireReportName");
                    _desireReportName = value;
                    SendPropertyChanged("DesireReportName");
                    OnDesireReportNameChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _companyWebSite;

        /// <summary>
        /// Gets or sets the CompanyWebSite column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "CompanyWebSite", Storage = "_companyWebSite", DbType = "varchar(1000)")]
        [System.ComponentModel.DataAnnotations.StringLength(1000)]
        [System.Runtime.Serialization.DataMember(Order = 13)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string CompanyWebSite
        {
            get { return _companyWebSite; }
            set
            {
                if (_companyWebSite != value)
                {
                    OnCompanyWebSiteChanging(value);
                    SendPropertyChanging("CompanyWebSite");
                    _companyWebSite = value;
                    SendPropertyChanged("CompanyWebSite");
                    OnCompanyWebSiteChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _notes;

        /// <summary>
        /// Gets or sets the Notes column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Notes", Storage = "_notes", DbType = "varchar(500)")]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        [System.Runtime.Serialization.DataMember(Order = 14)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    OnNotesChanging(value);
                    SendPropertyChanging("Notes");
                    _notes = value;
                    SendPropertyChanged("Notes");
                    OnNotesChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _intakeToken;

        /// <summary>
        /// Gets or sets the IntakeToken column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IntakeToken", Storage = "_intakeToken", DbType = "varchar(100)")]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.Runtime.Serialization.DataMember(Order = 15)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string IntakeToken
        {
            get { return _intakeToken; }
            set
            {
                if (_intakeToken != value)
                {
                    OnIntakeTokenChanging(value);
                    SendPropertyChanging("IntakeToken");
                    _intakeToken = value;
                    SendPropertyChanged("IntakeToken");
                    OnIntakeTokenChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _intakeUrl;

        /// <summary>
        /// Gets or sets the IntakeUrl column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IntakeUrl", Storage = "_intakeUrl", DbType = "varchar(200)")]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        [System.Runtime.Serialization.DataMember(Order = 16)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string IntakeUrl
        {
            get { return _intakeUrl; }
            set
            {
                if (_intakeUrl != value)
                {
                    OnIntakeUrlChanging(value);
                    SendPropertyChanging("IntakeUrl");
                    _intakeUrl = value;
                    SendPropertyChanged("IntakeUrl");
                    OnIntakeUrlChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime _dateCreated;

        /// <summary>
        /// Gets or sets the DateCreated column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "DateCreated", Storage = "_dateCreated", DbType = "datetime NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 17)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    OnDateCreatedChanging(value);
                    SendPropertyChanging("DateCreated");
                    _dateCreated = value;
                    SendPropertyChanged("DateCreated");
                    OnDateCreatedChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime _dateUpdated;

        /// <summary>
        /// Gets or sets the DateUpdated column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "DateUpdated", Storage = "_dateUpdated", DbType = "datetime NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 18)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public System.DateTime DateUpdated
        {
            get { return _dateUpdated; }
            set
            {
                if (_dateUpdated != value)
                {
                    OnDateUpdatedChanging(value);
                    SendPropertyChanging("DateUpdated");
                    _dateUpdated = value;
                    SendPropertyChanged("DateUpdated");
                    OnDateUpdatedChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private Nullable<System.DateTime> _intakeEmailSentDate;

        /// <summary>
        /// Gets or sets the IntakeEmailSentDate column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IntakeEmailSentDate", Storage = "_intakeEmailSentDate", DbType = "datetime")]
        [System.Runtime.Serialization.DataMember(Order = 19)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<System.DateTime> IntakeEmailSentDate
        {
            get { return _intakeEmailSentDate; }
            set
            {
                if (_intakeEmailSentDate != value)
                {
                    OnIntakeEmailSentDateChanging(value);
                    SendPropertyChanging("IntakeEmailSentDate");
                    _intakeEmailSentDate = value;
                    SendPropertyChanged("IntakeEmailSentDate");
                    OnIntakeEmailSentDateChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private bool _isActive;

        /// <summary>
        /// Gets or sets the IsActive column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IsActive", Storage = "_isActive", DbType = "bit NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 20)]
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

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private bool _isIntakeAnswered;

        /// <summary>
        /// Gets or sets the IsIntakeAnswered column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IsIntakeAnswered", Storage = "_isIntakeAnswered", DbType = "bit NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 21)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public bool IsIntakeAnswered
        {
            get { return _isIntakeAnswered; }
            set
            {
                if (_isIntakeAnswered != value)
                {
                    OnIsIntakeAnsweredChanging(value);
                    SendPropertyChanging("IsIntakeAnswered");
                    _isIntakeAnswered = value;
                    SendPropertyChanged("IsIntakeAnswered");
                    OnIsIntakeAnsweredChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties
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
        /// <summary>Called when <see cref="IdLead"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdLeadChanging(int value);
        /// <summary>Called after <see cref="IdLead"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdLeadChanged();
        /// <summary>Called when <see cref="FirstName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnFirstNameChanging(string value);
        /// <summary>Called after <see cref="FirstName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnFirstNameChanged();
        /// <summary>Called when <see cref="LastName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnLastNameChanging(string value);
        /// <summary>Called after <see cref="LastName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnLastNameChanged();
        /// <summary>Called when <see cref="Email"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnEmailChanging(string value);
        /// <summary>Called after <see cref="Email"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnEmailChanged();
        /// <summary>Called when <see cref="PhoneNumber"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnPhoneNumberChanging(string value);
        /// <summary>Called after <see cref="PhoneNumber"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnPhoneNumberChanged();
        /// <summary>Called when <see cref="CompanyName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCompanyNameChanging(string value);
        /// <summary>Called after <see cref="CompanyName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCompanyNameChanged();
        /// <summary>Called when <see cref="ServicesDescription"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnServicesDescriptionChanging(string value);
        /// <summary>Called after <see cref="ServicesDescription"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnServicesDescriptionChanged();
        /// <summary>Called when <see cref="Keywords"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnKeywordsChanging(string value);
        /// <summary>Called after <see cref="Keywords"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnKeywordsChanged();
        /// <summary>Called when <see cref="MainCompetitors"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnMainCompetitorsChanging(string value);
        /// <summary>Called after <see cref="MainCompetitors"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnMainCompetitorsChanged();
        /// <summary>Called when <see cref="Nickname"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnNicknameChanging(string value);
        /// <summary>Called after <see cref="Nickname"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnNicknameChanged();
        /// <summary>Called when <see cref="MarketPlaceName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnMarketPlaceNameChanging(string value);
        /// <summary>Called after <see cref="MarketPlaceName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnMarketPlaceNameChanged();
        /// <summary>Called when <see cref="DesireReportName"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDesireReportNameChanging(string value);
        /// <summary>Called after <see cref="DesireReportName"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDesireReportNameChanged();
        /// <summary>Called when <see cref="CompanyWebSite"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCompanyWebSiteChanging(string value);
        /// <summary>Called after <see cref="CompanyWebSite"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnCompanyWebSiteChanged();
        /// <summary>Called when <see cref="Notes"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnNotesChanging(string value);
        /// <summary>Called after <see cref="Notes"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnNotesChanged();
        /// <summary>Called when <see cref="IntakeToken"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIntakeTokenChanging(string value);
        /// <summary>Called after <see cref="IntakeToken"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIntakeTokenChanged();
        /// <summary>Called when <see cref="IntakeUrl"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIntakeUrlChanging(string value);
        /// <summary>Called after <see cref="IntakeUrl"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIntakeUrlChanged();
        /// <summary>Called when <see cref="DateCreated"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDateCreatedChanging(System.DateTime value);
        /// <summary>Called after <see cref="DateCreated"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDateCreatedChanged();
        /// <summary>Called when <see cref="DateUpdated"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDateUpdatedChanging(System.DateTime value);
        /// <summary>Called after <see cref="DateUpdated"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDateUpdatedChanged();
        /// <summary>Called when <see cref="IntakeEmailSentDate"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIntakeEmailSentDateChanging(Nullable<System.DateTime> value);
        /// <summary>Called after <see cref="IntakeEmailSentDate"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIntakeEmailSentDateChanged();
        /// <summary>Called when <see cref="IsActive"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsActiveChanging(bool value);
        /// <summary>Called after <see cref="IsActive"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsActiveChanged();
        /// <summary>Called when <see cref="IsIntakeAnswered"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsIntakeAnsweredChanging(bool value);
        /// <summary>Called after <see cref="IsIntakeAnswered"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIsIntakeAnsweredChanged();

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
        /// Deserializes an instance of <see cref="Leads"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Leads"/> instance.</param>
        /// <returns>An instance of <see cref="Leads"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Leads FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Leads));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as Leads;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Leads"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Leads"/> instance.</param>
        /// <returns>An instance of <see cref="Leads"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Leads FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Leads));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as Leads;
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
        public Leads Clone()
        {
            return (Leads)((ICloneable)this).Clone();
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
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
