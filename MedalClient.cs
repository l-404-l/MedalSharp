using MedalSharp.Endpoints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MedalSharp
{
    public static class MedalClientManager
    {
        private static MedalClient _globalmedalclient;
        public static MedalClient Instance { get {
                if (_globalmedalclient == null)
                {
                    _globalmedalclient = new MedalClient();
                    return _globalmedalclient;
                }
                return _globalmedalclient;
            } set { _globalmedalclient = value; } }
    }
    public class MedalClient
    {
        private HttpClient _httpClient;
        public MedalClient(string key = "")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12665/api/v1/"),
            };
            if (!string.IsNullOrEmpty(key))
                _httpClient.DefaultRequestHeaders.Add("publicKey", key);
        }

        public bool SetPublicKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return false;

            if (_httpClient.DefaultRequestHeaders.Contains("publicKey"))
                _httpClient.DefaultRequestHeaders.Remove("publicKey");

            _httpClient.DefaultRequestHeaders.Add("publicKey", key);

            return true;
        }

        public async Task<CreatorCodeResponse> SetCreatorCode(string gameOrServerId, string creatorCode)
        {
            var jObject = new CreateCodePost() { GameOrServerID = gameOrServerId, CreatorCode = creatorCode };

            HttpResponseMessage resp = await _httpClient.PostAsync("creatorcode/set", jObject.ToJson());

            string respcontent = await resp.Content.ReadAsStringAsync();
            CreatorCodeResponse value = JsonConvert.DeserializeObject<CreatorCodeResponse>(respcontent);
            value.StatusCode = (int)resp.StatusCode;
            value.IsSuccessStatusCode = resp.IsSuccessStatusCode;
            return value;
        }

        public async Task<GameEventResponse> GameEvent(GameEventPost gameEvent)
        {
            HttpResponseMessage resp = await _httpClient.PostAsync("event/invoke", gameEvent.ToJson());

            string respcontent = await resp.Content.ReadAsStringAsync();
            GameEventResponse value = JsonConvert.DeserializeObject<GameEventResponse>(respcontent);
            value.StatusCode = (int)resp.StatusCode;
            value.IsSuccessStatusCode = resp.IsSuccessStatusCode;
            return value;
        }

        public async Task<bool> ContextSubmit(ContextSubmitPost contextSubmit)
        {
            HttpResponseMessage resp = await _httpClient.PostAsync("context/submit", contextSubmit.ToJson());

            string respcontent = await resp.Content.ReadAsStringAsync();
            return resp.IsSuccessStatusCode;
        }

    }
}