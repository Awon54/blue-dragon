using blue_dragon.Controllers.API.V1;
using Xunit;
using test.Mocks.Service;
using test.Helpers;
using System.Threading.Tasks;
using blue_dragon.Models.V1;
using Microsoft.AspNetCore.Mvc;

namespace test.Tests
{
    public class ActivityControllerTests
    {

        [Fact]
        public async Task ActivityController_GetById_Sucess()
        {
            // Arrange
            var mockActivityService = new MockActivityService().MockGetActivityById(1);
            var controller = new ActivitiesController(mockActivityService.Object, AutoMapperSingleton.Mapper);

            // Act
            var actionResult = await controller.GetActivity(1);
            var resultObject = GetObjectResultContent<Activity>(actionResult);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(1, resultObject.Id);

        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
