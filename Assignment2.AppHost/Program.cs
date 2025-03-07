var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Assignment2_ApiService>("apiservice");

builder.AddProject<Projects.Assignment2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
