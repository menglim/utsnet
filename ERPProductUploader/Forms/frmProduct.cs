using Components;
using Components.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERPClientTools.Domains;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPClientTools.Forms
{
    public partial class frmProduct : Form
    {
        private SortableBindingList<Domains.Product> list;
        private List<String> category = new List<string>();

        public frmProduct()
        {
            InitializeComponent();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            list = dg.DataSource as SortableBindingList<Product>;
            if (list != null)
            {
                list = new SortableBindingList<Product>();
                dg.Bind(list);
            }
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            list = dg.DataSource as SortableBindingList<Product>;
            if (list != null)
            {
                if (list.Count > 0)
                {
                    MainForm.ListToExcel<Product>(list);
                }
            }
        }



        private void btnOption_Click(object sender, EventArgs e)
        {
            Forms.frmUploadProductOption frm = new frmUploadProductOption();
            frm.ShowDialog();
        }

        private void frmUploadProduct_Shown(object sender, EventArgs e)
        {
            var category = DataService.Default.GetProductCategories(BasedForm.AppConfig.GetLong(KEYS.KEY_PAGE_SIZE, KEYS.DEFAULT_PAGE_SIZE));
            if (category != null && category.Page != null && category.Page.Content != null)
            {
                var categoryList = category.Page.Content.OrderBy(x => x.CategoryName).ToList();
                categoryList.Insert(0, new Category { CategoryId = 0, CategoryNameEn = "", CategoryNameKh = "" });
                cboCategory.BindingDataSource<Domains.Category>(categoryList, "categoryId", "categoryName");

            }


            var product = DataService.Default.GetProducts(50);
            if (product != null && product.Page != null && product.Page.Content != null)
            {
                list = product.Page.Content;
                dg.Bind<Domains.Product>(list);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (list != null)
            //{
            //    SortableBindingList<Domains.Product> found = new SortableBindingList<Product>();

            //    //found = new SortableBindingList<Product>(list.Where(x => x.ProductNameEn.Contains(txtSearch.Text) && x.Category.Contains(cboCategory.SelectedItem.ToString())).ToList());
            //    dg.Bind<Domains.Product>(found);
            //    MainForm.setMessage(found.Count + " found of " + list.Count + " record(s)", true);
            //}
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            dg.MultiSelect = !dg.MultiSelect;
        }

        private void dg_MultiSelectChanged(object sender, EventArgs e)
        {
            if (dg.MultiSelect)
            {
                btnToggle.Text = "MULTIPLE";
            }
            else
            {
                btnToggle.Text = "SINGLE";
            }
        }

        private void frmUploadProduct_Load(object sender, EventArgs e)
        {
            dg_MultiSelectChanged(sender, e);
        }
    }
}
