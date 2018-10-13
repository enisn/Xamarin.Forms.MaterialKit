using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Plugin.MaterialKit.Core.Shared.Controls
{
    public class Checkbox : StackLayout
    {
        Frame frmBackground = new Frame { Padding = 0, HeightRequest = 25, WidthRequest = 25, MinimumHeightRequest = 25, MinimumWidthRequest = 25, BackgroundColor = Color.Transparent, BorderColor = Color.Accent, };
        //Label lblSelected = new Label { Text= "✓", IsVisible = false ,TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
        Image lblSelected = new Image { Source = "ic_check_white_24pt.png", IsVisible = false, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
        public Checkbox()
        {
            this.Orientation = StackOrientation.Horizontal;
            frmBackground.Content = lblSelected;
            this.Children.Add(frmBackground);
            this.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => IsChecked = !IsChecked) });
        }

        public bool IsChecked { get => lblSelected.IsVisible; set { lblSelected.IsVisible = value; Animate(); } }
        async void Animate()
        {
            try
            {
                await frmBackground.ScaleTo(0.9, 100, Easing.BounceIn);
                frmBackground.BackgroundColor = IsChecked ? Color.Accent : Color.Transparent;
                await frmBackground.ScaleTo(1, 100, Easing.BounceIn);
            }
            catch (Exception)
            {
            }
        }
    }
}
