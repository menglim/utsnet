using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ERPClientTools.Domains
{
    public class T24Transaction
    {
        [Components.MDataGridViewAttributes.DisplayName(Name = "Branch Code")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter)]
        public String BranchCode { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Branch Name")]
        public String BranchName { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Transaction Type")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter)]
        public String TransactionType { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Debit Account No")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter)]
        public String DebitAccountNo { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Credit Account No")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter)]
        public String CreditAccountNo { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Dedit Currency")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter)]
        public String DebitCurrency { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Dedit Amount")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight)]
        [Components.MDataGridViewAttributes.CurrencyFormat(Format = "#,##0.00")]
        public Double? DebitAmount { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Credit Currency")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter)]
        public String CreditCurrency { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Credit Amount")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight)]
        [Components.MDataGridViewAttributes.CurrencyFormat(Format = "#,##0.00")]
        public Double? CreditAmount { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Debit Their Ref")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft)]
        public String DebitTheirRef { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Credit Their Ref")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft)]
        public String CreditThierRef { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "Payment Details")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft)]
        public String PaymentDetail { get; set; }

        [Components.MDataGridViewAttributes.DisplayName(Name = "T24 Result")]
        [Components.MDataGridViewAttributes.Alignment(Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft)]
        public String T24Result { get; set; }

        [Components.MDataGridViewAttributes.Hidden]
        public bool Success { get; set; }
    }
}
