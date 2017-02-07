using System;
using System.Collections.Generic;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace CustomRendererDemo
{
	public partial class MainPage : ContentPage
	{
		private readonly List<Tuple<SKPoint, SKColor>> points = new List<Tuple<SKPoint, SKColor>>();
		private readonly Random random = new Random();

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnTouched(SKPoint point)
		{
			var color = new SKColor((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
			points.Add(new Tuple<SKPoint, SKColor>(point, color));

			canvasView.InvalidateSurface();
		}

		private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;

			// scale the canvas up (for higher resolution screens)
			var scale = e.Info.Width / (float)Width;
			canvas.Scale(scale);


			// make the surface nice
			canvas.Clear(SKColors.White);


			// draw the dots
			var dotPaint = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Fill
			};
			foreach (var point in points)
			{
				dotPaint.Color = point.Item2;
				canvas.DrawCircle(point.Item1.X, point.Item1.Y, 10, dotPaint);
			}


			// draw the instructions
			var textPaint = new SKPaint
			{
				IsAntialias = true,
				Color = SKColors.Brown,
				Style = SKPaintStyle.Fill,
				TextSize = 48,
				TextAlign = SKTextAlign.Center,
				Typeface = SKTypeface.FromFamilyName("Arial", SKTypefaceStyle.Bold)
			};
			canvas.DrawText("tap 4 dots!", (float)Width / 2, 50, textPaint);
			// give it a border
			textPaint.Style = SKPaintStyle.Stroke;
			textPaint.StrokeWidth = 1;
			textPaint.Color = SKColors.White;
			canvas.DrawText("tap 4 dots!", (float)Width / 2, 50, textPaint);
		}
	}
}
