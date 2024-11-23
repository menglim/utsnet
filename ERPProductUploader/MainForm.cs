using Components;
using Components.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPClientTools
{
    public class MainForm
    {
        private static Components.MButton mActionButton = null;
        public static String PRODUCT_TITLE
        {
            get
            {
                return BasedForm.AppConfig.Title;
            }
        }


        public static Domains.Server Server { get; set; }
        public static Domains.Login Login { get; set; }

        public static void setMessage(String message, bool isSuccess)
        {
            if (!isSuccess)
                AppUtils.Default.AlertMessage(PRODUCT_TITLE, message, isSuccess);
            Forms.frmMain frmMain = Application.OpenForms["frmMain"] as Forms.frmMain;
            if (frmMain != null)
            {
                frmMain.setMessage(PRODUCT_TITLE, message, isSuccess);
            }
        }

        public static string Version
        {
            get
            {
                return Application.ProductVersion;
            }
        }

        public static void waitCursor(bool waitCursor = true)
        {
            Application.DoEvents();
            Forms.frmUploadProduct frm = Application.OpenForms["frmMain"] as Forms.frmUploadProduct;
            Application.Idle -= Application_Idle;
            Application.Idle += Application_Idle;
            if (frm != null)
            {
                if (waitCursor)
                {
                    frm.UseWaitCursor = true;
                    frm.PerformSafely(() => frm.Cursor = Cursors.WaitCursor);
                }
                else
                {
                    frm.UseWaitCursor = false;
                    frm.PerformSafely(() => frm.Cursor = Cursors.Default);
                }
            }
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            Forms.frmUploadProduct frm = Application.OpenForms["frmMain"] as Forms.frmUploadProduct;
            Application.Idle -= Application_Idle;
            if (frm != null)
            {
                frm.UseWaitCursor = false;
                frm.PerformSafely(() => frm.Cursor = Cursors.Default);
                if (mActionButton != null)
                {
                    mActionButton.Enabled = true;
                    mActionButton = null;
                }
            }
        }

        public static List<String> getColumnName<T>(T t)
        {
            List<String> columns = new List<string>();
            foreach (var item in t.GetType().GetProperties())
            {
                Components.MDataGridViewAttributes.HiddenAttribute hiddenCOlumn = (Components.MDataGridViewAttributes.HiddenAttribute)item.GetCustomAttribute(typeof(Components.MDataGridViewAttributes.HiddenAttribute), true);
                if (hiddenCOlumn == null)
                {
                    Components.MDataGridViewAttributes.DisplayNameAttribute displayNameAtt = (Components.MDataGridViewAttributes.DisplayNameAttribute)item.GetCustomAttribute(typeof(Components.MDataGridViewAttributes.DisplayNameAttribute), true);
                    if (displayNameAtt != null)
                        columns.Add(displayNameAtt.Name);
                    columns.Add(item.Name);
                }
            }
            return columns;
        }

        public static bool ListToExcel<T>(SortableBindingList<T> list)
        {
            MainForm.waitCursor();
            bool result = false;
            if (list != null && list.Count > 0)
            {
                Type type = list[0].GetType();
                List<string> exportColumn = getColumnName<T>(list[0]);

                object instance = Activator.CreateInstance(type);
                PropertyInfo[] properties = instance.GetType().GetProperties(); // get properties
                try
                {
                    var appExcel = new Microsoft.Office.Interop.Excel.Application(); // create application excel
                    var workBook = appExcel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    //var sheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.Add();
                    var sheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[1];
                    int rowIndex = 1;
                    int columnIndex = 1;

                    //Create Row Header
                    Microsoft.Office.Interop.Excel.Range rng;
                    foreach (PropertyInfo info in properties)
                    {
                        String columnName = info.Name;
                        Components.MDataGridViewAttributes.DisplayNameAttribute displayNameAtt = (Components.MDataGridViewAttributes.DisplayNameAttribute)info.GetCustomAttribute(typeof(Components.MDataGridViewAttributes.DisplayNameAttribute), true);
                        if (displayNameAtt != null)
                        {
                            columnName = displayNameAtt.Name;
                        }
                        if (exportColumn.Contains(columnName))
                        {
                            sheet.Cells[rowIndex, columnIndex] = columnName.ToUpper();
                            rng = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowIndex, columnIndex];
                            //if (Properties.Settings.Default.BORDER_EXCEL) BorderAround(rng);
                            rng.Font.Bold = true;
                            columnIndex++;
                        }
                    }

                    rowIndex = 2;
                    columnIndex = 1;

                    foreach (T t in list)
                    {
                        foreach (PropertyInfo info in properties)
                        {
                            String columnName = info.Name;
                            Components.MDataGridViewAttributes.DisplayNameAttribute displayNameAtt = (Components.MDataGridViewAttributes.DisplayNameAttribute)info.GetCustomAttribute(typeof(Components.MDataGridViewAttributes.DisplayNameAttribute), true);
                            if (displayNameAtt != null)
                            {
                                columnName = displayNameAtt.Name;
                            }
                            if (exportColumn.Contains(columnName))
                            {
                                rng = sheet.Cells[rowIndex, columnIndex];
                                rng.NumberFormat = "@";
                                sheet.Cells[rowIndex, columnIndex] = t.GetType().GetProperty(info.Name).GetValue(t, null);
                                //if (Properties.Settings.Default.BORDER_EXCEL) BorderAround(rng);
                                columnIndex++;
                            }
                        }
                        columnIndex = 1;
                        rowIndex++;
                    }
                    result = true;
                    MainForm.setMessage("Exported to excel successfully", true);
                    appExcel.Visible = true;
                }
                catch (Exception ex)
                {
                    MainForm.setMessage("Failed to export to excel. Ex: " + ex.Message, false);
                    result = false;
                }
            }
            MainForm.waitCursor(false);
            return result;
        }
    }
}
