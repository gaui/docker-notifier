using System.Collections.Generic;
using DockerNotifier.Core.Models;
using DockerNotifier.Sinks.Slack.Models;

namespace DockerNotifier.Sinks.Slack.Parsers
{
    public sealed class DockerEventSlackDefaultParser : IDockerEventSlackParser
    {
        public SlackNotification Parse(DockerEvent dockerEvent)
        {
            string containerId = dockerEvent.Actor?.ID?.Substring(0, 8);
            string containerName = dockerEvent.Actor?.Attributes?.Name;

            string fallbackMsg = $"Container *{dockerEvent.Action}* : {containerId} ({containerName})";

            string color = dockerEvent.Action == "start" ? "good" : "danger";

            List<SlackAttachmentField> attachmentFields = new List<SlackAttachmentField>
            {
                new SlackAttachmentField
                {
                    Title = "Action",
                    Value = dockerEvent.Action,
                    Short = true
                },
                new SlackAttachmentField
                {
                    Title = "ID",
                    Value = containerId,
                    Short = true
                },
                new SlackAttachmentField
                {
                    Title = "Name",
                    Value = containerName,
                    Short = true
                },
                new SlackAttachmentField
                {
                    Title = "Image",
                    Value = dockerEvent.Actor?.Attributes?.Image,
                    Short = true
                }
            };

            List<SlackAttachment> attachments = new List<SlackAttachment>
            {
                new SlackAttachment
                {
                    Fallback = fallbackMsg,
                    Color = color,
                    Fields = attachmentFields,
                    MarkdownIn = new [] { "fallback", "text", "pretext", "fields" }
                }
            };

            SlackNotification notification = new SlackNotification
            {
                Text = fallbackMsg,
                Attachments = attachments
            };

            return notification;
        }
    }
}
