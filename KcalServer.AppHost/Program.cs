var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.KcalServer>("kcalserver");

builder.Build().Run();
