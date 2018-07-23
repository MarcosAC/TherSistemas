﻿using Android.Content;
using Android.Graphics;
using Android.Widget;
using MeDeiBem.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(AwesomeLabelRenderer))]
[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(AwesomeButtonRenderer))]
namespace MeDeiBem.Droid.Renderers
{
    public class AwesomeLabelRenderer : LabelRenderer
    {
        public AwesomeLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            AwesomeUtil.CheckAndSetTypeFace(Control);
        }
    }

    public class AwesomeButtonRenderer : ButtonRenderer
    {  
        public AwesomeButtonRenderer(Context context) : base(context)
        {
        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            
            AwesomeUtil.CheckAndSetTypeFace(Control);
        }
    }

    internal static class AwesomeUtil
    {
        public static void CheckAndSetTypeFace(TextView view)
        {
            if (view.Text.Length == 0) return;

            var text = view.Text;
            if (text.Length > 1 || text[0] < 0xf000)
            {
                return;
            }

            var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, "fontawesome.ttf");
            view.Typeface = font;
        }
    }
}