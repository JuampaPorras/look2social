using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSocial.Data.V2;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Repositories;

namespace SmartSocialServices.Services
{
    public class ShareReportService
    {
        public SharedReportResponse AddSharedReport(SharedReportDto sharedReportDto)
        {
            var response = new SharedReportResponse();
            try
            {
                var sharedReportRepository = new SharedReportRepository();
                var sharedReport = new SharedReport()
                {
                    CreatedBy = sharedReportDto.CreatedBy,
                    Comments = sharedReportDto.Comments,
                    CreatedDate = sharedReportDto.CreatedDate,
                    ExpiredDate = sharedReportDto.ExpiredDate,
                    SharedWith = sharedReportDto.SharedWith,
                    Token = sharedReportDto.Token,
                    URL = sharedReportDto.URL,
                    TinyUrl = sharedReportDto.TinyUrl,
                    SmartReportId = sharedReportDto.SmartReportId,
                    IsActive = true
                };
                sharedReportRepository.Add(sharedReport);
                sharedReportRepository.SaveChanges();
                sharedReportDto.IdSharedReports = sharedReport.IdSharedReports;
                response.SharedResponse = sharedReportDto;
                response.Acknowledgment = true;
                response.Message = "Success";
                sharedReportRepository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error creating the shared Report: " + ex.Message;
            }
            return response;
        }

        public SharedReportResponse GetSharedReportByToken(string token)
        {
            var response = new SharedReportResponse();
            try
            {
                var sharedReportRepository = new SharedReportRepository();
                var sharedReport = sharedReportRepository.Query().FirstOrDefault(x => x.Token == token);
                if (sharedReport != null)
                {
                    response.SharedResponse = new SharedReportDto()
                    {
                        URL = sharedReport.URL
                    };
                }
                sharedReportRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";

            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error getting the shared Report: " + ex.Message;
            }
            return response;
        }

        public SharedReportsResponse GetSharedReportsByUser(int userId)
        {
            var response = new SharedReportsResponse();
            try
            {
                var sharedReportRepository = new SharedReportRepository();
                var userProfileRepository = new UserProfileRepository();
                var sharedReports = sharedReportRepository.Query().Where(x => x.CreatedBy == userId);
                var sharedWithMeReports = sharedReportRepository.Query().Where(x => x.SharedWith == userId);
                response.SharedByMeReports=new List<SharedReportDto>();
                response.SharedWithMeReports=new List<SharedReportDto>();
                foreach (var sharedReport in sharedReports)
                {
                    if (sharedReport.IsActive)
                    {
                        var sharedWith = userProfileRepository.Query().FirstOrDefault(x => x.UserId == sharedReport.SharedWith).UserName;
                        response.SharedByMeReports.Add(new SharedReportDto()
                        {
                            IdSharedReports=sharedReport.IdSharedReports,
                            CreatedBy = sharedReport.CreatedBy,
                            Comments = sharedReport.Comments,
                            CreatorName = sharedReport.UserProfile.UserName,
                            ShareWithName = sharedWith,
                            CreatedDate = sharedReport.CreatedDate,
                            ExpiredDate = sharedReport.ExpiredDate,
                            SharedWith = sharedReport.SharedWith,
                            Token = sharedReport.Token,
                            URL = sharedReport.URL,
                            TinyUrl = sharedReport.TinyUrl,
                            SmartReportId = sharedReport.SmartReportId,
                            IsActive = true,
                            SubscriptionName = sharedReport.SmartReport.ServiceDelivery.ServiceSubscription.SubscriptionName,
                            ReportName=sharedReport.SmartReport.ReportName
                        });
                    }
                }
                foreach (var sharedReport in sharedWithMeReports)
                {
                    if (sharedReport.IsActive)
                    {
                        var sharedWith = userProfileRepository.Query().FirstOrDefault(x => x.UserId == sharedReport.SharedWith).UserName;
                        response.SharedWithMeReports.Add(new SharedReportDto()
                        {
                            IdSharedReports = sharedReport.IdSharedReports,
                            CreatedBy = sharedReport.CreatedBy,
                            Comments = sharedReport.Comments,
                            CreatorName = sharedReport.UserProfile.UserName,
                            ShareWithName = userProfileRepository.Query().FirstOrDefault(x=>x.UserId==sharedReport.SharedWith).UserName,
                            CreatedDate = sharedReport.CreatedDate,
                            ExpiredDate = sharedReport.ExpiredDate,
                            SharedWith = sharedReport.SharedWith,
                            Token = sharedReport.Token,
                            URL = sharedReport.URL,
                            TinyUrl = sharedReport.TinyUrl,
                            SmartReportId = sharedReport.SmartReportId,
                            IsActive = true,
                            SubscriptionName = sharedReport.SmartReport.ServiceDelivery.ServiceSubscription.SubscriptionName,
                            ReportName = sharedReport.SmartReport.ReportName
                        });
                    }
                }
                sharedReportRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";

            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error getting the shared Report: " + ex.Message;
            }
            return response;
        }

        public BaseResponse DeleteSharedReport(int idSharedReport) {
            var response = new SharedReportsResponse();
            try
            {
                var sharedReportRepository = new SharedReportRepository();
                var sharedReport = sharedReportRepository.Query().FirstOrDefault(x => x.IdSharedReports == idSharedReport);
                sharedReport.IsActive = false;
                sharedReportRepository.SaveChanges();
                sharedReportRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";

            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error deleting the shared Report: " + ex.Message;
            }
            return response;
        }
    }
}
