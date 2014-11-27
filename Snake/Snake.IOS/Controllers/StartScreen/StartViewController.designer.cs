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
	[Register ("StartViewController")]
	partial class StartViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnClose { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnEasy { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnHard { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnMedium { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnStart { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblEasy { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblEasyValue { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblHigh { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblHighValue { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblMedium { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblMediumValue { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblTitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView vwLevelSelector { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnEasy != null) {
				btnEasy.Dispose ();
				btnEasy = null;
			}

			if (btnHard != null) {
				btnHard.Dispose ();
				btnHard = null;
			}

			if (btnMedium != null) {
				btnMedium.Dispose ();
				btnMedium = null;
			}

			if (btnStart != null) {
				btnStart.Dispose ();
				btnStart = null;
			}

			if (lblEasy != null) {
				lblEasy.Dispose ();
				lblEasy = null;
			}

			if (lblEasyValue != null) {
				lblEasyValue.Dispose ();
				lblEasyValue = null;
			}

			if (lblHigh != null) {
				lblHigh.Dispose ();
				lblHigh = null;
			}

			if (lblHighValue != null) {
				lblHighValue.Dispose ();
				lblHighValue = null;
			}

			if (lblMedium != null) {
				lblMedium.Dispose ();
				lblMedium = null;
			}

			if (lblMediumValue != null) {
				lblMediumValue.Dispose ();
				lblMediumValue = null;
			}

			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}

			if (vwLevelSelector != null) {
				vwLevelSelector.Dispose ();
				vwLevelSelector = null;
			}

			if (btnClose != null) {
				btnClose.Dispose ();
				btnClose = null;
			}
		}
	}
}
