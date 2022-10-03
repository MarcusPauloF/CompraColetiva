using acme.sistemas.compracoletiva.service.Interfaces.Worker.Util;

namespace acme.sistemas.compracoletiva.service.Works.Util
{
    public class EmailWorkerServico : IEmailWorkerServico
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Iniciando Email {DateTime.Now}");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Finalizada Email {DateTime.Now}");
            return Task.CompletedTask;
        }

        public Task DoWork()
        {
            Console.WriteLine($"{DateTime.Now}");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}
