using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPriceListingGenerator.Domains
{
    public class ProductCodeSetting
    {
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public bool FontBold { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        public int Right { get; set; }
        public int Buttom { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string HexColor { get; set; }

    }
}
