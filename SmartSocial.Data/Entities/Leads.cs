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
    public partial class Leads
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdLead { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
            public string Email { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }

            public string CompanyName { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
            public string ServicesDescription { get; set; }

            public string Keywords { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
            public string MainCompetitors { get; set; }

            public string Nickname { get; set; }

            public string MarketPlaceName { get; set; }

            public string DesireReportName { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
            public string CompanyWebSite { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
            public string Notes { get; set; }

            public string IntakeToken { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Url)]
            public string IntakeUrl { get; set; }

            [Now(EntityState.New)]
            [CodeSmith.Data.Audit.NotAudited]
            public System.DateTime DateCreated { get; set; }

            public System.DateTime DateUpdated { get; set; }

            public System.DateTime? IntakeEmailSentDate { get; set; }

            public bool IsActive { get; set; }

            public bool IsIntakeAnswered { get; set; }

        }

        #endregion
    }
}