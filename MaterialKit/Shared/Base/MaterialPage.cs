using Plugin.MaterialKit.Shared.Abstraction;
using Plugin.MaterialKit.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialKit.Shared.Base
{
    public class MaterialContentPage : ContentPage
    {
        private bool _bannerPresented;
        public new static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content),typeof(View),typeof(MaterialContentPage),propertyChanged:(bo,ov,nv)=>(bo as MaterialContentPage).SetContent((View)nv));
        async void SetContent(View view)
        {
            this.Content = view;
            this.UpdateChildrenLayout();
        }
        public MaterialContentPage()
        {
            base.Content = new Grid
            {
                Children =
                {
                    new ContentView(),
                    new BannerView()
                }
            };
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Banner.Height > 0 && !IsBannerPresented)
                Banner.TranslateTo(0, Banner.BannerPlacement == BannerView.Placement.Top ? -Banner.Height : Banner.Height, 1);
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
        internal void UpdateBanner()
        {
            if (IsBannerPresented)
            {
                Banner.TranslateTo(0, 0, 250, Easing.SpringIn);

                this.Content.LayoutTo(new Rectangle(
                    0, Banner.BannerPlacement == BannerView.Placement.Top ? Banner.Height : 0,
                    this.Width, this.Height - Banner.Height)
                    );

                Banner.InputTransparent = false;
            }
            else
            {
                Banner.TranslateTo(0, Banner.Height * (int)Banner.BannerPlacement, 250, Easing.SpringOut);

                this.Content.LayoutTo(new Rectangle(0, 0, this.Width, this.Height));
                Banner.InputTransparent = true;
            }
        }
        internal bool IsBannerPresented { get => _bannerPresented; set { _bannerPresented = value; UpdateBanner(); } }
        public virtual BannerView Banner { get => (base.Content as Grid)?.Children[1] as BannerView; set => (base.Content as Grid).Children[1] = value; }
        public new View Content
        {
            get => ((base.Content as Grid)?.Children.FirstOrDefault() as ContentView ).Content;
            set => ((base.Content as Grid)?.Children.FirstOrDefault() as ContentView).Content = value;
        }

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
