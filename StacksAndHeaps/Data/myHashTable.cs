using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Data
{
    public class myHashTable<T> where T : IComparable
    {
        private T[] internalArray = new T[1];

        //The Open Addressing version
        public void AddOA(T value)
        {
            int hashCode = value.GetHashCode();
            // first check if we can place value
            //keep adding +1 to index until we can
            //unless we reach the end of the array, then we go on to extent it.
            while (internalArray.Length > hashCode && internalArray[hashCode] != null)
            {
                hashCode++;
            }
            //if the array isn't long enough, make it long enough.
            if (internalArray.Length <= hashCode)
            {
                T[] newArray = new T[hashCode+1];
                for (int i = 0; i < internalArray.Length; i++)
                {
                    newArray[i] = internalArray[i];
                }
                internalArray = newArray;
            }
            internalArray[hashCode] = value;
        }

        public T GetAtOA(int index)
        {
            return internalArray[index];
        }
        public T GetOA(T value)
        {
            int hashCode = value.GetHashCode();

            //while the T value at the index isn't the same as the sought value, increase.
            while (internalArray[hashCode].CompareTo(value) != 0)
            {
                hashCode++;
            }
            
            return internalArray[hashCode];
        }

        public int GetArraySize()
        {
            return internalArray.Length;
        }

        public void RemoveOA(T value)
        {
            int hashCode = value.GetHashCode();

            //while the T value at the index isn't the same as the sought value, increase.
            while (internalArray[hashCode].CompareTo(value) != 0 &&
                internalArray.Length > hashCode)
            {
                hashCode++;
            }
            if (internalArray[hashCode].CompareTo(value) != 0)
                Console.WriteLine("Value not found in hashtable.");
        }
    }
}
