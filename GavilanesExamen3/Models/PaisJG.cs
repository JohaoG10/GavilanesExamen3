using SQLite;

public class PaisJG
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string NombreOficial { get; set; }
    public string Region { get; set; }
    public string GoogleMapsLink { get; set; }
    public string NombreUsuario { get; set; } 
}