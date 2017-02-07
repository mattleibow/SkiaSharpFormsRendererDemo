using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace CustomRendererDemo
{
	public class TouchCanvasView : SKCanvasView, ITouchCanvasViewController
	{
		public event Action<SKPoint> Touched;

		public virtual void OnTouch(SKPoint point)
		{
			Touched?.Invoke(point);
		}
	}

	public interface ITouchCanvasViewController : IViewController
	{
		void OnTouch(SKPoint point);
	}
}
