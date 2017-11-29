using System.Data.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class ChartType
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdChartType { get; set; }

            public string ChartTypeName { get; set; }

            public string StoredProcedureName { get; set; }

            public string Description { get; set; }

            public EntitySet<SmartChart> SmartChartList { get; set; }

            public EntitySet<DataProviderXChartType> DataProviderXChartTypeList { get; set; }

        }

        #endregion
    }
}