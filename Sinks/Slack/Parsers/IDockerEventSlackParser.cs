using DockerNotifier.Core.Models;
using DockerNotifier.Sinks.Slack.Models;

namespace DockerNotifier.Sinks.Slack.Parsers
{
    public interface IDockerEventSlackParser
    {
        SlackNotification Parse(DockerEvent dockerEvent);
    }
}
