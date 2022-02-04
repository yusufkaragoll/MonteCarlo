using System;
using System.Collections.Generic;
using System.Text;

namespace Project_06_MonteCarlo
{
    class InputConverter
    {
        public int[] Convert(string input)
        {
            if(Check(input))
            {
                string[] strArr = input.Replace(" ", string.Empty).Split(',');
                int[] numbers = Array.ConvertAll(strArr, s => int.Parse(s));
                return numbers;
            }
            return null;
        }

        public bool Check(string input)
        {
            string[] inpArr = input.Replace(" ", string.Empty).Split(',');
            foreach(var str in inpArr)
            {
                if(!int.TryParse(str, out int temp) || inpArr.Length != 2)
                {
                    Console.WriteLine("Incorrect input");
                    return false;
                }
            }
            return true;
        }
    }
}
