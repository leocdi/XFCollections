using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ObservableTune.Controls;
using ObservableTune.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircleButton), typeof(CircleButtonRenderer))]
namespace ObservableTune.Droid.Renderers
{

    [Preserve(AllMembers = true)]
    class CircleButtonRenderer : ButtonRenderer
    {
        public CircleButtonRenderer(Context context) : base(context)
        {
        }
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="child"></param>
        /// <param name="drawingTime"></param>
        /// <returns></returns>
        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;

                var borderThickness = (float)((CircleButton)Element).BorderThickness;

                int strokeWidth = 0;

                if (borderThickness > 0)
                {
                    var logicalDensity = Context.Resources.DisplayMetrics.Density;
                    strokeWidth = (int)Math.Ceiling(borderThickness * logicalDensity + .5f);
                }

                radius -= strokeWidth / 2;

                var path = new Path();
                path.AddCircle(Width / 2.0f, Height / 2.0f, radius, Path.Direction.Ccw);

                canvas.Save();
                canvas.ClipPath(path);

                var paint = new Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Paint.Style.Fill);
                canvas.DrawPath(path, paint);
                paint.Dispose();

                var result = base.DrawChild(canvas, child, drawingTime);

                path.Dispose();
                canvas.Restore();



                if (strokeWidth > 0.0f)
                {
                    path = new Path();
                    path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

                    paint = new Paint();
                    paint.AntiAlias = true;
                    paint.StrokeWidth = strokeWidth;
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = ((CircleButton)Element).BorderColor.ToAndroid();
                    canvas.DrawPath(path, paint);
                    paint.Dispose();
                    path.Dispose();
                }


                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle button: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }
            }


            if (((CircleButton)Element).ImageSource != null)
            {
                Android.Widget.Button thisButton = Control as Android.Widget.Button;
                thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) =>
                {
                    if (e2.Event.Action == MotionEventActions.Down)
                    {
                        Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
                    }
                    else if (e2.Event.Action == MotionEventActions.Up)
                    {
                        Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
                        Control.SetShadowLayer(0, 0, 0, Android.Graphics.Color.Transparent);
                        Control.CallOnClick();
                    }
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CircleButton.BorderColorProperty.PropertyName ||
              e.PropertyName == CircleButton.BorderThicknessProperty.PropertyName ||
              e.PropertyName == CircleButton.TextProperty.PropertyName)
            {

                this.Invalidate();
            }
        }
    }
}