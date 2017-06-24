using System;
using DockerNotifier.Sinks.Slack.Parsers;

namespace DockerNotifier.Sinks.Slack
{
    public sealed class SlackSinkOptions
    {
        public string WebhookUri { get; set; } = Environment.GetEnvironmentVariable("SLACK.WEBHOOK_URL");
        public IDockerEventSlackParser DockerEventParser { get; set; } = new DockerEventSlackDefaultParser();
    }
}
