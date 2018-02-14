using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkiaSharpSample
{
	public partial class MainPage : ContentPage
    {
        public MainPage()
		{
			InitializeComponent();
		}

        private void OnStartAngleValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (canvasView != null)
            {
                canvasView.InvalidateSurface();
            }

        }
        private void OnSweepAngleValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (canvasView != null)
            {
                canvasView.InvalidateSurface();
            }
        }

        void OnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var info = args.Info;
            var surface = args.Surface;
            var canvas = surface.Canvas;

            canvas.Clear();

            var startAngle = (float)sliStart.Value;
            var sweepAngle = (float)sliSweep.Value;

            var center = new SKPoint(info.Width / 2F, info.Height / 2F);

            var radius = Math.Min(info.Width / 2, info.Height / 2) ;

            var rect = new SKRect(center.X - radius, center.Y - radius,
                center.X + radius, center.Y + radius);

            using (SKPath path = new SKPath())
            using (SKPaint fillPaint = new SKPaint())
            {
                fillPaint.Style = SKPaintStyle.Fill;
                fillPaint.Color = SKColors.DarkSlateBlue;
                
                path.MoveTo(center);

                path.ArcTo(rect, startAngle, sweepAngle == 360F ? 359.999F : sweepAngle, false);

                path.Close();
                canvas.DrawPath(path, fillPaint);
            }
        }
    }
}
