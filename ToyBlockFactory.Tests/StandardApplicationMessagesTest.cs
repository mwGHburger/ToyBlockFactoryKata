using Xunit;

namespace ToyBlockFactory.Tests
{
    public class StandardApplicationMessagesTest
    {
        [Fact]
        public void Welcome_ShouldReturnWelcomeMessageString()
        {
            var standardApplicationMessage = new StandardApplicationMessages();
            var expected = "Welcome to the Toy Block Factory!";

            var actual = standardApplicationMessage.Welcome();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EndApplication_ShouldReturnEndingMessageString()
        {
            var standardApplicationMessage = new StandardApplicationMessages();
            var expected = "Ending Application...";

            var actual = standardApplicationMessage.EndApplication();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Router_ShouldReturnApplicationFunctionsString()
        {
            var standardApplicationMessage = new StandardApplicationMessages();
            var expected = 
            "Choose a function\n" +
            "1 - Make Single Order\n" +
            "q - To Quit Application\n";

            var actual = standardApplicationMessage.Router();
            
            Assert.Equal(expected, actual);
        }
    }
}