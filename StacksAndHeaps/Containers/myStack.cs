using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Containers
{
    public class myStack<T>
    {
        //add last as first
        private myLinkedList<T> lList = new myLinkedList<T>();

        //Add new element on top of stack
        public void Add(T value)
        {
            lList.AddHead(value);
        }

        //pop top element
        public T Pop()
        {
            if (Count() < 1) //if there are no element,
                return default(T); //return null.
            T value = lList.GetHead();
            lList.RemoveHead();
            return value;            
        }

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
