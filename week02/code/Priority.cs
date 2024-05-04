public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: The Enqueue function shall add an item (which contains both data and priority) 
        // Expected Result: It will be stored to the back of the queue.
        Console.WriteLine("Test 1");

        priorityQueue.Enqueue("John", 5);
        Console.WriteLine(priorityQueue);
        priorityQueue.Enqueue("Mark", 1);
        Console.WriteLine(priorityQueue);
        priorityQueue.Enqueue("Lucas", 3);
        Console.WriteLine(priorityQueue);

        // Defect(s) Found: None, it is stored at the back of the queue.

        Console.WriteLine("---------");

        // Test 2
        // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
        // Expected Result: Should return the value of the highest priority.
        Console.WriteLine("Test 2");


        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 8);
        priorityQueue.Enqueue("Mark", 3);
        priorityQueue.Enqueue("Lucas", 9);
        Console.WriteLine(priorityQueue);

        var value = priorityQueue.Dequeue();
        Console.WriteLine(value);
        value = priorityQueue.Dequeue();
        Console.WriteLine(value);

        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 3);
        priorityQueue.Enqueue("Mark", 8);
        priorityQueue.Enqueue("Lucas", 9);
        Console.WriteLine(priorityQueue);

        value = priorityQueue.Dequeue();
        Console.WriteLine(value);
        value = priorityQueue.Dequeue();
        Console.WriteLine(value);

        // Defect(s) Found: It is returning the first value, if there is no other with higher priority 
        // but, if the last one has a higher priority number is going to ignore it, and choose
        // any other one, if the first one is not the higher one.
        // Also is not Dequeue is not removing any value from the Queue.

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Dequeue more than one item with the same highest priority.
        // Expected Result: The item closest to the front of the queue will be removed and its value returned.
        Console.WriteLine("Test 3");

        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("John", 2);
        priorityQueue.Enqueue("Mark", 5);
        priorityQueue.Enqueue("Lucas", 3);
        priorityQueue.Enqueue("Meg", 5);
        priorityQueue.Enqueue("Daniel", 1);
        priorityQueue.Enqueue("Josh", 5);
        Console.WriteLine(priorityQueue);

        value = priorityQueue.Dequeue();
        Console.WriteLine(value);
        value = priorityQueue.Dequeue();
        Console.WriteLine(value);
        value = priorityQueue.Dequeue();
        Console.WriteLine(value);
        value = priorityQueue.Dequeue();
        Console.WriteLine(value);

        // Defect(s) Found: Between two values with the same higher priority is returning 
        // the value closest to the end, if is not the last value. Also is not removing any value.

        Console.WriteLine("---------");

        // Test 4
        // Scenario: The queue is empty and we are tryng to dequeue.
        // Expected Result: An error message should be displayed.
        Console.WriteLine("Test 4");

        priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();

        // Defect(s) Found: None. It works, an error message was displayed.

        // Add more Test Cases As Needed Below
    }
}