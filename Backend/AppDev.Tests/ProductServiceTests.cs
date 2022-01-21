using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppDev.Models;
using AppDev.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace AppDev.Tests
{
    public class ProductServiceTests
    {
        ProductService _sut;
        Mock<IAssetsService> _assetService;
        Mock<IConfiguration> _config;

        [SetUp]
        public void Setup()
        {
            _assetService = new Mock<IAssetsService>();
            _config = new Mock<IConfiguration>();
            _config.Setup(i => i.GetSection(It.IsAny<string>())).Returns(It.IsAny<IConfigurationSection>());
        }

        [Test]
        public async Task TestSeedDataIsNotNullOrEmpty()
        {
            // arrange
            var json = JsonSerializer.Serialize(GetProducts());
            _assetService.Setup(i => i.GetFileStreamAsync(It.IsAny<string>())).ReturnsAsync(ToMemoryStream(json));
            _sut = new ProductService(_config.Object, new Mock<ILogger<ProductService>>().Object, _assetService.Object);

            // act
            var result = await _sut.GetProductsAsync();

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Products);
        }

        [Test]
        public async Task TestSeedDataIsNull()
        {
            // arrange
            _assetService.Setup(i => i.GetFileStreamAsync(It.IsAny<string>()))
                .ReturnsAsync(ToMemoryStream(It.IsAny<string>()));
            _sut = new ProductService(_config.Object, new Mock<ILogger<ProductService>>().Object, _assetService.Object);

            // act
            var result = await _sut.GetProductsAsync();

            // assert
            Assert.IsNull(result);
        }

        static ProductList GetProducts()
        {
            var productList = new ProductList
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Title = "Test Product",
                        Items = new List<ProductItem>
                        {
                            new ProductItem
                            {
                                Url = "someurls.com",
                                FullName = "Test Product",
                                ParentLocation = "Test Location",
                                LeadProduct = new LeadProduct
                                {
                                    Rounds = 1,
                                    Nights = 0,
                                    Price = 102.25,
                                    Badge = "myBadge.svg"
                                },
                                VenueItemData = new List<VenueItemData>
                                {
                                    new VenueItemData
                                    {
                                        VenueType = VenueType.GolfCourse,
                                        VenueInformation = new VenueInformation
                                        {
                                            OfficialStarRating = 4
                                        }
                                    }
                                },
                                Image = new Image
                                {
                                    Title = "Test Image",
                                    ImageFile = new ImageFile
                                    {
                                        Url = new Uri(
                                            "loghttps://images.contentstack.io/v3/assets/blt99dd26276e65134a/blt447ea9796f1322cd/5eea1355293eef25d2b6e029/TheBelfry_Clubhouse.jpg")
                                    }
                                }
                            }
                        }
                    },
                    new Product()
                }
            };

            return productList;
        }

        static MemoryStream ToMemoryStream(string s, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new MemoryStream();
            }

            encoding ??= Encoding.UTF8;

            return new MemoryStream(encoding.GetBytes(s));
        }
    }
}