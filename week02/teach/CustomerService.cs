using System;
using System.Collections.Generic;

/// <summary>
/// Manages a Customer Service Queue using FIFO (First-In, First-Out) logic.
/// Supports adding new customers and servicing them based on a fixed capacity.
/// </summary>
public class CustomerService {
    
    /// <summary>
    /// Entry point for running test cases to validate requirements.
    /// </summary>
    public static void Run() {
        // Test 1: Default size validation
        // Scenario: Create a queue with an invalid size (0) and verify it defaults to 10.
        Console.WriteLine("Test 1: Invalid Size Assignment");
        var service0 = new CustomerService(0);
        Console.WriteLine(service0); // Should show max_size=10
        Console.WriteLine("=================");

        // Test 2: Queue overflow validation
        // Scenario: Create a queue of size 1 and try to add 2 customers.
        Console.WriteLine("Test 2: Adding to Full Queue");
        var service1 = new CustomerService(1);
        service1.AddNewCustomer(); // Add 1st
        service1.AddNewCustomer(); // Should show error: "Maximum Number of Customers in Queue."
        Console.WriteLine("=================");

        // Test 3: Service empty queue validation
        // Scenario: Try to serve a customer when the queue is empty.
        Console.WriteLine("Test 3: Serving Empty Queue");
        var serviceEmpty = new CustomerService(5);
        serviceEmpty.ServeCustomer(); // Should show error: "The queue is empty."
        Console.WriteLine("=================");
        // Test 4: Enforce max size
        Console.WriteLine("Test 4: Enforcement of Max Size");
        var service4 = new CustomerService(2);
        service4.AddNewCustomer(); // Client 1
        service4.AddNewCustomer(); // Client 2
        service4.AddNewCustomer(); // Should show: "Maximum Number of Customers in Queue."
        Console.WriteLine("=================");
        
        // Test 5: Check default size
        Console.WriteLine("Test 5: Defaulting to 10");
        var service5 = new CustomerService(-5);
        Console.WriteLine(service5); // Should show Max size=10
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    /// <summary>
    /// Initializes a new instance of the CustomerService class.
    /// </summary>
    /// <param name="maxSize">The limit for the queue. Defaults to 10 if invalid.</param>
    public CustomerService(int maxSize) {
        // Requirement: If size is invalid (<= 0), default to 10.
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Represents a customer within the service system.
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId}) : {Problem}";
        }
    }

    /// <summary>
    /// Prompts user for details and adds a customer if space is available.
    /// </summary>
    public void AddNewCustomer() {
        // FIXED: Use >= to prevent exceeding the max size
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Problem: ");
        var problem = Console.ReadLine()?.Trim() ?? "";

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Services the next customer in the queue (FIFO).
    /// </summary>
    public void ServeCustomer() {
        // FIXED: Check if the queue is empty before processing
        if (_queue.Count == 0) {
            Console.WriteLine("Error: The queue is empty. No customers to serve.");
            return;
        }

        // FIXED: Get the customer record BEFORE removing it from the list
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine($"Now serving: {customer}");
    }

    public override string ToString() {
        return $"[Current size={_queue.Count} / Max size={_maxSize}] Contents: " + string.Join(", ", _queue);
    }
}