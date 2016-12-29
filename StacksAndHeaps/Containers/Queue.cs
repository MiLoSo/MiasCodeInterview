using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Containers
{
    public class Queue<T>
    {
        //add last as first
        private myLinkedList<T> lList = new myLinkedList<T>();

        //add item
        public void Enqueue(T value)
        {
            lList.AddTail(value);
        }

        //remove first item
        public T Dequeue()
        {
            T value = lList.GetHead();
            lList.RemoveHead();
            return value;
        }

        //copy queue to array:
        /* public Array[] CopyTo()
         {
             if (type != queueType)
                 throw new Exception("array type not matching queue type.");
         }*/

        //peek at top element
        public T Peek()
        {
            return lList.GetHead();
        }

        //return size of stack
        public int Count()
        {
            return lList.Size();
        }

        //Clear the Stack
        public void Clear()
        {
            lList.ClearList();
        }

    }
}
