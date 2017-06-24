using System.Collections.Generic;
using Newtonsoft.Json;

namespace DockerNotifier.Sinks.Slack.Models
{
    /// <summary>
    /// Model class for Slack attachment
    /// </summary>
    public class SlackAttachment
    {
        /// <summary>
        /// Fallback text
        /// </summary>
        [JsonProperty("fallback")]
        public string Fallback { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Pretext
        /// </summary>
        [JsonProperty("pretext")]
        public string Pretext { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Fields
        /// </summary>
        [JsonProperty("fields")]
        public List<SlackAttachmentField> Fields { get; set; }

        /// <summary>
        /// Markdown
        /// </summary>
        [JsonProperty("mrkdwn_in")]
        public string[] MarkdownIn { get; set; }
    }
}
