using System;

namespace Project_06_MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 1;
            string input;
            Plan plan = new Plan();
            InputConverter IC = new InputConverter();
            Console.WriteLine("Enter tasks in the following format: \"min, max\" (no avg needed)");
            Console.WriteLine("Type END to finish entering tasks");
            do
            {
                Console.Write($"Task #{id}: ");
                input = Console.ReadLine();
                if(IC.Check(input))
                {
                    id++;
                    plan.Add(new Task(input));
                }
            } while (input != "END");

            plan.GetStats();
            Console.ReadLine();
        }

        public int Simulate(Plan plan)
        {
            int totalCostOfRandomPlans = 0;
            int iterations = 1000;
            for (int i = 0; i < iterations; i++)
            {
                int randomPlanCost = 0;
                foreach (var task in plan.GetTasks())
                {
                    randomPlanCost += task.GetRandomEstimate();
                }
                totalCostOfRandomPlans += randomPlanCost;
            }
            return totalCostOfRandomPlans / iterations;
        }
    }
}
