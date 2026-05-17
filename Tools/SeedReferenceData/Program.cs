using Domain;

var host = Website.Program.CreateWebHostBuilder(Array.Empty<string>()).Build();
await host.StartAsync();
await new ReferenceData().Create();
Console.WriteLine("Reference data seeded successfully.");
await host.StopAsync();
