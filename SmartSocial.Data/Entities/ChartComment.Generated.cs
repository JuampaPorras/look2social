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
    /// The class representing the dbo.ChartComment table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.ChartComment")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.ChartComment.Metadata))]
    [System.Data.Services.Common.DataServiceKey("IdComment")]
    [System.Diagnostics.DebuggerDisplay("IdComment: {IdComment}")]
    public partial class ChartComment
        : LinqEntityBase, ICloneable 
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="ChartComment"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static ChartComment()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartComment"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public ChartComment()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private void Initialize()
        {
            _smartChart = default(System.Data.Linq.EntityRef<SmartChart>);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idComment = default(int);

        /// <summary>
        /// Gets the IdComment column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IdComment", Storage = "_idComment", DbType = "int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdComment
        {
            get { return _idComment; }
            set
            {
                if (_idComment != value)
                {
                    OnIdCommentChanging(value);
                    SendPropertyChanging("IdComment");
                    _idComment = value;
                    SendPropertyChanged("IdComment");
                    OnIdCommentChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _idUser;

        /// <summary>
        /// Gets or sets the IdUser column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IdUser", Storage = "_idUser", DbType = "nvarchar(128) NOT NULL", CanBeNull = false)]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string IdUser
        {
            get { return _idUser; }
            set
            {
                if (_idUser != value)
                {
                    OnIdUserChanging(value);
                    SendPropertyChanging("IdUser");
                    _idUser = value;
                    SendPropertyChanged("IdUser");
                    OnIdUserChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private int _idSmartChart;

        /// <summary>
        /// Gets or sets the IdSmartChart column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "IdSmartChart", Storage = "_idSmartChart", DbType = "int NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public int IdSmartChart
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
        private Nullable<System.DateTime> _datePosted;

        /// <summary>
        /// Gets or sets the DatePosted column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "DatePosted", Storage = "_datePosted", DbType = "datetime")]
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Nullable<System.DateTime> DatePosted
        {
            get { return _datePosted; }
            set
            {
                if (_datePosted != value)
                {
                    OnDatePostedChanging(value);
                    SendPropertyChanging("DatePosted");
                    _datePosted = value;
                    SendPropertyChanged("DatePosted");
                    OnDatePostedChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _message;

        /// <summary>
        /// Gets or sets the Message column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Message", Storage = "_message", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    OnMessageChanging(value);
                    SendPropertyChanging("Message");
                    _message = value;
                    SendPropertyChanged("Message");
                    OnMessageChanged();
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
        [System.Data.Linq.Mapping.Association(Name = "SmartChart_ChartComment", Storage = "_smartChart", ThisKey = "IdSmartChart", OtherKey = "IdSmartChart", IsForeignKey = true, DeleteRule = "CASCADE")]
        [System.Runtime.Serialization.DataMember(Order = 6, EmitDefaultValue = false)]
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
                        previousValue.ChartCommentList.Remove(this);
                    }
                    _smartChart.Entity = value;
                    if (value != null)
                    {
                        value.ChartCommentList.Add(this);
                        _idSmartChart = value.IdSmartChart;
                    }
                    else
                    {
                        _idSmartChart = default(int);
                    }
                    SendPropertyChanged("SmartChart");
                    OnSmartChartChanged();
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
        /// <summary>Called when <see cref="IdComment"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdCommentChanging(int value);
        /// <summary>Called after <see cref="IdComment"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdCommentChanged();
        /// <summary>Called when <see cref="IdUser"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdUserChanging(string value);
        /// <summary>Called after <see cref="IdUser"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdUserChanged();
        /// <summary>Called when <see cref="IdSmartChart"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSmartChartChanging(int value);
        /// <summary>Called after <see cref="IdSmartChart"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnIdSmartChartChanged();
        /// <summary>Called when <see cref="DatePosted"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDatePostedChanging(Nullable<System.DateTime> value);
        /// <summary>Called after <see cref="DatePosted"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnDatePostedChanged();
        /// <summary>Called when <see cref="Message"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnMessageChanging(string value);
        /// <summary>Called after <see cref="Message"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnMessageChanged();
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
        /// Deserializes an instance of <see cref="ChartComment"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="ChartComment"/> instance.</param>
        /// <returns>An instance of <see cref="ChartComment"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static ChartComment FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ChartComment));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as ChartComment;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="ChartComment"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="ChartComment"/> instance.</param>
        /// <returns>An instance of <see cref="ChartComment"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static ChartComment FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ChartComment));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as ChartComment;
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
        public ChartComment Clone()
        {
            return (ChartComment)((ICloneable)this).Clone();
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
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414
