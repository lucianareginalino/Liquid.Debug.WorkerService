using Liquid.Debug.Domain.Entities;
using Liquid.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid.Debug.WorkerService
{
    public interface IWorker<TEntity>
    {
        Task ProcessMessageAsync(ProcessMessageEventArgs<TEntity> args, CancellationToken cancellationToken);
    }
}