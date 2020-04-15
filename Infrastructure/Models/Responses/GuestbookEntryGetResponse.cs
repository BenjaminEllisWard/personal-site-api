using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.Models.Responses
{
    public class GuestbookEntryGetResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("entries")]
        public IEnumerable<GuestbookEntry> Entries { get; set; }
    }
}
