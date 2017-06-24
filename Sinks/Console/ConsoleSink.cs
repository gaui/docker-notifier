using DockerNotifier.Core.Models;
using DockerNotifier.Core.Sinks;

namespace DockerNotifier.Sinks.Console
{
    public class ConsoleSink : IDockerNotifierSink
    {
        public void Flow(DockerEvent dockerEvent)
        {
            string containerId = dockerEvent.Actor?.ID?.Substring(0, 8);
            string containerName = dockerEvent.Actor?.Attributes?.Name;

            string msg = $"Container *{dockerEvent.Action}* : {containerId} ({containerName})";

            System.Console.WriteLine(msg);
        }
    }
}
