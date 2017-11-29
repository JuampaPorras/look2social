using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SmartSocial.Data.V2;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Objects;
using SmartSocialServices.Repositories;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Web.Configuration;
//using NLog;



namespace SmartSocialServices.Services
{
    public class ChartsService
    {
        //private static readonly Logger _log = LogManager.GetCurrentClassLogger();

        public SmartChartResponse GetChartsBySmartReportId(int smartReportId)
        {
            var response = new SmartChartResponse();
            try
            {
                var smartChartRepository = new SmartChartRepository();
                var smartReportRepository = new SmartReportRepository();
                var chartCommentsRepository = new ChartCommentRepository();
                var smartReport = smartReportRepository.Query().FirstOrDefault(x => x.idSmartReport == smartReportId);
                if (smartReport != null)
                {
                    response.Delivery = new ServiceDeliveryDto()
                    {
                        DateDelivered = smartReport.ServiceDelivery.DateDelivered,
                        DeliveryDateTo = smartReport.ServiceDelivery.DeliveryDateTo
                    };
                    response.SmartReport = new SmartReportDto()
                    {

                        ReportName = smartReport.ReportName,
                        Insights = smartReport.Insights
                    };
                    var smartCharts =
                        smartChartRepository.Query()
                            .Where(x => x.idSmartReport == smartReportId && x.ChartType.idChartType!=10)
                            .OrderBy(x => x.ChartOrder)
                            .ToList();
                    foreach (var smartChart in smartCharts)
                    {
                        response.SmartCharts.Add(new SmartChartDto()
                        {
                            idSmartChart = smartChart.idSmartChart,
                            IdChartType = smartChart.IdChartType,
                            ChartType = null,
                            Insights = smartChart.Insights,
                            CssClasses = smartChart.CssClasses,
                            ChartName = smartChart.ChartName,
                            ChartTypeName = smartChart.ChartType.ChartTypeName,
                            ChartOrder = smartChart.ChartOrder,
                            CommentsCount = chartCommentsRepository.Query().Where(x=> x.IdSmartChart == smartChart.idSmartChart&&x.IsActive==true).Count()
                        });
                    }
                    smartChartRepository.Dispose();
                    smartReportRepository.Dispose();
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error getting SmartCharts. Exception :" + ex.Message;
            }
            return response;

        }

        private ChartTypeDto GetCharTypeById(int chartTypeId)
        {
            var response = new ChartTypeDto();
            try
            {
                var chartTypeRepository = new ChartTypeRepository();
                var chartType = chartTypeRepository.Query().FirstOrDefault(x => x.idChartType == chartTypeId);
                if (chartType != null)
                {
                    response.ChartTypeName = chartType.ChartTypeName;
                    response.StoredProcedureName = chartType.StoredProcedureName;
                    response.Description = chartType.Description;
                }
            }
            catch (Exception ex)
            {
                //TODO 
            }
            return response;
        }

        public ChartDataReponse GetColumnsChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    containerList.AddRange(context.spGetChartData_TermXCount(id).ToList());
                    
                }
                var listOfTermCount = new List<TermCountObject>();
                var series = containerList.Select(x => x.Term).Distinct();
                foreach (var serie in series)
                {
                    listOfTermCount.Add(new TermCountObject()
                    {
                        Term = serie,
                        theCount = 0
                    });
                }

                foreach (var item in containerList)
                {
                    listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount = listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount + int.Parse(item.theCount);
                }

                response.ChartData = (dynamic)listOfTermCount.OrderByDescending(x=> x.theCount);
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Columns Data";
            }
            return response;
        }

        public ChartDataReponse GetLinearChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    containerList.AddRange(context.spGetChartData_TermXTimeXCount(id).ToList());

                }
                
                var chartData  = (dynamic)containerList;
                foreach (var chartDataSeries in chartData)
                {
                    if (!response.Series.groupNames.Contains(chartDataSeries.theTime))
                    {
                        response.Series.groupNames.Add(chartDataSeries.theTime);                        
                    }
                }

                var series = containerList.Select(x => x.Term).Distinct();
                foreach (var serie in series) {
                    var newSerie = new Serie();
                    newSerie.name = serie;
                    newSerie.data = new ArrayList(response.Series.groupNames.Count());
                    for (int i = 0; i < newSerie.data.Capacity; i++)
                    {
                        newSerie.data.Insert(i, null);
                    }
                    response.Series.series.Add(newSerie);
                }
                int index = 0;
                foreach(var value in response.Series.groupNames){
                    var items = containerList.Where(x => x.theTime == value).ToList();
                    foreach (var item in items) {
                        var addToSerie = response.Series.series.FirstOrDefault(x => x.name == item.Term);
                        if (addToSerie.data[index] == null)
                        {
                            addToSerie.data[index] = Convert.ToInt32(item.theCount);
                        }
                        else {
                            addToSerie.data[index] = Convert.ToInt32(addToSerie.data[index]) + Convert.ToInt32(item.theCount);
                        }

                    }
                    index++;
                }
                
              
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Columns Data";
            }
            return response;
        }

        public ChartDataReponse GetPieChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    containerList.AddRange(context.spGetChartData_TermXCount(id).ToList());

                }
                var listOfTermCount = new List<TermCountObject>();
                var series = containerList.Select(x => x.Term).Distinct();
                foreach (var serie in series)
                {
                    listOfTermCount.Add(new TermCountObject() { 
                        Term = serie,
                        theCount = 0
                    });
                }

                foreach (var item in containerList) {
                    listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount = listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount + int.Parse(item.theCount);
                }

                response.ChartData = (dynamic)listOfTermCount;
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Columns Data";
            }
            return response;
        }

        public ChartDataReponse GetStackedColumnChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();

            try
            {

                var context = new SmartSocialContext();

                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    containerList.AddRange(context.spGetChartData_TermXGroupedTermXCount(id).ToList());

                }
                var chartData = (dynamic)containerList;

                foreach (var chartDataSeries in chartData)
                {
                    if (!response.Series.groupNames.Contains(chartDataSeries.theGroup))
                    {
                        response.Series.groupNames.Add(chartDataSeries.theGroup);
                    }
                    var serie = response.Series.series.FirstOrDefault(x => x.name == chartDataSeries.Term);
                    if (serie != null)
                    {
                        serie.data.Add(Convert.ToInt32(chartDataSeries.theCount));
                    }
                    else
                    {
                        var newSerie = new Serie();
                        newSerie.name = chartDataSeries.Term;
                        newSerie.data.Add(Convert.ToInt32(chartDataSeries.theCount));
                        response.Series.series.Add(newSerie);
                    }


                }

                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Stacked Columns Data";
            }
            return response;
        }

        public ChartDataReponse GetWordCloudChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {

                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    containerList.AddRange(context.spGetChartData_TermXCount(id).ToList());

                }
                var listOfTermCount = new List<TermCountObject>();
                var series = containerList.Select(x => x.Term).Distinct();
                foreach (var serie in series)
                {
                    listOfTermCount.Add(new TermCountObject()
                    {
                        Term = serie,
                        theCount = 0
                    });
                }

                foreach (var item in containerList)
                {
                    listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount = listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount + int.Parse(item.theCount);
                }

                response.ChartData = (dynamic)listOfTermCount.OrderByDescending(x => x.theCount);
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting WordCloud Data exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetMostProlificUsersChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                //var unSortedData=new List<spGetChartData_AudienceStream_Result1()>;
                var unSortedData = context.spGetChartData_AudienceStream(smartChartIds.FirstOrDefault()).ToList();
                foreach (var id in smartChartIds)
                {
                    if (id!=smartChartIds.FirstOrDefault())
                    {
                        unSortedData.AddRange(context.spGetChartData_AudienceStream(id).ToList());
                    }
                    //containerList.AddRange(unSortedData.OrderByDescending(x => int.Parse(x.Followers)).ToList());

                }
                containerList.AddRange(unSortedData.OrderByDescending(x => int.Parse(x.Followers)).ToList());
                response.ChartData = (dynamic)containerList;              
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Most Profilic Users Data exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetTopPostChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    var unSortedData = context.spGetChartData_TopSocialPost(id).ToList();
                    containerList.AddRange(unSortedData.OrderByDescending(x => x.dMessage.Value).ToList());

                }
                response.ChartData = (dynamic)containerList;
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Most Profilic Users Data exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetTopPostByProductChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    //var topSocialPost = new spGetChartData_TopSocialPostByProduct_Result();
                    var topSocialPost = new List<dynamic>();
                    var products = context.spGet_SmartReportProduct(id).ToList();
                    foreach (var product in products)
                    {
                         topSocialPost.AddRange(context.spGetChartData_TopSocialPostByProduct(id, product).ToList());
                    }
                    containerList.AddRange(topSocialPost.OrderByDescending(x => x.dMessage).ToList());

                }
                response.ChartData = (dynamic)containerList;
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Most Profilic Users Data exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetLocationAnalysisChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {

                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                foreach (var id in smartChartIds)
                {
                    containerList.AddRange(context.spGetChartData_TermXGroupedTermXCount(id).ToList());

                }
                var listOfTermCount = new List<TermCountObject>();
                var series = containerList.Select(x => x.Term).Distinct();
                foreach (var serie in series)
                {
                    listOfTermCount.Add(new TermCountObject()
                    {
                        Term = serie,
                        theCount = 0
                    });
                }

                foreach (var item in containerList)
                {
                    listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount = listOfTermCount.FirstOrDefault(x => x.Term == item.Term).theCount + int.Parse(item.theCount);
                }

                response.ChartData = (dynamic)listOfTermCount;
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Location Analysis Data exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetReachSummaryChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                if (smartChartIds.Count == 1)
                {
                    int pastDeliveryChart = GetPastDeliveryChart(smartChartIds[0]);
                    if (pastDeliveryChart != 0)
                    {
                        response.PastDelivery = context.spGetChartData_TermXCount(pastDeliveryChart).FirstOrDefault();
                    }
                }
                var listOfTermCount = new List<TermCountObject>();
                foreach (var id in smartChartIds)
                {
                    var result = context.spGetChartData_TermXCount(id).FirstOrDefault();
                    listOfTermCount.Add(new TermCountObject()
                    {
                        Term = result.Term,
                        theCount = Convert.ToInt32(result.theCount)
                    });                  

                }           


                response.ChartData = (dynamic)listOfTermCount.OrderByDescending(x => x.theCount).First();
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Location Reach Summary exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetMentionSummaryChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
   
                var context = new SmartSocialContext();
                if (smartChartIds.Count == 1)
                {
                    int pastDeliveryChart = GetPastDeliveryChart(smartChartIds[0]);
                    if (pastDeliveryChart != 0)
                    {
                        response.PastDelivery = context.spGetChartData_TermXCount(pastDeliveryChart).FirstOrDefault();
                    }
                }
                var listOfTermCount = new List<TermCountObject>();
                foreach (var id in smartChartIds)
                {
                    var result = context.spGetChartData_TermXCount(id).FirstOrDefault();
                    listOfTermCount.Add(new TermCountObject()
                    {
                        Term = result.Term,
                        theCount = Convert.ToInt32(result.theCount)
                    });
                }
                response.ChartData = (dynamic)listOfTermCount.OrderByDescending(x => x.theCount).First();              
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Location Mention Summary exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetBestDaySummaryChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                if (smartChartIds.Count == 1)
                {
                    int pastDeliveryChart = GetPastDeliveryChart(smartChartIds[0]);
                    if (pastDeliveryChart != 0)
                    {
                        response.PastDelivery = context.spGetChartData_TermXCount(pastDeliveryChart).FirstOrDefault();
                    }
                }
                var listOfTermCount = new List<TermCountObject>();
                foreach (var id in smartChartIds)
                {
                    var result = context.spGetChartData_TermXCount(id).FirstOrDefault();
                    listOfTermCount.Add(new TermCountObject()
                    {
                        Term = result.Term,
                        theCount = Convert.ToInt32(result.theCount)
                    });
                }
                response.ChartData = (dynamic)listOfTermCount.OrderByDescending(x => x.theCount).First();             
            
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting BestDay Summary exception:" + ex.Message;
            }
            return response;
        }

        public ChartDataReponse GetTopUserSummaryChartData(List<int> smartChartIds)
        {
            var response = new ChartDataReponse();
            try
            {
                var context = new SmartSocialContext();
                 if (smartChartIds.Count == 1)
                {
                    int pastDeliveryChart = GetPastDeliveryChart(smartChartIds[0]);
                    if (pastDeliveryChart != 0)
                    {
                        response.PastDelivery = context.spGetChartData_TermXCount(pastDeliveryChart).FirstOrDefault();
                    }
                }
                var listOfTermCount = new List<TermCountObject>();
                foreach (var id in smartChartIds)
                {
                    var result = context.spGetChartData_TermXCount(id).FirstOrDefault();
                    listOfTermCount.Add(new TermCountObject()
                    {
                        Term = result.Term,
                        theCount = Convert.ToInt32(result.theCount)
                    });
                }
                response.ChartData = (dynamic)listOfTermCount.OrderByDescending(x => x.theCount).First();             
            
               
                response.Acknowledgment = true;
                response.Message = "Success";
                context.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting TopUser Summary exception:" + ex.Message;
            }
            return response;
        }


        public ConversationStreamResponse GetConversationStream(int[] reportIds, string filter, int rowsSkipped)
        {
            var response = new ConversationStreamResponse();
            var topN = Convert.ToInt32(Resource.TopN.ToString());

            string conStr = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                foreach (var reportId in reportIds) {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("spGetChartData_SocialPostXIdXTopNXFilterXSkipRows", con))
                        {
                            var filterWhere = "";
                            using (var myDd = new SmartSocialContext())
                            {
                                var filterValues = filter.Split('|');
                                var filterParameters = filterValues.ElementAt(1).Split(',');
                                var smartChartId = Convert.ToInt32(filterValues.ElementAt(0));
                                filterWhere = myDd.SmartCharts.FirstOrDefault(x => x.idSmartChart == smartChartId).SocialPostFilter.Replace("SOCIALPOSTPARAM1", filterParameters.ElementAt(0));
                                if (filterParameters.Count() > 1)
                                {
                                    if (filterWhere.Contains("And [MessageCreatedDate]  = 'SOCIALPOSTPARAM2'"))
                                    {
                                        var dateFrom = DateTime.Parse(filterParameters.ElementAt(1)).Date;
                                        var dateTo = DateTime.Parse(filterParameters.ElementAt(1)).Date.AddDays(1).AddTicks(-1);
                                        filterWhere = filterWhere.Replace("[MessageCreatedDate]  = 'SOCIALPOSTPARAM2'", "[MessageCreatedDate]  BETWEEN '" + dateFrom.ToString() + "' AND '" + dateTo.ToString() + "'");
                                    }else{
                                    filterWhere = filterWhere.Replace("SOCIALPOSTPARAM2", filterParameters.ElementAt(1));
                                    }
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
                            DataTable dt = ds.Tables[0];
                            foreach (DataRow dr in dt.Rows)
                            {
                                response.conversationStreamObjects.Add(new ConversationStreamObject()
                                {
                                    idSocialPost = dr["idSocialPost"].ToString(),
                                    Message = dr["Message"].ToString(),
                                    MessageCreatedDate = dr["MessageCreatedDate"].ToString(),
                                    PermaLink = dr["PermaLink"].ToString(),
                                    SenderProfileImgUrl = dr["SenderProfileImgUrl"].ToString(),
                                    SenderScreenName = dr["SenderScreenName"].ToString(),
                                    SocialNetwork = dr["SocialNetwork"].ToString()
                                });
                            }
                        }
                    }
                }
                
            
                response.Acknowledgment = true;
                response.Message = "Success";



            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting Conversation Stream. Exception:" + ex.Message;
            }


            return response;
        }

        public ConversationStreamResponse GetConversationStreamMessage(int[] reportIds, string filter, int rowsSkipped)
        {

            var response = new ConversationStreamResponse();
            try
            {
                var context = new SmartSocialContext();
                var containerList = new List<dynamic>();
                var filterValues = filter.Split('|');
                var filterParameters = filterValues.ElementAt(1).Split(',');
                var smartChartId = Convert.ToInt32(filterValues.ElementAt(0));
                var message = filterValues.ElementAt(1);
                var socialPostList = context.spGetChartData_MessageSocialPosts(smartChartId, message).ToList();

                foreach (var socialPost in socialPostList)
                {

                    response.conversationStreamObjects.Add(new ConversationStreamObject()
                            {
                                idSocialPost = socialPost.idSocialPost.ToString(),
                                Message = socialPost.Message,
                                MessageCreatedDate = socialPost.MessageCreatedDate.ToString(),
                                PermaLink = socialPost.PermaLink,
                                SenderProfileImgUrl = socialPost.SenderProfileImgUrl,
                                SenderScreenName = socialPost.SenderScreenName,
                                SocialNetwork = socialPost.SocialNetwork
                            });
                }
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Getting GetConversationStreamMessage Data exception:" + ex.Message;
            }
            return response;

        }
        public int GetPastDeliveryChart(int smartChartId)
        {
            int response = 0;
            try
            {
                var smartChartRepository = new SmartChartRepository();
                var deliveryRepository = new ServiceDeliveryRepository();
                var smartReportRepository = new SmartReportRepository();
                var smartChart = smartChartRepository.Query().FirstOrDefault(x => x.idSmartChart == smartChartId);

                if (smartChart != null) {
                    var idSubscription = smartChart.SmartReport.ServiceDelivery.ServiceSubscription.idServiceSubscription;
                    var currentDeliveryDate = smartChart.SmartReport.ServiceDelivery.DateDelivered;
                    var currentReportName = smartChart.SmartReport.ReportName;
                    var pastDelivery = deliveryRepository.Query().Where(x => x.IdServiceSubscription == idSubscription && x.DateDelivered < currentDeliveryDate).OrderByDescending(x=> x.DateDelivered).FirstOrDefault();
                    if (pastDelivery != null)
                    {
                        var pastSmartreports = smartReportRepository.Query().Where(x => x.idServiceDelivery == pastDelivery.idServiceDelivery).ToList();
                        if (pastSmartreports != null)
                        {
                            foreach (var smartReport in pastSmartreports)
                            {
                                if (smartReport.ReportName.Equals(currentReportName))
                                {
                                    var pastChart = smartChartRepository.Query().FirstOrDefault(x => x.idSmartReport == smartReport.idSmartReport &&
                                                                                                x.IdChartType == smartChart.IdChartType &&
                                                                                                x.ChartName.Contains(smartChart.ChartName));
                                    if (pastChart != null && smartChartId != pastChart.idSmartChart)
                                    {
                                        response = pastChart.idSmartChart;
                                    }
                                }
                            }
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                //TODO
                return 0;
            }
            return response;

        }

        public SmartChartDto GetSmartChartById(int smartChartId)        
        {
            var response = new SmartChartDto();
            try
            {
                var smartChartRepository = new SmartChartRepository();
                var smartChart = smartChartRepository.Query().FirstOrDefault(x => x.idSmartChart == smartChartId);
                if (smartChart != null)
                {
                    response = new SmartChartDto()
                    {
                        idSmartReport = smartChart.idSmartReport,
                        SmartReport = new SmartReportDto()
                        {
                            idServiceDelivery = smartChart.SmartReport.idServiceDelivery,
                        },
                        ChartName = smartChart.ChartName
                    };
                }

                smartChartRepository.Dispose();

            }
            catch (Exception ex)
            {
                //TODO
 
            }
            return response;
        }

        public List<int> GetChartsIdByDateRange( int currentChartId, string chartName, string dateFrom, string dateTo)
        {
            var response = new List<int>();
            try
            {
                var serviceDeliveryRepository = new ServiceDeliveryRepository();
                var smartChartRepository = new SmartChartRepository();
                //_log.Warn("Started");
                var from = DateTime.Parse(dateFrom).AddDays(1);
                var to = DateTime.Parse(dateTo);
                var report = smartChartRepository.Query().FirstOrDefault(x => x.idSmartChart == currentChartId).SmartReport;
                var deliveries = serviceDeliveryRepository.Query().Where(x => x.IdServiceSubscription == report.ServiceDelivery.IdServiceSubscription && x.DateDelivered < from && x.DateDelivered > to).ToList();
                var currentReportName = report.ReportName;
                foreach (var delivery in deliveries)
                {
                    foreach (var smartReport in delivery.SmartReports)
                    {
                        if (smartReport.ReportName.Equals(currentReportName))
                        {
                            foreach (var smartChart in smartReport.SmartCharts)
                            {
                                if (smartChart.ChartName.Equals(chartName) && currentChartId != smartChart.idSmartChart && smartChart.ChartType.idChartType!=10)
                                {
                                    response.Add(smartChart.idSmartChart);
                                }
                            }
                        }
                    }
                }
                response.Add(currentChartId);
                serviceDeliveryRepository.Dispose();
                smartChartRepository.Dispose();
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        
    }
}
