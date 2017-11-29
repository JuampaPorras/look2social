using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class ChartComment
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdComment { get; set; }

            [Required]
            public string IdUser { get; set; }

            public int IdSmartChart { get; set; }

            public System.DateTime? DatePosted { get; set; }

            public string Message { get; set; }

            public SmartChart SmartChart { get; set; }

        }

        #endregion
    }
}