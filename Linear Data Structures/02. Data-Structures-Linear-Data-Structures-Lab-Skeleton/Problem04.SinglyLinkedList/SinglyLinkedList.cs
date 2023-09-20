namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            Node newNode = new Node(item, this.head);
            this.head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item, null);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node currentNode = this.head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
            this.Count++;
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

        public T GetFirst()
        {
            CheckIfHeadIsNull();
            return this.head.Element;
        }

        public T GetLast()
        {
            CheckIfHeadIsNull();
            Node currentNode = this.head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Element;
        }

        public T RemoveFirst()
        {
            CheckIfHeadIsNull();
            T elementToReturn = this.head.Element;
            this.head = this.head.Next;
            this.Count--;
            return elementToReturn;
        }

        public T RemoveLast()
        {
            CheckIfHeadIsNull();
            Node currentNode = this.head;
            T elementToReturn;
            if (this.Count == 1)
            {
                elementToReturn = this.head.Element;
                this.head = null;
            }
            else
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                elementToReturn = currentNode.Next.Element;
                currentNode.Next = null;
            }
            this.Count--;
            return elementToReturn;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckIfHeadIsNull()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}