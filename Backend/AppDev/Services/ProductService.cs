using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AppDev.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

#nullable enable

namespace AppDev.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Asynchronously gets all products.
        /// </summary>
        /// <returns> Nullable <see cref="ProductList"/></returns>
        Task<ProductList?> GetProductsAsync();
    }

    public class ProductService : IProductService
    {
        readonly IConfiguration _config;
        readonly ILogger<ProductService> _logger;
        readonly IAssetsService _assetsService;

        public ProductService(IConfiguration config, ILogger<ProductService> logger, IAssetsService assetsService)
        {
            _config = config;
            _logger = logger;
            _assetsService = assetsService;
        }

        public async Task<ProductList?> GetProductsAsync()
        {
            var path =
                $"{Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)}/{_config.GetSection("Assets")?.GetSection("JsonAsset").Value}";

            _logger.LogDebug($"🤖📢 Asset path is => {path}");

            try
            {
                await using var stream = await _assetsService.GetFileStreamAsync(path);

                if (stream is not null && stream.CanRead)
                {
                    var option = new JsonSerializerOptions
                    {
                        Converters =
                        {
                            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                        }
                    };

                    return await JsonSerializer.DeserializeAsync<ProductList>(stream, option);
                }

                _logger.LogError($"🤖📢 Asset file is null or can't be read");

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deserializing json 😢");

                return null;
            }
            finally
            {
                _logger.LogDebug("🤖📢 Finished deserializing json ");
            }
        }
    }
}