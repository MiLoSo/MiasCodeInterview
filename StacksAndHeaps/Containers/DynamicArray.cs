using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Containers
{
    public class DynamicArray<T> where T : IComparable
    {
        private T[] internalArray;
        private int n = 0;
        //start size 1
        //if array is full, double size and move the old to there

        public void Add(T value)
        {
            if (internalArray == null)
            {
                internalArray = new T[1] { value };
                n++;
                return;
            }
            //if we have reached the end of the array, double it.
            if (internalArray.Length == n)
            {
                T[] newArray = new T[Size() * 2];
                for (int i = 0; i < internalArray.Length; i++)
                {
                    //put the old elements in the new, doubled array.
                    newArray[i] = internalArray[i];
                }
                //the old array is now the new doubled array.
                internalArray = newArray;
            }
            //now add the new element:
            internalArray[n] = value;
            n++;

        }

        public void Remove(T value)
        {
            // Hvis der er 2 af den samme, bare fjern den foerste
            T[] newArray = new T[internalArray.Length];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                //if the value and the value at i is the same, decrease size score and continue to next,
                //without adding the current value.
                if (internalArray[i].CompareTo(value) == 0)
                {
                    n--;
                    continue;
                }
                newArray[index] = internalArray[i];
                index++;
            }
            internalArray = newArray;
        }

        public T Get(int index)
        {
            if (index > n - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range of the dynamic array: index was " + index + " and the size is " + n + ".");
            }

            return internalArray[index];
        }

        public int Size()
        {
            if (internalArray == null)
                return 0;
            else
                return n;
        }
    }
}
