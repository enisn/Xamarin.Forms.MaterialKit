using Plugin.MaterialKit.Shared.Backdrop;
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
	public partial class BackdropSamplePage : BackdropPage
	{
		public BackdropSamplePage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayBanner(new BannerContext(null,"Hi There, this is my Message!","Close","OK",new Command(()=>DisplayAlert("","Clicked from banner.\nClicked!","OK")),null));
        }
    }
}