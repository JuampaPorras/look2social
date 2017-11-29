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
    public partial class SpGetChartDataParentTopicXTopicXWeightResult
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public string ParentTopic { get; set; }

            public string TheParentWeight { get; set; }

            public string TheTopic { get; set; }

            public string TheWeight { get; set; }

        }

        #endregion
    }
}