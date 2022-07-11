using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.work.Recursion
{
    public class PermutationWithCaseChange
    {
        public List<string> Result { get; set; } = new List<string>();

        public void Run(string input)
        {
            permutation(input, "");
        }

        private void permutation(string input, string output)
        {
            if(input == "")
            {
                Result.Add(output);
                return;
            }

            var choice1 = output + input[0].ToString().ToLower();
            var choice2 = output + input[0].ToString().ToUpper();
            var ShorterInput = input.Substring(1, input.Length - 1);

            permutation(ShorterInput,  choice1);
            permutation(ShorterInput, choice2);

            return;
        }
    }
}
