using System;
using Newtonsoft.Json;

namespace Infrastructure.Models
{
    public class GuestbookEntry
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
