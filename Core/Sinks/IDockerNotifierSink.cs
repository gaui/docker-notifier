using DockerNotifier.Core.Models;

namespace DockerNotifier.Core.Sinks
{
    public interface IDockerNotifierSink
    {
        void Flow(DockerEvent dockerEvent);
    }
}
