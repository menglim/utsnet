using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools
{
    public class DataService
    {
        private static DataService _default;

        public static DataService Default
        {
            get
            {
                if (_default == null) _default = new DataService();
                return _default;
            }
        }

        public Domains.Response<Domains.Login> Login(string username, string password)
        {
            Domains.Response<Domains.Login> response = new Domains.Response<Domains.Login>
            {
                Data = new Domains.Login
                {
                    Username = username
                }
            };

            Components.WaitWindow.WaitWindow.Show((obj, arg) =>
            {
                string json = AppUtils.Default.Post(MainForm.Server.URL + "/login", "", GetAuthenticationHeader);
                response = AppUtils.Default.FromStringToObject<Domains.Response<Domains.Login>>(json);
                if (response != null)
                    if (response.ErrorCode == 0)
                    {
                        response.Data.Username = username;
                    }
            });

            return response;
        }

        private Dictionary<string, string> GetAuthenticationHeader
        {
            get
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authentication", "DDDD");
                header.Add("apiKey", MainForm.Server.APIKey);
                return header;
            }
        }

        public Domains.Pager<Domains.Category> GetProductCategories(long pageSize = 10)
        {
            Domains.Response<Domains.Pager<Domains.Category>> response = new Domains.Response<Domains.Pager<Domains.Category>>();
            Components.WaitWindow.WaitWindow.Show((obj, arg) =>
            {
                string json = AppUtils.Default.Get(MainForm.Server.URL + "/category?pageSize=" + pageSize, GetAuthenticationHeader);
                response = AppUtils.Default.FromStringToObject<Domains.Response<Domains.Pager<Domains.Category>>>(json);
            });
            if (response != null && response.ErrorCode == 0)
            {
                return response.Data;
            }
            return null;
        }

        public Domains.Pager<Domains.Unit> GetProductUnits(long pageSize = 10)
        {
            Domains.Response<Domains.Pager<Domains.Unit>> response = new Domains.Response<Domains.Pager<Domains.Unit>>();
            Components.WaitWindow.WaitWindow.Show((obj, arg) =>
            {
                string json = AppUtils.Default.Get(MainForm.Server.URL + "/unit?pageSize=" + pageSize, GetAuthenticationHeader);
                response = AppUtils.Default.FromStringToObject<Domains.Response<Domains.Pager<Domains.Unit>>>(json);
            });
            if (response != null && response.ErrorCode == 0)
            {
                return response.Data;
            }
            return null;
        }

        public Domains.Pager<Domains.Product> GetProducts(long pageSize = 10)
        {
            Domains.Response<Domains.Pager<Domains.Product>> response = new Domains.Response<Domains.Pager<Domains.Product>>();
            Components.WaitWindow.WaitWindow.Show((obj, arg) =>
            {
                string json = AppUtils.Default.Get(MainForm.Server.URL + "/product?pageSize=" + pageSize, GetAuthenticationHeader);
                response = AppUtils.Default.FromStringToObject<Domains.Response<Domains.Pager<Domains.Product>>>(json);
            });
            if (response != null && response.ErrorCode == 0)
            {
                return response.Data;
            }
            return null;
        }

        public Domains.Product GetProductDetailByProductCode(string productCode)
        {
            Domains.Response<Domains.Product> response = new Domains.Response<Domains.Product>();
            Components.WaitWindow.WaitWindow.Show((obj, arg) =>
            {
                string json = AppUtils.Default.Get(MainForm.Server.URL + "/product/view/product-code/" + productCode, GetAuthenticationHeader);
                response = AppUtils.Default.FromStringToObject<Domains.Response<Domains.Product>>(json);
            });
            if (response != null && response.ErrorCode == 0)
            {
                return response.Data;
            }
            return null;
        }
    }
}
