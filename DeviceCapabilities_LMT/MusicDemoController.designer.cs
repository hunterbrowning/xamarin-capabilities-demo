// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace DeviceCapabilities_LMT
{
	[Register ("MusicDemoController")]
	partial class MusicDemoController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton justPlayBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem pauseBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem playBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem stopBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel theArtistLbl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem theOpenBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel theTitleLbl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider theVolumeSld { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (justPlayBtn != null) {
				justPlayBtn.Dispose ();
				justPlayBtn = null;
			}

			if (theArtistLbl != null) {
				theArtistLbl.Dispose ();
				theArtistLbl = null;
			}

			if (theOpenBtn != null) {
				theOpenBtn.Dispose ();
				theOpenBtn = null;
			}

			if (theTitleLbl != null) {
				theTitleLbl.Dispose ();
				theTitleLbl = null;
			}

			if (theVolumeSld != null) {
				theVolumeSld.Dispose ();
				theVolumeSld = null;
			}

			if (stopBtn != null) {
				stopBtn.Dispose ();
				stopBtn = null;
			}

			if (pauseBtn != null) {
				pauseBtn.Dispose ();
				pauseBtn = null;
			}

			if (playBtn != null) {
				playBtn.Dispose ();
				playBtn = null;
			}
		}
	}
}
