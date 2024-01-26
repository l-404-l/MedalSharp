using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedalSharp.Endpoints
{
    public class ContextSubmitPost : MedalRequest
    {
        [JsonProperty("serverId")]
        public string ServerID { get; set; }

        [JsonProperty("serverName")]
        public string ServerName { get; set; }

        [JsonProperty("localPlayer")]
        public ContextPlayer LocalPlayer { get; set; }

        [JsonProperty("globalContextTags")]
        public Dictionary<string,string> GlobalContextTags { get; set; }

        [JsonProperty("globalContextData")]
        public Dictionary<string,string> GlobalContextData { get; set; }
    }

    public class ContextPlayer
    {
        [JsonProperty("playerName")]
        public string Name { get; set; }

        [JsonProperty("playerId")]
        public string ID { get; set; }
    }
}
