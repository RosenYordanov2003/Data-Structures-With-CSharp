namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (CheckForResise())
            {
                Resize();
            }
            this.items[Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            if (CheckForResise())
            {
                Resize();
            }
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[Count - 1] = default(T);
            this.Count--;
            if (CheckForShrink())
            {
                Shrink();
            }

        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private bool CheckForResise()
        {
            return this.items.Length == this.Count;
        }
        private void Resize()
        {
            T[] arrayCopy = new T[this.items.Length * 2];
            Array.Copy(this.items, arrayCopy, this.Count);
            this.items = arrayCopy;
        }
        private bool CheckForShrink()
        {
            return this.items.Length >= this.Count * 2;
        }
        private void Shrink()
        {
            T[] arrayShrinked = new T[this.items.Length / 2];
            Array.Copy(this.items, arrayShrinked, this.Count);
            this.items = arrayShrinked;
        }
    }
}