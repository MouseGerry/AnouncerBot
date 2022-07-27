var bot = new TelegramBot("");
var twitchAPI = new TwitchAPI("", "");

List<string> streams = new List<string>();
streams.Add("safrit22");
streams.Add("katevolved");
streams.Add("x3_xto");
streams.Add("x2_xto");
streams.Add("mousegerry_");
streams.Add("emperrorlp_");

var timer = new Timer(async (bruh) =>
{
    var jss = await twitchAPI.StreamsJustStarted(streams);
    jss.ForEach((username) => {
        var _ = bot.SendMessage(820904181, $"{username} just started their stream PogT\ntwitch.tv/{username}");
    });
}, null, 0, 1000*60);

Console.ReadLine();
