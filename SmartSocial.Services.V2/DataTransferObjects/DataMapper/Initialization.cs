using AutoMapper;
using SmartSocial.Data.V2;

namespace SmartSocial.Services.V2.DataTransferObjects.DataMapper
{
    public class Initialization
    {
        public static bool Initialized = false;

        public static void InitialiceMapper()
        {
            Mapper.CreateMap<ChartComment, ChartCommentDto>();
            Mapper.CreateMap<ChartSery, ChartSeryDto>();
            Mapper.CreateMap<Company, CompanyDto>();
            Mapper.CreateMap<Country, CountryDto>();
            Mapper.CreateMap<DataProvider, DataProviderDto>();
            Mapper.CreateMap<DataProviderXChartType, DataProviderXChartTypeDto>();
            Mapper.CreateMap<DataType, DataTypeDto>();
            Mapper.CreateMap<SeriesValue, SeriesValueDto>();
            Mapper.CreateMap<ServiceDelivery, ServiceDeliveryDto>();
            Mapper.CreateMap<ServiceSubscription, ServiceSubscriptionDto>();
            Mapper.CreateMap<SmartChart, SmartChartDto>();
            Mapper.CreateMap<SmartReport, SmartReportDto>();
            Mapper.CreateMap<SocialPost, SocialPostDto>();
            Mapper.CreateMap<SocialPostTMP, SocialPostTMPDto>();
            Mapper.CreateMap<UsersXSubscription, UsersXSubscriptionDto>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
