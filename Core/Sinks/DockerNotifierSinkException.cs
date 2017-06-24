using System;

namespace DockerNotifier.Core.Sinks
{
    public class DockerNotifierSinkException : Exception
    {
        public DockerNotifierSinkException()
            : base("No sinks configured")
        { }
    }
}
