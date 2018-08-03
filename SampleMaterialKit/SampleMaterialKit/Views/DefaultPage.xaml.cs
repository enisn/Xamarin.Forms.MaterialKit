using Plugin.MaterialKit.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMaterialKit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DefaultPage : MaterialContentPage
	{
		public DefaultPage ()
		{
			InitializeComponent();
            Banner.BannerPlacement = Plugin.MaterialKit.Shared.Common.BannerView.Placement.Top;
		}

        private void Display_Banner(object sender, EventArgs e)
        {
            DisplayBanner(new BannerContext("warning_icon.png", "Hi There, this is my Message!", "Close", "OK", new Command(() => DisplayAlert("", "Clicked from banner.\nClicked!", "OK")), null));
        }
    }
}