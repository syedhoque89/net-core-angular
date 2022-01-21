using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

#nullable enable

namespace AppDev.Services
{
    public interface IAssetsService
    {
        /// <summary>
        /// Returns a stream of the requested asset.
        /// </summary>
        /// <param name="path">Fully qualified path to the asset</param>
        /// <returns>Nullable <see cref="Stream"/></returns>
        Task<Stream?> GetFileStreamAsync(string path);
    }

    public class AssetsService : IAssetsService
    {
        readonly ILogger<AssetsService> _logger;

        static readonly SemaphoreSlim FileLock = new(1, 1);

        public AssetsService(ILogger<AssetsService> logger)
        {
            _logger = logger;
        }

        public async Task<Stream?> GetFileStreamAsync(string path)
        {
            await FileLock.WaitAsync();
            try
            {
                return File.Open(path, FileMode.OpenOrCreate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting file stream!!");
                return null;
            }
            finally
            {
                FileLock.Release();
            }
        }
    }
}