using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.work.Recursion
{
    public class BalancedParenthesis
    {
        public List<string> Answer = new List<string>();

        public void Run(int n)
        {
            Answer = new List<string>();
            Generate(n, n, "");
        }

        public void Generate(int open,int close,string str)
        {
            if(open==0 && close == 0)
            {
                Answer.Add(str);
                return;
            }
            
            if(open == close)//no choice you can only use open 
            {
                Generate(open - 1, close, str + "(");
            }
            else //you always have 2 choice when close > open
            {
                if(open>0) //you always have a choice to use open if count is > 0
                {
                    Generate(open - 1, close, str + "(");
                }
                if(close > open) //using ( 
                {
                    Generate(open, close-1, str + ")");
                }
            }
        }
    }
}
