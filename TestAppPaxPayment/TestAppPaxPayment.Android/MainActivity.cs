using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

using POSLink2;

namespace TestAppPaxPayment.Droid
{
    [Activity(Label = "TestAppPaxPayment", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /* Pax Configuration */

            /*
            POSLink2.POSLink2 posLink;
            POSLink2.CommSetting.CommSetting commSetting;

            POSLink2.ManageRequest manageReq;
            ManageResponse manageRes;
            ProcessTransResult transResult;

            /* Instantiating Objects *
            posLink = new POSLink2.POSLink2();
            commSetting = new POSLink2.CommSetting();
            manageReq = new ManageRequest();

            /* Setting up Communications *
            commSetting.CommType = CommSetting.Tcp;
            commSetting.SetTimeOut("300000");
            commSetting.SetDestIP("172.20.2.115");
            commSetting.SetDestPort("10009");
            posLink.SetCommSetting(commSetting);

            /*Sets up ManageRequest Object to perform INIT Command*
            manageReq.TransType = manageReq.ParseTransType("INIT");

            /*Assign ManageRequest Object to the POSLink Object *
            posLink.ManageRequest = manageReq;

            /*Tell terminal to perform the assigned transaction *
            transResult = posLink.ProcessTrans();

            /*Stores the response from the terminal *
            manageRes = posLink.ManageResponse;

            /*Prints stored information from terminal *
            Console.WriteLine(manageRes.ResultCode + " - " + manageRes.ResultTxt
            + "\r\nSN: " + manageRes.Sn
            + "\r\nModel Name: " + manageRes.ModelName
            + "\r\nOS Version: " + manageRes.OSVersion
            + "\r\nMac Address: " + manageRes.MacAddress
            + "\r\nLines Per Screen: " + manageRes.LinesPerScreen
            + "\r\nCharsPerLine: " + manageRes.CharsPerLine);
            */

            POSLink2.CommSetting.TcpSetting commSetting = new POSLink2.CommSetting.TcpSetting();
            commSetting.Ip = "127.0.0.1";
            commSetting.Port = 10009;
            commSetting.Timeout = 60000;

            POSLink2.POSLink2 poslink = POSLink2.POSLink2.GetPOSLink2();
            POSLink2.Terminal terminal = poslink.GetTerminal(commSetting);

            POSLink2.Util.AmountReq amountReq = new POSLink2.Util.AmountReq();
            amountReq.TransactionAmount = "100";
            POSLink2.Util.TraceReq traceReq = new POSLink2.Util.TraceReq();
            traceReq.EcrRefNum = "1";

            POSLink2.Transaction.DoCreditReq doCreditRequest = new POSLink2.Transaction.DoCreditReq();
            doCreditRequest.TransactionType = POSLink2.Const.TransType.Sale;
            doCreditRequest.AmountInformation = amountReq;
            doCreditRequest.TraceInformation = traceReq;

            POSLink2.Transaction.DoCreditRsp doCreditResponse = null;
            POSLink2.ExecutionResult executionResult = terminal.Transaction.DoCredit(doCreditRequest, out doCreditResponse);
            if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
            {
                //Transaction success.
            }

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}