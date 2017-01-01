using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Data
{
    public class myHashTable<T, U> where T : IComparable
    {
        private HashNode<T, U>[] internalArray = new HashNode<T, U>[1];
        private int count = 0;
        private double maxLoad = 0.7;

        // TODO: Overskriv hvis den given key allerede eksisterer
        // HINT: Brug Get
        public void Add(T key, U value)
        {
            if (count / internalArray.Length > maxLoad)
            {
                expandArray();
            }
            add(key, value, internalArray);
            count++;
        }

        private void expandArray()
        {
            var a = new HashNode<T, U>[internalArray.Length*2];
            for (int i = 0; i < internalArray.Length; i++)
            {
                if (internalArray[i] != null)
                {
                    add(internalArray[i].key, internalArray[i].value, a);
                }
            }
            internalArray = a;
        }

        private void add(T key, U value, HashNode<T, U>[] array)
        {
            int hashCode = Math.Abs(key.GetHashCode());
            int index = hashCode % internalArray.Length;

            while (true)
            {
               
                if (array[index] == null)
                {
                    array[index] = new HashNode<T, U>()
                    {
                        key = key,
                        value = value
                    };
                    return;
                }
                //no need for logic for checking if array is full,
                //because we have a guarantee that it never is (maxload 0.7)
                index++;
                if (index == array.Length)
                {
                    index = 0;
                }
            }
        }

        public U Get(T key)
        {
            int hashCode = Math.Abs(key.GetHashCode());
            int startIndex = hashCode % internalArray.Length;
            int index = startIndex;

            while (true)
            {
                //if index is within the limits of the array, and we have found the key...
                if (index < internalArray.Length && internalArray[index] != null &&
                    key.CompareTo(internalArray[index].key) == 0)
                    return internalArray[index].value;
                //if we have reached end of array, go to beginning and continue
                if (index == internalArray.Count() - 1)
                {
                    index = 0;
                    continue;
                }
                //keys were compared above, so if they weren't identical,
                //the key doesn't exist in the array...
                if (index == startIndex - 1)
                {
                    return default(U);
                }
                //if we're not at end of array, increase index
                index++;
            }
            //return internalArray[index].value;
        }

        public void Remove(T key)
        {
            int hashCode = Math.Abs(key.GetHashCode());
            int startIndex = hashCode % internalArray.Length;
            int index = startIndex;

            while (true)
            {
                
                if (index < internalArray.Length && internalArray[index] != null 
                    && key.CompareTo(internalArray[index].key) == 0)
                    internalArray[index] = null;
                //if we have reached end of array, go to beginning and continue
                if (index == internalArray.Count() - 1)
                {
                    index = 0;
                    continue;
                }
                //keys were compared above, so if they weren't identical,
                //the key doesn't exist in the array...
                if (index == startIndex - 1)
                {
                    break;
                }
                
                //if we're not at end of array, increase index
                index++;
            }
            
        }

        public T[] GetKeyList()
        {
            // Hint: Count ved hvormange keys der er.

            //first make an array of the same size as internalarray,
            T[] a = new T[internalArray.Count()];
            int keys = 0;
            for (int i  = 0; i < internalArray.Count(); i++)
            {
                //find the values that aren't null, and save them:
                if (internalArray[i] != null)
                {
                    a[keys] = internalArray[i].key;
                    keys++;
                }
            }
            //Now make an array of the correct size, and transfer values:
            T[] arrayKeys = new T[keys];
            for (int i = 0; i < keys; i++)
            {
                arrayKeys[i] = a[i];
            }
            return arrayKeys;
        }

        private class HashNode<T, U>
        {
            public T key;
            public U value;
        }
    }
}
