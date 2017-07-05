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

```
docker run -d \
    -e PLATFORM=windows
    -e SLACK.WEBHOOK_URL=https://hooks.slack.com/services/YOUR_ID \
    gaui/docker-notifier:latest
```

## Contributors

- Guðjón Jónsson <<https://www.gaui.is>>

## TODO

- Add unit tests
- Split sinks into seperate packages
- Add more Docker event types

## Changelog

### v0.2.0

- Fixed connection to Docker host for Windows platform

### v0.1.0 initial release
