using Android.App;
using Android.Widget;
using Android.OS;

using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AndroidSendGmailSample
{
	[Activity (Label = "AndroidSendGmailSample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				Send_Gmail("this is body", "this is subject", "puremars2k10@gmail.com");
			};
		}

		public void Send_Gmail(string msg, string mysubject, string address)
		{
			MailMessage mmsg = new MailMessage (@"puremars2k10@gmail.com", @"sean.ma@jetfusion.com.tw");
			mmsg.IsBodyHtml = true; //設定是否採用HTML格式
			mmsg.BodyEncoding = Encoding.UTF8; //設定mail內容的編碼
			mmsg.SubjectEncoding = Encoding.UTF8; //設定mail主旨的編碼
			mmsg.Priority = MailPriority.Normal; //設定優先權 1.High 2.Normail 3.Low
			mmsg.Subject = mysubject; // mail主旨
			mmsg.Body = msg; //mail內容

			SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587); //允許程式使用smtp來發mail，並設定smtp server & port
			MySmtp.Credentials = new NetworkCredential("puremars2k10@gmail.com", "7527540a"); //設定帳號與密碼 需要using system.net;
			MySmtp.EnableSsl = true; //開啟SSL連線 (gmail體系須使用SSL連線)
			MySmtp.Send(mmsg);

			MySmtp = null; //將MySmtp清空
			mmsg.Dispose(); //釋放資源
		}
	}
}


