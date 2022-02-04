using System;
using System.Collections.Generic;
using System.Text;

namespace Project_06_MonteCarlo
{
    class Plan
    {
        private const int iterations = 10000;
        private const int buckets = 10;
        private double gap; 
        private int min, avg, max;
        private List<Task> plan = new List<Task>();
        private int[] intervals = new int[buckets];

        public void Add(Task task)
        {
            plan.Add(task);
            UpdateInfo();
        }

        public List<Task> GetTasks()
        {
            return plan;
        }

        public int Simulate()
        {
            int totalCostOfRandomPlans = 0;
            for (int i = 0; i < iterations; i++)
            {
                int randomPlanCost = 0;
                foreach (var task in plan)
                {
                    randomPlanCost += task.GetRandomEstimate();
                }
                intervals[(int)((randomPlanCost - min) / gap)]++;
                totalCostOfRandomPlans += randomPlanCost;
            }
            return totalCostOfRandomPlans / iterations;
        }

        public void GetStats()
        {
            Console.WriteLine($"After probing {iterations} random plans, the results are: ");
            Console.WriteLine($"Minimum = {min}");
            Console.WriteLine($"Maximum = {max}");
            Console.WriteLine($"Average = {avg}");
            Console.WriteLine("\nProbability of finishing the plan in: ");
            double day = min;
            foreach(var num in intervals)
            {
                Console.WriteLine($"{day} - {day+gap}: {num*100.0/iterations}%");
                day = day + gap <= max - gap ? day + gap : max - gap;
            }
            Console.WriteLine("\nAccumulated probability of finishing the plan in or before: ");
            day = min;
            double prob = 0;
            foreach (var num in intervals)
            {
                prob += num;
                Console.WriteLine($"{day+gap}: {prob * 100.0 / iterations}%");
                day += gap;
            }
        }
        private void UpdateInfo()
        {
            min = 0;
            max = 0;
            intervals = new int[10];
            foreach (var task in plan)
            {
                min += task.GetMinimum();
                max += task.GetMaximum();
            }
            gap = Math.Ceiling((double)(max - min) / buckets);
            avg = Simulate();
        }
    }
}
