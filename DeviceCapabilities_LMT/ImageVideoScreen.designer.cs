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
	[Register ("ImageVideoScreen")]
	partial class ImageVideoScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton playMovie { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton showPicker { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (showPicker != null) {
				showPicker.Dispose ();
				showPicker = null;
			}

			if (playMovie != null) {
				playMovie.Dispose ();
				playMovie = null;
			}

			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}
		}
	}
}
