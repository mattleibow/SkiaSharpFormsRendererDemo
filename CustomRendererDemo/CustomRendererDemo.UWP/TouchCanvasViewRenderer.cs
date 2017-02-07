using System;
using Windows.UI.Xaml.Input;
using Xamarin.Forms.Platform.UWP;

using SkiaSharp;
using SkiaSharp.Views.UWP;
using SkiaSharp.Views.Forms;

[assembly: ExportRenderer(typeof(CustomRendererDemo.TouchCanvasView), typeof(CustomRendererDemo.UWP.TouchCanvasViewRenderer))]

namespace CustomRendererDemo.UWP
{
	public class TouchCanvasViewRenderer : SKCanvasViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<SKCanvasView> e)
		{
			// clean up old native control
			if (Control != null)
			{
				Control.PointerReleased -= OnReleased;
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
				Control.PointerReleased += OnReleased;
			}

			// set up new element
			if (e.NewElement != null)
			{
				var newTouchCanvas = (TouchCanvasView)Element;
				var newTouchController = (ITouchCanvasViewController)Element;

				// ...
			}
		}

		private void OnReleased(object sender, PointerRoutedEventArgs e)
		{
			var touchController = Element as ITouchCanvasViewController;
			if (touchController != null)
			{
				var current = e.GetCurrentPoint(Control);
				var point = current.Position.ToSKPoint();
				touchController.OnTouch(point);
			}
		}
	}
}
