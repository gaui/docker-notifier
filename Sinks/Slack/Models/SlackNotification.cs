using System.Collections.Generic;
using Newtonsoft.Json;

namespace DockerNotifier.Sinks.Slack.Models
{
    /// <summary>
    /// Model class for a Slack notification
    /// Which is sent to the Slack webhook API
    /// </summary>
    public class SlackNotification
    {
        /// <summary>
        /// Text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Attachments
        /// </summary>
        [JsonProperty("attachments")]
        public List<SlackAttachment> Attachments { get; set; }
    }
}
