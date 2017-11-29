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
    public partial class AspNetUserRoles
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            [Required]
            public string UserId { get; set; }

            [Required]
            public string RoleId { get; set; }

            public AspNetRoles RoleAspNetRoles { get; set; }

            public AspNetUsers UserAspNetUsers { get; set; }

        }

        #endregion
    }
}