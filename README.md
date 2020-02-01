
# Net Core 3.1 Project with Memory Leak PoC in Docker / Kubernetes

The purpose of the project is how to debug / track memory leak in applicaton using [dotnet-dump](https://docs.microsoft.com/en-us/dotnet/core/diagnostics/dotnet-dump) and [dotnet-counters](https://docs.microsoft.com/en-us/dotnet/core/diagnostics/dotnet-counters) in Docker / Kubernetes

The example project is based on the [sample project](https://github.com/dotnet/samples/tree/master/core/diagnostics/DiagnosticScenarios) the only difference is that it contains the Dockerfile and the code is moved in an manager 



[![Build status](https://dev.azure.com/MirceaMProjects/NetCore-Microservices/_apis/build/status/MemoryLeak-Git)](https://dev.azure.com/MirceaMProjects/NetCore-Microservices/_build/latest?definitionId=11)

## Tracking memory leak
The debug of memory leak can be found [here](https://docs.microsoft.com/en-us/dotnet/core/diagnostics/debug-memory-leak). 

### Kubernetes flow

    kubectl exec pod-name -n namespace -it -- /bin/bash
Where **pod-name** is the pod of the memory leak application and **namespace** where the pod was deployed 

### Docker flow 

    docker exec container-id -it /bin/bash

Where **container-id** is the container that is running on your local machine.
