using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPriceListingGenerator.Domains
{
    public class AppSetting
    {
        private LayoutSetting _layoutSetting;

        public LayoutSetting LayoutSetting
        {
            get
            {
                if (_layoutSetting == null)
                {
                    _layoutSetting = new LayoutSetting();
                }
                return _layoutSetting;
            }
            set { _layoutSetting = value; }
        }

        public ProductCodeSetting ProductCodeSetting { get; set; }
        public ProductNameSetting ProductNameEnSetting { get; set; }
        public ProductNameSetting ProductNameKhSetting { get; set; }
        public ProductNameSetting UnitSalePriceSetting { get; set; }
        public ProductPicture ProductPicture { get; set; }
        public ProductNameSetting CategoryEnSetting { get; set; }
        public ProductNameSetting CategoryKhSetting { get; set; }
    }
}
