using Microsoft.Extensions.Hosting;

namespace acme.sistemas.compracoletiva.service.Interfaces.Worker
{
    public interface IBaseWorkerService : IHostedService, IDisposable
    {
        Task DoWork();
    }
}
