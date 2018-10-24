

<table>
<tr>
	<td> <img src="http://enisnecipoglu.com/Plugins/materialkit_backdrop.png" width="120" /></td>
	<td> 
		<h1> MaterialKit.Backdrop </h1>
		<p> This is base componenets for all MaterialKit.* plugins. </p>
        <p> 
            <a href="https://www.nuget.org/packages/MaterialKit.Backdrop/" rel="nofollow">
                <img src="https://img.shields.io/badge/Nuget-1.0.0.1-blue.svg" style="max-width:100%;">
            </a>  
             <a href="#" rel="nofollow">
                <img src="https://img.shields.io/badge/Visit-WiKi-orange.svg" style="max-width:100%;">
            </a>  
        </p> 
	</td>
</tr>
</table>

<hr />


# SET-UP

 *  Install NuGet from [here](https://www.nuget.org/packages/MaterialKit.Backdrop/)
 *  Create a  **ContentPage**   into your project
 *  Inherit from **BackdropPage** instead of ContentPage
    *  Add this line into XAML: `xmlns:backdrop="clr-namespace:Plugin.MaterialKit.Backdrop.Views;assembly=Plugin.MaterialKit.Backdrop"`
    *  Replace `ContentPage` tag to `backdrop:BackdropPage`
    *  In the **.cs** file Replace `ContentPage` inheritance to `BackdropPage`


### Finally XAML should be like this:

```xml

<?xml version="1.0" encoding="utf-8" ?>
<backdrop:BackdropPage
    xmlns:backdrop="clr-namespace:Plugin.MaterialKit.Backdrop.Views;assembly=Plugin.MaterialKit.Backdrop"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="SampleMaterialKit.Views.BackdropSamplePage"
    Title="Backdrop">

    
    <backdrop:BackdropPage.BackdropChildren>
        
            <!--PLACE YOUR BACK PAGES HERE-->

        <!--<backdrop:BackdropView Title="First Backdrop" Icon="aler.png">
            <StackLayout>
                <Label Text="Hello Xamarin Forms!" HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand" />
            </StackLayout>
        </backdrop:BackdropView>-->        
        
    </backdrop:BackdropPage.BackdropChildren>


    <backdrop:BackdropPage.FrontContent>
        <StackLayout>
            <!--PLACE YOUR REAL FRONT CONTENT HERE-->
        </StackLayout>
    </backdrop:BackdropPage.FrontContent>
</backdrop:BackdropPage>
```

### Finally XAML should be like this:

```csharp
using Plugin.MaterialKit.Backdrop.Views;
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
    }
}
```


<hr />
Will be added...
<hr />

<center> 

<table>
<tr>
<td><img src="https://media.giphy.com/media/1xlo1b4afWmTOBIFG3/giphy.gif" /></td>
<td><img src="https://scontent.xx.fbcdn.net/v/t1.15752-0/p280x280/41193932_303776750401814_4151777789340549120_n.png?_nc_cat=0&_nc_ad=z-m&_nc_cid=0&oh=69a7c635222f2cfa37f91677edae0a86&oe=5C251E07" /></td>
<td><img src="https://scontent.xx.fbcdn.net/v/t1.15752-0/p280x280/41062806_245109362843998_4556611923373719552_n.png?_nc_cat=0&_nc_ad=z-m&_nc_cid=0&oh=ffd37b55776b7febf0a079fb1b61d69b&oe=5C2A1138" /></td>
<td><img src="https://scontent.xx.fbcdn.net/v/t1.15752-0/p280x280/41078152_233577757334843_3495207040744161280_n.png?_nc_cat=0&_nc_ad=z-m&_nc_cid=0&oh=43ca7b3e40c6fb849b623fba4259d094&oe=5BF60461" /></td>
</tr>
</table>
 From material.io:
 <a href="https://material.io/design/components/backdrop.html">Backdrop</a>
</center>
    <hr/>