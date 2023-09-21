namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
            }
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Element { get; set; }
        }

        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item);
            if (this.Count == 0)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                node.Next = this.head;
                this.head.Previous = node;
                this.head = node;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node node = new Node(item);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                node.Previous = this.tail;
                this.tail.Next = node;
                this.tail = node;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            CheckForEmptyDoublyLinkedList();
            return this.head.Element;
        }

        public T GetLast()
        {
            CheckForEmptyDoublyLinkedList();
            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            CheckForEmptyDoublyLinkedList();
            T elementToReturn = this.head.Element;
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }
            this.Count--;
            return elementToReturn;
        }

        public T RemoveLast()
        {
            CheckForEmptyDoublyLinkedList();
            T elementToReturn = this.tail.Element;
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }
            this.Count--;
            return elementToReturn;
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

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void CheckForEmptyDoublyLinkedList()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

    }
}