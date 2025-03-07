var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql").AddDatabase("sqldata"); 

var apiService = builder.AddProject<Projects.Assignment2_ApiService>("apiservice")
    .WithReference(sql)
    .WaitFor(sql);

var api = builder.AddProject<Projects.Assignment2_Server>("backend")
    .WithReference(sql)
    .WaitFor(sql);

builder.AddProject<Projects.Assignment2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
