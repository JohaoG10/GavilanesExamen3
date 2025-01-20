using System.Collections.ObjectModel;
using System.Threading.Tasks;

public class HistorialJGViewModel : BindableObject
{
    public ObservableCollection<PaisJG> Paises { get; set; }

    public HistorialJGViewModel()
    {
        LoadData();
    }

    private async Task LoadData()
    {
        Paises = new ObservableCollection<PaisJG>(await App.Database.GetItemsAsync());
    }
}