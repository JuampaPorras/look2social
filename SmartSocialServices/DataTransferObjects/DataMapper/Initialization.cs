using System;
using AutoMapper;
using SmartSocial.Data.V2;

namespace SmartSocialServices.DataTransferObjects.DataMapper
{
    public class Initialization
    {
        public static bool Initialized = false;
        public static void InitialiceMapper()
        {
            try
            {
                //Mapper.CreateMap<ChartComment, ChartCommentDto>().ForMember(x => x.UserName, opt => opt.Ignore()).ForMember(x => x.AspNetUser, opt => opt.Ignore()).IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<ChartSery, ChartSeryDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<ChartType, ChartType>().ForMember(x => x.SmartCharts, opt => opt.Ignore()).ForSourceMember(x=> x.SmartCharts, opt=> opt.Ignore());
                Mapper.CreateMap<Company, CompanyDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<Country, CountryDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<DataProvider, DataProviderDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<DataProviderXChartType, DataProviderXChartTypeDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<DataType, DataTypeDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<SeriesValue, SeriesValueDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<ServiceDelivery, ServiceDeliveryDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<ServiceSubscription, ServiceSubscriptionDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<SmartChart, SmartChartDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<SmartReport, SmartReportDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<SocialPost, SocialPostDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<SocialPostTMP, SocialPostTMPDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<UserProfile, UserProfileDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.CreateMap<UsersXSubscription, UsersXSubscriptionDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                Mapper.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
