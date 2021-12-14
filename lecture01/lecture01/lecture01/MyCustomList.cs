using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lecture01
{
    public class MyCustomList<T> : IEnumerable<T>
    {
        private T[] _items;
        public int counter { get; private set; }
        public int capacity
        {
            get
            {
                return _items.Length;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyCustomEnumerator<T>(_items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if(_items.Length == counter)
            {
                T[] newArray = new T[counter * 2];
                Array.Copy(_items, newArray, counter);
                _items = newArray;
            }
            _items[counter++] = item;
        }

        public void AddRange(T[] items)
        {
            if (_items.Length <= counter + items.Length)
            {
                T[] newArray = new T[(counter + items.Length)*2];
                Array.Copy(_items, newArray, counter + items.Length);
                _items = newArray;
            }
            int count = 0;
            if (count < items.Length)
            {
                _items[counter++] = items[count++];
            }
        }

        public void Remove(T item)
        {
            if(counter == 0)
            {
                throw new InvalidOperationException();
            }
            _items[--counter] = default(T);
        }

        public void RemoveAt(int itemIndex)
        {
            // your implementation here
            throw new NotImplementedException();
        }

        public void Sort()
        {
            // your implementation here
            throw new NotImplementedException();
        }
        internal class MyCustomEnumerator<T> : IEnumerator<T>
        {
            private readonly T[] array;
            private int position = -1;
            public MyCustomEnumerator(T[] array)
            {
                this.array = array;
            }
            public T Current
            {
                get
                {
                    return array[position];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                position++;
                return position < array.Length;
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}