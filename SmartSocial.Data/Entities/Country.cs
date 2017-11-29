using CodeSmith.Data.Audit;
using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;

namespace SmartSocial.Data
{
    public partial class Country
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdCountry { get; set; }

            public string Iso2 { get; set; }

            public string CountryName { get; set; }

            public string LongCountryName { get; set; }

            public string Iso3 { get; set; }

            public string NumCode { get; set; }

            public string UNMemberState { get; set; }

            public string CallingCode { get; set; }

            public string Cctld { get; set; }

            public string FlagImageFilename { get; set; }

        }

        #endregion
    }
}