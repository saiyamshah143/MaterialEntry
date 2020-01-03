using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MaterialEntry
{
    public class EntryView : ContentView
    {
        public static readonly BindableProperty TextProperty =
          BindableProperty.Create("Text", typeof(string), typeof(EntryView), null);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
