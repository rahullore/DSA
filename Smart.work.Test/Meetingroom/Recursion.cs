using Smart.work.Recursion;

namespace Smart.work.Test.Meetingroom{
    
    public class recursionTest{

        PermutationWithSpaces _permutationWithSpace = null;
        List<string> answer=null;

        PermutationWithCaseChange _permutationWithCaseChange = null;
        List<string> answer2 = null;


        [SetUp]
        public void Setup()
        {
            _permutationWithSpace = new PermutationWithSpaces();    
            _permutationWithSpace.Run("ABC");
            this.answer = _permutationWithSpace.Answer;

            _permutationWithCaseChange  = new PermutationWithCaseChange();
            _permutationWithCaseChange.Run("ab");
            this.answer2 = _permutationWithCaseChange.Result;
        }

        [Test]
        public void CheckAllCombination(){
            
            var expected = new List<string>{"A_BC","AB_C","ABC","A_B_C"};
            Assert.IsTrue(answer.Contains("ABC"));
            Assert.IsTrue(answer.Contains("A BC"));
            Assert.IsTrue(answer.Contains("A B C"));
            Assert.IsTrue(answer.Contains("AB C"));
        }

        [Test]
        public void CheckCase()
        {
            var expected = new List<string> { "Ab", "aB", "AB", "ab" };

            Assert.IsTrue(answer2.Contains("AB"));
            Assert.IsTrue(answer2.Contains("Ab"));
            Assert.IsTrue(answer2.Contains("aB"));
            Assert.IsTrue(answer2.Contains("ab"));
        }
    }
}