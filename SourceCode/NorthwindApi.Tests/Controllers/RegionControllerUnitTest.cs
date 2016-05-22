﻿using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.EntityLayer;
using NorthwindApi.Controllers;
using NorthwindApi.Responses;
using NorthwindApi.Services;

namespace NorthwindApi.Tests
{
    [TestClass]
    public class RegionUnitTest
    {
        private IBusinessObjectService service;

        [TestInitialize]
        public void Init()
        {
            service = new BusinessObjectService();
        }

        [TestMethod]
        public async Task GetAsync()
        {
            // Arrange
            var controller = new RegionController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Get();

            // Assert
            var value = default(IComposedModelResponse<Region>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
        }

        [TestMethod]
        public async Task PostAsync()
        {
            // Arrange
            var controller = new RegionController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Region()
            {
                RegionID = 5,
                RegionDescription = "Acme Region"
            };

            var result = await controller.Post(model);

            // Assert
            var response = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model.RegionID);
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            // Arrange
            var controller = new RegionController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Get(5);

            // Assert
            var response = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model);
        }

        [TestMethod]
        public async Task PutAsync()
        {
            // Arrange
            var controller = new RegionController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Region()
            {
                RegionDescription = "Acme Region 2",
            };

            var result = await controller.Put(5, model);

            // Assert
            var value = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record updated successfully");
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            // Arrange
            var controller = new RegionController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Delete(5);

            // Assert
            var value = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record deleted successfully");
        }
    }
}
