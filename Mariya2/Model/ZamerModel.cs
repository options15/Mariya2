using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariya2
{
    public class Zamer
    {
        public int CountOfZamer { get; set; }
        public List<Client> ClientList { get; set; }

        public Zamer(int countOfZamer)
        {
            this.CountOfZamer = countOfZamer;
            ClientList = new List<Client>();
        }
    }
}
