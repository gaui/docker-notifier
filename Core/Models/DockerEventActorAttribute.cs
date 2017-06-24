using Newtonsoft.Json;

namespace DockerNotifier.Core.Models
{
    public class DockerEventActorAttribute
    {
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
