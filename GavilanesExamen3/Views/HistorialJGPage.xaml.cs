using Microsoft.Maui.Controls;

public partial class HistorialJGPage : ContentPage
{
    public HistorialJGPage()
    {
        InitializeComponent();
        BindingContext = new HistorialJGViewModel();
    }
}