using Newtonsoft.Json;

namespace StackExchange.Api
{
    [WrapperObject("users")]
    [JsonObject(MemberSerialization.OptIn)]
    public class User
    {
        [JsonProperty(PropertyName = "user_id")]
        public int Id { get; internal set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; internal set; }

        [JsonProperty(PropertyName = "reputation")]
        public int Reputation { get; internal set; }

        [JsonProperty(PropertyName = "badge_counts")]
        public BadgeCounts BadgeCounts { get; set; }
    }
}
