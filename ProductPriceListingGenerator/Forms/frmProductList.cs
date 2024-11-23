using Components;
using ProductPriceListingGenerator.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductPriceListingGenerator.Forms
{
    public partial class frmProductList : Form
    {
        private SortableBindingList<Product> list;
        public frmProductList(SortableBindingList<Product> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void frmProductList_Shown(object sender, EventArgs e)
        {
            dgv.Bind(list);
        }
    }
}
