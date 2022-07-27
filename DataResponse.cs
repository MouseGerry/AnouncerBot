using System.Text.Json.Serialization;


class DataResponse
{
    [JsonPropertyName("data")]
    #pragma warning disable
    public List<StreamResponse> Data { get; set; }
    #pragma warning restore

}
