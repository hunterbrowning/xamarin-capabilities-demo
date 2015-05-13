using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MediaPlayer;

namespace DeviceCapabilities_LMT
{
	public partial class MusicDemoController : UIViewController
	{
		/*
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public MusicDemoController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public MusicDemoController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public MusicDemoController () : base("MusicDemoController", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}

		#endregion*/

		MPMusicPlayerController _musicPlayer;
		MPMediaPickerController _mediaController;
		MediaPickerDelegate _mpDelegate;

		public MusicDemoController () : base ("MusicDemoController", null)
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
			_musicPlayer = new MPMusicPlayerController ();
			// volume is dicpercated in ios7
			_musicPlayer.Volume = theVolumeSld.Value;
			_mediaController = new MPMediaPickerController (MPMediaType.Music);
			_mediaController.AllowsPickingMultipleItems = false;
			_mpDelegate = new MediaPickerDelegate (this);
			_mediaController.Delegate = _mpDelegate;

			theVolumeSld.ValueChanged += delegate {
				_musicPlayer.Volume = theVolumeSld.Value;
			};
			justPlayBtn.TouchUpInside += (object sender, EventArgs e) => {
				_musicPlayer.CurrentPlaybackTime = 5000; // this works. 
				_musicPlayer.Play ();
			};
			theOpenBtn.Clicked += (object sender, EventArgs e) => {
				this.PresentViewController(_mediaController, true, null); };
			stopBtn.Clicked += (object sender, EventArgs e) => {
				Console.WriteLine(_musicPlayer.CurrentPlaybackTime);
				_musicPlayer.Stop();
			};
			pauseBtn.Clicked += (object sender, EventArgs e) => {
				_musicPlayer.Pause();
			};
			playBtn.Clicked += (object sender, EventArgs e) => {
				_musicPlayer.Play();
			};
		}

		public class MediaPickerDelegate : MPMediaPickerControllerDelegate
		{
			MusicDemoController _musicView;

			public MediaPickerDelegate (MusicDemoController viewController) : base()
			{
				_musicView = viewController;
			}

			public override void MediaItemsPicked (MPMediaPickerController sender, MPMediaItemCollection mediaItemCollection)
			{
				_musicView._musicPlayer.SetQueue (mediaItemCollection);
				_musicView.DismissViewController (true, null);

				MPMediaItem mediaItem = mediaItemCollection.Items [0];

				string artist = mediaItem.ValueForProperty ("artist").ToString ();

				string title = mediaItem.Title;

				_musicView.theArtistLbl.Text = artist;
				_musicView.theTitleLbl.Text = title;
			}

			public override void MediaPickerDidCancel (MPMediaPickerController sender)
			{
				_musicView.DismissViewController (true, null);
			}
		}
	}
}

