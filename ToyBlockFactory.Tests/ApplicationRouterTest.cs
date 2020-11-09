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
            var mockStandardApplicationMessages = new Mock<IStandardApplicationMessages>();
            var applicationRouter = new ApplicationRouter(mockApplicationController.Object, mockConsoleIO.Object, mockStandardApplicationMessages.Object);
            var prompt = 
            "Choose a function\n" +
            "1 - Make Single Order\n" +
            "q - To Quit Application\n";

            
            mockStandardApplicationMessages.Setup(x => x.Welcome()).Returns("Welcome to the Toy Block Factory!");
            mockStandardApplicationMessages.Setup(x => x.Router()).Returns("Choose a function\n" +
            "1 - Make Single Order\n" +
            "q - To Quit Application\n");
            mockStandardApplicationMessages.Setup(x => x.EndApplication()).Returns("Ending Application...");
            mockConsoleIO.SetupSequence(x => x.GetInput(prompt))
                .Returns("1")
                .Returns("q");

            applicationRouter.Run();

            mockStandardApplicationMessages.Verify(x => x.Welcome(),Times.Exactly(1));
            mockStandardApplicationMessages.Verify(x => x.Router(),Times.Exactly(2));
            mockStandardApplicationMessages.Verify(x => x.EndApplication(),Times.Exactly(1));
            mockConsoleIO.Verify(x => x.GetInput(prompt),Times.Exactly(2));
            mockApplicationController.Verify(x => x.HandleSingleOrder(), Times.Exactly(1));
        }
    }
}