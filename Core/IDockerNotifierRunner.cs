using System.Collections.Generic;
using DockerNotifier.Core.Sinks;

namespace DockerNotifier.Core
{
    public interface IDockerNotifierRunner
    {
        List<string> GetRegisteredSinks();
        string RegisterSink(IDockerNotifierSink sink);
        void UnregisterSink(string guid);
        void MonitorEvents();
    }
}
