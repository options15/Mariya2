using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariya2
{
    public class Client
    {
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }

        public Client(string clientName, string clientPhone)
        {
            this.ClientName = clientName;
            this.ClientPhone = clientPhone;
        }
    }
}
