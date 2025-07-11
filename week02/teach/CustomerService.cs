/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: attempt to serve a customer from an empty queue
        // Expected Result: An error message will be displayed indicating that the queue is empty 

        Console.WriteLine("Test 1");
        CustomerService customerService1 = new CustomerService(3);
        customerService1.ServeCustomer();

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The customers are added following the established limit for the queue
        // Expected Result: The console output will show that the customers were served in the exact order they were added.
        Console.WriteLine("Test 2");
        CustomerService customerService2 = new CustomerService(3);
        Customer customer1 = new Customer("Customer1", "1", "Return of product");
        Customer customer2 = new Customer("Customer2", "2", "Delay in Delivery");
        Customer customer3 = new Customer("Customer3", "3", "Payment questions");
        customerService2.AddCustomer(customer1);
        customerService2.AddCustomer(customer2);
        customerService2.AddCustomer(customer3);
        customerService2.ServeCustomer();
        customerService2.ServeCustomer();
        customerService2.ServeCustomer();

        customerService2.ToString();

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Adding new customers when the queue reaches its maximum size 
        // Expected Result: An error message will be displayed indicating that the queue is full.
        Console.WriteLine("Test 3");
        CustomerService customerService3 = new CustomerService(2);
        Customer customer4 = new Customer("Customer4", "4", "Return of product");
        Customer customer5 = new Customer("Customer5", "5", "Delay in Delivery");
        Customer customer6 = new Customer("Customer6", "6", "Payment questions");
        customerService3.AddCustomer(customer4);
        customerService3.AddCustomer(customer5);
        customerService3.AddCustomer(customer6);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Adding a new customer to a queue that was full, but now has space after a customer has been served 
        // Expected Result: Customer will be added successfully without any error message..
        Console.WriteLine("Test 4");
        CustomerService customerService4 = new CustomerService(2);
        Customer customer7 = new Customer("Customer7", "7", "Return of product");
        Customer customer8 = new Customer("Customer8", "8", "Delay in Delivery");
        Customer customer9 = new Customer("Customer9", "9", "Payment questions");
        customerService2.AddCustomer(customer7);
        customerService2.AddCustomer(customer8);
        customerService2.ServeCustomer();
        customerService2.AddCustomer(customer9);

        customerService4.ToString();

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Queue defaults to size 10 when an invalid size (0 or negative) is provided on creation 
        // Expected Result: A error message will be displayed in the attempting to add the 11th curstomer after adding 10 costumers successfull.
        Console.WriteLine("Test 5");
        CustomerService customerService5 = new CustomerService(-1);
        Customer customer10 = new Customer("Customer10", "10", "Return of product");
        Customer customer11 = new Customer("Customer11", "11", "Delay in Delivery");
        Customer customer12 = new Customer("Customer12", "12", "Payment questions");
        Customer customer13 = new Customer("Customer13", "10", "Return of product");
        Customer customer14 = new Customer("Customer14", "11", "Delay in Delivery");
        Customer customer15 = new Customer("Customer15", "12", "Payment questions");
        Customer customer16 = new Customer("Customer16", "10", "Return of product");
        Customer customer17 = new Customer("Customer17", "11", "Delay in Delivery");
        Customer customer18 = new Customer("Customer18", "12", "Payment questions");
        Customer customer19 = new Customer("Customer19", "10", "Return of product");
        Customer customer20 = new Customer("Customer20", "10", "Return of product");
        customerService5.AddCustomer(customer10);
        customerService5.AddCustomer(customer11);
        customerService5.AddCustomer(customer12);
        customerService5.AddCustomer(customer13);
        customerService5.AddCustomer(customer14);
        customerService5.AddCustomer(customer15);
        customerService5.AddCustomer(customer16);
        customerService5.AddCustomer(customer17);
        customerService5.AddCustomer(customer18);
        customerService5.AddCustomer(customer19);
        customerService5.AddCustomer(customer20);

        Console.WriteLine("=================");
    }

    private readonly Queue<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    public class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    public void AddCustomer(Customer customer)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
        _queue.Enqueue(customer);
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Enqueue(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count > 0)
        {
            var customer = _queue.Dequeue();
            Console.WriteLine(customer);
        }
        else
        {
            Console.WriteLine("There isn´t customer in queue");
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}