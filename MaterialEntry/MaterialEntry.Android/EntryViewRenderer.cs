using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaterialEntry;
using MaterialEntry.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryView), typeof(EntryViewRenderer))]
namespace MaterialEntry.Droid
{
    [Obsolete]
    public class EntryViewRenderer : ViewRenderer
    {
        global::Android.Views.View view;
        global::Android.Widget.EditText editText;
        EntryView entryView;
        Activity activity;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                entryView = e.NewElement as EntryView;
            }
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                SetupUserInterface();
                SetupEventHandlers();
                AddView(view);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
            }
        }

        private void SetupEventHandlers()
        {
            editText.TextChanged += EditText_TextChanged;
        }

        private void EditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            entryView.Text = editText.Text;
            Console.WriteLine("chanegd +" + entryView.Text);
        }

        void SetupUserInterface()
        {
            activity = this.Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.EntryLayout, this, false);
            editText = view.FindViewById<EditText>(Resource.Id.editText1);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }
    }
}