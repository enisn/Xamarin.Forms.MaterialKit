using Plugin.MaterialKit.Shared.Abstraction;
using Plugin.MaterialKit.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialKit.Shared.Base
{
    public class MaterialContentPage : ContentPage
    {
        private bool _bannerPresented;

        public MaterialContentPage() : base()
        {
            base.Content = new Grid
            {
                Children =
                {
                    new ContentView(),
                    new BannerView(),
                }
            };
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Banner.Height > 0 && !IsBannerPresented)
                Banner.TranslateTo(0, -Banner.Height, 1);
        }
        public void DisplayBanner(IBannerContent content)
        {
            Banner.BindingContext = content;
            IsBannerPresented = true;
        }
        public void DisplayBanner(BannerContext context)
        {
            Banner.BindingContext = context;
            IsBannerPresented = true;
        }
        void UpdateBanner()
        {
            if (IsBannerPresented)
            {
                Banner.TranslateTo(0, 0, 250, Easing.SpringIn);
                this.Content.LayoutTo(new Rectangle(0, Banner.Height, this.Width, this.Height - Banner.Height));
                //this.Animate("BannerOpennig", (d) => new Rectangle(0, Banner.Height * d, this.Width, (this.Height - Banner.Height) * d));
                Banner.InputTransparent = false;

                //this.Padding = new Thickness(this.Padding.Left, this.Padding.Top + Banner.Height + 10, this.Padding.Right, this.Padding.Bottom);
            }
            else
            {
                Banner.TranslateTo(0, -Banner.Height, 250, Easing.SpringOut);
                this.Content.LayoutTo(new Rectangle(0, 0, this.Width, this.Height));
                //this.Animate("BannerHiding", (d) => new Rectangle(0, Banner.Height * (1 - d), this.Width, (this.Height + Banner.Height) * d));
                //this.Padding = new Thickness(this.Padding.Left, this.Padding.Top - Banner.Height - 10, this.Padding.Right, this.Padding.Bottom);
                Banner.InputTransparent = true;
            }
        }
        internal bool IsBannerPresented { get => _bannerPresented; set { _bannerPresented = value; UpdateBanner(); } }
        public virtual View Banner { get => (base.Content as Grid).Children[1]; set => (base.Content as Grid).Children[1] = value; }
        public new View Content { get => ((base.Content as Grid).Children[0] as ContentView).Content; set => ((base.Content as Grid).Children[0] as ContentView).Content = value; }

        public class BannerContext : IBannerContent
        {
            public BannerContext(string icon, string text, string cancel, string oK, ICommand command, object commandParameter)
            {
                Icon = icon;
                Text = text;
                Cancel = cancel;
                OK = oK;
                Command = command;
                CommandParameter = commandParameter;
            }

            public string Icon { get; set; }
            public string Text { get; set; }
            public string Cancel { get; set; }
            public string OK { get; set; }
            public ICommand Command { get; set; }
            public object CommandParameter { get; set; }
        }
    }
}
