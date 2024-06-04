using System;
using System.Collections.Generic;

namespace RuleEngine.Rules
{
    /// <summary>
    /// Represents a rule in the email encryption service.
    /// This class holds a set of conditions and actions for the rule,
    /// along with its priority and a function to update the priority.
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Gets the list of conditions for this rule.
        /// Each condition is a function that returns a boolean value.
        /// </summary>
        public List<Func<bool>> Conditions { get; } = new List<Func<bool>>();

        /// <summary>
        /// Gets the list of actions for this rule.
        /// Each action is a method that performs a specific operation.
        /// </summary>
        public List<Action> Actions { get; } = new List<Action>();

        /// <summary>
        /// Gets the priority of this rule.
        /// The priority determines the order in which rules are processed.
        /// </summary>
        public int Priority => _priorityFunction?.Invoke() ?? _staticPriority;

        /// <summary>
        /// A function that calculates and sets the priority of this rule.
        /// </summary>
        private Func<int> _priorityFunction;

        private int _staticPriority;

        /// <summary>
        /// Sets the priority of the rule to a specific value.
        /// </summary>
        /// <param name="priority">The priority value to set.</param>
        public void SetPriority(int priority)
        {
            _staticPriority = priority;
            _priorityFunction = null;
        }

        /// <summary>
        /// Sets a function that calculates the priority of the rule.
        /// This function can be used to dynamically update the priority.
        /// </summary>
        /// <param name="priorityFunction">The function to calculate the priority.</param>
        public void SetPriorityFunction(Func<int> priorityFunction)
        {
            _priorityFunction = priorityFunction;
        }
    }
}