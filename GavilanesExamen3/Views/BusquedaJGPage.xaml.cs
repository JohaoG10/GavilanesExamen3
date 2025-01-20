using Microsoft.Maui.Controls;

public partial class BusquedaJGPage : ContentPage
{
    public BusquedaJGPage()
    {
        InitializeComponent();
        BindingContext = new BusquedaJGViewModel();
    }
}