﻿using System.ComponentModel.DataAnnotations;
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
    public partial class WebpagesRoles
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int RoleId { get; set; }

            [Required]
            public string RoleName { get; set; }

            public EntitySet<WebpagesUsersInRoles> WebpagesUsersInRolesList { get; set; }

        }

        #endregion
    }
}