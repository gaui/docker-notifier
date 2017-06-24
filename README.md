# Docker Notifier

Docker Notifier is a .NET Core console application that monitors Docker events and pipes them out to various _sinks_. A sink is something that allows some data to _flow through it_.

## Quick start

### Linux

```
docker run -d \
    -v /var/run/docker.sock:/var/run/docker.sock \
    -e SLACK.WEBHOOK_URL=https://hooks.slack.com/services/YOUR_ID \
    gaui/docker-notifier:latest
```

### Windows

I haven't successfully tested this because of [this issue on my machine](https://github.com/Microsoft/Docker.DotNet/issues/220) but it should in theory work.

```
docker run -d \
    -p 2375:2375 \
    -e PLATFORM=windows
    -e SLACK.WEBHOOK_URL=https://hooks.slack.com/services/YOUR_ID \
    gaui/docker-notifier:latest
```

#### Named pipes

By default I use `tcp://localhost:2375` but if you want to used _named pipe_ you can specify environment variable `PLATFORM=windows-npipe`

## Contributors

- Guðjón Jónsson <<https://www.gaui.is>>

## TODO

- Add unit tests
- Split sinks into seperate packages
- Add more Docker event types

## Changelog

### v0.1 initial release
