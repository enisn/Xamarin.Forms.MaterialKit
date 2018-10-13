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

        private void Backdrop_Tapped(object sender, EventArgs e) => Navigation.PushAsync(new Views.BackdropSample());
    }
}
