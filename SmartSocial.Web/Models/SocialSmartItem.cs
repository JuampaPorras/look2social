using System;

namespace SmartSocial.Web.Models
{
    public class SocialSmartItem
    {
        public string SocialPostId { get; set; }
        public string SocialNetwork { get; set; }
        public string ScreenName { get; set; }
        public string ProfileImg { get; set; }
        public string Message { get; set; }
        public string PermaLink { get; set; }
        public DateTime DatePost { get; set; }


    }
}