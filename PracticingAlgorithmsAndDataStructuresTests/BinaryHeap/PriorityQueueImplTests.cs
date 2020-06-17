using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PracticingAlgorithmsAndDataStructures.BinaryHeap.Tests
{
    [TestClass()]
    public class PriorityQueueImplTests
    {
        [TestMethod()]
        public void PollTest_IntegersAsInput()
        {
            PriorityQueueImpl<int> queue = new PriorityQueueImpl<int>();

            queue.Add(7);
            queue.Add(12);
            queue.Add(6);
            queue.Add(15);
            queue.Add(17);
            queue.Add(10);

            Assert.AreEqual(17, queue.Poll());

            Assert.AreEqual(15, queue.Poll());

            Assert.AreEqual(12, queue.Poll());

            Assert.AreEqual(10, queue.Poll());

            Assert.AreEqual(7, queue.Poll());

            Assert.AreEqual(6, queue.Poll());
        }

        [TestMethod()]
        public void PollTest_CharsAndFrequencyAsInput()
        {
            Dictionary<char, int> charsAndWeights = new Dictionary<char, int>
            {
                { 'a', 10 },
                { 'b', 30 },
                { 'c', 50 },
                { 'd', 40 },
                { 'e', 45 },
                { 'f', 20 }
            };

            PriorityQueueImpl<char> queue = new PriorityQueueImpl<char>(Comparer<char>.Create((char1, char2) => charsAndWeights[char1] - charsAndWeights[char2]));
            
            queue.Add('a');
            queue.Add('b');
            queue.Add('c');
            queue.Add('d');
            queue.Add('e');
            queue.Add('f');

            Assert.AreEqual('c', queue.Poll());

            Assert.AreEqual('e', queue.Poll());

            Assert.AreEqual('d', queue.Poll());

            Assert.AreEqual('b', queue.Poll());

            Assert.AreEqual('f', queue.Poll());

            Assert.AreEqual('a', queue.Poll());
        }
    }
}