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
    public partial class frmUploadProduct : Form
    {
        private SortableBindingList<Domains.ProductExcelImport> list;
        private SortableBindingList<Domains.Category> categories;
        private SortableBindingList<Domains.Unit> units;

        public frmUploadProduct()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Choose Excel File";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                if (System.IO.File.Exists(openFileDialog.FileName))
                {
                    Excel.Application appExcel = null;
                    Excel.Workbook workbook = null;
                    Excel.Worksheet worksheet = null;
                    try
                    {
                        appExcel = new Excel.Application();
                        workbook = appExcel.Workbooks.Open(openFileDialog.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                        int sheetIndex = 1;
                        worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(sheetIndex);
                        Excel.Range range = null;

                        list = new SortableBindingList<Domains.ProductExcelImport>();
                        int startRowIndex = BasedForm.AppConfig.GetInt(KEYS.KEY_EXCEL_START, 2);
                        int endRowIndex = BasedForm.AppConfig.GetInt(KEYS.KEY_EXCEL_END, 200);
                        string colProductCode = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CODE);
                        string colProductNameEn = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_NAME_EN);
                        string colProductNameKh = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_NAME_KH);
                        string colCategoryEn = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CATEGORY_EN);
                        string colCategoryKh = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_CATEGORY_KH);
                        string colUnitEn = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_EN);
                        string colUnitKh = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_KH);
                        string colUnitPrice = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_UNIT_PRICE);
                        string colRetailPrice = BasedForm.AppConfig.GetParameterValue(KEYS.KEY_EXCEL_COLUMN_PRODUCT_RETAILSALE_PRICE);

                        Components.WaitWindow.WaitWindow.Show((obj, arg) =>
                        {
                            for (int i = startRowIndex; i <= endRowIndex; i++)
                            {
                                arg.Window.Message = i + " record(s) reading...";
                                range = worksheet.Cells[i, colProductCode];
                                String productCode = AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, colProductNameEn];
                                String productNameEn = AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, colProductNameKh];
                                String productNameKh = AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, colCategoryEn];
                                String categoryEn = AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, colCategoryKh];
                                String categoryKh = AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, colUnitEn];
                                String unitEn = AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, colUnitKh];
                                String unitKh = AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, colUnitPrice];
                                Double? unitPrice = AppUtils.Default.GetDouble(range);

                                range = worksheet.Cells[i, colRetailPrice];
                                Double? retailPrice = AppUtils.Default.GetDouble(range);

                                if (productCode.NonNullOrEmpty())
                                {
                                    Domains.ProductExcelImport product = new Domains.ProductExcelImport
                                    {
                                        CategoryNameEn = categoryEn,
                                        CategoryNameKh = categoryKh,
                                        ProductCode = productCode,
                                        ProductNameEn = productNameEn,
                                        ProductNameKh = productNameKh,
                                        RetailsalePrice = retailPrice.HasValue ? retailPrice.Value : 0D,
                                        UnitNameEn = unitEn,
                                        UnitNameKh = unitKh,
                                        UnitPrice = unitPrice.HasValue ? unitPrice.Value : 0D
                                    };
                                    list.Add(product);
                                }
                            }
                        });
                        List<string> listOfCategory = new List<string>(list.Select(x => x.CategoryName).Distinct().OrderBy(x => x).ToList());
                        listOfCategory.Insert(0, "");
                        cboCategory.BindingDataSource(listOfCategory, "", "");

                        int productIdColumnIndex = 0;
                        int productNameColumnIndex = 2;

                        for (int i = 0; i < dg.Rows.Count; i++)
                        {
                            Domains.ProductExcelImport product = dg.Rows[i].DataBoundItem as Domains.ProductExcelImport;
                            if (product != null)
                            {
                                if (product.ProductCode.NonNullOrEmpty())
                                {
                                    var productDb = DataService.Default.GetProductDetailByProductCode(product.ProductCode);
                                    if (productDb != null)
                                    {
                                        product.ProductId = productDb.ProductId;
                                    }
                                    else
                                    {
                                        dg.Rows[i].Cells[productIdColumnIndex].ErrorText = "ProductCode not found";
                                        dg.Rows[i].Cells[productNameColumnIndex].ErrorText = "ProductName mismatch";
                                    }

                                    if (product.UnitName.NonNullOrEmpty())
                                    {
                                        Domains.Unit unit = units.Where(x => x.UnitNameEn == product.UnitNameEn && x.UnitNameKh == product.UnitNameKh).FirstOrDefault();
                                        product.UnitId = unit?.UnitId;
                                    }
                                    if (product.CategoryName.NonNullOrEmpty())
                                    {
                                        //categories.ForEach(x =>
                                        //{
                                        //    Console.WriteLine("DB: " + x.CategoryNameEn + " and Excel: " + product.CategoryNameEn);
                                        //});
                                        Domains.Category category = categories.Where(x => x.CategoryNameEn.ToLower() == product.CategoryNameEn.ToLower()).FirstOrDefault();
                                        product.CategoryId = category?.CategoryId;
                                    }
                                }
                            }
                        }

                        dg.Bind<Domains.ProductExcelImport>(list);
                    }
                    catch (Exception ex)
                    {
                        MainForm.setMessage(ex.Message, false);
                        if (workbook != null)
                            workbook.Close();
                        if (appExcel != null)
                        {
                            appExcel.Visible = false;
                            appExcel.Quit();
                        }
                    }
                    finally
                    {
                        MainForm.setMessage("Loaded from excel", true);
                        if (workbook != null)
                            workbook.Close();
                        if (appExcel != null)
                        {
                            appExcel.Visible = false;
                            appExcel.Quit();
                        }
                    }
                }
                else
                {
                    MainForm.setMessage(openFileDialog.FileName + " does not exist", false);
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            SortableBindingList<T24Transaction> list = dg.DataSource as SortableBindingList<T24Transaction>;
            if (list != null)
            {
                if (list.Count > 0)
                {

                    //backgroundWorker1.RunWorkerAsync(list);
                    int displayedRow = dg.Rows.GetRowCount(DataGridViewElementStates.Displayed);

                    Components.WaitWindow.WaitWindow.Show((obj, arg) =>
                    {
                        long success = 0, failed = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            dg.Rows[i].Selected = true;
                            if (i > displayedRow)
                            {
                                dg.PerformSafely(() => dg.FirstDisplayedScrollingRowIndex = i - (displayedRow / 2));
                            }
                            T24Transaction transaction = dg.getSelectedObject<T24Transaction>();
                            if (transaction != null)
                            {
                                //transaction = service.process(transaction);
                                list[i].T24Result = transaction.T24Result;
                                list[i].Success = transaction.Success;
                                if (transaction.Success)
                                {
                                    success = success + 1;
                                }
                                else
                                {
                                    failed = failed + 1;
                                }
                            }
                            arg.Window.Message = success + " success and " + failed + " failed and " + (success + failed) + " in total...";
                        }
                    });

                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    dg.Rows[i].Selected = true;
                    //    T24Transaction transaction = dg.getSelectedObject<T24Transaction>();
                    //    if (transaction != null)
                    //    {
                    //        transaction = service.process(transaction);
                    //        list[i].T24Result = transaction.T24Result;
                    //        list[i].Success = transaction.Success;
                    //    }
                    //}
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            list = dg.DataSource as SortableBindingList<ProductExcelImport>;
            if (list != null)
            {
                list = new SortableBindingList<ProductExcelImport>();
                dg.Bind(list);
            }
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmOption frmOption = new frmOption();
            frmOption.ShowDialog(this);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            list = dg.DataSource as SortableBindingList<ProductExcelImport>;
            if (list != null)
            {
                if (list.Count > 0)
                {
                    MainForm.ListToExcel<ProductExcelImport>(list);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            list = e.Argument as SortableBindingList<ProductExcelImport>;
            if (list != null)
            {
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        dg.Rows[i].Selected = true;
                        T24Transaction transaction = dg.getSelectedObject<T24Transaction>();
                        if (transaction != null)
                        {
                            // transaction = service.process(transaction);
                            //list[i].T24Result = transaction.T24Result;
                            // list[i].Success = transaction.Success;
                        }
                        Double percentage = Double.Parse(i + "") / Double.Parse(list.Count + "");
                        e.Result = percentage * 100;
                    }
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //Console.WriteLine("RowCount: " + dg.Rows.GetRowCount(DataGridViewElementStates.Displayed));
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
                categories = category.Page.Content;
                categoryToolStripMenuItem.DropDownItems.Clear();
                foreach (var item in category.Page.Content.OrderBy(x => x.CategoryName))
                {
                    ToolStripMenuItem toolStripItem = new ToolStripMenuItem();
                    toolStripItem.Text = item.CategoryName;
                    toolStripItem.Tag = item;
                    toolStripItem.Click += ToolStripItem_Category_Click;
                    categoryToolStripMenuItem.DropDownItems.Add(toolStripItem);
                }
            }

            var unit = DataService.Default.GetProductUnits(BasedForm.AppConfig.GetInt(KEYS.KEY_PAGE_SIZE, 99999));
            if (unit != null && unit.Page != null && unit.Page.Content != null)
            {
                unitToolStripMenuItem.DropDownItems.Clear();
                units = unit.Page.Content;
                foreach (var item in unit.Page.Content.OrderBy(x => x.UnitName))
                {
                    ToolStripMenuItem toolStripItem = new ToolStripMenuItem();
                    toolStripItem.Text = item.UnitName;
                    toolStripItem.Tag = item;
                    toolStripItem.Click += ToolStripItem_Category_Click;
                    unitToolStripMenuItem.DropDownItems.Add(toolStripItem);
                }
            }
        }

        private void ToolStripItem_Category_Click(object sender, EventArgs e)
        {
            List<Domains.ProductExcelImport> selectedProducts = dg.getSelectedObjects<Domains.ProductExcelImport>();
            if (selectedProducts != null)
            {
                ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
                if (toolStripMenuItem != null)
                {
                    if (toolStripMenuItem.Tag != null)
                    {
                        Domains.Category category = toolStripMenuItem.Tag as Domains.Category;
                        if (category != null)
                        {
                            selectedProducts.ForEach(x =>
                            {
                                x.CategoryId = category.CategoryId;
                                x.CategoryNameKh = category.CategoryNameKh;
                                x.CategoryNameEn = category.CategoryNameEn;
                            });
                        }
                    }
                }
            }
            dg.RefreshSelect();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (list != null)
            {
                SortableBindingList<Domains.ProductExcelImport> found = new SortableBindingList<ProductExcelImport>();

                found = new SortableBindingList<ProductExcelImport>(list.Where(x => x.ProductNameEn.Contains(txtSearch.Text) && x.CategoryName.Contains(cboCategory.SelectedItem.ToString())).ToList());
                dg.Bind<Domains.ProductExcelImport>(found);
                MainForm.setMessage(found.Count + " found of " + list.Count + " record(s)", true);
            }
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
