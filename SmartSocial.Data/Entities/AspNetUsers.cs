using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class AspNetUsers
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
            public string Id { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
            public string Email { get; set; }

            public bool EmailConfirmed { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string PasswordHash { get; set; }

            public string SecurityStamp { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }

            public bool PhoneNumberConfirmed { get; set; }

            public bool TwoFactorEnabled { get; set; }

            public System.DateTime? LockoutEndDateUtc { get; set; }

            public bool LockoutEnabled { get; set; }

            public int AccessFailedCount { get; set; }

            [Required]
            public string UserName { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Company { get; set; }

            public int? IdCompany { get; set; }

            public int? IdLastReport { get; set; }

            public Company Company1 { get; set; }

            public EntitySet<AspNetUserClaims> UserAspNetUserClaimsList { get; set; }

            public EntitySet<AspNetUserLogins> UserAspNetUserLoginsList { get; set; }

            public EntitySet<AspNetUserRoles> UserAspNetUserRolesList { get; set; }

        }

        #endregion
    }
}