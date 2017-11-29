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
    public partial class SeriesValue
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdSeriesValue { get; set; }

            public int? IdChartSeries { get; set; }

            public int? IdDataType { get; set; }

            public string Value { get; set; }

            public int? RowPosition { get; set; }

            public ChartSeries ChartSeries { get; set; }

            public DataType DataType { get; set; }

        }

        #endregion
    }
}