FROM microsoft/dotnet:1.1-runtime
ARG source
WORKDIR /app
COPY dist/ .
ENTRYPOINT ["dotnet", "DockerNotifier.dll"]
