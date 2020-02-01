FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
RUN apt-get update \
  && apt-get upgrade -y \
  && apt-get install -y \
     file \
     lldb \
  && rm -rf /var/lib/apt/lists/*
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MemoryLeak/MemoryLeak.csproj", "MemoryLeak/"]
RUN dotnet restore "MemoryLeak/MemoryLeak.csproj"
COPY . .
WORKDIR "/src/MemoryLeak"
RUN dotnet build "MemoryLeak.csproj" -c Release -o /app/build
RUN dotnet tool install --tool-path /dotnetcore-tools dotnet-sos
RUN dotnet tool install --tool-path /dotnetcore-tools dotnet-trace
RUN dotnet tool install --tool-path /dotnetcore-tools dotnet-dump
RUN dotnet tool install --tool-path /dotnetcore-tools dotnet-counters
RUN dotnet tool install --tool-path /dotnetcore-tools dotnet-gcdump

FROM build AS publish
RUN dotnet publish "MemoryLeak.csproj" -c Release -o /app/publish

FROM base AS final
COPY --from=build /dotnetcore-tools /opt/dotnetcore-tools
ENV PATH="/opt/dotnetcore-tools:${PATH}"
RUN dotnet-sos install
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MemoryLeak.dll"]