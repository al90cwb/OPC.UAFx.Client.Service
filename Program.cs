using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OPC.UAFx.Client.Service;
using OPC.UAFx.Client.Service.Models;

try
{
    var builder = Host.CreateApplicationBuilder(args);
    builder.Logging.AddConsole();

    // Log de verificação do início da configuração
    Console.WriteLine("Iniciando configuração dos serviços...");

    // Configuração da string de conexão SQLite
    var connectionString = "Data Source=MaquinaOee.db";

    // Registrar o AppDbContext no contêiner de serviços
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(connectionString));

    // Log após registro do DbContext
    Console.WriteLine("DbContext registrado.");

    // Registrar o MaquinaOeeClient como serviço escopado
    builder.Services.AddScoped<MaquinaOeeClient>(provider =>
    {
        var dbContext = provider.GetRequiredService<AppDbContext>();
        return new MaquinaOeeClient("opc.tcp://10.0.0.4:4840", dbContext);
    });

    // Log após registro do MaquinaOeeClient
    Console.WriteLine("MaquinaOeeClient registrado.");

    // Adicionar o Worker como serviço hospedado
    builder.Services.AddHostedService<Worker>();

    // Log após registro do Worker
    Console.WriteLine("Worker registrado.");

    // Construir e rodar o host
    var host = builder.Build();

    Console.WriteLine("Iniciando host...");
    await host.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao inicializar o programa: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}
