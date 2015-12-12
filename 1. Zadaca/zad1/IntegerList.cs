using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
   public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int n;
        private int size;

        public IntegerList()
        {
            _internalStorage = new int[4];
            size = 4;
            n = 0;
        }

        public IntegerList(int initialSize)
        {
            size = initialSize;
            n = 0;
            _internalStorage = new int[initialSize];
        }

        public int Count
        {
            get
            {
                return n;
            }
        }

        public void Add(int item)
        {
            if (size == n)
            {
                int[] tmp = new int[2 * size];
                for(int i=0; i< n; i++)
                {
                    tmp[i] = _internalStorage[i];
                }
                _internalStorage = tmp;
                size *= 2;
            }
            _internalStorage[n] = item;
            n++;
        }

        public void Clear()
        {
            _internalStorage = new int[size];
            n = 0;
        }

        public bool Contains(int item)
        {
            for(int i=0; i< n; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index > n)
            {
                throw new IndexOutOfRangeException("index je veci od velicine polja");
            }

            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
           for(int i=0; i< n; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            Console.WriteLine("element nije u kolekciji");
            return -1;
        }

        public bool Remove(int item)
        {
           for(int i=0; i< n; i++)
            {
                if (_internalStorage[i] == item)
                {
                    n--;
                    for(int j= i; j<size-1; j++)
                    {
                        _internalStorage[j] = _internalStorage[j + 1];
                    }
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index > n)
            {
                Console.WriteLine("index je veći od broja elemenata");
                return false;
            }
            for(int i= index; i< size-1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            n--;
            return true;  
        }
    }
}
