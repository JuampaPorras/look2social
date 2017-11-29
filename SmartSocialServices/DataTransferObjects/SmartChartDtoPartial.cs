using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace SmartSocialServices.DataTransferObjects
{
    public partial class SmartChartDto
    {
        public string ChartTypeName { get; set; }
        public int CommentsCount { get; set; }
    }
}
