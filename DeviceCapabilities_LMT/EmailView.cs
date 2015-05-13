using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MessageUI;

namespace DeviceCapabilities_LMT
{
	public partial class EmailView : UIViewController
	{
		MFMailComposeViewController _mail;

		public EmailView () : base ("EmailView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			emailBtn.TouchUpInside += (object sender, EventArgs e) => {
				if (MFMailComposeViewController.CanSendMail) {
					_mail = new MFMailComposeViewController ();
					_mail.SetToRecipients (new string[] { "person1@flargan.me", "person2@flargan.me" });
					_mail.SetCcRecipients (new string[] { "person3@flargan.me" });
					_mail.SetBccRecipients (new string[] { "person4@flargan.me" });
					_mail.SetMessageBody ("This is the body of the message homie", false);
					_mail.SetSubject ("Demo Email");
					_mail.Finished += HandleMailFinished;
					this.PresentViewController (_mail, true, null);
				} else {
					var alert = new UIAlertView ("Mail Alert", "Mail Not Sent", null, "Mail Demo", null);
					alert.Show ();
				}
			};
		}

		void HandleMailFinished (object sender, MFComposeResultEventArgs e)
		{
			if (e.Result == MFMailComposeResult.Sent)
			{
				var alert = new UIAlertView ("Mail Alert", "Mail Sent", null, "Mail Demo", null);
				alert.Show ();
			}
			e.Controller.DismissViewController (true, null);
		}
	}
}

