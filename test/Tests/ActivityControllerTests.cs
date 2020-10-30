using blue_dragon.Controllers.API.V1;
using Xunit;
using test.Mocks.Service;
using test.Helpers;
using System.Threading.Tasks;
using blue_dragon.Models.V1;
using Microsoft.AspNetCore.Mvc;
using System;
using blue_dragon.Dto.V1;
using System.Collections.Generic;
using Moq;

namespace test.Tests
{
    public class ActivityControllerTests
    {

        [Fact]
        public async Task ActivityController_GetActivityById_Sucess()
        {

            
            // Arrange
            Activity newActivity = new Activity
            {
                Id = 1,
                Amount = 10,
                DateTime = DateTime.Now,
                Description = "Test",
                Status = "Pending"
            };

            var mockActivityService = new MockActivityService().MockGetActivityById(newActivity);
            var controller = new ActivitiesController(mockActivityService.Object, AutoMapperSingleton.Mapper);

            // Act
            var actionResult = await controller.GetActivity(1);
            var resultObject = Utils.GetObjectResultContent<Activity>(actionResult);

            //Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(1, resultObject.Id);
            Assert.Equal(10, resultObject.Amount);
            Assert.Equal("Test", resultObject.Description);
            Assert.Equal("Pending", resultObject.Status);


        }

        [Fact]
        public async Task ActivityController_GetById_NotFound()
        {
            // Arrange
            Activity newActivity = null;
            var mockActivityService = new MockActivityService().MockGetActivityById(newActivity);
            var controller = new ActivitiesController(mockActivityService.Object, AutoMapperSingleton.Mapper);

            // Act
            var actionResult = await controller.GetActivity(2);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);

        }

        [Fact]
        public async Task ActivityController_GetAllActivities()
        {

            // Arrange
            Activity activity1 = new Activity
            {
                Id = 1,
                Amount = 10,
                DateTime = DateTime.Now,
                Description = "Test-1",
                Status = "Completed"
            };

            Activity activity2 = new Activity
            {
                Id = 2,
                Amount = 20,
                DateTime = DateTime.Now,
                Description = "Test-2",
                Status = "Cancelled"
            };

            Activity activity3 = new Activity
            {
                Id = 3,
                Amount = 30,
                DateTime = DateTime.Now,
                Description = "Test-3",
                Status = "Pending"
            };

            List<Activity> activities = new List<Activity>();
            activities.Add(activity1);
            activities.Add(activity2);
            activities.Add(activity3);

            var mockActivityService = new MockActivityService().MockGetActivities(activities);
            var controller = new ActivitiesController(mockActivityService.Object, AutoMapperSingleton.Mapper);

            // Act
            var actionResult = await controller.GetActivities();
            var resultObject = Utils.GetObjectResultContent<IEnumerable<Activity>>(actionResult);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Collection(resultObject,
                              elem1 => {
                                  Assert.Equal(1, elem1.Id);
                                  Assert.Equal(10, elem1.Amount);
                                  Assert.Equal("Test-1", elem1.Description);
                                  Assert.Equal("Completed", elem1.Status);

                              },
                              elem2 =>
                              {
                                  Assert.Equal(2, elem2.Id);
                                  Assert.Equal(20, elem2.Amount);
                                  Assert.Equal("Test-2", elem2.Description);
                                  Assert.Equal("Cancelled", elem2.Status);

                              },
                               elem3 =>
                               {
                                   Assert.Equal(3, elem3.Id);
                                   Assert.Equal(30, elem3.Amount);
                                   Assert.Equal("Test-3", elem3.Description);
                                   Assert.Equal("Pending", elem3.Status);
                               }
                              );

        }

       

        [Fact]
        public async Task ActivityController_PatchActivityStatus_Sucess()
        {
            // Arrange
            Activity toBeUpdated = new Activity
            {
                Id = 1,
                Amount = 10,
                DateTime = DateTime.Now,
                Description = "Test",
                Status = "Pending"
            };

            string newStatus = "Completed";

            PatchActivityStatusDto patchDto = new PatchActivityStatusDto 
            { 
                Status = newStatus
            };

            var mockActivityService = new MockActivityService().MockPatchActivityStatus(toBeUpdated, newStatus);
            var controller = new ActivitiesController(mockActivityService.Object, AutoMapperSingleton.Mapper);

            // Act
            var actionResult = await controller.PatchActivityStatus(1, patchDto) ;

            //Assert
           Assert.IsType<NoContentResult>(actionResult);

        }

        [Fact]
        public async Task ActivityController_PatchActivityStatus_BadRequest()
        {
            // Arrange
            Activity toBeUpdated = new Activity
            {
                Id = 1,
                Amount = 10,
                DateTime = DateTime.Now,
                Description = "Test",
                Status = "Pending"
            };

            string newStatus = "Completed";

            PatchActivityStatusDto patchDto = null;

            var mockActivityService = new MockActivityService().MockPatchActivityStatus(toBeUpdated, newStatus);
            var controller = new ActivitiesController(mockActivityService.Object, AutoMapperSingleton.Mapper);

            // Act
            var actionResult = await controller.PatchActivityStatus(1, patchDto);

            //Assert
            Assert.IsType<BadRequestResult>(actionResult);

        }


        [Fact]
        public async Task ActivityController_PatchActivityStatus_NotFound()
        {
            // Arrange
            Activity toBeUpdated = null;

            string newStatus = "Completed";

            PatchActivityStatusDto patchDto = new PatchActivityStatusDto
            {
                Status = newStatus
            };

            var mockActivityService = new MockActivityService().MockPatchActivityStatus(toBeUpdated, newStatus);
            var controller = new ActivitiesController(mockActivityService.Object, AutoMapperSingleton.Mapper);

            // Act
            var actionResult = await controller.PatchActivityStatus(1, patchDto);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult);

        }
      
    }
}
