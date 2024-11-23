using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Components;
using Components.Extensions;
using ProductPriceListingGenerator.Domains;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProductPriceListingGenerator.Forms
{
    public partial class frmMain : Form
    {
        private List<String> fonts = FontFamily.Families.Select(x => x.Name).OrderBy(y => y).ToList();
        private Graphics graphics;
        private SortableBindingList<Product> list = new SortableBindingList<Product>();
        private SortableBindingList<Product> productsInCategroy = new SortableBindingList<Product>();
        private AppSetting appSetting = new AppSetting();
        private int currentPage = 0;
        private int totalPage = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            imagePanel.Zoom = trackBar1.Value * 0.02f;
        }

        public static void SetTitle(string messaage)
        {

        }

        private Bitmap preview()
        {
            appSetting = new AppSetting
            {
                LayoutSetting = new LayoutSetting
                {
                    Background = txtBackground.Text,
                    ProductCover = txtProductCover.Text,
                    X = txtProductCoverX.getInt(),
                    Y = txtProductCoverY.getInt(),
                    Right = txtProductCoverRight.getInt(),
                    Buttom = txtProductCoverButtom.getInt(),
                    Column = txtLayoutColumn.getInt(),
                    Row = txtLayoutRow.getInt(),
                },
                ProductCodeSetting = new Domains.ProductCodeSetting
                {
                    FontName = cboProductCodeFont.SelectedItem.ToString(),
                    Buttom = txtProductCodeButtom.getInt(),
                    FontBold = cbProductCodeBold.Checked,
                    Height = txtProductCodeH.getInt(),
                    Width = txtProductCodeW.getInt(),
                    X = txtProductCodeX.getInt(),
                    Y = txtProductCodeY.getInt(),
                    Right = txtProductCodeRight.getInt(),
                    HexColor = txtProductCodeColor.Text,
                },
                ProductNameEnSetting = new ProductNameSetting
                {
                    Buttom = txtProductNameEnButtom.getInt(),
                    HexColor = txtProductNameEnColor.Text,
                    FontBold = cbProductNameEnBold.Checked,
                    FontName = cboProductNameEnFont.SelectedItem.ToString(),
                    Height = txtProductNameEnH.getInt(),
                    Right = txtProductNameEnRight.getInt(),
                    Width = txtProductNameEnW.getInt(),
                    X = txtProductNameEnX.getInt(),
                    Y = txtProductNameEnY.getInt()
                },
                ProductNameKhSetting = new ProductNameSetting
                {
                    Buttom = txtProductNameKhButtom.getInt(),
                    HexColor = txtProductNameKhColor.Text,
                    FontBold = cbProductNameKhBold.Checked,
                    FontName = cboProductNameKhFont.SelectedItem.ToString(),
                    Height = txtProductNameKhH.getInt(),
                    Right = txtProductNameKhRight.getInt(),
                    Width = txtProductNameKhW.getInt(),
                    X = txtProductNameKhX.getInt(),
                    Y = txtProductNameKhY.getInt()
                },
                UnitSalePriceSetting = new ProductNameSetting
                {
                    Buttom = txtUnitSalePriceButtom.getInt(),
                    HexColor = txtUnitSalePriceColor.Text,
                    FontBold = cbUnitSalePriceBold.Checked,
                    FontName = cboUnitSalePriceFont.SelectedItem.ToString(),
                    Height = txtUnitSalePriceH.getInt(),
                    Right = txtUnitSalePriceRight.getInt(),
                    Width = txtUnitSalePriceW.getInt(),
                    X = txtUnitSalePriceX.getInt(),
                    Y = txtUnitSalePriceY.getInt()
                },
                ProductPicture = new ProductPicture
                {
                    Y = txtProductPictureY.getInt(),
                    X = txtProductPictureX.getInt(),
                    Right = txtProductPictureRight.getInt(),
                    Buttom = txtProductPictureButtom.getInt(),
                    Folder = txtProductPictureFolder.Text,
                    Height = txtProductPictureH.getInt() == 0 ? 100 : txtProductPictureH.getInt(),
                    Width = txtProductPictureW.getInt() == 0 ? 100 : txtProductPictureW.getInt(),
                },
                CategoryEnSetting = new ProductNameSetting
                {
                    Y = txtCategoryEnY.getInt(),
                    X = txtCategoryEnX.getInt(),
                    Right = txtCategoryEnR.getInt(),
                    Buttom = txtCategoryEnB.getInt(),
                    Height = txtCategoryEnH.getInt() == 0 ? 100 : txtCategoryEnH.getInt(),
                    Width = txtCategoryEnW.getInt() == 0 ? 100 : txtCategoryEnW.getInt(),
                    FontBold = cbCategoryEnBold.Checked,
                    FontName = cboCategoryEnFont.SelectedItem.ToString(),
                    HexColor = txtCategoryEnColor.Text
                },
                CategoryKhSetting = new ProductNameSetting
                {
                    Y = txtCategoryKhY.getInt(),
                    X = txtCategoryKhX.getInt(),
                    Right = txtCategoryKhR.getInt(),
                    Buttom = txtCategoryKhB.getInt(),
                    Height = txtCategoryKhH.getInt() == 0 ? 100 : txtCategoryKhH.getInt(),
                    Width = txtCategoryKhW.getInt() == 0 ? 100 : txtCategoryKhW.getInt(),
                    FontBold = cbCategoryKhBold.Checked,
                    FontName = cboCategoryKhFont.SelectedItem.ToString(),
                    HexColor = txtCategoryKhColor.Text
                },
            };

            Bitmap bitmap = null;

            Components.WaitWindow.WaitWindow.Show((o, et) =>
            {
                if (appSetting.LayoutSetting.Background.NonNullOrEmpty())
                {
                    if (System.IO.File.Exists(appSetting.LayoutSetting.Background))
                    {
                        bitmap = (Bitmap)Image.FromFile(appSetting.LayoutSetting.Background);
                        graphics = Graphics.FromImage(bitmap);

                        StringFormat strFormat = new StringFormat();
                        strFormat.Alignment = StringAlignment.Center;
                        strFormat.LineAlignment = StringAlignment.Center;
                        strFormat.FormatFlags = StringFormatFlags.NoWrap;
                        strFormat.Trimming = StringTrimming.None;

                        bool categoryDrawing = false;

                        int productCounter = (appSetting.LayoutSetting.Column * appSetting.LayoutSetting.Row) * (currentPage - 1);
                        if (productCounter < 0) productCounter = 0;

                        for (int i = 0; i < appSetting.LayoutSetting.Row; i++)
                        {
                            for (int k = 0; k < appSetting.LayoutSetting.Column; k++)
                            {

                                if (productCounter < productsInCategroy.Count)
                                {
                                    Product product = productsInCategroy[productCounter];

                                    //if (appSetting.CategoryEnSetting != null)
                                    //{
                                    //    if (!categoryDrawing)
                                    //    {
                                    //        Pen pen = new Pen(Color.Black, 1);
                                    //        pen.Alignment = PenAlignment.Inset;

                                    //        float bestFontSize = Components.AppUtils.Default.FindBestFontSize(graphics, product.CategoryNameEn.Trim(), appSetting.CategoryEnSetting.Width, appSetting.CategoryEnSetting.Height, appSetting.CategoryEnSetting.FontName);
                                    //        if (cbCategoryEnBorder.Checked)
                                    //        {
                                    //            Rectangle rectangle = new Rectangle(
                                    //            appSetting.CategoryEnSetting.X,
                                    //            appSetting.CategoryEnSetting.Y,
                                    //            appSetting.CategoryEnSetting.Width,
                                    //            appSetting.CategoryEnSetting.Height);
                                    //            graphics.DrawRectangle(pen, rectangle);
                                    //        }

                                    //        graphics.DrawString(product.CategoryNameEn.Trim(),
                                    //            new Font(appSetting.CategoryEnSetting.FontName, bestFontSize, appSetting.CategoryEnSetting.FontBold ? FontStyle.Bold : FontStyle.Regular),
                                    //            new SolidBrush(ColorTranslator.FromHtml(appSetting.CategoryEnSetting.HexColor)),
                                    //            new RectangleF(appSetting.CategoryEnSetting.X, appSetting.CategoryEnSetting.Y, appSetting.CategoryEnSetting.Width, appSetting.CategoryEnSetting.Height),
                                    //            strFormat
                                    //        );
                                    //    }
                                    //}

                                    if (appSetting.CategoryKhSetting != null)
                                    {
                                        if (!categoryDrawing)
                                        {
                                            Pen pen = new Pen(Color.Black, 1);
                                            pen.Alignment = PenAlignment.Inset;

                                            float bestFontSize = Components.AppUtils.Default.FindBestFontSize(graphics, product.CategoryNameEnKh.Trim(), appSetting.CategoryKhSetting.Width, appSetting.CategoryKhSetting.Height, appSetting.CategoryKhSetting.FontName);
                                            if (cbCategoryKhBorder.Checked)
                                            {
                                                Rectangle rectangle = new Rectangle(
                                                appSetting.CategoryKhSetting.X,
                                                appSetting.CategoryKhSetting.Y,
                                                appSetting.CategoryKhSetting.Width,
                                                appSetting.CategoryKhSetting.Height);
                                                graphics.DrawRectangle(pen, rectangle);
                                            }

                                            graphics.DrawString(product.CategoryNameEnKh.Trim(),
                                                new Font(appSetting.CategoryKhSetting.FontName, bestFontSize, appSetting.CategoryKhSetting.FontBold ? FontStyle.Bold : FontStyle.Regular),
                                                new SolidBrush(ColorTranslator.FromHtml(appSetting.CategoryKhSetting.HexColor)),
                                                new RectangleF(appSetting.CategoryKhSetting.X, appSetting.CategoryKhSetting.Y, appSetting.CategoryKhSetting.Width, appSetting.CategoryKhSetting.Height),
                                                strFormat
                                            );
                                        }
                                        categoryDrawing = true;
                                    }

                                    if (appSetting.LayoutSetting.ProductCover.NonNullOrEmpty())
                                    {
                                        if (System.IO.File.Exists(appSetting.LayoutSetting.ProductCover))
                                        {
                                            using (var productCover = Image.FromFile(appSetting.LayoutSetting.ProductCover))
                                            {
                                                graphics.DrawImage(productCover,
                                                    appSetting.LayoutSetting.X + (k * appSetting.LayoutSetting.Right) + (k * 6),
                                                    appSetting.LayoutSetting.Y + (i * appSetting.LayoutSetting.Buttom)
                                                    );
                                            }
                                        }
                                    }

                                    Bitmap productPicture = Properties.Resources.picture_not_available;
                                    String fileImage = "images" + "\\" + product.ProductCode + "." + Properties.Settings.Default.IMAGE_EXTENSION;
                                    if (System.IO.File.Exists(fileImage))
                                    {
                                        productPicture = (Bitmap)Image.FromFile(fileImage);
                                    }

                                    //productPicture = (Bitmap)AppUtils.Default.Resize(productPicture, appSetting.ProductPicture.Width, appSetting.ProductPicture.Height);

                                    // Scaling
                                    float scaling;
                                    float scalingY = (float)productPicture.Height / appSetting.ProductPicture.Height;
                                    float scalingX = (float)productPicture.Width / appSetting.ProductPicture.Width;
                                    if (scalingX < scalingY) scaling = scalingX; else scaling = scalingY;
                                    int newWidth = (int)(productPicture.Width / scaling);
                                    int newHeight = (int)(productPicture.Height / scaling);
                                    if (newWidth < appSetting.ProductPicture.Width) newWidth = appSetting.ProductPicture.Width;
                                    if (newHeight < appSetting.ProductPicture.Height) newHeight = appSetting.ProductPicture.Height;

                                    graphics.DrawImage(productPicture,
                                        appSetting.ProductPicture.X + (k * appSetting.ProductPicture.Right) + (k * 6),
                                        appSetting.ProductPicture.Y + (i * appSetting.ProductPicture.Buttom),
                                        newWidth,
                                        newHeight
                                    );
                                    productPicture.Dispose();

                                    if (appSetting.ProductCodeSetting.FontName.NonNullOrEmpty())
                                    {
                                        //string productCode = "GL-0001"; //product.ProductCode.Trim();
                                        Pen pen = new Pen(Color.Black, 2);
                                        pen.Alignment = PenAlignment.Inset;

                                        float bestFontSize = Components.AppUtils.Default.FindBestFontSize(graphics, product.ProductCode.Trim(), appSetting.ProductCodeSetting.Width, appSetting.ProductCodeSetting.Height, appSetting.ProductCodeSetting.FontName);
                                        if (cbProductCodeBorder.Checked)
                                        {
                                            Rectangle rectangle = new Rectangle(
                                            appSetting.ProductCodeSetting.X + (k * appSetting.ProductCodeSetting.Right) + (k * 6),
                                            appSetting.ProductCodeSetting.Y + (i * appSetting.ProductCodeSetting.Buttom),
                                            appSetting.ProductCodeSetting.Width,
                                            appSetting.ProductCodeSetting.Height);
                                            graphics.DrawRectangle(pen, rectangle);
                                        }

                                        graphics.DrawString(product.ProductCode.Trim(),
                                            new Font(appSetting.ProductCodeSetting.FontName, bestFontSize, appSetting.ProductCodeSetting.FontBold ? FontStyle.Bold : FontStyle.Regular),
                                            new SolidBrush(ColorTranslator.FromHtml(appSetting.ProductCodeSetting.HexColor)),
                                            new RectangleF(appSetting.ProductCodeSetting.X + (k * appSetting.ProductCodeSetting.Right), appSetting.ProductCodeSetting.Y + (i * appSetting.ProductCodeSetting.Buttom), appSetting.ProductCodeSetting.Width, appSetting.ProductCodeSetting.Height),
                                            strFormat
                                        );
                                    }

                                    if (appSetting.ProductNameKhSetting.FontName.NonNullOrEmpty())
                                    {
                                        Pen pen = new Pen(Color.Black, 2);
                                        pen.Alignment = PenAlignment.Inset;

                                        float bestFontSize = Components.AppUtils.Default.FindBestFontSize(graphics, product.ProductNameKh.Trim(), appSetting.ProductNameKhSetting.Width, appSetting.ProductNameKhSetting.Height, appSetting.ProductNameKhSetting.FontName);
                                        if (cbProductNameKhBorder.Checked)
                                        {
                                            Rectangle rectangle = new Rectangle(
                                                appSetting.ProductNameKhSetting.X + (k * appSetting.ProductNameKhSetting.Right),
                                                appSetting.ProductNameKhSetting.Y + (i * appSetting.ProductNameKhSetting.Buttom),
                                                appSetting.ProductNameKhSetting.Width,
                                                appSetting.ProductNameKhSetting.Height);
                                            graphics.DrawRectangle(pen, rectangle);
                                        }

                                        graphics.DrawString(product.ProductNameKh.Trim(),
                                            new Font(appSetting.ProductNameKhSetting.FontName, bestFontSize, appSetting.ProductNameKhSetting.FontBold ? FontStyle.Bold : FontStyle.Regular),
                                            new SolidBrush(ColorTranslator.FromHtml(appSetting.ProductNameKhSetting.HexColor)),
                                            new RectangleF(appSetting.ProductNameKhSetting.X + (k * appSetting.ProductNameKhSetting.Right), appSetting.ProductNameKhSetting.Y + (i * appSetting.ProductNameKhSetting.Buttom), appSetting.ProductNameKhSetting.Width, appSetting.ProductNameKhSetting.Height),
                                            strFormat
                                         );
                                    }

                                    if (appSetting.ProductNameEnSetting.FontName.NonNullOrEmpty())
                                    {

                                        float bestFontSize = AppUtils.Default.FindBestFontSize(graphics, product.ProductNameEn.Trim(), appSetting.ProductNameEnSetting.Width, appSetting.ProductNameEnSetting.Height, appSetting.ProductNameEnSetting.FontName);
                                        if (cbProductNameEnBorder.Checked)
                                        {
                                            Pen pen = new Pen(Color.Black, 1);
                                            pen.Alignment = PenAlignment.Inset;

                                            Rectangle rectangle = new Rectangle(
                                                appSetting.ProductNameEnSetting.X + (k * appSetting.ProductNameEnSetting.Right),
                                                appSetting.ProductNameEnSetting.Y + (i * appSetting.ProductNameEnSetting.Buttom),
                                                appSetting.ProductNameEnSetting.Width,
                                                appSetting.ProductNameEnSetting.Height);
                                            graphics.DrawRectangle(pen, rectangle);
                                        }

                                        graphics.DrawString(product.ProductNameEn.Trim(),
                                            new Font(appSetting.ProductNameEnSetting.FontName, bestFontSize, appSetting.ProductNameEnSetting.FontBold ? FontStyle.Bold : FontStyle.Regular),
                                            new SolidBrush(ColorTranslator.FromHtml(appSetting.ProductNameEnSetting.HexColor)),
                                            new RectangleF(appSetting.ProductNameEnSetting.X + (k * appSetting.ProductNameEnSetting.Right), appSetting.ProductNameEnSetting.Y + (i * appSetting.ProductNameEnSetting.Buttom), appSetting.ProductNameEnSetting.Width, appSetting.ProductNameEnSetting.Height),
                                            strFormat
                                        );
                                    }

                                    if (appSetting.UnitSalePriceSetting.FontName.NonNullOrEmpty())
                                    {
                                        Pen pen = new Pen(Color.Black, 2);
                                        pen.Alignment = PenAlignment.Inset;

                                        String unitString = "1" + product.UnitName + txtUnitPriceAppendText.Text + product.SalePrice.ToString("#,##0") + Properties.Settings.Default.CURRENCY_SYMBOL;

                                        float bestFontSize = Components.AppUtils.Default.FindBestFontSize(graphics, unitString, appSetting.UnitSalePriceSetting.Width, appSetting.UnitSalePriceSetting.Height, appSetting.UnitSalePriceSetting.FontName);
                                        if (cbUnitSalePriceBorder.Checked)
                                        {
                                            Rectangle rectangle = new Rectangle(
                                                appSetting.UnitSalePriceSetting.X + (k * appSetting.UnitSalePriceSetting.Right),
                                                appSetting.UnitSalePriceSetting.Y + (i * appSetting.UnitSalePriceSetting.Buttom),
                                                appSetting.UnitSalePriceSetting.Width,
                                                appSetting.UnitSalePriceSetting.Height);
                                            graphics.DrawRectangle(pen, rectangle);
                                        }

                                        graphics.DrawString(unitString,
                                            new Font(appSetting.UnitSalePriceSetting.FontName, bestFontSize, appSetting.UnitSalePriceSetting.FontBold ? FontStyle.Bold : FontStyle.Regular),
                                            new SolidBrush(ColorTranslator.FromHtml(appSetting.UnitSalePriceSetting.HexColor)),
                                            new RectangleF(appSetting.UnitSalePriceSetting.X + (k * appSetting.UnitSalePriceSetting.Right), appSetting.UnitSalePriceSetting.Y + (i * appSetting.UnitSalePriceSetting.Buttom), appSetting.UnitSalePriceSetting.Width, appSetting.UnitSalePriceSetting.Height),
                                            strFormat
                                         );
                                    }
                                }
                                productCounter = productCounter + 1;
                            }
                        }
                        graphics.Save();
                    }
                }
            });
            if (bitmap != null)
            {
                imagePanel.Image = bitmap;
            }
            return bitmap;
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            preview();
        }


        private void btnChooseExcel_Click(object sender, EventArgs e)
        {
            txtExcelFile.Text = Components.AppUtils.Default.openFileDialog("Choose Excel File", "Excel Files|*.xls;*.xlsx;*.xlsm");
            string excelFile = txtExcelFile.Text;
            string password = txtPasswordExcel.Text;
            List<string> sheetName = new List<string>();
            if (txtExcelFile.DoValidation())
            {
                Excel.Application application = null;
                Excel.Workbook workbook = null;
                try
                {
                    int worksheetIndex = 1;
                    int start = Properties.Settings.Default.EXCEL_START;
                    int to = Properties.Settings.Default.EXCEL_END;
                    list = new SortableBindingList<Product>();

                    Components.WaitWindow.WaitWindow.Show((o, ev) =>
                    {
                        try
                        {
                            application = new Excel.Application();
                            application.Visible = false;
                            workbook = application.Workbooks.Open(excelFile, 0, true, 5, password, "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(worksheetIndex);
                            Excel.Range range = null;

                            for (int i = start; i <= to; i++)
                            {
                                range = worksheet.Cells[i, Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NO];
                                string productNo = Components.AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NAME_EN];
                                string productNameEn = Components.AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_NAME_KH];
                                string productNameKh = Components.AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, Properties.Settings.Default.EXCEL_COLUMN_CATEGORY_EN];
                                string categoryNameEn = Components.AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, Properties.Settings.Default.EXCEL_COLUMN_CATEGORY_KH];
                                string categoryNameKh = Components.AppUtils.Default.GetString(range);


                                range = worksheet.Cells[i, Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_UNIT_NAME];
                                string unitName = Components.AppUtils.Default.GetString(range);

                                range = worksheet.Cells[i, Properties.Settings.Default.EXCEL_COLUMN_PRODUCT_SALE_PRICE];
                                double salePrice = Components.AppUtils.Default.GetDouble(range);

                                if (AppUtils.Default.NoneNullOrEmpty(productNo) && AppUtils.Default.NoneNullOrEmpty(productNameEn) && AppUtils.Default.NoneNullOrEmpty(productNameEn) && AppUtils.Default.NoneNullOrEmpty(unitName)
                                && AppUtils.Default.NoneNullOrEmpty(categoryNameKh) && AppUtils.Default.NoneNullOrEmpty(categoryNameEn))
                                {
                                    Product product = new Product
                                    {
                                        ProductCode = productNo,
                                        ProductNameEn = productNameEn,
                                        ProductNameKh = productNameKh,
                                        SalePrice = salePrice,
                                        UnitName = unitName,
                                        CategoryNameEn = categoryNameEn,
                                        CategoryNameKh = categoryNameKh
                                    };
                                    list.Add(product);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                if (workbook != null)
                                {
                                    workbook.Close();
                                }
                                if (application != null)
                                {
                                    application.Quit();
                                }
                            }
                            catch (Exception)
                            {

                            }
                            workbook = null;
                            application = null;
                            Components.AppUtils.Default.AlertMessage("Error while reading from excel becasue " + ex.Message, false);
                        }
                        finally
                        {
                            try
                            {
                                if (workbook != null)
                                {
                                    workbook.Close();
                                }
                                if (application != null)
                                {
                                    application.Quit();
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }
                    });

                    List<string> categories = list.Select(x => x.CategoryNameEnKh).Distinct().ToList();
                    cboWorksheets.BindingDataSource(categories, "", "");
                    if (cboWorksheets.Items.Count > 0)
                    {
                        cboWorksheets.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    Components.AppUtils.Default.AlertMessage("Error while reading from excel becasue " + ex.Message, false);
                }
                finally
                {
                    try
                    {
                        if (workbook != null)
                        {
                            workbook.Close();
                        }
                        if (application != null)
                        {
                            application.Quit();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnListOfItem_Click(object sender, EventArgs e)
        {
            frmProductList frm = new frmProductList(list);
            frm.ShowDialog();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            frmOption frm = new frmOption();
            frm.ShowDialog();
        }

        private void btnLoadSetting_Click(object sender, EventArgs e)
        {
            string file = Components.AppUtils.Default.openFileDialog("Save File", "Product Price Generator Files (*.ppgf) | *.ppgf");

            if (System.IO.File.Exists(file))
            {
                string josn = System.IO.File.ReadAllText(file);
                txtSetting.Text = file;
                appSetting = Components.AppUtils.Default.FromStringToObject<AppSetting>(josn);
                if (appSetting.LayoutSetting != null)
                {
                    txtBackground.Text = appSetting.LayoutSetting.Background;
                    txtProductCover.Text = appSetting.LayoutSetting.ProductCover;
                    txtProductCoverX.Text = appSetting.LayoutSetting.X + "";
                    txtProductCoverY.Text = appSetting.LayoutSetting.Y + "";
                    txtProductCoverRight.Text = appSetting.LayoutSetting.Right + "";
                    txtProductCoverButtom.Text = appSetting.LayoutSetting.Buttom + "";
                    txtLayoutColumn.Text = appSetting.LayoutSetting.Column + "";
                    txtLayoutRow.Text = appSetting.LayoutSetting.Row + "";
                }
                if (appSetting.ProductCodeSetting != null)
                {
                    txtProductCodeButtom.Text = appSetting.ProductCodeSetting.Buttom + "";
                    txtProductCodeH.Text = appSetting.ProductCodeSetting.Height + "";
                    txtProductCodeRight.Text = appSetting.ProductCodeSetting.Right + "";
                    txtProductCodeW.Text = appSetting.ProductCodeSetting.Width + "";
                    txtProductCodeX.Text = appSetting.ProductCodeSetting.X + "";
                    txtProductCodeY.Text = appSetting.ProductCodeSetting.Y + "";
                    cboProductCodeFont.SelectedItem = appSetting.ProductCodeSetting.FontName;
                    cbProductCodeBold.Checked = appSetting.ProductCodeSetting.FontBold;
                    txtProductCodeColor.Text = appSetting.ProductCodeSetting.HexColor;
                }
                if (appSetting.ProductNameEnSetting != null)
                {
                    txtProductNameEnButtom.Text = appSetting.ProductNameEnSetting.Buttom + "";
                    txtProductNameEnH.Text = appSetting.ProductNameEnSetting.Height + "";
                    txtProductNameEnRight.Text = appSetting.ProductNameEnSetting.Right + "";
                    txtProductNameEnW.Text = appSetting.ProductNameEnSetting.Width + "";
                    txtProductNameEnX.Text = appSetting.ProductNameEnSetting.X + "";
                    txtProductNameEnY.Text = appSetting.ProductNameEnSetting.Y + "";
                    cboProductNameEnFont.SelectedItem = appSetting.ProductNameEnSetting.FontName;
                    cbProductNameEnBold.Checked = appSetting.ProductNameEnSetting.FontBold;
                    txtProductNameEnColor.Text = appSetting.ProductNameEnSetting.HexColor;
                }
                if (appSetting.ProductNameKhSetting != null)
                {
                    txtProductNameKhButtom.Text = appSetting.ProductNameKhSetting.Buttom + "";
                    txtProductNameKhH.Text = appSetting.ProductNameKhSetting.Height + "";
                    txtProductNameKhRight.Text = appSetting.ProductNameKhSetting.Right + "";
                    txtProductNameKhW.Text = appSetting.ProductNameKhSetting.Width + "";
                    txtProductNameKhX.Text = appSetting.ProductNameKhSetting.X + "";
                    txtProductNameKhY.Text = appSetting.ProductNameKhSetting.Y + "";
                    cboProductNameKhFont.SelectedItem = appSetting.ProductNameKhSetting.FontName;
                    cbProductNameKhBold.Checked = appSetting.ProductNameKhSetting.FontBold;
                    txtProductNameKhColor.Text = appSetting.ProductNameKhSetting.HexColor;
                }
                if (appSetting.UnitSalePriceSetting != null)
                {
                    txtUnitSalePriceButtom.Text = appSetting.UnitSalePriceSetting.Buttom + "";
                    txtUnitSalePriceH.Text = appSetting.UnitSalePriceSetting.Height + "";
                    txtUnitSalePriceRight.Text = appSetting.UnitSalePriceSetting.Right + "";
                    txtUnitSalePriceW.Text = appSetting.UnitSalePriceSetting.Width + "";
                    txtUnitSalePriceX.Text = appSetting.UnitSalePriceSetting.X + "";
                    txtUnitSalePriceY.Text = appSetting.UnitSalePriceSetting.Y + "";
                    cboUnitSalePriceFont.SelectedItem = appSetting.UnitSalePriceSetting.FontName;
                    cbUnitSalePriceBold.Checked = appSetting.UnitSalePriceSetting.FontBold;
                    txtUnitSalePriceColor.Text = appSetting.UnitSalePriceSetting.HexColor;
                }
                if (appSetting.ProductPicture != null)
                {
                    txtProductPictureFolder.Text = appSetting.ProductPicture.Folder;
                    txtProductPictureButtom.Text = appSetting.ProductPicture.Buttom + "";
                    txtProductPictureRight.Text = appSetting.ProductPicture.Right + "";
                    txtProductPictureX.Text = appSetting.ProductPicture.X + "";
                    txtProductPictureY.Text = appSetting.ProductPicture.Y + "";
                    txtProductPictureW.Text = appSetting.ProductPicture.Width + "";
                    txtProductPictureH.Text = appSetting.ProductPicture.Height + "";
                }
                if (appSetting.CategoryEnSetting != null)
                {
                    txtCategoryEnB.Text = appSetting.CategoryEnSetting.Buttom + "";
                    txtCategoryEnH.Text = appSetting.CategoryEnSetting.Height + "";
                    txtCategoryEnR.Text = appSetting.CategoryEnSetting.Right + "";
                    txtCategoryEnW.Text = appSetting.CategoryEnSetting.Width + "";
                    txtCategoryEnX.Text = appSetting.CategoryEnSetting.X + "";
                    txtCategoryEnY.Text = appSetting.CategoryEnSetting.Y + "";
                    cboCategoryEnFont.SelectedItem = appSetting.CategoryEnSetting.FontName;
                    cbCategoryEnBold.Checked = appSetting.CategoryEnSetting.FontBold;
                    txtCategoryEnColor.Text = appSetting.CategoryEnSetting.HexColor;
                }
                if (appSetting.CategoryKhSetting != null)
                {
                    txtCategoryKhB.Text = appSetting.CategoryKhSetting.Buttom + "";
                    txtCategoryKhH.Text = appSetting.CategoryKhSetting.Height + "";
                    txtCategoryKhR.Text = appSetting.CategoryKhSetting.Right + "";
                    txtCategoryKhW.Text = appSetting.CategoryKhSetting.Width + "";
                    txtCategoryKhX.Text = appSetting.CategoryKhSetting.X + "";
                    txtCategoryKhY.Text = appSetting.CategoryKhSetting.Y + "";
                    cboCategoryKhFont.SelectedItem = appSetting.CategoryKhSetting.FontName;
                    cbCategoryKhBold.Checked = appSetting.CategoryKhSetting.FontBold;
                    txtCategoryKhColor.Text = appSetting.CategoryKhSetting.HexColor;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (appSetting != null)
            {
                string filesave = Components.AppUtils.Default.openFileSaveDialog("Save File", "Product Price Generator Files (*.ppgf) | *.ppgf");
                if (filesave.NonNullOrEmpty())
                {
                    string json = Components.AppUtils.Default.FromObjectToJsonString<AppSetting>(appSetting);
                    System.IO.File.WriteAllText(filesave, json);
                    Components.AppUtils.Default.AlertMessage("Configuration saved to " + filesave, true);
                }
            }
        }

        private void btnLayoutSetting_Click(object sender, EventArgs e)
        {
            Forms.frmLayoutSetting frm = new frmLayoutSetting(appSetting.LayoutSetting == null ? new LayoutSetting() : appSetting.LayoutSetting);
            frm.PreviewLayoutSettingEventHandler_Click += Frm_PreviewLayoutSettingEventHandler_Click;
            frm.ShowDialog();
        }

        private void Frm_PreviewLayoutSettingEventHandler_Click(LayoutSetting layoutSetting)
        {
            appSetting.LayoutSetting = layoutSetting;
            if (cbPreview.Checked)
            {
                preview();
            }
        }

        private void mButton9_Click(object sender, EventArgs e)
        {
            Forms.frmProductNameEnSetting frm = new frmProductNameEnSetting(appSetting.ProductNameEnSetting == null ? new ProductNameSetting() : appSetting.ProductNameEnSetting);
            frm.PreviewProductNameEnSettingEventHandler_Click += Frm_PreviewProductNameEnSettingEventHandler_Click;
            frm.ShowDialog();
        }

        private void Frm_PreviewProductNameEnSettingEventHandler_Click(ProductNameSetting productNameEnSetting)
        {
            appSetting.ProductNameEnSetting = productNameEnSetting;
            if (cbPreview.Checked)
            {
                preview();
            }
        }

        private void mButton10_Click(object sender, EventArgs e)
        {
            Forms.frmProductNameKhSetting frm = new frmProductNameKhSetting(appSetting.ProductNameKhSetting == null ? new ProductNameSetting() : appSetting.ProductNameKhSetting);
            frm.PreviewProductNameKhSettingEventHandler_Click += Frm_PreviewProductNameKhSettingEventHandler_Click;
            frm.ShowDialog();
        }

        private void Frm_PreviewProductNameKhSettingEventHandler_Click(ProductNameSetting productNameKhSetting)
        {
            appSetting.ProductNameKhSetting = productNameKhSetting;
            if (cbPreview.Checked)
            {
                preview();
            }
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            pageNagivation();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentPage = currentPage - 1;
            pageNagivation();
        }

        private void pageNagivation()
        {
            if (currentPage <= 0) currentPage = 1;
            if (currentPage > totalPage) currentPage = totalPage;

            txtCurrentPage.Text = currentPage + " of " + totalPage;
            if (cbPreview.Checked)
            {
                preview();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage = currentPage + 1;
            pageNagivation();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPage;
            pageNagivation();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbPreview.Checked = Properties.Settings.Default.AUTO_PREVIEW;
            lbVersion.Text = "v" + Application.ProductVersion;

            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;

            AutoUpdater.Mandatory = true;
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.Start("https://csds-group.com/pplg/release.xml");
        }

        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"Closing application...";
            Thread.Sleep(5000);
            Application.Exit();
        }


        private void frmMain_Shown(object sender, EventArgs e)
        {
            cboProductCodeFont.BindingDataSource(new List<string>(fonts), "", "");
            cboProductNameEnFont.BindingDataSource(new List<string>(fonts), "", "");
            cboProductNameKhFont.BindingDataSource(new List<string>(fonts), "", "");
            cboUnitSalePriceFont.BindingDataSource(new List<string>(fonts), "", "");
            cboCategoryEnFont.BindingDataSource(new List<string>(fonts), "", "");
            cboCategoryKhFont.BindingDataSource(new List<string>(fonts), "", "");
        }

        private void btnProductCodePickupColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtProductCodeColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtProductNameEnColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void mButton4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtProductNameKhColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void cbPreview_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AUTO_PREVIEW = cbPreview.Checked;
            Properties.Settings.Default.Save();
        }

        private void mButton6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtUnitSalePriceColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void mButton5_Click(object sender, EventArgs e)
        {
            string folder = AppUtils.Default.openFolderBrowsing();
            if (folder.NonNullOrEmpty())
            {
                txtProductPictureFolder.Text = folder;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = preview();
            if (bitmap != null)
            {
                string filename = AppUtils.Default.openFileSaveDialog("Save File", "Image files (*.jpg) | *.jpg");
                if (filename.NonNullOrEmpty())
                {
                    bitmap.Save(filename);
                    AppUtils.Default.AlertMessage("File saved to " + filename);
                }
            }
        }

        private void btnChooseBackground_Click(object sender, EventArgs e)
        {
            string filename = Components.AppUtils.Default.openFileDialog("Choose Background", "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png");
            if (filename.NonNullOrEmpty())
            {
                if (System.IO.File.Exists(filename))
                {
                    txtBackground.Text = filename;
                }
            }
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            string filename = Components.AppUtils.Default.openFileDialog("Choose Product Cover", "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png");
            if (filename.NonNullOrEmpty())
            {
                txtProductCover.Text = filename;
            }
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            if (totalPage >= 1)
            {
                string folder = AppUtils.Default.openFolderBrowsing();
                if (System.IO.Directory.Exists(folder))
                {
                    for (int i = 1; i <= totalPage; i++)
                    {
                        currentPage = i;
                        Bitmap bitmap = preview();
                        if (bitmap != null)
                        {
                            bitmap.Save(folder + "\\Page_" + i + ".jpg");
                        }
                    }
                    AppUtils.Default.AlertMessage(totalPage + " file(s) saved to " + folder);
                }
            }
        }

        private void cboWorksheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsInCategroy = new SortableBindingList<Product>(list.Where(x => x.CategoryNameEnKh == cboWorksheets.Text));

            lbStatus.Text = productsInCategroy.Count + " record(s) found of " + list.Count + " record(s)";
            double page = ((double)productsInCategroy.Count / (double)(txtLayoutRow.getInt() * txtLayoutColumn.getInt()));
            totalPage = (int)AppUtils.Default.RoundUp(page);
            if (totalPage <= 0)
            {
                totalPage = 1;
            }
            btnMoveFirst_Click(sender, e);
        }

        private void mButton8_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtCategoryKhColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }

        private void mButton7_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtCategoryEnColor.Text = Components.AppUtils.Default.HexConverter(colorDialog.Color);
            }
        }
    }
}