var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.mnyControl_Api>("mnycontrol-api");

builder.Build().Run();
