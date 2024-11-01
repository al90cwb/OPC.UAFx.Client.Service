using OPC.UAFx.Client.Service.Models;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            // Usar um escopo para obter uma instância de MaquinaOeeClient
            using (var scope = _serviceProvider.CreateScope())
            {
                var maquinaOeeClient = scope.ServiceProvider.GetRequiredService<MaquinaOeeClient>();

                maquinaOeeClient.Conectar();

                // Coleta de dados
                var dadosMaquina = maquinaOeeClient.ColetarDados();
                maquinaOeeClient.SalvarDados(dadosMaquina);

                maquinaOeeClient.Desconectar();
            }

            // Esperar 1 minuto
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
