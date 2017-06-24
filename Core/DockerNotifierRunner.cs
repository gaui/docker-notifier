using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using DockerNotifier.Core.Models;
using DockerNotifier.Core.Sinks;
using Newtonsoft.Json;

namespace DockerNotifier.Core
{
    public sealed class DockerNotifierRunner
    {
        private readonly Dictionary<string, IDockerNotifierSink> _sinks;

        private readonly IDockerClient _dockerClient;

        public DockerNotifierRunner(string dockerUri)
        {
            _sinks = new Dictionary<string, IDockerNotifierSink>();

            _dockerClient = new DockerClientConfiguration(new Uri(dockerUri))
                    .CreateClient();
        }

        public List<string> GetRegisteredSinks()
        {
            var list = _sinks.Keys.ToList();

            return list;
        }

        public string RegisterSink(IDockerNotifierSink sink)
        {
            string guid = new Guid().ToString();
            _sinks.Add(guid, sink);

            return guid;
        }

        public void UnregisterSink(string guid)
        {
            _sinks.Remove(guid);
        }

        public void MonitorEvents()
        {
            if(!_sinks.Any())
                throw new DockerNotifierSinkException();

            monitorEvents().Wait();
        }

        private async Task<Stream> monitorEvents()
        {
            CancellationTokenSource cancellation = new CancellationTokenSource();
            Stream stream = await _dockerClient.Miscellaneous.MonitorEventsAsync(new ContainerEventsParameters(), cancellation.Token);
            using (StreamReader reader = new StreamReader(stream))
            {
                string content;
                while ((content = await reader.ReadLineAsync()) != null && !cancellation.IsCancellationRequested)
                {
                    var dockerEvent = JsonConvert.DeserializeObject<DockerEvent>(content);

                    foreach (var sink in _sinks)
                    {
                        sink.Value.Flow(dockerEvent);
                    }
                }
            }

            return stream;
        }
    }
}
