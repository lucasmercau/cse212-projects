/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The user specify an invalid size of the Customer Service Queue of less than or equal to 0
        // Expected Result: The size shall default to 10 if is less than or equal to 0.
        Console.WriteLine("Test 1");

        var costumerServiceQueue = new CustomerService(-2);
        Console.WriteLine(costumerServiceQueue._maxSize == 10 ? "Works! Invalid size less than 0, default to 10" : "ERROR: Invalid Queue Size");
        costumerServiceQueue = new CustomerService(0);
        Console.WriteLine(costumerServiceQueue._maxSize == 10 ? "Works! Invalid size equal to 0, default to 10" : "ERROR: Invalid Queue Size");

        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: AddNewCustomer method shall enqueue a new customer into the queue
        // Expected Result: If the queue is full when trying to add a customer, then an error message will be displayed.
        Console.WriteLine("Test 2");

        int sizeOfQueue = 2;
        costumerServiceQueue = new CustomerService(sizeOfQueue);
        for (int i = 0; i <= sizeOfQueue; i++) {
            costumerServiceQueue.AddNewCustomer();
        }
        

        // Defect(s) Found: An error message is displayed but after enqueue 1 extra customer. 
        // To fix this in AddNewCustomer we fix the part that verify if there is room in the 
        // service queue by changing "if (_queue.Count > _maxSize)" to "if (_queue.Count >= _maxSize)"

        Console.WriteLine("=================");

        // Test 3
        // Scenario: ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: If the queue is empty when trying to serve a customer, then an error message will be displayed.
        Console.WriteLine("Test 3");

        for (int i = 0; i <= sizeOfQueue; i++) {
            costumerServiceQueue.ServeCustomer();
        }

        // Defect(s) Found: There is an Index error when trying to display the customer that was served, 
        // so we move the variable var customer before _queue.RemoveAt(0); and that fixed that problem.
        // Other problem was when the Queue was empty and we tried to serve a Customer, an error message was not displayed,
        // to fix this we used try and catch and when there was no Customer to be removed we displayed an error message.

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
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

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
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
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        try {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        } catch {
            Console.WriteLine("There are no Customers in Queue.");
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
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}