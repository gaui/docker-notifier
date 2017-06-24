using System;
using System.Collections.Generic;

namespace DockerNotifier
{
    public static class Helper
    {
        public static string GetDockerHost()
        {
            string platform = Environment.GetEnvironmentVariable("PLATFORM");

            if (new List<string> { "windows", "windows-tcp" }.Contains(platform))
                return "tcp://localhost:2375";

            if (platform == "windows-npipe")
                return "npipe://./pipe/docker_engine";

            return "unix://var/run/docker.sock";
        }
    }
}
