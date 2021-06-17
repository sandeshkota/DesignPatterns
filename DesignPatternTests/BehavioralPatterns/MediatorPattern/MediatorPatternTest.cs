using DesignPatterns.BehavioralPatterns.MediatorPattern;
using Xunit;

namespace DesignPatternTests.BehavioralPatterns.MediatorPattern
{
    public class MediatorPatternTest
    {
        [Fact]
        public void OneWay_Chat_Test()
        {
            // arrange
            var amar = new Visitor("amar");
            var akbar = new Visitor("akbar");

            var chatRoom = new ChatRoom();
            amar.Enter(chatRoom);
            akbar.Enter(chatRoom);

            // act
            amar.Send("Hello!!");
            amar.Send("I am from Mysuru");

            // assert
            Assert.Equal(2, amar.TotalMessagesSent);
            Assert.Equal(2, akbar.TotalMessagesRecieved);
        }


        [Fact]
        public void TwoWay_Chat_Test()
        {
            // arrange
            var amar = new Visitor("amar");
            var akbar = new Visitor("akbar");

            var chatRoom = new ChatRoom();
            amar.Enter(chatRoom);
            akbar.Enter(chatRoom);

            // act
            amar.Send("Hello!!");
            amar.Send("I am from Mysuru");
            akbar.Send("Hey! Welcome Amar");

            // assert
            Assert.Equal(2, amar.TotalMessagesSent);
            Assert.Equal(1, amar.TotalMessagesRecieved);

            Assert.Equal(1, akbar.TotalMessagesSent);
            Assert.Equal(2, akbar.TotalMessagesRecieved);
        }

        [Fact]
        public void Leave_Chat_Test()
        {
            // arrange
            var amar = new Visitor("amar");
            var akbar = new Visitor("akbar");

            var chatRoom = new ChatRoom();
            amar.Enter(chatRoom);
            akbar.Enter(chatRoom);

            // act
            amar.Send("Hello!!");
            amar.Send("I am from Mysuru");

            akbar.Leave();

            amar.Send("Are you there??");

            // assert
            Assert.Equal(3, amar.TotalMessagesSent);
            Assert.Equal(2, akbar.TotalMessagesRecieved);
        }

    }
}
