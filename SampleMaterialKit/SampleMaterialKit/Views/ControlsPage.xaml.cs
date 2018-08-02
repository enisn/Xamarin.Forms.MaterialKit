using Plugin.MaterialKit.Shared.Controls;
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
	public partial class ControlsPage : ContentPage
	{
		public ControlsPage ()
		{
			InitializeComponent ();
            sl.Children.Add(new Checkbox());
		}
	}
}