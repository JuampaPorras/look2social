using System;
using System.Linq;
using SmartSocial.Data.V2;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Repositories;
using System.Collections.Generic;

namespace SmartSocialServices.Services
{
    public class ServiceDeliveryService
    {

        public BaseResponse AddServiceDelivery(DateTime dateDelivered,DateTime deliveryDateTo,int idServiceSubscription)
        {
            var response = new BaseResponse();
            try
            {
               var serviceDeliveryRepository = new ServiceDeliveryRepository();
               serviceDeliveryRepository.Add(new ServiceDelivery()
               {
                   DateDelivered = dateDelivered,
                   DeliveryDateTo = deliveryDateTo,
                   IdServiceSubscription = idServiceSubscription
               });
                serviceDeliveryRepository.SaveChanges();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ServiceDeliveryResponse GetServiceSDeliveryById(int serviceDeliveryId)
        {
            var response = new ServiceDeliveryResponse();
            try
            {
                var serviceDeliveryRepository = new ServiceDeliveryRepository();
                var serviceDelivery = serviceDeliveryRepository.Query().FirstOrDefault(x => x.idServiceDelivery == serviceDeliveryId);
                if (serviceDelivery != null)
                {
                    response.ServiceDelivery = new ServiceDeliveryDto()
                    {
                        idServiceDelivery = serviceDelivery.idServiceDelivery,
                        IdServiceSubscription = serviceDelivery.IdServiceSubscription,
                        DateDelivered = serviceDelivery.DateDelivered,
                        DeliveryDateTo = serviceDelivery.DeliveryDateTo
                    };
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Acknowledgment = false;
                    response.Message = "Invalid Delivery Id";
                }
               
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }

            return response;
        }


    }
}
