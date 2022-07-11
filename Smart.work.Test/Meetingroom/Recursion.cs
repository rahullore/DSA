using Smart.work.Recursion;

namespace Smart.work.Test.Meetingroom{
    
    public class recursionTest{

        PermutationWithSpaces _permutationWithSpace = null;
        List<string> answer=null;


        [SetUp]
        public void Setup()
        {
            _permutationWithSpace = new PermutationWithSpaces();    
            _permutationWithSpace.Run("ABC");
            this.answer = _permutationWithSpace.Answer;
        }

        [Test]
        public void CheckAllCombination(){
            
            var expected = new List<string>{"A_BC","AB_C","ABC","A_B_C"};
            Assert.IsTrue(answer.Contains("ABC"));
            Assert.IsTrue(answer.Contains("A BC"));
            Assert.IsTrue(answer.Contains("A B C"));
            Assert.IsTrue(answer.Contains("AB C"));
        }
    }
}