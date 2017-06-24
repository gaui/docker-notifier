using DockerNotifier.Core;
using DockerNotifier.Sinks.Slack;

namespace DockerNotifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string dockerHost = Helper.GetDockerHost();

            DockerNotifierRunner runner = new DockerNotifierRunner(dockerHost);

            runner.RegisterSink(new SlackSink());
            runner.MonitorEvents();
        }
    }
}