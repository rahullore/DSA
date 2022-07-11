using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.work.Recursion{
    public class PermutationWithSpaces{
           
           public List<string> Answer { get; set; }= new List<string>();
          public void Run(string input)
        {
            if (input.Length == 1)
            {
                Answer.Add(input);
                return;
            }

            Solve(input.Substring(1, input.Length - 1), input.Substring(0, 1));
        }

        public void Solve(string input, string output)
        {
            if (input == "")
            {
                Answer.Add(output);
                return;
            }
            string output1 = output + input[0];
            string output2 = output + " " + input[0]; 
            string shorterInput = input.Substring(1, input.Length-1 );
            Solve(shorterInput, output1);
            Solve(shorterInput, output2);
            return;
        }
    }
}