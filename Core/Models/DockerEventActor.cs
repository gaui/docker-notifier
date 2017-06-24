using Newtonsoft.Json;

namespace DockerNotifier.Core.Models
{
    public class DockerEventActor
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("Attributes")]
        public DockerEventActorAttribute Attributes { get; set; }
    }
}
