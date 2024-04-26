public class SimpleQueue {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display 100
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: It was trying to dequeue data from index 1 and not index 0

        Console.WriteLine("------------");

        // Test 2
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: Insert method was used with index 0 in Enqueue() but Add is necessary to add things to the end of the array

        Console.WriteLine("------------");

        // Test 3
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found: No errors found, this is working properly.
    }

    private readonly List<int> _queue = new();

    /// <summary>
    /// Enqueue the value provided into the queue
    /// </summary>
    /// <param name="value">Integer value to add to the queue</param>
    private void Enqueue(int value) {
        _queue.Add(value); // I changed Insert(0, value) to Add(value).
    }

    /// <summary>
    /// Dequeue the next value and return it
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">If queue is empty</exception>
    /// <returns>First integer in the queue</returns>
    private int Dequeue() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();

        var value = _queue[0]; // I changed 1 to 0 here.
        _queue.RemoveAt(0); // I changed 1 to 0 here.
        return value;
    }
}