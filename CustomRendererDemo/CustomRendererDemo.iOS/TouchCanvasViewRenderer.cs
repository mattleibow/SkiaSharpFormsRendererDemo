using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using SkiaSharp;
using SkiaSharp.Views.iOS;
using SkiaSharp.Views.Forms;

[assembly: ExportRenderer(typeof(CustomRendererDemo.TouchCanvasView), typeof(CustomRendererDemo.Droid.TouchCanvasViewRenderer))]

namespace CustomRendererDemo.Droid
{
	public class TouchCanvasViewRenderer : SKCanvasViewRenderer
	{
		private readonly UITapGestureRecognizer tapGestureRecognizer;

		public TouchCanvasViewRenderer()
		{
			tapGestureRecognizer = new UITapGestureRecognizer(OnTapped);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<SkiaSharp.Views.Forms.SKCanvasView> e)
		{
			// clean up old native control
			if (Control != null)
			{
				Control.RemoveGestureRecognizer(tapGestureRecognizer);
			}

			// do clean up old element
			if (Element != null)
			{
				var oldTouchCanvas = (TouchCanvasView)Element;
				var oldTouchController = (ITouchCanvasViewController)Element;

				// ...
			}

			base.OnElementChanged(e);

			// set up new native control
			if (Control != null)
			{
				Control.UserInteractionEnabled = true;
				Control.AddGestureRecognizer(tapGestureRecognizer);
			}

			// set up new element
			if (e.NewElement != null)
			{
				var newTouchCanvas = (TouchCanvasView)Element;
				var newTouchController = (ITouchCanvasViewController)Element;

				// ...
			}
		}

		private void OnTapped(UITapGestureRecognizer recognizer)
		{
			var touchController = Element as ITouchCanvasViewController;
			if (touchController != null)
			{
				touchController.OnTouch(recognizer.LocationInView(Control).ToSKPoint());
			}
		}
	}
}
