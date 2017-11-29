using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using SmartSocial.Data.V2;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.DataTransferObjects.DataMapper;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Repositories;

namespace SmartSocialServices.Services
{
    public class CommentsService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static CommentsService() {
            if (!Initialization.Initialized)
            {
                Initialization.InitialiceMapper();
                Initialization.Initialized = true;
            }
        }

        public CommentsResponse GetCommentsByChart(int smartChartId) {
            var response = new CommentsResponse();
            try { 
                var commentRepository = new ChartCommentRepository();
                var userRepository = new UserProfileRepository();
                var comments = commentRepository.Query().Where(x=> x.IdSmartChart == smartChartId && x.IsActive==true).OrderBy(x=> x.DatePosted).Take(25).ToList();
                foreach(var comment in comments){
                    int userId = Convert.ToInt32(comment.IdUser);
                    response.Comments.Add(new ChartCommentDto() {
                        Message = comment.Message,
                        DatePosted = comment.DatePosted,
                        UserName = userRepository.Query().FirstOrDefault(x => x.UserId == userId).UserName,
                        IdComment=comment.IdComment,
                        IdUser=userId.ToString()
                    });
                }

                // CHECK ROLE - IsAppAdmin
                commentRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex) {
                _logger.Error("Error Getting the comments for chartid: " + smartChartId + ". With the exception: " + ex.Message);
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public CommentsResponse DeactivateCommentsByChartId(int userId,int idComment, string[] appRoles)
        {
            var response = new CommentsResponse();
            var isAppAdmin = new List<string>(appRoles).Exists(x => x == "Administrator");
            try
            {
                var commentRepository = new ChartCommentRepository();
                var userRepository = new UserProfileRepository();
                var userXSubscription = new UsersXSubscriptionRepository();

                var comment = commentRepository.Query().FirstOrDefault(x => x.IdComment == idComment);
                var isSubAdmin=userXSubscription.Query().Any(x=>x.IdSubscriptionRoleTypes==1&&x.idSubscription==comment.SmartChart.SmartReport.ServiceDelivery.ServiceSubscription.idServiceSubscription&&x.idUser==userId);
                if (comment.IdUser == userId.ToString() || isAppAdmin || isSubAdmin)
                {
                comment.IsActive = false;
                commentRepository.SaveChanges();
                commentRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
                }
                else
                {
                    _logger.Error("User "+userId+" does not have the right roles to delete this comment " + idComment + " date:" + DateTime.Now.ToString());
                    response.Acknowledgment = false;
                    response.Message = "User " + userId + " does not have the right roles to delete this comment " + idComment + " date:" + DateTime.Now.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error Getting the comment " + idComment + ". With the exception: " + ex.Message);
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public CommentsResponse AddChartComment(ChartCommentDto comment)
        {
            var response = new CommentsResponse();
            try
            {
                var commentRepository = new ChartCommentRepository();
                var userRepository = new UserProfileRepository();
                var newComment = new ChartComment
                {
                    
                    IdUser = comment.IdUser,
                    DatePosted = DateTime.Now,
                    Message = comment.Message,
                    IdSmartChart = comment.IdSmartChart,
                    IsActive=true
                };
                commentRepository.Add(newComment);
                commentRepository.SaveChanges();
                int userId = Convert.ToInt32(comment.IdUser);
                response.Comments.Add(new ChartCommentDto()
                {
                    Message = newComment.Message,
                    DatePosted = newComment.DatePosted,
                    UserName = userRepository.Query().FirstOrDefault(x => x.UserId == userId).UserName,
                    IdComment = newComment.IdComment,
                    IdUser = userId.ToString()
                });
                commentRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                _logger.Error("Error adding comment. With the exception: " + ex.Message);
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

    }
}
