using System.Text.Json.Serialization;

namespace HackatonFiap.Comum;

public class ListaPaginada<T>
{
    public int Total { get; set; }
    public int Pagina { get; set; }
    public List<T> Itens { get; set; } = new ();
        
    [JsonIgnore]
    public T First => Itens.FirstOrDefault();
}