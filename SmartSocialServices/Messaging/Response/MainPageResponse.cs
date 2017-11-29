namespace SmartSocialServices.Messaging.Response
{
    public class MainPageResponse : BaseResponse
    {
        public UserResponse userResponse { get; set; }
        public UserSubscriptionsReponse userSubscriptionsReponse { get; set; }
        public string billingPortalLink { get; set; }
        public bool isGuest { get; set; }
        public string []SystemRoles { get; set; }    
        public string UserName { get; set; }
        public bool isTrialEnding { get; set; }
        public bool isTrialEnded { get; set; }

    }
}
