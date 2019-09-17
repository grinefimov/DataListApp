using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers;
using WebApi.Models;
using Xunit;

namespace WebApi.Tests
{
    public class DataControllerTest
    {
        [Fact]
        public async Task TestGetDataListAsync()
        {
            // Arrange
            var dbContext = ContextMocker.GetDataContext(nameof(TestGetDataListAsync));
            var controller = new DataController(dbContext);
            var result = new List<Data>
            {
                new Data
                {
                    Data1 = "1-1",
                    Data2 = "1-2",
                    Data3 = "1-3",
                    Data4 = "1-4",
                    Data5 = "1-5"
                },
                new Data
                {
                    Data1 = "2-1",
                    Data2 = "2-2",
                    Data3 = "2-3",
                    Data4 = "2-4",
                    Data5 = "2-5"
                }
            };
            
            // Act
            ActionResult<List<Data>> response = await controller.GetDataListAsync();
            List<Data> value = response.Value;
            dbContext.Dispose();

            // Assert
            Assert.Equal(result[0].Data1, value[0].Data1);
            Assert.Equal(result[1].Data1, value[1].Data1);
        }

        [Fact]
        public async Task TestGetDataAsync()
        {
            // Arrange
            var dbContext = ContextMocker.GetDataContext(nameof(TestGetDataAsync));
            var controller = new DataController(dbContext);
            int id = 1;
            var result = new Data
            {
                Data1 = "1-1",
                Data2 = "1-2",
                Data3 = "1-3",
                Data4 = "1-4",
                Data5 = "1-5"
            };

            // Act
            ActionResult<Data> response = await controller.GetDataAsync(id);
            Data value = response.Value;
            dbContext.Dispose();

            // Assert
            Assert.Equal(result.Data1, value.Data1);
        }

        [Fact]
        public async Task TestPostDataAsync()
        {
            // Arrange
            var dbContext = ContextMocker.GetDataContext(nameof(TestPostDataAsync));
            var controller = new DataController(dbContext);
            var request = new Data
            {
                ID = 3,
                Data1 = "3-1",
                Data2 = "3-2",
                Data3 = "3-3",
                Data4 = "3-4",
                Data5 = "3-5"
            };

            // Act
            ActionResult response = await controller.PostDataAsync(request);
            OkResult result = response as OkResult;
            dbContext.Dispose();

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task TestPutDataAsync()
        {
            // Arrange
            var dbContext = ContextMocker.GetDataContext(nameof(TestPutDataAsync));
            var controller = new DataController(dbContext);
            var id = 2;
            var request = new Data
            {
                Data1 = "2-1",
                Data2 = "2-2",
                Data3 = "2-3",
                Data4 = "2-4",
                Data5 = "2-5"
            };

            // Act
            ActionResult response = await controller.PutDataAsync(id, request);
            OkResult result = response as OkResult;
            dbContext.Dispose();

            // Assert
            Assert.IsType<OkResult>(result);

        }

        [Fact]
        public async Task TestDeleteDataAsync()
        {
            // Arrange
            var dbContext = ContextMocker.GetDataContext(nameof(TestDeleteDataAsync));
            var controller = new DataController(dbContext);
            var id = 2;

            // Act
            ActionResult response = await controller.DeleteDataAsync(id);
            OkResult result = response as OkResult;
            dbContext.Dispose();

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}