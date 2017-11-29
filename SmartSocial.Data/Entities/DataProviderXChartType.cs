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
    public partial class DataProviderXChartType
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdDataProvider { get; set; }

            public int IdChartType { get; set; }

            public string FileLoadFunctionName { get; set; }

            public ChartType ChartType { get; set; }

            public DataProvider DataProvider { get; set; }

        }

        #endregion
    }
}