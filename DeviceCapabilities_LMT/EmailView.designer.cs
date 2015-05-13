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
	[Register ("EmailView")]
	partial class EmailView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton emailBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (emailBtn != null) {
				emailBtn.Dispose ();
				emailBtn = null;
			}
		}
	}
}
