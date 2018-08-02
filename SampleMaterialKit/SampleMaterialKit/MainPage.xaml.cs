using SampleMaterialKit.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleMaterialKit
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Go_Controls(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ControlsPage());
        }

        private void Go_BackdropSample(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BackdropSamplePage());
        }
    }
}
