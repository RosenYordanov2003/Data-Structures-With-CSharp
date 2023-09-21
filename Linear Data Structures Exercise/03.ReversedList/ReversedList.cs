namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (CheckForInvalidIndex(index))
                {
                    return this.items[this.Count - 1 - index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (this.CheckForInvalidIndex(index))
                {
                    this.items[this.Count - 1 - index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.items.Length == this.Count)
            {
                Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (!CheckForInvalidIndex(index))
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (this.items.Length == this.Count)
                {
                    Resize();
                }
                int newIndex = this.Count - index;
                ShiftLeft(newIndex);
                this.items[newIndex] = item;

                this.Count++;
            }
        }

        public bool Remove(T item)
        {
            if (this.IndexOf(item) == -1)
            {
                return false;
            }
            this.RemoveAt(this.IndexOf(item));
            return true;
        }

        public void RemoveAt(int index)
        {
            if (!CheckForInvalidIndex(index))
            {
                throw new IndexOutOfRangeException();
            }
            index = this.Count - 1 - index;
            ShiftRight(index);
            this.items[this.Count - 1] = default(T);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[this.Count - i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Resize()
        {
            T[] newArray = new T[this.items.Length * 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
        }
        private bool CheckForInvalidIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return true;
            }
            return false;
        }
        private void ShiftLeft(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
    }
}