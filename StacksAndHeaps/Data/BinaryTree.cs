using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndHeaps.Data
{
    public class BinaryTree<T> where T : IComparable
    {
        /*private*/ public BinaryTreeNode<T> root;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value) 
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>() { value = value };
            // Must keep the tree sorted
            if (root == null)
            {
                root = newNode;
                return;
            }
            //otherwise, find best place:
            BinaryTreeNode<T> current = root;
            while (true)
            {
                if (current == null) { //we've found the correct node.
                    current = newNode; //doesn't work for root.
                    return;
                }
                if (value.CompareTo(current.value) > 0)
                {//follow right branch / add
                    if (current.right == null) {
                        current.right = newNode;
                        return;
                    }
                    else
                        current = current.right;
                }
                else
                {//follow left branch / add
                    if (current.left == null)
                    {
                        current.left = newNode;
                        return;
                    }
                    else
                        current = current.left; //evt a recursive function that takes next node as input Add(root, value)
                }
            }
        }

        public void Remove(T value)
        {
            // Must keep the tree sorted
            BinaryTreeNode<T> current = root;
            BinaryTreeNode<T> prevNode;
            while (true)
            {
                //if no prev node, it's the root.
                if (value.CompareTo(current.value) > 0)
                {//follow right branch / add
                    if (current.right == null)
                        throw new Exception("Value not found");
                    if (value.CompareTo(current.right.value) == 0) //if correct value, remove:
                    {
                        sortRemove(current, false);
                        return;
                    }
                    else
                        current = current.right;
                }
                else
                {//follow left branch / add
                    if (current.left == null)
                        throw new Exception("Value not found");
                    if (value.CompareTo(current.left.value) == 0) //if correct value, remove:
                    {
                        sortRemove(current, true);
                        return;
                    }
                    else
                        current = current.left;
                }
            }
        }
        
        private void sortRemove(BinaryTreeNode<T> parent, bool left)
        {
            BinaryTreeNode<T> node;
            if (left)
                node = parent.left;
            else
                node = parent.right;

            //if the node has no children, remove
            if (node.right == null && node.left == null)
            {
                node = null;
                return;
            }
            //if the node has one child, it takes the node's place. (this assumes balancing is being done correctly... which it isn't.)
            if (node.left == null && node.right != null )
            {
                node = node.right;
                return;
            } else if (node.right == null && node.left != null){
                node = node.left;
                return;
            }

            if (left)
                parent.left = parent.left.right;
            else
                parent.right = parent.right.right;
            //if parent.child's left and right nodes can be directly parented to the parent(no other children), do it.
            //else, look to the parent's other children
        }
        //depth first. Visit all children before the node itself.
        //visit all the left nodes first, from the closest (and outermost) first.
        //then the right, closest, and outmost right children.
        public void TransversePostOrder(Action<T> action)
        {//recursive?
            TransversePostOrder(root, action);
        }
        private void TransversePostOrder(BinaryTreeNode<T> parent, Action<T> action)
        {
            if (parent != null)
            {
                TransversePostOrder(parent.left, action);
                TransversePostOrder(parent.right, action);
                action(parent.value);
            }
        }

        //visit the node before the children.
        public void TraversePreOrder(Action<T> action)
        {
            TraversePreOrder(root, action);   
        }
        private void TraversePreOrder(BinaryTreeNode<T> parent, Action<T> action)
        {
            if (parent != null)
            {
                action(parent.value);
                TraversePreOrder(parent.left, action);
                TraversePreOrder(parent.right, action);
            }
        }

        //visit left node, then the node itself, then the right node. For binary trees.
        public void TraverseInOrder(Action<T> action)
        {
            TraverseInOrder(root, action);
        }

        private void TraverseInOrder(BinaryTreeNode<T> parent, Action<T> action)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.left, action);
                action(parent.value);
                TraverseInOrder(parent.right, action);
            }
        }
    }

    public class BinaryTreeNode<T>
    {
        public T value;
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;
    }
}
