using blue_dragon.Models.V1;
using blue_dragon.Service.V1;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace test.Mocks.Service
{
    public class MockActivityService : Mock<IActivityService>
    {
        public MockActivityService MockGetActivityById(int id)
        {
            Setup(x => x.GetActivityById(It.IsAny<int>())).ReturnsAsync(new Activity { Id = id ,Amount = 10, DateTime = DateTime.Now, Description ="Test", Status = "Pending" 
            });
            return this;
        }

    }
}
