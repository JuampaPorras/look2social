using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSocialServices.Objects
{
    public class LeftNavReportObject
    {
        public string ReportName { get; set; }
        public List<LeftNavItemObject> Items { get; set; }

        public LeftNavReportObject() {
            Items = new List<LeftNavItemObject>();
        }

    }
}
