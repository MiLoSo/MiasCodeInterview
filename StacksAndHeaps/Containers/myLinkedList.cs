using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Containers
{
    public class myLinkedList<T>
    {
        public Node<T> head = null;
        public Node<T> tail = null;

        int size = 0;

        public int Size()
        {
            return size;
        }

        public void ClearList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        private Node<T> getNode(int index)
        {
            if (index >= size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            Node<T> current = head;
            while (i < index && current != null)
            {
                current = current.next;
                i++;
            }
            return current;
        }
        public T Get(int index)
        {
            return getNode(index).value;
        }
        
        private void AddAfterNode(Node<T> n, T value)
        {
            size++;
            var newNode = new Node<T>();
            newNode.value = value;

            if (n == null && head != null)
            {
                newNode.next = head;
                head = newNode;
                return;
            } else if (n == null && head == null) {
                head = newNode;
                tail = head;
                return;
            }

            if (n.next == null)
            {
                n.next = newNode;
                tail = newNode;
                return;
            }

            // There is a next
            newNode.next = n.next;
            n.next = newNode;
        }

        public void AddHead(T value)
        {
            AddAfterNode(null, value);
        }
        public void AddTail(T value)
        {
            AddAfterNode(tail, value);
        }
        public void AddAfter(int index, T value)
        {
            AddAfterNode(getNode(index), value);
        }
        public void AddBefore(int index, T value)
        {
            AddAfterNode(getNode(index - 1), value);
        }


        public void RemoveFirst()
        {
            remove(0);
        }
        public void RemoveLast()
        {
            remove(size - 1);
        }   
        public void RemoveAt(int index)
        {
            remove(index);
        }             
        private void remove(int index)
        {//note: doing it this way means I have to go through the list twice,
            //instead of once, as I did before.
            Node<T> node = getNode(index); //find current node
            size--;
            if (index == 0)
            {
                head = node.next;
                return;
            }
            Node<T> prevNode = getNode(index - 1); //find prev node, so I can couple to node.next
            prevNode.next = node.next;
            
            
        }
    }
}
