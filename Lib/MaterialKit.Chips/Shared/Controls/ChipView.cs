using Plugin.MaterialKit.Chips.Shared.Configuration;
using Plugin.MaterialKit.Core.Shared.Rendered;
using Plugin.MaterialKit.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Plugin.MaterialKit.Chips.Shared.Controls
{
    public class ChipView : Frame
    {
        public static GlobalSetting GlobalSetting { get; private set; } = new GlobalSetting
        {
            ImageSource = "cancel_icon.png"
        };
        IconView imgCancel = new IconView { Source = GlobalSetting.ImageSource, FillColor = GlobalSetting.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65) };
        IconView imgIcon = new IconView { FillColor = GlobalSetting.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65) };
        Label lblContent = new Label { TextColor = GlobalSetting.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65), HorizontalOptions = LayoutOptions.FillAndExpand };
        public ChipView()
        {
            base.HasShadow = false;
            this.Padding = new Thickness(5, 0);
            UpdateIsDeletable();
            this.Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    imgIcon,
                    lblContent,
                    imgCancel
                }
            };
        }
        public bool IsDeletable { get => (bool)GetValue(IsDeletableProperty); set => SetValue(IsDeletableProperty, value); }
        public Command Command { get; set; }
        public Command DeleteCommand { get; set; }
        public object CommandParameter { get; set; }

        private void UpdateIsDeletable()
        {
            imgCancel.IsVisible = IsDeletable;
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(Command), typeof(ChipView), null, propertyChanged: (bo, ov, nv) => (bo as ChipView).Command = (Command)nv);
        public static readonly BindableProperty IsDeletableProperty =
            BindableProperty.Create(nameof(IsDeletable), typeof(bool), typeof(ChipView), true, propertyChanged: (bo, ov, nv) => (bo as ChipView).UpdateIsDeletable());
    }
}
