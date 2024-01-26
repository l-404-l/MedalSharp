using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedalSharp.Endpoints
{
    public class MedalRequest
    {
        public StringContent ToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }
    }

    public class MedalResponse
    {
        public bool IsSuccessStatusCode { get; set; } = false;
        public int StatusCode { get; set; }
    }
}
