//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartSocial.Data.V2
{
    using System;
    
    public partial class spGetSocialPosts_Result
    {
        public int idSocialPost { get; set; }
        public Nullable<int> idSmartReport { get; set; }
        public string SocialNetwork { get; set; }
        public string SenderScreenName { get; set; }
        public string SenderProfileImgUrl { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> MessageCreatedDate { get; set; }
        public string Permalink { get; set; }
        public string Country { get; set; }
    }
}
