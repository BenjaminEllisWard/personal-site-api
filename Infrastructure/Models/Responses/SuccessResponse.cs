using Newtonsoft.Json;

namespace Infrastructure.Models.Responses
{
    public class SuccessResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
