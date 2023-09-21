namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] items;
        public CircularQueue()
        {
            items = new T[4];
        }
        public int Count { get; private set; }

        public T Dequeue()
        {
            CheckForEmptyQueue();
            T elementToReturn = items[0];
            this.items[0] = default(T);
            Shift();
            this.Count--;

            return elementToReturn;
        }

        public void Enqueue(T item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }
            this.items[Count++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        public T Peek()
        {
            CheckForEmptyQueue();
            return this.items[0];
        }

        public T[] ToArray()
        {
            T[] arrayToReturn = new T[this.Count];
            Array.Copy(this.items, arrayToReturn, this.Count);

            return arrayToReturn;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Resize()
        {
            T[] newArray = new T[this.items.Length * 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
        }
        private void CheckForEmptyQueue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
        private void Shift()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = default(T);
        }
    }

}
