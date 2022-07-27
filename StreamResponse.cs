using System.Text.Json.Serialization;

class StreamResponse 
{
    #pragma warning disable
    [JsonPropertyName("started_at")]
    public string StartedAt { get; set; }
    [JsonPropertyName("user_login")]
    public string UserLogin { get; set; }
    #pragma warning restore

    
}
