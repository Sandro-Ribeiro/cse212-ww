using System.Runtime.Serialization.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The function will create a queue with the follwing values and prioritys: Diogo(2) Sandro(5) Maria Cecília(1) Isis(4) Ana Clara(3) 
    // Expected Result: [Diogo (Pri:2), Sandro (Pri:5), Maria Cecilia (Pri:1), Isis (Pri:4), Ana Clara (Pri:3)]
    // Defect(s) Found: Assert.Fail failded. Implement the test case and then remove this. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue1 = new PriorityQueue();
        priorityQueue1.Enqueue("Diogo", 2);
        priorityQueue1.Enqueue("Sandro", 5);
        priorityQueue1.Enqueue("Maria Cecilia", 1);
        priorityQueue1.Enqueue("Isis", 4);
        priorityQueue1.Enqueue("Ana Clara", 3);

        var expectedResult1 = "[Diogo (Pri:2), Sandro (Pri:5), Maria Cecilia (Pri:1), Isis (Pri:4), Ana Clara (Pri:3)]";

        Assert.AreEqual(5, priorityQueue1.Lenght);
        Assert.AreEqual(expectedResult1, priorityQueue1.ToString());
    }

    [TestMethod]
    // Scenario: The function will remove the itens with the highest priority and return its value in order
    // Expected Result: Sandro, Isis, Ana Clara, Diogo, Maria Cecilia
    // Defect(s) Found: Assert.Fail failed. Implement the test case and then remove this. 
    public void TestPriorityQueue_2()
    {
        var priorityQueue2 = new PriorityQueue();

        priorityQueue2.Enqueue("Diogo", 2);
        priorityQueue2.Enqueue("Sandro", 5);
        priorityQueue2.Enqueue("Maria Cecilia", 1);
        priorityQueue2.Enqueue("Isis", 4);
        priorityQueue2.Enqueue("Ana Clara", 3);

        string[] expectedResult2 = ["Sandro", "Isis", "Ana Clara", "Diogo", "Maria Cecilia"];

        for (int i = 0; i < expectedResult2.Length; i++)
        {
            string name = priorityQueue2.Dequeue();
            Assert.AreEqual(expectedResult2[i], name);
        }
    }

    [TestMethod]
    // Scenario:  If there is more than one item with the highest priority, 
    // then the function will rmove the item closest to the front of the queue
    // and its value returned.
    // Expected Result: Sandro, Isis, Ana Clara, Diogo, Maria Cecilia
    // Defect(s) Found: Assert.Fail failed. Implement the test case and then remove this. 
    public void TestPriorityQueue_3()
    {
        var priorityQueue4 = new PriorityQueue();

        priorityQueue4.Enqueue("Diogo", 2);
        priorityQueue4.Enqueue("Sandro", 5);
        priorityQueue4.Enqueue("Maria Cecilia", 4);
        priorityQueue4.Enqueue("Isis", 4);
        priorityQueue4.Enqueue("Ana Clara", 3);

        string[] expectedResult3 = ["Sandro", "Maria Cecilia", "Isis", "Ana Clara", "Diogo"];

        for (int i = 0; i < expectedResult3.Length; i++)
        {
            string name = priorityQueue4.Dequeue();
            Assert.AreEqual(expectedResult3[i], name);
        }
    }

    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be throw
    // Expected Result: The queue is empty.
    // Defect(s) Found: Assert.Fail failed. Implement the test case and then remove this. 
    public void TestPriorityQueue_4()
    {
        var priorityQueue4 = new PriorityQueue();

        try
        {
            priorityQueue4.Dequeue();
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}