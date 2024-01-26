using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedalSharp.Endpoints
{
    public class GameEventResponse : MedalResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("actionsCompleted")]
        [JsonConverter(typeof(GameEventTriggersConverter))]
        public List<GameEventTriggers> ActionsCompleted { get; set; }
    }

    public class GameEventPost : MedalRequest
    {
        [JsonProperty("eventId")]
        public string EventID { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("otherPlayers", NullValueHandling = NullValueHandling.Ignore)]
        public List<GameEventPlayer> OtherPlayers { get; set; }

        [JsonProperty("contextTags", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> ContextTags { get; set; }

        [JsonProperty("triggerActions", Required = Required.DisallowNull)]
        [JsonConverter(typeof(GameEventTriggersConverter))]
        public List<GameEventTriggers> Actions { get; set; }

        [JsonProperty("clipOptions")]
        public Dictionary<string, int> ClipOptions { get; set; }
    }

    public class GameEventPlayer
    {
        [JsonProperty("playerName")]
        public string PlayerName { get; set; }

        [JsonProperty("playerId")]
        public string PlayerID { get; set; }
    }

    public class ClipOption
    {
        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
    
    public enum GameEventTriggers : int
    {
        SaveClip = 0,
        Screenshot = 1,
    }

    public class GameEventTriggersConverter : JsonConverter<List<GameEventTriggers>>
    {
        public override List<GameEventTriggers> ReadJson(JsonReader reader, Type objectType, List<GameEventTriggers> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                JArray array = JArray.Load(reader);

                // Convert the array of strings to a List<GameEventTriggers>
                List<GameEventTriggers> triggerList = array.ToObject<List<string>>()
                    .ConvertAll(triggerString => Enum.Parse<GameEventTriggers>(triggerString, true));
                return triggerList;
            }
            return new List<GameEventTriggers> { };
        }

        public override void WriteJson(JsonWriter writer, List<GameEventTriggers> value, JsonSerializer serializer)
        {
            var stringList = value.ConvertAll(trigger => trigger.ToString());
            serializer.Serialize(writer, stringList);
        }
    }
}
