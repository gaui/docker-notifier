using System;
using System.Collections.Generic;

namespace DockerNotifier
{
    public static class Helper
    {
        public static string GetDockerHost()
        {
            string platform = Environment.GetEnvironmentVariable("PLATFORM");

            if (platform == "windows")
                return "tcp://docker.for.win.localhost:2375";

            return "unix://var/run/docker.sock";
        }
    }
}
