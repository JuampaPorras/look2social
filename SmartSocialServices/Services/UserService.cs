using System;
using System.Collections.Generic;
using System.Linq;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Objects;
using SmartSocialServices.Repositories;
using SmartSocialServices.Utilities;
using System.Web.Security;
using WebMatrix.WebData;
using SmartSocial.Data.V2;
using System.Net.Mail;
using System.Text;

namespace SmartSocialServices.Services
{

    public class UserService
    {
        public UserSubscriptionsReponse GetUserSubscriptionDeliveriesReportsById(int userId)
        {
            var response = new UserSubscriptionsReponse();
            try
            {
                var serviceSubscriptionRepository = new ServiceSubscriptionRepository();
                var userXSubscription = new UsersXSubscriptionRepository();
                var subscriptions = userXSubscription.Query().Where(x => x.idUser == userId).GroupBy(x => x.idSubscription).ToList();
                var subscriptionRoleTypeRepository = new SubscriptionRoleTypeRepository();
                string userRole = "";
                foreach (var subScription in subscriptions)
                {
                    var subObject = subScription.FirstOrDefault(x => x.ServiceSubscription.SubscriptionName != "Guest");
                    if (subObject != null)
                    {
                        var userSubscriptionObject = new UserSubscriptionsObjects();
                        var serviceSubscritionElement = serviceSubscriptionRepository.Query().Where(x => x.idServiceSubscription == subObject.idSubscription && x.IsActive == true).FirstOrDefault();

                        var subscriptionRoleType = subscriptionRoleTypeRepository.Query().FirstOrDefault(x => x.IdSubscriptionRoleTypes == subObject.IdSubscriptionRoleTypes);
                        if (subscriptionRoleType != null)
                            userRole = subscriptionRoleType.RoleName;

                        if (serviceSubscritionElement != null)
                        {
                            userSubscriptionObject.ServiceSubscription = new ServiceSubscriptionDto()
                            {
                                idServiceSubscription = serviceSubscritionElement.idServiceSubscription,
                                SubscriptionName = serviceSubscritionElement.SubscriptionName,
                                SubscriptionRoleName = userRole
                            };
                            userSubscriptionObject.Reports = GetLeftNav(serviceSubscritionElement.idServiceSubscription);
                            response.UserSubscriptionsObjects.Add(userSubscriptionObject);
                        }

                    }
                }
                response.ShareWithMe = GetReportsSharedWithMe(userId);
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }
        public ProfileSettingsResponse GetProfileSettingsByUserId(int userId)
        {
            var response = new ProfileSettingsResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var userXsubscriptionRepository = new UsersXSubscriptionRepository();
                var subscriptionRoleTypeRepository = new SubscriptionRoleTypeRepository();
                var serviceSubscriptionRepository = new ServiceSubscriptionRepository();

                string userRole = "Admin - Provisional";
                string businessType = "";
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);
                var usersXsubscription = userXsubscriptionRepository.Query().FirstOrDefault(x => x.idUser == userId);

                if (usersXsubscription != null)
                {
                    if (usersXsubscription.IdSubscriptionRoleTypes != null)
                    {
                        var subscriptionRoleType = subscriptionRoleTypeRepository.Query().FirstOrDefault(x => x.IdSubscriptionRoleTypes == usersXsubscription.IdSubscriptionRoleTypes);
                        if (subscriptionRoleType != null)
                            userRole = subscriptionRoleType.RoleName;
                    }
                    var serviceSubscriptionResult = serviceSubscriptionRepository.Query().FirstOrDefault(x => x.idServiceSubscription == usersXsubscription.idSubscription);
                    businessType = new SubscriptionService().GetSubscriptionProductName(int.Parse(serviceSubscriptionResult.idChargifySuscription));
                }
                response.UserProfile = new UserProfileDto()
                {
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    Phone = userProfile.Phone,
                    CountryCode = userProfile.CountryCode,
                    UserName = userProfile.UserName,
                    SubscriptionRoleName = userRole,
                    BusinessType = businessType
                };
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }
        public ProfileSettingsResponse GetUserInSubsById(int userId, int subsId)
        {
            var response = new ProfileSettingsResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var userXsubscriptionRepository = new UsersXSubscriptionRepository();
                var subscriptionRoleTypeRepository = new SubscriptionRoleTypeRepository();
                var serviceSubscriptionRepository = new ServiceSubscriptionRepository();

                List<RoleActive> userRole = new List<RoleActive>();
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);
                var usersXsubscription = userXsubscriptionRepository.Query().Where(x => x.idUser == userId && x.idSubscription == subsId);

                response.UserProfile = new UserProfileDto()
                {
                    UserId = userId,
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    Phone = userProfile.Phone,
                    CountryCode = userProfile.CountryCode,
                    UserName = userProfile.UserName,
                };

                if (usersXsubscription != null)
                {
                    foreach (var role in subscriptionRoleTypeRepository.Query())
                    {
                        response.UserProfile.RolesInSubscription.Add(new RoleActive()
                        {
                            RoleName = role.RoleName,
                            RoleId = role.IdSubscriptionRoleTypes,
                            isActive = usersXsubscription.Where(x => x.IdSubscriptionRoleTypes == role.IdSubscriptionRoleTypes && x.IsActive == true).Count() > 0
                        });

                    }
                }
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }
        public ProfileSettingsResponse GetUserInfoByIdWithRoles(int userId, int subsId)
        {
            var response = new ProfileSettingsResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var userXsubscriptionRepository = new UsersXSubscriptionRepository();
                var subscriptionRoleTypeRepository = new SubscriptionRoleTypeRepository();
                var serviceSubscriptionRepository = new ServiceSubscriptionRepository();

                List<RoleActive> userRole = new List<RoleActive>();
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);
                if (userXsubscriptionRepository.Query().Where(x => x.idUser == userId && x.idSubscription == subsId).Count() > 0)
                {
                    response.Acknowledgment = false;
                    response.Message = "User already in subscription";
                }
                else
                {

                    response.UserProfile = new UserProfileDto()
                    {
                        UserId = userId,
                        FirstName = userProfile.FirstName,
                        LastName = userProfile.LastName,
                        Phone = userProfile.Phone,
                        CountryCode = userProfile.CountryCode,
                        UserName = userProfile.UserName,
                    };

                    foreach (var role in subscriptionRoleTypeRepository.Query())
                    {
                        response.UserProfile.RolesInSubscription.Add(new RoleActive()
                        {
                            RoleName = role.RoleName,
                            RoleId = role.IdSubscriptionRoleTypes,
                            isActive = role.RoleName == "User"
                        });

                    }
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public RolesInSubscriptionReponse GetSubscriptionRoles(int subscriptionId)
        {
            var response = new RolesInSubscriptionReponse();
            try
            {
                var subscriptionRoleTypeRepository = new SubscriptionRoleTypeRepository();
                foreach (var role in subscriptionRoleTypeRepository.Query())
                {
                    response.RolesInSubscription.Add(new RoleActive()
                    {
                        RoleName = role.RoleName,
                        RoleId = role.IdSubscriptionRoleTypes,
                        isActive = role.RoleName == "User"
                    });

                }
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }


        public BaseResponse UpdateProfileSettings(int userId, string pFirstName, string pLastName, int pPhone, string pCountryCode)
        {
            var response = new BaseResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);

                userProfile.FirstName = pFirstName;
                userProfile.LastName = pLastName;
                userProfile.Phone = pPhone;
                userProfile.CountryCode = pCountryCode;
                userProfileRepository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }





        public BaseResponse DeactivateUserId(int userId)
        {
            var response = new ProfileSettingsResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);
                response.UserProfile = new UserProfileDto()
                {
                    IsActive = false
                };
                userProfileRepository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public BaseResponse DeactivateUserFromSub(int userId, int subId)
        {
            var response = new ProfileSettingsResponse();
            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var userRoles = userXSubsRespository.Query().Where(x => x.idUser == userId && x.idSubscription == subId);
                foreach (var userRole in userRoles)
                {
                    userXSubsRespository.Delete(userRole);
                }
                userXSubsRespository.SaveChanges();
                userXSubsRespository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        /* public List<ServiceDeliveryDto> GetDeliveriesBySubscription(int subScriptionId,int userId)
         {
             var response = new List<ServiceDeliveryDto>();
             try {
                var serviceDeliveryRepository = new ServiceDeliveryRepository();
                var deliveries = serviceDeliveryRepository.Query().Where(x => x.IdServiceSubscription == subScriptionId).OrderByDescending(x=>x.DateDelivered).ToList();
                foreach (var delivery in deliveries) {
                    response.Add(new ServiceDeliveryDto() { 
                        idServiceDelivery = delivery.idServiceDelivery,
                        DateDelivered = delivery.DateDelivered,
                        Insights = delivery.Insights,
                        SmartReports = GetSmartReportsByDelivery(delivery.idServiceDelivery,userId)

                    });
                }
                serviceDeliveryRepository.Dispose();
             }
             catch (Exception ex) { 

             }
             return response;
         }*/



        /*public List<SmartReportDto> GetSmartReportsByDelivery(int deliveryId,int userId) {
            var response = new List<SmartReportDto>();
            try {
                var smartReportRepository = new SmartReportRepository();
                var reports = smartReportRepository.Query().Where(x => x.idServiceDelivery == deliveryId).ToList();
                foreach(var report in reports){
                    response.Add(new SmartReportDto() { 
                        idSmartReport = report.idSmartReport,
                        ReportName = report.ReportName,
                        Insights = report.Insights,
                        DateCreated = report.DateCreated,
                        IsShared = false
                    });
                }
                response.AddRange(GetReportsSharedWithMe(userId));
                smartReportRepository.Dispose();
            }
            catch (Exception ex)
            {

            }
            return response;
        }*/

        public List<LeftNavReportObject> GetReportsSharedWithMe(int userId)
        {
            var response = new List<LeftNavReportObject>();
            var sharedReportRepository = new SharedReportRepository();
            var smartReportRepository = new SmartReportRepository();
            var deliveryRepository = new ServiceDeliveryRepository();
            try
            {
                var sharedReports = sharedReportRepository.Query().Where(x => x.SharedWith == userId).ToList();

                foreach (var sharedReport in sharedReports)
                {
                    var report = smartReportRepository.Query().FirstOrDefault(x => x.idSmartReport == sharedReport.SmartReportId);
                    var reportName = report.ReportName + " (" + report.ServiceDelivery.ServiceSubscription.SubscriptionName + ")";
                    var currentReport = response.FirstOrDefault(x => x.ReportName == reportName);
                    if (currentReport != null)
                    {
                        currentReport.Items.Add(new LeftNavItemObject()
                        {
                            DeliveryDate = report.ServiceDelivery.DateDelivered.Value.ToShortDateString(),
                            ReportId = report.idSmartReport
                        });
                    }
                    else
                    {
                        var newReport = new LeftNavReportObject()
                        {
                            ReportName = reportName,
                            Items = new List<LeftNavItemObject>()
                        };
                        newReport.Items.Add(new LeftNavItemObject()
                        {
                            DeliveryDate = report.ServiceDelivery.DateDelivered.Value.ToShortDateString(),
                            ReportId = report.idSmartReport
                        });
                        response.Add(newReport);
                    }

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sharedReportRepository.Dispose();
                smartReportRepository.Dispose();
            }
            return response;

        }

        public UserResponse GetUserInformation(int userId)
        {
            var response = new UserResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var companyRepository = new CompanyRepository();
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);

                if (userProfile != null)
                {
                    if (userProfile.LastReportId != null)
                    {
                        response.userLastReportId = Convert.ToInt32(userProfile.LastReportId);
                    }
                    else
                    {
                        response.userLastReportId = 0;
                    }
                    response.User = new UserProfileDto()
                    {
                        UserName = userProfile.UserName,
                        UserId = userProfile.UserId
                    };


                    var companyInformation = companyRepository.Query().FirstOrDefault(x => x.IdCompany == userProfile.CompanyId);
                    if (companyInformation != null)
                    {
                        response.CompanyInformation = new CompanyDto()
                        {
                            IdCompany = companyInformation.IdCompany,
                            CompanyName = companyInformation.CompanyName,
                            LogoFileName = companyInformation.LogoFileName
                        };
                        response.Acknowledgment = true;
                        response.Message = "Success";
                    }
                    else
                    {
                        response.Acknowledgment = false;
                        response.Message = "User Doesnt have a valid company Id";
                    }
                }
                else
                {
                    response.Acknowledgment = false;
                    response.Message = "Inavlid user Profile";
                }
                userProfileRepository.Dispose();
                companyRepository.Dispose();


            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public UserResponse GetBillingPortal(int userId)
        {
            var response = new UserResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var companyRepository = new CompanyRepository();
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);
                var subscriptionService = new SubscriptionService();

                if (userProfile != null)
                {
                    response.BillingPortalUrl = subscriptionService.GetBillingPortal(userProfile.ChargifyCustomerId.Value);
                }
                userProfileRepository.Dispose();
                response.Acknowledgment = true;
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public MainPageResponse GetMainPageInfo(int userId, string[] roles, string userName)
        {
            var response = new MainPageResponse();
            try
            {
                var subscriptionService = new SubscriptionService();
                var userXSubscription = new UsersXSubscriptionRepository();
                var subscriptions = userXSubscription.Query().Where(x => x.idUser == userId && x.IdSubscriptionRoleTypes != 3).GroupBy(x => x.idSubscription).ToList();
                var guestCompany = GetCompanyByName("Guest");
                var isTrialEnded = false;
                var isTrialEnding = false;
                if (subscriptions.Count > 0)
                {
                    var trialEnd = subscriptionService.getTrialEnding(userId);
                    switch (DateTime.Now.CompareTo(trialEnd))
                    {
                        case -1:
                            isTrialEnded = false;
                              var trialEnding = trialEnd.AddDays(-5);
                              switch (DateTime.Now.CompareTo(trialEnding))
                            {
                                case -1:
                                    isTrialEnding = false;
                                    break;
                                case 0:
                                    isTrialEnding = true;
                                    break;
                                default:
                                    isTrialEnding = true;
                                    break;
                            }
                            break;
                        case 0:
                            isTrialEnded = true;
                            break;
                        default:
                            isTrialEnded = true;
                            break;
                    }
                }
                response.userResponse = GetUserInformation(userId);
                response.isGuest = subscriptions.Count == 0;
                response.billingPortalLink = GetBillingPortal(userId).BillingPortalUrl;
                response.userSubscriptionsReponse = GetUserSubscriptionDeliveriesReportsById(userId);
                response.isTrialEnding = isTrialEnding;
                response.isTrialEnded = isTrialEnded;
                response.Acknowledgment = true;
                response.SystemRoles = roles;
                response.UserName = userName;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public BaseResponse UpdateLastReport(int userId, int reportId)
        {
            var response = new MainPageResponse();
            try
            {
                var userProfileRepository = new UserProfileRepository();
                var userProfile = userProfileRepository.Query().FirstOrDefault(x => x.UserId == userId);
                userProfile.LastReportId = reportId;
                userProfileRepository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
                userProfileRepository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public UserResponse SearchUsersByEmail(string email)
        {
            var response = new UserResponse();
            var userProfileRepository = new UserProfileRepository();
            try
            {
                var users = userProfileRepository.Query().Where(x => x.UserName.Contains(email)).ToList();
                foreach (var user in users)
                {
                    response.Users.Add(new UserProfileDto()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName
                    });
                }
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error searching for an user: " + ex.Message;

            }
            return response;
        }

        public BaseResponse InviteUser(string email, List<SharedReportDto> shareReportDtos, string urlToValidateUser, string comment, string ranges, string reportName, bool sendMeACopy)
        {
            var response = new BaseResponse();
            var shareService = new ShareReportService();
            var userService = new UserService();
            var shareReportRepository = new SharedReportRepository();
            try
            {
                var accountCreator = GetUserInformation(shareReportDtos[0].CreatedBy);
                var existingUser = SearchUsersByEmail(email).Users;
                if (existingUser.Count > 0)
                {
                    var existingUserId = existingUser.FirstOrDefault().UserId;
                    var myCurrentSharedReports = shareReportRepository.Query().Where(x => x.SharedWith == existingUserId).ToList();
                    foreach (var shareReportDto in shareReportDtos)
                    {
                        var report = myCurrentSharedReports.FirstOrDefault(x => x.SmartReportId == shareReportDto.SmartReportId);
                        if (report == null)
                        {
                            shareReportDto.SharedWith = existingUserId;
                            var result = shareService.AddSharedReport(shareReportDto);
                            if (!result.Acknowledgment)
                            {
                                response.Acknowledgment = false;
                                response.Message = result.Message;
                                return response;
                            }
                        }
                    }
                    response.Acknowledgment = true;
                    response.Message = "Report added to an existing user";
                    SendAccountInvitationEmail(email, accountCreator.User.UserName, reportName, ranges, comment, urlToValidateUser + "/Home/Main#/MainReport/" + shareReportDtos[0].SmartReportId, sendMeACopy);
                    return response;

                }

                var guestCompany = GetCompanyByName("Guest");
                var guestSubscription = GetSubscriptionByName("Guest");
                var recentCreatedUser = CreateUserAndAccount(email, "", guestCompany.IdCompany, "", "", null, "");
                string token = WebSecurity.GeneratePasswordResetToken(email);
                if (recentCreatedUser.Acknowledgment)
                {
                    if (guestSubscription != null)
                    {
                        var resultAddingSubscription = AddUserXSubscription(guestSubscription.idServiceSubscription, recentCreatedUser.User.UserId);
                        if (resultAddingSubscription.Acknowledgment)
                        {
                            foreach (var shareReportDto in shareReportDtos)
                            {
                                shareReportDto.SharedWith = recentCreatedUser.User.UserId;
                                shareService.AddSharedReport(shareReportDto);
                                userService.UpdateLastReport(recentCreatedUser.User.UserId, shareReportDto.SmartReportId);
                            }
                            SendAccountInvitationEmail(recentCreatedUser.User.UserName, accountCreator.User.UserName, reportName, ranges, comment, urlToValidateUser + "Account/Invite?token=" + token, sendMeACopy);
                        }
                    }
                }
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch
            {
            }

            return response;
        }

        public UserResponse CreateUserAndAccount(string email, string password, int companyId, string firstName, string lastName, int? phone, string countryCode, int CustomerId = 0)
        {
            var response = new UserResponse();
            try
            {
                var userRepository = new UserProfileRepository();
                if (string.IsNullOrEmpty(password))
                {
                    password = PasswordUtility.GeneratePassword();
                }
                WebSecurity.CreateUserAndAccount(email, password, null, false);
                WebSecurity.GeneratePasswordResetToken(email);
                var user = userRepository.Query().FirstOrDefault(x => x.UserName == email);
                if (user != null)
                {
                    user.CompanyId = companyId;
                    user.ChargifyCustomerId = CustomerId;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.Phone = phone;
                    user.CountryCode = countryCode;
                    response.User = new UserProfileDto()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                    };
                    userRepository.SaveChanges();
                    response.Acknowledgment = true;
                    response.Message = "sucess";
                }
                else
                {
                    response.Acknowledgment = false;
                    response.Message = "User not Found";
                }
                Roles.AddUserToRole(user.UserName, "User");

                userRepository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponse AddNexUserXSubscription(string email, int adminUserId, string firstName, string lastName, int phone, string countryCode, int subscriptionId, int[] roleIds, string urlValid)
        {
            var response = new UserResponse();
            try
            {
                var userProfileRespository = new UserProfileRepository();
                var subscriptionRespository = new ServiceSubscriptionRepository();
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var adminUser = userProfileRespository.Query().FirstOrDefault(x => x.UserId == adminUserId);
                var newUser = CreateUserAndAccount(email, "", adminUser.Company.IdCompany, firstName, lastName, phone, countryCode);
                var subscription = subscriptionRespository.Query().FirstOrDefault(x => x.idServiceSubscription == subscriptionId);
                var token = WebSecurity.GeneratePasswordResetToken(email);
                SendSubscriptionInvitationEmail(email, adminUser.UserName, subscription.SubscriptionName, urlValid + "/Account/Invite?token=" + token);
                foreach (var roleId in roleIds)
                {
                    var newUserXSubs = new UsersXSubscription()
                    {
                        idSubscription = subscriptionId,
                        idUser = newUser.User.UserId,
                        DateCreated = DateTime.Now,
                        IdSubscriptionRoleTypes = roleId,
                        IsActive = true
                    };
                    userXSubsRespository.Add(newUserXSubs);
                    userXSubsRespository.SaveChanges();
                }
                response.Acknowledgment = true;
                response.Message = "Success";
                response.User.UserId = newUser.User.UserId;
                userXSubsRespository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public BaseResponse AddUserXSubscription(int userId, int adminId, int subscriptionId, int[] roleIds)
        {
            var response = new BaseResponse();
            try
            {
                var userProfileRespository = new UserProfileRepository();
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var subscriptionRespository = new ServiceSubscriptionRepository();
                var adminUser = userProfileRespository.Query().FirstOrDefault(x => x.UserId == adminId);
                var newUserInSub = userProfileRespository.Query().FirstOrDefault(x => x.UserId == userId);
                var subscription = subscriptionRespository.Query().FirstOrDefault(x => x.idServiceSubscription == subscriptionId);
                SendSubscriptionAddedEmail(newUserInSub.UserName, adminUser.UserName, subscription.SubscriptionName);
                foreach (var roleId in roleIds)
                {
                    var newUserXSubs = new UsersXSubscription()
                    {
                        idSubscription = subscriptionId,
                        idUser = userId,
                        DateCreated = DateTime.Now,
                        IdSubscriptionRoleTypes = roleId,
                        IsActive = true
                    };
                    userXSubsRespository.Add(newUserXSubs);
                    userXSubsRespository.SaveChanges();
                }
                response.Acknowledgment = true;
                response.Message = "Success";
                userXSubsRespository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponse AddUserXSubscription(int subscriptionId, int userId)
        {
            var response = new BaseResponse();
            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var newUserXSubs = new UsersXSubscription()
                {
                    idSubscription = subscriptionId,
                    idUser = userId,
                    DateCreated = DateTime.Now,
                    IdSubscriptionRoleTypes = 3,
                    IsActive = true
                };
                userXSubsRespository.Add(newUserXSubs);
                userXSubsRespository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
                userXSubsRespository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponse AddAdminXSubscription(int subscriptionId, int userId)
        {
            var response = new BaseResponse();
            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var newUserXSubs = new UsersXSubscription()
                {
                    idSubscription = subscriptionId,
                    idUser = userId,
                    DateCreated = DateTime.Now,
                    IdSubscriptionRoleTypes = 1,
                    IsActive = true
                };
                userXSubsRespository.Add(newUserXSubs);
                userXSubsRespository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
                userXSubsRespository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public List<UsersXSubscriptionDto> GetUserSubscription(int userId)
        {
            var response = new List<UsersXSubscriptionDto>();

            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var result = userXSubsRespository.Query().Where(x => x.idUser == userId).ToList();
                if (result.Count > 0)
                {
                    foreach (var subscription in result)
                    {
                        response.Add(new UsersXSubscriptionDto()
                        {
                            idSubscription = subscription.idSubscription,
                            idUser = subscription.idUser,
                            DateCreated = subscription.DateCreated
                        });

                    }
                }
                userXSubsRespository.Dispose();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //TODO
            }
            return response;
        }

        public BaseResponse AddRoleUserSubscription(int userId, int subscriptionId, int roleId)
        {
            var response = new BaseResponse();

            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var newUserXSubs = new UsersXSubscription()
                {
                    idSubscription = subscriptionId,
                    idUser = userId,
                    DateCreated = DateTime.Now,
                    IdSubscriptionRoleTypes = roleId
                };

                userXSubsRespository.Add(newUserXSubs);
                userXSubsRespository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
                userXSubsRespository.Dispose();
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponse UpdateRoleUserSubscription(int userId, int subscriptionId, int roleId)
        {
            var response = new UserSubscriptionsReponse();

            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var userXSub = userXSubsRespository.Query().FirstOrDefault(x => x.idUser == userId && x.idSubscription == subscriptionId);

                if (userXSub != null)
                {
                    userXSub.IdSubscriptionRoleTypes = roleId;
                    //response.UsersXSubscription = new UsersXSubscriptionDto()
                    //{
                    //    IdSubscriptionRoleTypes = roleId,
                    //};
                }

                userXSubsRespository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //TODO
            }
            return response;
        }

        public BaseResponse DeactivateRoleUserSubscription(int userId, int subscriptionId, int roleId, bool activate)
        {
            var response = new UserSubscriptionsReponse();

            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var userXSub = userXSubsRespository.Query().FirstOrDefault(x => x.idUser == userId && x.idSubscription == subscriptionId && x.IdSubscriptionRoleTypes == roleId);

                if (userXSub != null)
                {
                    response.UsersXSubscription = new UsersXSubscriptionDto()
                    {
                        IsActive = activate
                    };
                }

                userXSubsRespository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //TODO
            }
            return response;
        }

        public BaseResponse EditRolesUserSubscription(int userId, int subscriptionId, int[] rolesId)
        {
            var response = new UserSubscriptionsReponse();

            try
            {
                var userXSubsRespository = new UsersXSubscriptionRepository();
                var usersXSub = userXSubsRespository.Query().Where(x => x.idUser == userId && x.idSubscription == subscriptionId);
                foreach (var userxSub in usersXSub)
                {
                    userXSubsRespository.Delete(userxSub);

                }
                foreach (var roleId in rolesId)
                {
                    var newUserXSubs = new UsersXSubscription()
                    {
                        idSubscription = subscriptionId,
                        idUser = userId,
                        DateCreated = DateTime.Now,
                        IdSubscriptionRoleTypes = roleId,
                        IsActive = true
                    };
                    userXSubsRespository.Add(newUserXSubs);
                    userXSubsRespository.SaveChanges();
                }
                userXSubsRespository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //TODO
            }
            return response;
        }




        public UserProfileDto GetUserByResetToken(string token)
        {
            var response = new UserProfileDto();
            try
            {
                var membershipRepository = new WebMembershipRepository();
                var membershipInformation = membershipRepository.Query().FirstOrDefault(x => x.PasswordVerificationToken == token);
                if (membershipInformation != null)
                {
                    response = GetUserInformation(membershipInformation.UserId).User;
                }
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }

        public BaseResponse AdminCreateUser(string email, int idCompany, string urlToValidateUser)
        {
            var response = new BaseResponse();
            var shareService = new ShareReportService();

            try
            {
                var existingUser = SearchUsersByEmail(email).Users;
                if (existingUser.Count > 0)
                {

                    response.Acknowledgment = false;
                    response.Message = "User Already Exist";
                    return response;
                }

                var recentCreatedUser = CreateUserAndAccount(email, "", idCompany, "", "", null, "");
                string token = WebSecurity.GeneratePasswordResetToken(email);
                if (recentCreatedUser.Acknowledgment)
                {

                    var resultAddingSubscription = AddUserXSubscription(idCompany, recentCreatedUser.User.UserId);
                    if (resultAddingSubscription.Acknowledgment)
                    {
                        SendAdminAccountInvitationEmail(recentCreatedUser.User.UserName, urlToValidateUser + token);
                    }


                }
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch
            {
            }

            return response;
        }

        public bool TrialCreateUser(string email, int idCompany, string urlToValidateUser, int suscriptionId, int CustomerId, int dbSubscriptionId)
        {
            var response = new BaseResponse();
            var shareService = new ShareReportService();
            int userId = 0;

            try
            {
                // Create Edit User
                var existingUser = SearchUsersByEmail(email).Users;
                if (existingUser.Count > 0)
                {

                    userId = existingUser.FirstOrDefault().UserId;
                }
                else
                {
                    var recentCreatedUser = CreateUserAndAccount(email, "", idCompany, "", "", null, "", CustomerId);
                    if (recentCreatedUser.Acknowledgment)
                    {
                        userId = recentCreatedUser.User.UserId;
                    }
                }

                var resultAddingSubscription = AddAdminXSubscription(dbSubscriptionId, userId);
                if (resultAddingSubscription.Acknowledgment)
                {
                    return resultAddingSubscription.Acknowledgment;
                }

            }
            catch
            {
                return false;
            }

            return true;
        }

        public BaseResponse ForgotPassword(string email, string urlToForApplication)
        {
            var response = new BaseResponse();
            try
            {
                var existingUser = SearchUsersByEmail(email).Users;
                if (existingUser.Count > 0)
                {
                    string token = WebSecurity.GeneratePasswordResetToken(email);
                    token = urlToForApplication + "Account/Invite?token=" + token;
                    SendForgotPasswordEmail(email, token);
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Acknowledgment = true;
                    response.Message = "Invalid email address";
                }

            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error " + ex.Message;
            }
            return response;
        }

        public static void SendAccountInvitationEmail(string email, string creatorEmail, string reportName, string ranges, string comments, string confirmation, bool sendMeACopy)
        {
            try
            {
                string html = Resource.AccountInvitation.ToString(); //File.ReadAllText("~/HtmlEmails/LeadConfirmation.html");
                html = html.Replace("<creatorEmail>", creatorEmail);
                html = html.Replace("<reportName>", reportName);
                html = html.Replace("<reportRanges>", ranges);
                html = html.Replace("<comment>", comments);
                html = html.Replace("<invitationUrl>", confirmation);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                if (sendMeACopy)
                {
                    message.CC.Add(new MailAddress(creatorEmail));
                }
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social -- Invitation to join";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = html;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void SendForgotPasswordEmail(string email, string token)
        {
            try
            {

                string html = Resource.ForgotPassword.ToString(); //File.ReadAllText("~/HtmlEmails/LeadConfirmation.html");
                var withname = html.Replace("<creatorEmail>", email);
                var finalHtml = withname.Replace("<invitationUrl>", token);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social -- Forgotten Password";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = finalHtml;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void SendAdminAccountInvitationEmail(string email, string confirmation)
        {
            try
            {

                string html = Resource.AccountInvitation.ToString(); //File.ReadAllText("~/HtmlEmails/LeadConfirmation.html");
                var withname = html.Replace("<creatorEmail>", "SmartSocial Administrator");
                var finalHtml = withname.Replace("<invitationUrl>", confirmation);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social -- Invitation to join";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = finalHtml;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public static void SendSubscriptionInvitationEmail(string email, string admin, string subscriptionName, string passwordLink)
        {
            try
            {

                string html = Resource.SubscritionInvitation.ToString();
                html = html.Replace("<subscriptionName>", subscriptionName);
                html = html.Replace("<creatorEmail>", email);
                html = html.Replace("<adminEmail>", admin);
                html = html.Replace("<passwordLink>", passwordLink);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social -- Subscription Invitation";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = html;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void SendSubscriptionAddedEmail(string email, string admin, string subscriptionName)
        {
            try
            {

                string html = Resource.SubscritionAdded.ToString();
                html = html.Replace("<subscriptionName>", subscriptionName);
                html = html.Replace("<creatorEmail>", email);
                html = html.Replace("<adminEmail>", admin);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social -- Subscription Invitation";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = html;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public List<LeftNavReportObject> GetLeftNav(int subscriptionId)
        {
            var response = new List<LeftNavReportObject>();
            var smartChartRepository = new SmartChartRepository();
            var deliveryRepository = new ServiceDeliveryRepository();
            var smartReportRepository = new SmartReportRepository();
            try
            {
                var reportTemplates = smartReportRepository.Query().Where(x => x.isTemplate == true).OrderBy(x => x.ReportName).ToList();
                var deliveriesBySubscription = deliveryRepository.Query().Where(x => x.IdServiceSubscription == subscriptionId).OrderByDescending(x => x.DateDelivered).ToList();
                foreach (var reportTemplate in reportTemplates)
                {
                    var leftnavreport = new LeftNavReportObject();
                    leftnavreport.ReportName = reportTemplate.ReportName;
                    foreach (var delivery in deliveriesBySubscription)
                    {
                        var reports = delivery.SmartReports.Where(x => x.ReportName == reportTemplate.ReportName).ToList();
                        foreach (var report in reports)
                        {
                            leftnavreport.Items.Add(new LeftNavItemObject()
                            {
                                ReportId = report.idSmartReport,
                                DeliveryDate = delivery.DateDelivered.Value.ToShortDateString()
                            });
                        }

                    }
                    if (leftnavreport.Items.Count > 0)
                    {
                        response.Add(leftnavreport);
                    }
                }
                smartChartRepository.Dispose();
                deliveryRepository.Dispose();
                smartReportRepository.Dispose();
            }
            catch (Exception ex)
            {
            }
            return response;
        }

        protected CompanyDto GetCompanyByName(string companyName)
        {
            var response = new CompanyDto();
            try
            {
                var companyRepository = new CompanyRepository();
                var company = companyRepository.Query().FirstOrDefault(x => x.CompanyName == companyName);
                if (company != null)
                {
                    response = new CompanyDto()
                    {
                        CompanyName = company.CompanyName,
                        IdCompany = company.IdCompany,
                        LogoFileName = company.LogoFileName
                    };
                }
                companyRepository.Dispose();
            }
            catch (Exception e)
            {
                //TODO
            }
            return response;
        }

        protected ServiceSubscriptionDto GetSubscriptionByName(string subscriptionName)
        {
            var response = new ServiceSubscriptionDto();
            try
            {
                var subscriptionRepository = new ServiceSubscriptionRepository();
                var subscription = subscriptionRepository.Query().FirstOrDefault(x => x.SubscriptionName == subscriptionName);
                if (subscription != null)
                {
                    response = new ServiceSubscriptionDto()
                    {
                        idServiceSubscription = subscription.idServiceSubscription,
                        SubscriptionName = subscription.SubscriptionName
                    };
                }
                subscriptionRepository.Dispose();

            }
            catch (Exception e)
            {
                //TODO
            }
            return response;
        }

        public List<UserProfileDto> GetUsersPerSubscriptionId(int subscriptionId, int userId)
        {
            var response = new List<UserProfileDto>();
            try
            {
                var userXsubscriptionRepository = new UsersXSubscriptionRepository();
                var userProfileRespository = new UserProfileRepository();
                var subscriptionRoleTypeRepository = new SubscriptionRoleTypeRepository();
                string userRole = "";
                var usersXsubscription = userXsubscriptionRepository.Query().Where(x => x.idSubscription == subscriptionId && x.idUser != userId).GroupBy(x => x.idUser).ToList();
                if (usersXsubscription != null)
                {
                    var order = 0;
                    foreach (var userInSubscription in usersXsubscription)
                    {
                        var currentUser = userInSubscription.FirstOrDefault();
                        var userProfile = userProfileRespository.Query().FirstOrDefault(x => x.UserId == currentUser.idUser);
                        if (userProfile != null)
                        {
                            //var subscriptionRoleType = subscriptionRoleTypeRepository.Query().Where(x => x.IdSubscriptionRoleTypes == currentUser.IdSubscriptionRoleTypes);
                            foreach (var roles in subscriptionRoleTypeRepository.Query())
                            {
                                if (userInSubscription.Any(x => x.IdSubscriptionRoleTypes == roles.IdSubscriptionRoleTypes && x.IsActive == true))
                                {
                                    userRole += roles.RoleName + " ";
                                }
                            }
                            //userRole.Remove(userRole.Length - 1);

                            response.Add(new UserProfileDto()
                            {
                                UserId = userProfile.UserId,
                                Phone = userProfile.Phone,
                                UserName = userProfile.UserName,
                                FirstName = userProfile.FirstName,
                                LastName = userProfile.LastName,
                                CompanyId = userProfile.CompanyId,
                                SubscriptionRoleName = userRole,
                                Order = order
                            });
                            userRole = "";
                            order++;
                        }
                    }
                }
                userXsubscriptionRepository.Dispose();
                userProfileRespository.Dispose();

            }
            catch (Exception e)
            {
                //TODO
            }
            return response;
        }




        public List<ServiceSubscriptionDto> GetSubscriptions(int userId)
        {
            var response = new List<ServiceSubscriptionDto>();
            string businessType = "";
            string userRole = "";
            try
            {
                var userXsubscriptionRepository = new UsersXSubscriptionRepository();
                var subscriptionRoleTypeRepository = new SubscriptionRoleTypeRepository();
                var usersXsubscription = userXsubscriptionRepository.Query().Where(x => x.idUser == userId && x.IdSubscriptionRoleTypes == 1).ToList(); // 1 == admin
                if (usersXsubscription != null)
                {
                    foreach (var userInSubscription in usersXsubscription)
                    {
                        var subscription = userInSubscription.ServiceSubscription;
                        businessType = new SubscriptionService().GetSubscriptionProductName(int.Parse(subscription.idChargifySuscription));
                        //var subscriptionRoleType = subscriptionRoleTypeRepository.Query().FirstOrDefault(x => x.IdSubscriptionRoleTypes == userInSubscription.IdSubscriptionRoleTypes);
                        //if (subscriptionRoleType != null)
                        //userRole = subscriptionRoleType.RoleName;

                        if (subscription != null && subscription.IsActive.Equals(true))
                        {
                            response.Add(new ServiceSubscriptionDto()
                            {
                                idServiceSubscription = subscription.idServiceSubscription,
                                SubscriptionName = subscription.SubscriptionName,
                                StartDate = subscription.StartDate,
                                EndDate = subscription.EndDate,
                                BusinessType = businessType,
                                SubscriptionRoleName = userRole
                            });
                        }
                    }
                }
                userXsubscriptionRepository.Dispose();

            }
            catch (Exception e)
            {
                //TODO
            }
            return response;
        }


    }
}
