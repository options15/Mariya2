using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariya2
{
    public class ZamerList
    {
        public string CityName { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public int DateDay { get; set; }
        public int DateMounth { get; set; }
        public int DateYear { get; set; }
        public int CountZamer { get; set; }
        public int OstalosZamerov { get; set; }

        public ZamerList(string CityName, string ClientName, string ClientPhone, int DateDay, int DateMounth, int DateYear)
        {
            this.CityName = CityName;
            this.ClientName = ClientName;
            this.ClientPhone = ClientPhone;
            this.DateDay = DateDay;
            this.DateMounth = DateMounth;
            this.DateYear = DateYear;
        }

        public ZamerList(string CityName, int CountZamer, int OstalosZamerov, int DateDay, int DateMounth, int DateYear)
        {
            this.CityName = CityName;
            this.CountZamer = CountZamer;
            this.DateDay = DateDay;
            this.DateMounth = DateMounth;
            this.DateYear = DateYear;
            this.OstalosZamerov = OstalosZamerov;
        }
    }
}
