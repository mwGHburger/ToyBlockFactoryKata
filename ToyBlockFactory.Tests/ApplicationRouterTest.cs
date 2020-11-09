using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class ApplicationRouterTest
    {
        [Fact]
        public void Run_ShouldAllowUsersToMakeSingleOrder()
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            var mockApplicationController = new Mock<IApplicationController>();
            var applicationRouter = new ApplicationRouter(mockApplicationController.Object, mockConsoleIO.Object);
            var prompt = 
            "Choose a function\n" +
            "1 - Make Single Order\n" +
            "q - To Quit Application";

            mockConsoleIO.SetupSequence(x => x.GetInput(prompt))
                .Returns("1")
                .Returns("q");

            applicationRouter.Run();

            mockConsoleIO.Verify(x => x.GetInput(prompt),Times.Exactly(2));
            mockApplicationController.Verify(x => x.HandleSingleOrder(), Times.Exactly(1));
        }
    }
}