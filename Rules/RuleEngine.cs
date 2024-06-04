using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Rules
{
    /// <summary>
    /// Manages and executes a collection of rules in the email encryption service.
    /// This class provides methods to add rules and execute them based on their conditions and priorities.
    /// </summary>
    public class RuleEngine
    {
        private readonly List<Rule> _rules = new List<Rule>();

        /// <summary>
        /// Adds a new rule to the rule engine.
        /// This method uses a builder pattern to construct the rule.
        /// </summary>
        /// <param name="ruleBuilder">A delegate that configures the RuleBuilder.</param>
        /// <returns>The current instance of RuleEngine for method chaining.</returns>
        public RuleEngine AddRule(Action<RuleBuilder> ruleBuilder)
        {
            var builder = new RuleBuilder();
            ruleBuilder(builder);
            _rules.Add(builder.Build());
            return this;
        }

        /// <summary>
        /// Executes all rules in the engine.
        /// Rules are first updated for priority, then executed in order of their priority.
        /// Each rule's conditions are checked, and if all conditions are met, the rule's actions are performed.
        /// </summary>
        public void Execute()
        {
            // Sort the rules by their priority and execute those whose conditions are met.
            foreach (var rule in _rules.OrderBy(r => r.Priority))
            {
                // Check if all conditions of the rule are met.
                if (rule.Conditions.All(condition => condition()))
                {
                    // Execute all actions associated with the rule.
                    foreach (var action in rule.Actions)
                    {
                        action();
                    }
                }
            }
        }
    }
}