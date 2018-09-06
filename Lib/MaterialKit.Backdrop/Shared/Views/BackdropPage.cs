using Plugin.MaterialKit.Backdrop.Abstraction;
using Plugin.MaterialKit.Core.Shared.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Plugin.MaterialKit.Backdrop.Views
{
    public class BackdropPage : MaterialContentPage
    {
        Grid grdBackDrops = new Grid();
        Frame frmContent = new Frame { Padding = 0, BackgroundColor = Color.White, CornerRadius = 6, VerticalOptions = LayoutOptions.FillAndExpand };
        public BackdropPage()
        {
            grdBackDrops.ChildAdded += GrdBackDrops_ChildAdded;
            base.Content = new Grid
            {
                Children =
                {
                    grdBackDrops,
                    frmContent,
                }
            };
            InitColor();
        }
        async void InitColor()
        {
            await Task.Delay(100);
            if (this.Parent is NavigationPage)
                this.BackgroundColor = (this.Parent as NavigationPage).BarBackgroundColor;
            else
                this.BackgroundColor = (Color)NavigationPage.BarBackgroundColorProperty.DefaultValue;
        }
        private void GrdBackDrops_ChildAdded(object sender, ElementEventArgs e)
        {
            if (e.Element is IBackdropView)
            {
                var _toolbarItem = new ToolbarItem
                {
                    CommandParameter = this.BackdropChildren.Count - 1,
                    Command = new Command((p) => PresentedIndex = (int)p),
                };
                _toolbarItem.SetBinding(ToolbarItem.IconProperty, new Binding("Icon",source:e.Element));
                _toolbarItem.SetBinding(ToolbarItem.TextProperty, new Binding("Text",source:e.Element));
                ToolbarItems.Add(_toolbarItem);
            }
        }

        public int PresentedIndex
        {
            get => (int)GetValue(PresentedIndexProperty);
            set => SetValue(PresentedIndexProperty, PresentedIndex == value ? -1 : value);

        }
        void SetPresented(int index)
        {
            frmContent.TranslateTo(0, index == -1 ? 0 : BackdropChildren[index].Height, 250, Easing.SinIn);

            if (frmContent.Content != null)
            {
                frmContent.Content.IsEnabled = index == -1;
                //frmContent.Content.InputTransparent = index != -1;
                frmContent.Content.Opacity = index != -1 ? 0.6 : 1;
            }

            if (index != -1)
                for (int i = 0; i < this.BackdropChildren.Count; i++)
                {
                    (this.BackdropChildren[i]).IsVisible = i == index;
                }
        }
        /// <summary>
        /// Blocks to set content directly
        /// </summary>
        public new View Content { get; }

        public IList<View> BackdropChildren { get => grdBackDrops.Children; }
        public View FrontContent { get => frmContent.Content; set => frmContent.Content = value; }

        public static readonly BindableProperty PresentedIndexProperty = BindableProperty.Create(nameof(PresentedIndex), typeof(int), typeof(BackdropPage), -1, BindingMode.TwoWay, propertyChanged: (bo, ov, nv) => (bo as BackdropPage).SetPresented((int)nv));


        protected override bool OnBackButtonPressed()
        {
            if (PresentedIndex == -1)
            {
                return base.OnBackButtonPressed();
            }

            PresentedIndex = -1;
            return true;
        }


    }
}
