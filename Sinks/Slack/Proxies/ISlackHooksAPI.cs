using System.Threading.Tasks;
using DockerNotifier.Sinks.Slack.Models;
using Refit;

namespace DockerNotifier.Sinks.Slack.Proxies
{
    public interface ISlackHooksAPI
    {
        [Post("")]
        Task SendNotification([Body] SlackNotification slackNotification);
    }
}
