using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

public class BusquedaJGViewModel : BindableObject
{
    private string _nombrePais;
    public string NombrePais
    {
        get => _nombrePais;
        set { _nombrePais = value; OnPropertyChanged(); }
    }

    public ICommand BuscarCommand { get; }
    public ICommand LimpiarCommand { get; }

    public BusquedaJGViewModel()
    {
        BuscarCommand = new Command(async () => await BuscarPais());
        LimpiarCommand = new Command(() => NombrePais = string.Empty);
    }

    private async Task BuscarPais()
    {
        try
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<dynamic>(
                $"https://restcountries.com/v3.1/name/{NombrePais}?fields=name,region,maps");

            if (response != null)
            {
                var pais = new PaisJG
                {
                    NombreOficial = response[0].name["official"].ToString(),
                    Region = response[0].region.ToString(),
                    GoogleMapsLink = response[0].maps["googleMaps"].ToString()
                };

                await App.Database.SaveItemAsync(pais);
            }
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "País no encontrado", "OK");
        }
    }
}