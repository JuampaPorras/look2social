using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Services;
using SmartSocial.Data;

namespace SmartSocial.Web
{
    /// <summary>
    /// Summary description for SocialPostService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class SocialPostService : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        private string ProcessScreenName(object myValue)
        {
            if (myValue == "")
            {
                return "User";
            }

            return myValue.ToString();
        }

        private string ProcessImage(string myValue)
        {
            if (myValue == "")
            {
                return "../images/userPlaceHolder.jpg";
            }

            return myValue.ToString();
        }

        private string ProcessSocialNetwork(object socialNetwork)
        {
            switch (socialNetwork.ToString())
            {
                case "TWITTER":
                    return "../images/SocialNetworkIcons/twitter-icon.png";
                case "WORDPRESS":
                    return "../images/SocialNetworkIcons/wordpress-icon.png";
                case "WEB":
                    return "../images/SocialNetworkIcons/blog-icon.jpg";
                case "FACEBOOK":
                    return "../images/SocialNetworkIcons/facebook-icon.jpg";
                case "FORUMS":
                    return "../images/SocialNetworkIcons/forum-icon.png";
                case "REDDIT":
                    return "../images/SocialNetworkIcons/reddit-icon.png";
                case "GOOGLE_PLUS":
                    return "../images/SocialNetworkIcons/google-plus-icon.png";
                case "INSTAGRAM":
                    return "../images/SocialNetworkIcons/Instagram-icon.png";
                case "YOUTUBE":
                    return "../images/SocialNetworkIcons/youtube-icon.png";
                default:
                    return "../images/SocialNetworkIcons/blog-icon.jpg";
            }
        }

        [WebMethod]
        public string SocialPostDatasource(int reportId, int topN, string filter, int rowsSkipped)
        {
            using (SqlConnection con = new SqlConnection("Data Source='208.43.238.109, 780';Initial Catalog=espriella_SmartSocial;Persist Security Info=True;User ID=espri_admin;Password=SmartSocial00!"))
            {
                using (SqlCommand cmd = new SqlCommand("spGetChartData_SocialPostXIdXTopNXFilterXSkipRows", con))
                {
                    var filterWhere = "";
                    using (SmartSocialdbDataContext myDd = new SmartSocialdbDataContext())
                    {
                        var filterValues = filter.Split('|');
                        var filterParameters = filterValues.ElementAt(1).Split(',');
                        filterWhere = myDd.SmartChart.FirstOrDefault(x => x.IdSmartChart == Convert.ToInt32(filterValues.ElementAt(0))).SocialPostFilter.Replace("SOCIALPOSTPARAM1", filterParameters.ElementAt(0));
                        if (filterParameters.Count() > 1)
                        {
                            filterWhere = filterWhere.Replace("SOCIALPOSTPARAM2", filterParameters.ElementAt(1));
                        }
                    }

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Param1IdSmartReport", SqlDbType.Int).Value = reportId;
                    cmd.Parameters.Add("@Param2TopN", SqlDbType.Int).Value = topN;// Solo 15
                    cmd.Parameters.Add("@Param3Filter", SqlDbType.NVarChar).Value = filterWhere;
                    cmd.Parameters.Add("@Param4SkipRows", SqlDbType.Int).Value = rowsSkipped;
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt=ds.Tables[0];
                    var returnPosts = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        returnPosts += "<li class='list-group-item clearfix comment-info' id='dyn_" + dr["idSocialPost"].ToString() + "'>" +
                                        "<div class='panel-heading'>"+
                                                        "<div class='avatar pull-left mr15'>" +
                                                            "<img src='" + ProcessImage(dr["SenderProfileImgUrl"].ToString()) + "' alt='avatar' style='width:48px;height:48px'>" +
                                                        "</div>" +
                                                        "<p class='text-ellipsis'><a href='" + dr["PermaLink"].ToString() + "'  target='_blanc'><span class='name strong'>" + ProcessScreenName(dr["SenderScreenName"].ToString()) + ": </span></a>" + dr["Message"].ToString().Replace("<", "&lt;").Replace(">", "&gt;") + " </p>" +
                                                        "<span class='date text-muted small pull-left'><img style='width:16px;height:16px' src='" +
                            ProcessSocialNetwork(dr["SocialNetwork"].ToString()) + "'/> "+Convert.ToDateTime(dr["MessageCreatedDate"].ToString())+"</span>" +
                                                "<a class='accordion-toggle collapsed see-more small pull-right' style='float:right' data-toggle='collapse' href='#collapse" + dr["idSocialPost"].ToString() + "' aria-expanded='false'>Show More</a>" +
                                            "</h5>" +
                                        "</div>"+
                                        "<div id='collapse" + dr["idSocialPost"].ToString() + "' class='panel-collapse collapse' aria-expanded='false' style='height: 0px;'>" +
                                            "<div class='panel-body'>"+
                                             "<div class='socialPostItem'><div class='SocialPostMessage'>" +  dr["Message"].ToString()+ "</div></div>"+
                                            "</div>"+
                                        "</div>"+
                                    "</li>";
                    }

                    return returnPosts;
                }
            }
        }
    }
}
