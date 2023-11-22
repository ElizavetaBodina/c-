using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_5
{
    internal class Planet
    {
        [DisplayName("Планета"), Category("Сводка")]
        public string PlanetName { get; set; }

        [DisplayName("Год открытия"), Category("Сводка")]
        public int Year { get; set; }

        [DisplayName("Внешний вид"), Category("Сводка")]
        public string Img { get; set; } = "../../images/default.jpg";

        [DisplayName("Размер"), Category("Сводка")]
        public long Size { get; set; }

        [DisplayName("Расстояние до Солнца"), Category("Сводка")]
        public long PathToSun { get; set; }
        
        [DisplayName("Группа"), Category("Сводка")]
        public string Group { get; set; }
        [Browsable(false)]

        public Planet(string n, int y, string i, long s, long p, string g)
        {
            PlanetName = n;
            Year = y;
            Img = i;
            Size = s;
            PathToSun = p;
            Group = g;
        }
        public Planet() { }
    }
}
