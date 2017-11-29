using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class SpGetChartsByReportXIDResult
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdSmartchart { get; set; }

            public string ChartName { get; set; }

            public int? ChartOrder { get; set; }

            public string AxisSeriesTitle { get; set; }

            public string AxisValuesTitle { get; set; }

            public string CssClasses { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
            public string HtmlStyles { get; set; }

            public string ChartTypeName { get; set; }

        }

        #endregion
    }
}