using System;

namespace RuleEngine.Rules
{
    /// <summary>
    /// Helps in constructing a Rule by providing methods to set its conditions, actions, and priority.
    /// This class follows the builder pattern to simplify the creation of complex Rule objects.
    /// </summary>
    public class RuleBuilder
    {
        private readonly Rule _rule = new Rule();

        /// <summary>
        /// Adds a condition to the rule.
        /// This condition is a function that returns a boolean value.
        /// </summary>
        /// <param name="condition">The condition function to add.</param>
        /// <returns>The current instance of RuleBuilder for method chaining.</returns>
        public RuleBuilder When(Func<bool> condition)
        {
            _rule.Conditions.Add(condition);
            return this;
        }

        /// <summary>
        /// Adds an additional condition to the rule.
        /// This condition is a function that returns a boolean value.
        /// </summary>
        /// <param name="condition">The additional condition function to add.</param>
        /// <returns>The current instance of RuleBuilder for method chaining.</returns>
        public RuleBuilder And(Func<bool> condition)
        {
            _rule.Conditions.Add(condition);
            return this;
        }

        /// <summary>
        /// Adds an action to the rule.
        /// This action is a method that performs a specific operation.
        /// </summary>
        /// <param name="action">The action to add.</param>
        /// <returns>The current instance of RuleBuilder for method chaining.</returns>
        public RuleBuilder Then(Action action)
        {
            _rule.Actions.Add(action);
            return this;
        }

        /// <summary>
        /// Sets a fixed priority for the rule.
        /// </summary>
        /// <param name="priority">The priority value to set.</param>
        /// <returns>The current instance of RuleBuilder for method chaining.</returns>
        public RuleBuilder WithPriority(int priority)
        {
            _rule.SetPriority(priority);
            return this;
        }

        /// <summary>
        /// Sets a function to dynamically calculate the priority of the rule.
        /// </summary>
        /// <param name="priorityFunction">The function to calculate the priority.</param>
        /// <returns>The current instance of RuleBuilder for method chaining.</returns>
        public RuleBuilder WithDynamicPriority(Func<int> priorityFunction)
        {
            _rule.SetPriorityFunction(priorityFunction);
            return this;
        }

        /// <summary>
        /// Builds and returns the constructed rule.
        /// </summary>
        /// <returns>The constructed Rule object.</returns>
        public Rule Build()
        {
            return _rule;
        }
    }
}