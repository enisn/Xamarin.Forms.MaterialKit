

<table>
<tr>
	<td> <img src="http://enisnecipoglu.com/Plugins/materialkit_backdrop.png" width="120" /></td>
	<td> 
		<h1> MaterialKit.Backdrop </h1>
		<p> This is base componenets for all MaterialKit.* plugins. </p>
        <p> 
            <a href="https://www.nuget.org/packages/MaterialKit.Backdrop/" rel="nofollow">
                <img src="https://img.shields.io/badge/Nuget-1.0.0-blue.svg" style="max-width:100%;">
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
  <img src="https://media.giphy.com/media/1xlo1b4afWmTOBIFG3/giphy.gif" height="480"/>
    <hr/>
 From material.io:
 <a href="https://material.io/design/components/backdrop.html">Backdrop</a>
</center>