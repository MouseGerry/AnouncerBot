using System.Collections.Generic;
using System.Text.Json;

class TwitchAPI
{
    private string clientId;
    private string token;
    private HttpClient httpClient;

    public TwitchAPI(string clientId,string token)
    {
        this.clientId = clientId;
        this.token = token;
        this.httpClient = new HttpClient();
    }

    public async Task<List<string>> StreamsJustStarted(List<string> logins) {
        
        string url = "https://api.twitch.tv/helix/streams?";

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("Client-Id", $"{this.clientId}");
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.token}");


        var user_logins = logins.Select(x => $"user_login={x}");
        string logins_url = String.Join('&', user_logins);


        Console.WriteLine(logins_url);

        var body = await httpClient.GetStreamAsync($"{url}{logins_url}");
        var streams = await JsonSerializer.DeserializeAsync<DataResponse>(body);

        var just_started = new List<string>();

        if (streams is null)
            return just_started;

        streams.Data.ForEach(stream =>
        {
            var startedAt = DateTime.Parse(stream.StartedAt);
            var now = DateTime.Now;

            var seconds = (now - startedAt).TotalSeconds;
            if (seconds <= 90)
                just_started.Add(stream.UserLogin);
        });

        return just_started;
    }
}
