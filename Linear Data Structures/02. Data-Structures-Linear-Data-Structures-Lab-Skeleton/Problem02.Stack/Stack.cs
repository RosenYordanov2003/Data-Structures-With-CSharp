namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
        }
        //Becomes the first element(The element who is on the top of the stack)
        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node node = new Node(item, top);
            this.top = node;
            this.Count++;
        }

        public T Pop()
        {
            CheckIfStackIsEmpty();
            T elementToReturn = this.top.Element;
            //Remove refe rence from current top Node and set top Node to the next Node in the stack
            this.top = this.top.Next;
            this.Count--;
            return elementToReturn;
        }

        public T Peek()
        {
            CheckIfStackIsEmpty();
            return this.top.Element;
        }

        public bool Contains(T item)
        {
            Node currentNode = this.top;
            while (currentNode != null)
            {
                if (item.Equals(currentNode.Element))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.top;
            while (currentNode != null)
            {
                yield return currentNode.Element;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void CheckIfStackIsEmpty()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}