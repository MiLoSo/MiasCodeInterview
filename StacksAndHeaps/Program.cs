using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StacksAndHeaps.Containers;

namespace StacksAndHeaps
{
    class Program
    {
        public static void TestLinkedList()
        {
            Node<int> head = new Node<int>()
            {
                value = 1
            };
            myLinkedList<int> lList = new myLinkedList<int>();
            lList.AddHead(2);
            lList.AddHead(1);
            lList.AddTail(3);
            lList.AddAfter(4, 2);

            lList.RemoveLast();

            lList.AddTail(5);
            lList.AddTail(6);

            lList.RemoveAt(3);

            // Print kun index 1 ud

            Node<int> current = lList.head;
            int n = 0;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
                n++;
            }
            Console.WriteLine(" ");
            Console.WriteLine("Value at 3rd spot: " + lList.Get(3));
            Console.WriteLine("head: " + lList.GetHead());
            Console.WriteLine("tail: " + lList.GetTail());

            Console.ReadLine();
        }

        public static void TestStacks()
        {
            Console.ReadLine();

            Node<int> n = new Node<int>();
        }

        static void Main(string[] args)
        {
            //TestLinkedList();
            TestStacks();

        }
    }

    
}
