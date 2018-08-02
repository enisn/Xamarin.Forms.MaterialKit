using Plugin.MaterialKit.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialKit.Shared.Common
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BannerView : Frame
	{
		public BannerView ()
		{
			InitializeComponent ();
		}

        private void Close(object sender, EventArgs e)
        {
            if (this.Parent?.Parent is MaterialContentPage)
                (this.Parent.Parent as MaterialContentPage).IsBannerPresented = false;
            
        }
    }
}