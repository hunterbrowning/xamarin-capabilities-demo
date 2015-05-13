using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.SlideoutNavigation;
using MonoTouch.Dialog;

namespace DeviceCapabilities_LMT
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		public SlideoutNavigationController Menu { get; private set; }

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			Menu = new SlideoutNavigationController ();
			Menu.SlideHeight = 9999f;
			Menu.TopView = new WelcomeScreen ();
			Menu.MenuViewLeft = new SlideControllerLeft ();
			Menu.RightMenuEnabled = false;
			Menu.SlideWidth = 260f; // allows you to determine how much of the menu is vissible
			Menu.SlideSpeed = 1; // how many seconds you want the slide transition to take
		
			window.RootViewController = Menu;
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}

	public class SlideControllerLeft : DialogViewController
	{
		public SlideControllerLeft () : base(UITableViewStyle.Plain,new RootElement(""))
		{
		}

		public override void ViewDidLoad ()
		{
			Root.Add (new Section () {
				new StyledStringElement ("Home", () => {
					NavigationController.PushViewController (new WelcomeScreen (), true);
				}),
				new StyledStringElement("Email", () => {
					NavigationController.PushViewController(new EmailView(), true);
				}),
				new StyledStringElement("Music", () => {
					NavigationController.PushViewController(new MusicDemoController(), true);
				}),
				new StyledStringElement("Address Book", () => {
					NavigationController.PushViewController(new AddressBookScreen(), true);
				}),
				new StyledStringElement("Image / Video", () => {
					NavigationController.PushViewController(new ImageVideoScreen(), true);
				})
			});
		}
	}
}

