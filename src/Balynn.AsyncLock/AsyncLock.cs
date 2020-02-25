using System;
using System.Threading;
using System.Threading.Tasks;

namespace Balynn.AsyncLock
{
    public class AsyncLock : IDisposable
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private async Task Enter()
        {
            await _semaphore.WaitAsync();
        }

        private void Exit()
        {
            _semaphore.Release();
        }

        public void Dispose()
        {
            _semaphore?.Dispose();
        }

        public static async Task<AsyncLock> EnterAsync()
        {
            var asyncLock = new AsyncLock();
            await asyncLock.Enter();

            return asyncLock;
        }
    }
}
