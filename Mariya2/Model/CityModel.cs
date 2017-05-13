using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariya2
{
    public class CityModel
    {
        public string CityName { get; set; }
        public Zamer[,,] DateOfZamer { get; set; }
        public CityModel(string CityName)
        {
            this.CityName = CityName;
            DateOfZamer = new Zamer[31, 12, 20];
            ZapolnenieZamerov();
        }

        private void ZapolnenieZamerov()
        {
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    for (int z = 0; z < 19; z++)
                    {
                        Random rnd = new Random();
                        DateOfZamer[x, y, z] = new Zamer(rnd.Next(0, 10));
                    }
                }
            }
        }
    }
}
