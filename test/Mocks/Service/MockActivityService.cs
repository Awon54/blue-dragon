using blue_dragon.Models.V1;
using blue_dragon.Service.V1;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace test.Mocks.Service
{
    public class MockActivityService : Mock<IActivityService>
    {

        public MockActivityService MockGetActivityById(Activity activity)
        {
            Setup(x => x.GetActivityById(It.IsAny<int>())).ReturnsAsync(activity);

            return this;
        }

        public MockActivityService MockPatchActivityStatus(Activity activityToBeUpdated, string status)
        {
            Setup(x => x.GetActivityById(It.IsAny<int>())).ReturnsAsync(activityToBeUpdated);
            Setup(x => x.UpdateActivityStatus(activityToBeUpdated, status)).Returns(Task.CompletedTask);
            return this;
        }

        public MockActivityService MockGetActivities(List<Activity> activities)
        {
            Setup(x => x.GetAllActivity()).ReturnsAsync(activities);

            return this;
        }

    }
}
