namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public T Element { get; set; }
            public Node Next { get; set; }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Node node = new Node(item, null);
            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                Node currentNode = this.head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = node;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            CheckQueueIsEmpty();
            T itemToReturn = this.head.Element;
            this.head = this.head.Next;
            this.Count--;
            return itemToReturn;
        }

        public T Peek()
        {
            CheckQueueIsEmpty();
            return this.head.Element;
        }

        public bool Contains(T item)
        {
            Node currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Element.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Element;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        private void CheckQueueIsEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}