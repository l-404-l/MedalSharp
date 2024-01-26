using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedalSharp.Endpoints
{
    public class CreatorCodeResponse : MedalResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("medalUserId")]
        public string UserID { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }

    public class CreateCodePost : MedalRequest
    {

        [JsonProperty("gameOrServerId")]
        public string GameOrServerID { get; set; }

        [JsonProperty("creatorCode")]
        public string CreatorCode { get; set; }
    }
}
