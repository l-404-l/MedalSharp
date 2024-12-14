# MedalSharp
 Makes it easy to access the Medal Games & Servers API. Made for a StreamDeck Plugin that will release soon.
 
# Support me!
Use code 404 when signing up for medal! https://medal.tv/code/404

```C#

namespace Example
{
    class MedalExample
    {
        public async Task RunTest()
        {
            MedalClient client = new MedalClient();
            client.SetPublicKey("pub_yourkey"); // Required Todo anything (https://thirdpartyregister.pages.dev/)

            GameEventPost evnt = new GameEventPost()
            {
                EventID = "evt_dragon_defeat01", // Unique ID of the game event (Required)
                EventName = "Ender Dragon Defeated", // Name of the game event (Required)
                Actions = new List<GameEventTriggers>() { GameEventTriggers.SaveClip }, // Save a Clip (Screenshot WIP) (Not Required)
                ClipOptions = new Dictionary<string, int> { ["duration"] = 30 }, // 30 seconds (Not Required)
                ContextTags = new Dictionary<string, string>() { ["location"] = "finalboss", ["boss"] = "enderdragon" }, // (Not Required)
                OtherPlayers = new List<GameEventPlayer>() { new GameEventPlayer() { PlayerName = "Bob", PlayerID = "uuid_123456" } } // (Not Required)
            };
            await client.GameEvent(evnt);
        }
    }
}
```
