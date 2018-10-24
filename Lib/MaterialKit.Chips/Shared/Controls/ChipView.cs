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
            ImageSource = "cancel_icon.png",
            BackgroundColor = Color.WhiteSmoke,
        };
        IconView imgCancel = new IconView { Source = GlobalSetting.ImageSource, FillColor = GlobalSetting.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65), IsVisible = false };
        IconView imgIcon = new IconView { FillColor = GlobalSetting.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65) };
        Label lblContent = new Label { TextColor = GlobalSetting.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65), HorizontalOptions = LayoutOptions.FillAndExpand };
        public ChipView()
        {
            base.HasShadow = false;
            this.Padding = new Thickness(5);
            this.HorizontalOptions = LayoutOptions.Start;
            this.CornerRadius = 20;
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
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(Tapped)
            });
            imgCancel.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(CalcelTapped) });
        }

        private void CalcelTapped(object obj)
        {
            if (this.IsDeletable)
                (this.Parent as Layout<View>)?.Children.Remove(this);
        }
        private void Tapped(object obj)
        {
            if (this.Command?.CanExecute(CommandParameter) ?? false)
                this.Command?.Execute(CommandParameter);
        }

        public bool IsDeletable { get => (bool)GetValue(IsDeletableProperty); set => SetValue(IsDeletableProperty, value); }
        public string Text { get => lblContent.Text; set => lblContent.Text = value; }
        public Command Command { get; set; }
        public Command DeleteCommand { get; set; }
        public object CommandParameter { get; set; }
        public string Icon { get => (string)GetValue(IconProperty); set => SetValue(IconProperty, value); }
        private void UpdateIsDeletable()
        {
            imgCancel.IsVisible = IsDeletable;
        }
        private void UpdateColors()
        {
            imgCancel.FillColor = this.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65);
            imgIcon.FillColor = this.BackgroundColor.ToSurfaceColor().MultiplyAlpha(0.65);
            lblContent.TextColor = this.BackgroundColor.ToSurfaceColor();
        }

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(nameof(Text), typeof(String), typeof(ChipView), null, propertyChanged: (bo, ov, nv) => (bo as ChipView).Text = (string)nv);
        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(ChipView), GlobalSetting.BackgroundColor, propertyChanged: (bo, ov, nv) => { (bo as ChipView).BackgroundColor = (Color)nv; (bo as ChipView).UpdateColors(); });
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(String), typeof(ChipView), null, propertyChanged: (bo, ov, nv) => (bo as ChipView).imgIcon.Source = (string)nv);
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(Command), typeof(ChipView), null, propertyChanged: (bo, ov, nv) => (bo as ChipView).Command = (Command)nv);
        public static readonly BindableProperty IsDeletableProperty =
            BindableProperty.Create(nameof(IsDeletable), typeof(bool), typeof(ChipView), false, propertyChanged: (bo, ov, nv) => (bo as ChipView).UpdateIsDeletable());
    }
}
