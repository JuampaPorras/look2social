using SmartSocialServices.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSocialServices.Messaging.Response
{
    public class LeadResponse : BaseResponse
    {
        public LeadDto Lead { get; set; }
    }
}
