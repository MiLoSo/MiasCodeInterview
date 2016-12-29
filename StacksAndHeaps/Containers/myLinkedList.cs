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

        public void RemoveAt(int index)
        {
            if (index > size || index < 0)
                throw new Exception("index beyond length of linked list.");

            Node<T> current = head;
            int n = 0;
            while (n < index-1 && current.next != null)
            {
                current = current.next;
                n++;
            }
            RemoveAfterNode(current);

        }

        public void RemoveHead()
        {
            RemoveAfterNode(null);
        }

        public void RemoveLast()
        {
            if (tail == null)
                throw new Exception("index beyond length of linked list.");

            Node<T> current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            RemoveAfterNode(current);
        }

        public T Get(int index)
        {
            Node<T> node = getNode(index);
            if (node != null)
                return node.value;
            else
                throw new Exception("index beyond length of linked list.");
        }

        public T GetHead()
        {
            Node<T> node = getNode(0);
            if (node != null)
                return node.value;
            else
                throw new Exception("index beyond length of linked list.");
        }

        public T GetTail()
        {
            Node<T> node = getNode(size-1);
            if (node != null)
                return node.value;
            else
                throw new Exception("index beyond length of linked list.");
        }

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

        private void RemoveAfterNode(Node<T> n)
        {     
            if (n == null && head != null)
            {//if there is a next, it's the new head.
                if (head.next != null)
                    head = head.next;
                else //if not, both are null.
                {
                    head = null;
                    tail = null;
                }
            }
            else if (head == null)
            {     
                throw new IndexOutOfRangeException("Cannot remove node: out of range exception.");
            }else if (size == 1)
            {
                n = null;
            }

            //if there are more nodes after, add them as the new next.
            if (n != null && n.next != null)
            {
                Node<T> tempNode = n.next.next;
                n.next = tempNode;
            } else if (n != null)
            {   //else, next is null.
                n.next = null;
            }
            size--;
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
    }
}
