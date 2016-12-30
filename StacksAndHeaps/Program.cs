using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StacksAndHeaps.Containers;
using StacksAndHeaps.Data;

namespace StacksAndHeaps
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ListNames((name) => {
                Console.WriteLine(name + " is awesome");
            });*/
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(3);
            tree.Add(11);
            tree.Add(3);
            tree.Add(4);
            tree.Add(9);
            //tree.Remove(3);

            int n = 0;
            BinaryTreeNode<int> node = tree.root;

            /* tree.TransversePostOrder((value) => {
                 Console.WriteLine(value + " ");
             });*/

            /*tree.TraversePreOrder((value) => {
                Console.WriteLine(value + " ");
            });*/
            tree.TraverseInOrder((value) => {
                Console.WriteLine(value + " ");
            });
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        

        static void ListNames(Action<string> action)
        {
            List<String> names = new List<string>() { "Kasper", "Mia", "Yingmei" };
            foreach(string name in names)
            {
                action(name);
            }
            // 
        }
    }

    
}
