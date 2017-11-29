using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using System.Data.Linq;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class SmartChart
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdSmartChart { get; set; }

            public int? IdSmartReport { get; set; }

            public string ChartName { get; set; }

            public string FileName { get; set; }

            public string Insights { get; set; }

            public int? IdChartType { get; set; }

            public string AxisSeriesTitle { get; set; }

            public string AxisValuesTitle { get; set; }

            public int? ChartOrder { get; set; }

            public string SocialPostFilter { get; set; }

            public string CssClasses { get; set; }

            public int? IdDataProvider { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
            public string HtmlStyles { get; set; }

            public ChartType ChartType { get; set; }

            public SmartReport SmartReport { get; set; }

            public DataProvider DataProvider { get; set; }

            public EntitySet<ChartComment> ChartCommentList { get; set; }

            public EntitySet<ChartSeries> ChartSeriesList { get; set; }

        }

        #endregion
    }
}