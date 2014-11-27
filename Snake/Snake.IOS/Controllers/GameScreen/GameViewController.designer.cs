// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Snake.IOS
{
	[Register ("GameViewController")]
	partial class GameViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnBottom { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnClose { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLeft { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnPause { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnQuit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnRestart { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnRight { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnTop { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblLevel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblScore { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel[] lblTiles { get; set; }

		[Outlet]
		Snake.IOS.GamePanel Panel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView vwFinishDialog { get; set; }

		[Action ("OnCloseApp:")]
		partial void OnCloseApp (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnBottom != null) {
				btnBottom.Dispose ();
				btnBottom = null;
			}

			if (btnClose != null) {
				btnClose.Dispose ();
				btnClose = null;
			}

			if (btnLeft != null) {
				btnLeft.Dispose ();
				btnLeft = null;
			}

			if (btnPause != null) {
				btnPause.Dispose ();
				btnPause = null;
			}

			if (btnQuit != null) {
				btnQuit.Dispose ();
				btnQuit = null;
			}

			if (btnRestart != null) {
				btnRestart.Dispose ();
				btnRestart = null;
			}

			if (btnRight != null) {
				btnRight.Dispose ();
				btnRight = null;
			}

			if (btnTop != null) {
				btnTop.Dispose ();
				btnTop = null;
			}

			if (lblLevel != null) {
				lblLevel.Dispose ();
				lblLevel = null;
			}

			if (lblScore != null) {
				lblScore.Dispose ();
				lblScore = null;
			}

			if (Panel != null) {
				Panel.Dispose ();
				Panel = null;
			}

			if (vwFinishDialog != null) {
				vwFinishDialog.Dispose ();
				vwFinishDialog = null;
			}
		}
	}
}
