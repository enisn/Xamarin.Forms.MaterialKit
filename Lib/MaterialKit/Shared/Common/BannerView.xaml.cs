using Plugin.MaterialKit.Core.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialKit.Core.Shared.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BannerView : Frame
    {
        public BannerView()
        {
            InitializeComponent();
        }

        private void Close(object sender, EventArgs e)
        {
            if (this.Parent?.Parent is MaterialContentPage)
                (this.Parent.Parent as MaterialContentPage).IsBannerPresented = false;
        }
        public Placement BannerPlacement { get => (Placement)GetValue(BannerPlacementProperty); set => SetValue(BannerPlacementProperty, value); }
        void UpdatePlacement()
        {
            switch (BannerPlacement)
            {
                case Placement.Top:
                    this.VerticalOptions = LayoutOptions.Start;
                    break;
                case Placement.Bottom:
                    this.VerticalOptions = LayoutOptions.End;
                    break;
            }
            (this.Parent?.Parent as MaterialContentPage)?.UpdateBanner();
        }
        public static readonly BindableProperty BannerPlacementProperty = BindableProperty.Create(nameof(BannerPlacement), typeof(Placement), typeof(BannerView), Placement.Bottom, propertyChanged: (bo, ov, nv) => (bo as BannerView).UpdatePlacement());
        public enum Placement
        {
            Top = -1,
            Bottom = 1
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    DisplayBanner(new BannerContext(null, "Hi There, this is my Message!", "Close", "OK", new Command(() => DisplayAlert("", "Clicked from banner.\nClicked!", "OK")), null));
        //}
    }
}