using System.Collections.Generic;
using System.Collections;

namespace SmartSocialServices.Objects
{
    public class SeriesObject
    {
        public List<string> groupNames {get; set;}
        public List<Serie> series { get; set;}

        public SeriesObject() {
            series = new List<Serie>();
            groupNames = new List<string>();
        }
    }

    public class Serie {
        public string name { get; set; }
        public ArrayList data { get; set; }
        
        public Serie() {
            data = new ArrayList();

        }
    }
}
