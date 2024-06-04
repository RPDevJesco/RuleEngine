using System;

namespace RuleEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a rule engine instance
            var ruleEngine = new Rules.RuleEngine();

            // Add a rule with static priority
            ruleEngine.AddRule(builder =>
                builder
                    .When(() => DateTime.Now.Hour < 12)
                    .Then(() => Console.WriteLine("Good Morning!"))
                    .WithPriority(1)
            );

            // Add a rule with a dynamic priority for the afternoon
            ruleEngine.AddRule(builder =>
                builder
                    .When(() => DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
                    .Then(() => Console.WriteLine("Good Afternoon!"))
                    .WithDynamicPriority(() => DateTime.Now.Hour)
            );

            // Add a rule with a dynamic priority for the evening
            ruleEngine.AddRule(builder =>
                builder
                    .When(() => DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 24)
                    .Then(() => Console.WriteLine("Good Evening!"))
                    .WithDynamicPriority(() => DateTime.Now.Hour)
            );

            // Add a rule with multiple conditions
            ruleEngine.AddRule(builder =>
                builder
                    .When(() => DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                    .And(() => DateTime.Now.Hour < 12)
                    .Then(() => Console.WriteLine("It's Monday morning!"))
                    .WithPriority(2)
            );

            // Execute the rules
            ruleEngine.Execute();

            Console.ReadLine(); // Keep the console open
        }
    }
}