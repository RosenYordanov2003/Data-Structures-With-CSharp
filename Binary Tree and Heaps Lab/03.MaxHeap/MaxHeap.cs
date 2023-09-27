namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;
        private const int IndexOfBiggerElement = 0;
        public MaxHeap()
        {
            elements = new List<T>();
        }
        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            HeapifyUp(this.Size - 1);
        }

        public T ExtractMax()
        {
            CheckForEmptyCollection();
            T element = this.elements[IndexOfBiggerElement];
            this.Swap(IndexOfBiggerElement, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);

            HeapifyDown(IndexOfBiggerElement);
            return element;
        }

        public T Peek()
        {
            CheckForEmptyCollection();

            return this.elements.First();
        }
        private void CheckForEmptyCollection()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && IsGreater(index, parentIndex))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
        private void HeapifyDown(int index)
        {
            int biggherChildIndex = GetBiggherChildIndex(index);
            while (ValidateIndex(biggherChildIndex) && IsGreater(biggherChildIndex, index))
            {
                Swap(biggherChildIndex, index);
                index = biggherChildIndex;
                biggherChildIndex = GetBiggherChildIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            T temElement = this.elements[index];

            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temElement;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }
        private int GetBiggherChildIndex(int index)
        {
            int firstChildIndex = (index * 2) + 1;
            int secondChildIndex = (index * 2) + 2;

            if (secondChildIndex < this.Size)
            {
                if (this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) > 0)
                {
                    return firstChildIndex;
                }
                return secondChildIndex;
            }
            else if (firstChildIndex < this.Size)
            {
                return firstChildIndex;
            }
            else
            {
                return - 1;
            }
        }
        private bool ValidateIndex(int index)
        {
            return index >= 0 && index < this.Size;
        }
    }
}
