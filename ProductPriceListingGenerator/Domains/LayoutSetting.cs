using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPriceListingGenerator.Domains
{
    public class LayoutSetting
    {
        public string Background { get; set; }

        public string ProductCover { get; set; }

        public int X { get; set; } = 1;
        public int Y { get; set; } = 1;
        public int Right { get; set; }
        public int Buttom { get; set; }

        public int Row { get; set; } = 1;
        public int Column { get; set; } = 1;

    }
}
