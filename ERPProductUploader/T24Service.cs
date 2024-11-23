using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERPClientTools.Domains;

namespace ERPClientTools
{
    public class T24Service
    {

        public T24Transaction process(T24Transaction transaction)
        {
            //String url = Properties.Settings.Default.T24_WEBSERVICE_URL + "?companyId=" + transaction.BranchCode;

            //Dictionary<string, object> requestBody = new Dictionary<string, object>();
            //Dictionary<string, object> body = new Dictionary<string, object>();
            //body.Add("transactionType", transaction.TransactionType);
            //body.Add("debitAccountId", transaction.DebitAccountNo);

            //if (transaction.DebitCurrency != null && transaction.DebitAmount > 0)
            //{
            //    body.Add("debitCurrency", transaction.DebitCurrency);
            //    body.Add("debitAmount", transaction.DebitAmount);
            //}
            //else if (transaction.CreditCurrency != null && transaction.CreditAmount > 0)
            //{
            //    body.Add("creditCurrencyId", transaction.CreditCurrency);
            //    body.Add("creditAmount", transaction.CreditAmount);
            //}
            //else
            //{
            //    transaction.T24Result = "Skipped";
            //}

            //if (transaction.T24Result != "Skipped")
            //{
            //    body.Add("creditAccountId", transaction.CreditAccountNo);
            //    body.Add("debitTheirRef", transaction.DebitTheirRef);
            //    body.Add("creditTheirRef", transaction.CreditThierRef);
            //    body.Add("paymentDetails", transaction.PaymentDetail);
            //    requestBody.Add("body", body);

            //    //            var body = @"{
            //    //" + "\n" +
            //    //            @"  ""body"": {
            //    //" + "\n" +
            //    //            @"    ""transactionType"": ""ACFT"",
            //    //" + "\n" +
            //    //            @"    ""debitAccountId"": ""100013355"",
            //    //" + "\n" +
            //    //            @"    ""debitCurrency"": ""USD"",
            //    //" + "\n" +
            //    //            @"    ""debitAmount"": 1,
            //    //" + "\n" +
            //    //            @"    ""creditAccountId"": ""100012863"",
            //    //" + "\n" +
            //    //            @"    ""debitTheirRef"": ""Remark testing"",
            //    //" + "\n" +
            //    //            @"    ""creditTheirRef"": ""Remark testing"",
            //    //" + "\n" +
            //    //            @"    ""paymentDetails"": ""UNK000001""
            //    //" + "\n" +
            //    //            @"  }
            //    //" + "\n" +
            //    //            @"}";
            //    String response = Components.Utilities.RestAPIUtilities.Default.Post(url, requestBody);
            //    T24Response t24Response = Components.Utilities.JsonUtilities.Default.FromStringToObject<T24Response>(response);
            //    Components.Log.Debug("After deserilized => " + Components.Utilities.JsonUtilities.Default.FromObjectToJsonString<T24Response>(t24Response));
            //    if (t24Response.Error != null)
            //    {
            //        //Console.WriteLine("=> " + t24Response.Error.ErrorDetails[0].FieldName + "-" + t24Response.Error.ErrorDetails[0].Message);
            //        transaction.T24Result = t24Response.Error.ErrorDetails != null ? t24Response.Error.ErrorDetails[0].FieldName + "-" + t24Response.Error.ErrorDetails[0].Message : t24Response.Header.Status;
            //        transaction.Success = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("=> " + t24Response.Header.Status);
            //        if (t24Response.Header.Status == "success")
            //        {
            //            Console.WriteLine("=> " + "OK" + "-" + t24Response.Header.ID);
            //            transaction.T24Result = "OK" + "-" + t24Response.Header.ID;
            //            transaction.Success = true;
            //        }
            //        else
            //        {
            //            Console.WriteLine("=> " + "Failed" + "-" + t24Response.Header.ID);
            //            transaction.T24Result = "Failed" + "-" + t24Response.Header.ID;
            //            transaction.Success = false;
            //        }
            //    }
            //}

            //return transaction;
            return null;
        }
    }
}
