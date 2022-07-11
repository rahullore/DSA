using Smart.work.Meetingroom;

namespace Smart.work.Test.Meetingroom
{
    [TestFixture]
    public class MeetingroomTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CheckWhenThereIsNoAcivity()
        {
            LogTimeHandler logTimeHandler = new LogTimeHandler(new List<Logtime>());

            Assert.That(logTimeHandler.GetIdleTime(), Is.EqualTo(24 * 60));
        }

        [Test]
        public void CheckWhenThereIsOnlyOneAcivity()
        {

            LogTimeHandler logTimeHandler = new LogTimeHandler(new List<Logtime>()
            { 
                new Logtime {
                    Start= new DateTimeOffset(2022,07,02,10,00,00,TimeSpan.Zero),
                    End = new DateTimeOffset(2022,07,02,12,00,00,TimeSpan.Zero),
                },                
            });

            Assert.That(logTimeHandler.GetIdleTime(), Is.EqualTo(22 * 60));//because 2 hours it's busy
        }

        [Test]
        public void CheckWhenThereIsMultipleAcivity()
        {

            LogTimeHandler logTimeHandler = new LogTimeHandler(new List<Logtime>()
            {
                new Logtime {
                    Start= new DateTimeOffset(2022,07,02,02,00,00,TimeSpan.Zero),
                    End = new DateTimeOffset(2022,07,02,03,00,00,TimeSpan.Zero),
                },

                 new Logtime {
                    Start= new DateTimeOffset(2022,07,02,02,30,00,TimeSpan.Zero),
                    End = new DateTimeOffset(2022,07,02,03,30,00,TimeSpan.Zero),
                },

                  new Logtime {
                    Start= new DateTimeOffset(2022,07,02,04,00,00,TimeSpan.Zero),
                    End = new DateTimeOffset(2022,07,02,05,00,00,TimeSpan.Zero),
                },

                    new Logtime {
                    Start= new DateTimeOffset(2022,07,02,02,00,00,TimeSpan.Zero),
                    End = new DateTimeOffset(2022,07,02,05,00,00,TimeSpan.Zero),
                },
            });

            double busyTime = 3 * 60;

            Assert.That(logTimeHandler.GetIdleTime(), Is.EqualTo((24 * 60) - busyTime));
        }

    }
}