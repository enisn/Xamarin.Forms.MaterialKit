using Plugin.MaterialKit.Backdrop.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Plugin.MaterialKit.Backdrop.Views
{
    public class BackdropView : ContentView, IBackdropView
    {
        public BackdropView()
        {
            this.VerticalOptions = LayoutOptions.StartAndExpand;
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(BackdropView), propertyChanged: (bo, ov, nv) => (bo as BackdropView).OnPropertyChanged(nameof(Title)));
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(BackdropPage), propertyChanged: (bo, ov, nv) => (bo as BackdropView).OnPropertyChanged(nameof(Icon)));


    }
}
