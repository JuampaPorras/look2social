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
    public partial class WebpagesMembership
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int UserId { get; set; }

            public System.DateTime? CreateDate { get; set; }

            public string ConfirmationToken { get; set; }

            public bool? IsConfirmed { get; set; }

            public System.DateTime? LastPasswordFailureDate { get; set; }

            public int PasswordFailuresSinceLastSuccess { get; set; }

            [Required]
            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string Password { get; set; }

            public System.DateTime? PasswordChangedDate { get; set; }

            [Required]
            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string PasswordSalt { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string PasswordVerificationToken { get; set; }

            public System.DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        }

        #endregion
    }
}