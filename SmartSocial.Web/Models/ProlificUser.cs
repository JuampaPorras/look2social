namespace SmartSocial.Web.Models
{
    public class ProlificUser
    {
        public int ID { get; set; }
        public string SocialNetwork {get;set;}
        public string UserName {get;set;}
        public string FullName{get;set;}
        public string Bio {get;set;}
        public string ProfileUrl { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string ImageUrl { get; set; }
    }
}