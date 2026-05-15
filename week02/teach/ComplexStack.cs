using System;
using System.Collections.Generic;

namespace StackCheckApp
{
    /// <summary>
    /// Entry point for the application to demonstrate stack-based string validation.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Delimiter Balance Test Results ---");

            // Test Case 1: Balanced expression
            // Expected: True
            bool test1 = ComplexStack.DoSomethingComplicated("(a == 3 or (b == 5 and c == 6))");
            Console.WriteLine($"Test 1 (Balanced): {test1}");

            // Test Case 2: Mismatched closing bracket
            // Expected: False
            bool test2 = ComplexStack.DoSomethingComplicated("(students]i].Grade > 80 and students[i].Grade < 90)");
            Console.WriteLine($"Test 2 (Mismatched): {test2}");

            // Test Case 3: Missing final closing parenthesis
            // Expected: False
            bool test3 = ComplexStack.DoSomethingComplicated("(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))");
            Console.WriteLine($"Test 3 (Incomplete): {test3}");
        }
    }

    /// <summary>
    /// Provides utility methods for managing complex data structures using Stacks.
    /// </summary>
    public static class ComplexStack 
    {
        /// <summary>
        /// Validates whether a string has correctly balanced delimiters: (), [], and {}.
        /// </summary>
        /// <param name="line">The text string to analyze for symbol balance.</param>
        /// <returns>
        /// True if every opening symbol is matched by a corresponding closing symbol 
        /// in the correct order; otherwise, false.
        /// </returns>
        public static bool DoSomethingComplicated(string line) 
        {
            // We use a Stack because it follows LIFO (Last-In, First-Out), 
            // which is perfect for matching the nested nature of brackets.
            var stack = new Stack<char>();

            foreach (var item in line) 
            {
                // Check for opening symbols and store them
                if (item is '(' or '[' or '{') 
                {
                    stack.Push(item);
                }
                // Check for closing symbols and validate against the last opener
                else if (item is ')') 
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                        return false;
                }
                else if (item is ']') 
                {
                    if (stack.Count == 0 || stack.Pop() != '[')
                        return false;
                }
                else if (item is '}') 
                {
                    if (stack.Count == 0 || stack.Pop() != '{')
                        return false;
                }
            }

            // If the stack count is 0, every opening symbol was matched and removed.
            return stack.Count == 0;
        }
    }
}