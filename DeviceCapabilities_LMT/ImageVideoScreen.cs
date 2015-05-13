using System;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MediaPlayer;
using System.Collections.Generic;

namespace DeviceCapabilities_LMT
{
	public partial class ImageVideoScreen : UIViewController
	{
		UIImagePickerController _picker;
		PickerDelegate _pickerDel;
		UIActionSheet _actionSheet;
		MPMoviePlayerController _mp;
	
		public ImageVideoScreen () : base ("ImageVideoScreen", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			_picker = new UIImagePickerController ();
			_pickerDel = new PickerDelegate (this);
			_picker.Delegate = _pickerDel;

			_actionSheet = new UIActionSheet ();
			_actionSheet.AddButton ("Library");
			_actionSheet.AddButton ("Camera");
			_actionSheet.AddButton ("Cancel");
			_actionSheet.CancelButtonIndex = 2;
			_actionSheet.Delegate = new ActionSheetDelegate (this);

			showPicker.TouchUpInside += delegate {
				_actionSheet.ShowInView (this.View);
			};

			playMovie.Hidden = true;

			playMovie.TouchUpInside += delegate {
				if (_mp != null) {
					View.AddSubview (_mp.View);
					_mp.SetFullscreen (true, true);
					_mp.Play ();
				}
			};
		}

		class ActionSheetDelegate : UIActionSheetDelegate
		{
			ImageVideoScreen _controller;

			public ActionSheetDelegate (ImageVideoScreen controller)
			{
				_controller = controller;
			}

			void ShowPicker (UIImagePickerControllerSourceType sourceType)
			{
				if (!UIImagePickerController.IsSourceTypeAvailable (sourceType)) {
					var alert = new UIAlertView ("Image Picker", "Source type not available", null, "Close");
					alert.Show ();
				} else {
					_controller._picker.SourceType = sourceType;
					string[] availableMediaTypes = UIImagePickerController.AvailableMediaTypes (sourceType);
					string[] requestMediatypes = new string[] {
						"public.image", "public.movie"
					};
					List<string> mediaTypes = new List<string> ();

					foreach (string mediaType in requestMediatypes) {
						if (availableMediaTypes.Contains (mediaType))
							mediaTypes.Add (mediaType);
					}

					_controller._picker.MediaTypes = mediaTypes.ToArray ();

					_controller.PresentViewController (_controller._picker, true, null);
				}
			}

			public override void Clicked (UIActionSheet actionSheet, int buttonIndex)
			{
				switch (buttonIndex) {
				case 0:
					ShowPicker (UIImagePickerControllerSourceType.PhotoLibrary);
					break;
				case 1:
					ShowPicker (UIImagePickerControllerSourceType.Camera);
					break;
				}
				actionSheet.DismissWithClickedButtonIndex (buttonIndex, true);
			}
		}

		class PickerDelegate : UIImagePickerControllerDelegate
		{
			ImageVideoScreen _controller;

			public PickerDelegate (ImageVideoScreen controller)
			{
				_controller = controller;
			}

			public override void FinishedPickingMedia (UIImagePickerController picker, NSDictionary info)
			{
				picker.DismissViewController (true, null);

				string mediaType = info [new NSString ("UIImagePickerControllerMediaType")].ToString ();
				UIImage img = null;

				if (mediaType == "public.image") {
					img = (UIImage)info [new NSString ("UIImagePickerControllerOriginalImage")];
					_controller.playMovie.Hidden = true;
				}
				else if (mediaType == "public.movie"){
					NSUrl videoUrl = (NSUrl)info[new NSString ("UIImagePickerControllerMediaURL")];
					_controller._mp = new MPMoviePlayerController (videoUrl);
					// ThumbnailImageAt has been decipricated in iOS7
					img = _controller._mp.ThumbnailImageAt(0, MPMovieTimeOption.NearestKeyFrame);
					_controller.playMovie.Hidden = false;
				}
				if (img != null)
					_controller.imageView.Image = img;
			}
		}
	}
}

