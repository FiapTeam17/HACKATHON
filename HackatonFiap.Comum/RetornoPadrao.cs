using System.Text.Json.Serialization;

namespace HackatonFiap.Comum;

public class RetornoPadrao<T>
{
    public bool Success { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T Data { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> Errors { get; set; }

}