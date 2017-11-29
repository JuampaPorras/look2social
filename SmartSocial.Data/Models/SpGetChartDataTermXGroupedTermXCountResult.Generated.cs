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
    /// Class representing SpGetChartDataTermXGroupedTermXCountResult data.
    /// </summary>
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(SmartSocial.Data.SpGetChartDataTermXGroupedTermXCountResult.Metadata))]
    public partial class SpGetChartDataTermXGroupedTermXCountResult
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        static SpGetChartDataTermXGroupedTermXCountResult()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public SpGetChartDataTermXGroupedTermXCountResult()
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
        private string _term;

        /// <summary>
        /// Gets or sets the Term column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Term", Storage = "_term", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string Term
        {
            get { return _term; }
            set
            {
                if (_term != value)
                {
                    OnTermChanging(value);
                    _term = value;
                    OnTermChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _theGroup;

        /// <summary>
        /// Gets or sets the theGroup column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "theGroup", Storage = "_theGroup", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string TheGroup
        {
            get { return _theGroup; }
            set
            {
                if (_theGroup != value)
                {
                    OnTheGroupChanging(value);
                    _theGroup = value;
                    OnTheGroupChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private string _theCount;

        /// <summary>
        /// Gets or sets the theCount column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "theCount", Storage = "_theCount", DbType = "nvarchar(MAX)")]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public string TheCount
        {
            get { return _theCount; }
            set
            {
                if (_theCount != value)
                {
                    OnTheCountChanging(value);
                    _theCount = value;
                    OnTheCountChanged();
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
        /// <summary>Called when <see cref="Term"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTermChanging(string value);
        /// <summary>Called after <see cref="Term"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTermChanged();
        /// <summary>Called when <see cref="TheGroup"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTheGroupChanging(string value);
        /// <summary>Called after <see cref="TheGroup"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTheGroupChanged();
        /// <summary>Called when <see cref="TheCount"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTheCountChanging(string value);
        /// <summary>Called after <see cref="TheCount"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        partial void OnTheCountChanged();

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
        /// Deserializes an instance of <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> instance.</param>
        /// <returns>An instance of <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SpGetChartDataTermXGroupedTermXCountResult FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SpGetChartDataTermXGroupedTermXCountResult));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as SpGetChartDataTermXGroupedTermXCountResult;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> instance.</param>
        /// <returns>An instance of <see cref="SpGetChartDataTermXGroupedTermXCountResult"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SpGetChartDataTermXGroupedTermXCountResult FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SpGetChartDataTermXGroupedTermXCountResult));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as SpGetChartDataTermXGroupedTermXCountResult;
            }
        }
        
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414