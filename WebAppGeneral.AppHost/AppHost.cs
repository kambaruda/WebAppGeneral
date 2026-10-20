var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebAppGeneral>("webappgeneral");

builder.Build().Run();
