using System;
using System.Collections.Generic;
using System.Text;

namespace Project_06_MonteCarlo
{
    class Task
    {
        private int worst, best;
        public Task(string input)
        {
            InputConverter convert = new InputConverter();
            int[] numbers = convert.Convert(input);
            if (Check(numbers[0], numbers[1]))
            {
                this.worst = numbers[0];
                this.best = numbers[1];
            }
            else
            {
                Console.WriteLine("Numbers are invalid (best > avg > worst)");
                throw new Exception("Invalid input");
            }
        }
        public Task(int worst, int best)
        {
            if(Check(worst, best))
            {
                this.worst = worst;
                this.best = best;
            }
            else
            {
                Console.WriteLine("Numbers are invalid (best > avg > worst)");
                throw new Exception("Invalid input");
            }
        }
        public int GetMinimum() { return worst; }
        public int GetMaximum() { return best; }
        public double GetAverage() { return (double)(worst + best)/2; }
        public int GetRandomEstimate()
        {
            Random rnd = new Random();
            return rnd.Next(worst, best);
        }

        public bool Check(int worst, int best)
        {
            if (worst > best)
            {
                return false;
            }
            return true;
        }
    }
}
