using System.Collections.Generic;
using System.Threading.Tasks;
using DockerNotifier.Core.Models;
using DockerNotifier.Core.Sinks;
using DockerNotifier.Sinks.Slack.Models;
using DockerNotifier.Sinks.Slack.Proxies;
using Refit;

namespace DockerNotifier.Sinks.Slack
{
    public class SlackSink : IDockerNotifierSink
    {
        private readonly SlackSinkOptions _options;

        public SlackSink()
        {
            _options = new SlackSinkOptions();
        }

        public SlackSink(SlackSinkOptions options)
        {
            _options = options;
        }

        public void Flow(DockerEvent dockerEvent)
        {
            if (dockerEvent.Type != "container")
                return;

            if (!new List<string> {"start", "stop"}.Contains(dockerEvent.Action))
                return;

            var notification = _options.DockerEventParser.Parse(dockerEvent);
            postNotification(notification).Wait();
        }

        private async Task postNotification(SlackNotification notification)
        {
            var slackHooksAPI = RestService.For<ISlackHooksAPI>(_options.WebhookUri);

            await slackHooksAPI.SendNotification(notification);
        }
    }
}
