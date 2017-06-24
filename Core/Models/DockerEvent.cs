using System;
using Newtonsoft.Json;

namespace DockerNotifier.Core.Models
{
    public class DockerEvent
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Action")]
        public string Action { get; set; }
        [JsonProperty("Actor")]
        public DockerEventActor Actor { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("time")]
        public Int64 Time { get; set; }
        [JsonProperty("timeNano")]
        public Int64 TimeNano { get; set; }
    }
}
