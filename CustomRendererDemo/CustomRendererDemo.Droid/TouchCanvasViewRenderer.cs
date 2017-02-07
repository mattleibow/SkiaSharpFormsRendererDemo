using System;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using SkiaSharp;
using SkiaSharp.Views.Forms;

[assembly: ExportRenderer(typeof(CustomRendererDemo.TouchCanvasView), typeof(CustomRendererDemo.Droid.TouchCanvasViewRenderer))]

namespace CustomRendererDemo.Droid
{
	public class TouchCanvasViewRenderer : SKCanvasViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<SKCanvasView> e)
		{
			// clean up old native control
			if (Control != null)
			{
				Control.Touch -= OnTouch;
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
				Control.Touch += OnTouch;
			}

			// set up new element
			if (e.NewElement != null)
			{
				var newTouchCanvas = (TouchCanvasView)Element;
				var newTouchController = (ITouchCanvasViewController)Element;

				// ...
			}
		}

		private void OnTouch(object sender, TouchEventArgs e)
		{
			var touchController = Element as ITouchCanvasViewController;
			if (touchController != null)
			{
				var wasTap = e.Event.ActionMasked == MotionEventActions.Up || e.Event.ActionMasked == MotionEventActions.Cancel;
				if (wasTap)
				{
					var scale = Control.Resources.DisplayMetrics.Density;
					touchController.OnTouch(new SKPoint(e.Event.GetX() / scale, e.Event.GetY() / scale));
				}
			}
		}
	}
}
