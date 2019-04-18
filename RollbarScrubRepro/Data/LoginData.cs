using System;
using Newtonsoft.Json;

namespace RollbarScrubRepro.Data
{
    public class LoginData
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
