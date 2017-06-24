using Newtonsoft.Json;

namespace DockerNotifier.Sinks.Slack.Models
{
    /// <summary>
    /// Model class for Slack attachment field
    /// </summary>
    public class SlackAttachmentField
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Short column
        /// </summary>
        [JsonProperty("short")]
        public bool Short { get; set; }
    }
}
