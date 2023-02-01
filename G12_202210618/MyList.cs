using System;
using System.Collections;

namespace G12_202210618
{
    internal class MyList : IList, IEnumerable
    {
        private object[] _data;
        private int _counnt;

        public MyList() : this(2) 
        {

        }

        public MyList(int capasity)
        {
            _data = new object[capasity];
            _counnt = 0;
        }

        public int Add(object value1)
        {
            AddValue(value1);

            return 1;
        }

        public object Get(int index)
        {
            return _data[index];
        }

        public void Insert(int index, object value)
        {
            InsertValue(index, value);
            
        }

        public void Remove(object value)
        {
            int index=0;
            DeleteValue(value, index);
        }

        public void RemoveAt(int index)
        {
            object value=null;
            DeleteValue(value, index);
        }

        public void Clear()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                RemoveAt(i - 1);
            }
        }

        public bool Contains(object value)
        {
            if (Find(value) != -1)
                return true;

           return false;
        }

        public int IndexOf(object value)
        {
           return Find(value);
        }

        public int IndexOf(object value, int startIndex)
        {
            return Find(value, startIndex);
        }

        public int Count
        {
            get
            {
              return  _counnt;
            }
        }

        public int Capacity
        {
            get
            {
                return _data.Length;
            }
        }
        public object this[int index] { get => _data[index]; set => _data[index] = value; }
        public void AddValue( object value)
        {
            if (_counnt == _data.Length )
                Resize(ref _data, _data.Length * 2);

           _data[_counnt] = value;
           _counnt++;
           TrimToSize();
        }

        public void InsertValue(int index, object value)
        {
            if (_counnt == _data.Length)
                Resize(ref _data, _data.Length + 1);

            object[] array = new object[_counnt + 1];

            for (int i = 0; i < array.Length-1; i++)
            {
                if(i<index)
                    array[i] = _data[i];

                if(i>=index)
                    array[i + 1] = _data[i];
            }


            array[index] = value;

            _data = array;

            _counnt++;

        }

        public int Resize(ref object[] newArray, int size)
        {
            object[] array = new object[size];

            if (newArray.Length < size)
                size = newArray.Length;

            for (int i = 0; i < size; i++)
            {
               array[i] = newArray[i];
            }
    
            newArray = array;
           
            return 1;
        }

        public void TrimToSize()
        {
            Resize( ref _data, _counnt);
        }


        public void DeleteValue(object value, int index)
        {
            if(index==0)
                index=Find(value);

            if(index==-1)
                return;

            for (int i = index; i < _data.Length - 2; i++)
            {
                if (i >= index)
                    _data[i] = _data[i + 1];
            }
            _counnt--;
            TrimToSize();
        }

        public int Find(object value, int index = 0)
        {
            for (int i = index; i < _data.Length; i++)
            {
                if (_data[i].ToString() == value.ToString())
                    return i;
            }

            return -1;
        }

       
        //___________________________________________________

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
           
            MyEnumerator myEnumerator = new MyEnumerator(_data);

            return myEnumerator;
        }

        #region Not used
        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();
        #endregion 

    }

    class MyEnumerator : IEnumerator
    {
        private int _index;
        private object[] _items;

        public MyEnumerator(object[] items)
        {
            _index = -1;
            _items = items;
        }

        public object Current => _items[_index];
        
        public bool MoveNext()
        {
            if( _index < _items.Length - 1 )
            {
                _index++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _index=-1;
        }
    }
}
