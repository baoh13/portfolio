using Aspire.Hosting;

using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<BlazorApp>("frontend")
       .WithExternalHttpEndpoints();

builder.Build().Run();
