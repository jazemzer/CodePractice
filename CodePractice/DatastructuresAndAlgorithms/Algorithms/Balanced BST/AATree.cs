using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Algorithms.Balanced_BST
{
    /// <summary>
    ///     Original Paper - http://user.it.uu.se/~arnea/ps/simp.pdf
    ///     Good explanation - http://www.eternallyconfuzzled.com/tuts/datastructures/jsw_tut_andersson.aspx
    ///     C# code - http://demakov.com/snippets/aatree.html
    ///     
    ///     Wiki - http://en.wikipedia.org/wiki/AA_tree
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class AATree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node sentinel;
        private Node root;
        private Node deleted;
        public AATree()
        {
            sentinel = root = new Node();
        }

        public void TraverseInOrder(Action<TKey, TValue> action)
        {
            Inorder(root, action);
        }

        public void TraversePreOrder(Action<TKey, TValue> action)
        {
            Preorder(root, action);
        }

        public void TraversePostOrder(Action<TKey, TValue> action)
        {
            Postorder(root, action);
        }

        private void Inorder(Node node, Action<TKey, TValue> action)
        {
            if (node == sentinel)
                return;

            Inorder(node.left, action);
            action(node.Key, node.Value);
            Inorder(node.right, action);
        }

        private void Preorder(Node node, Action<TKey, TValue> action)
        {
            if (node == sentinel)
                return;

            action(node.Key, node.Value);
            Preorder(node.left, action);
            Preorder(node.right, action);
        }

        private void Postorder(Node node, Action<TKey, TValue> action)
        {
            if (node == sentinel)
                return;

            Postorder(node.left, action);
            Postorder(node.right, action);
            action(node.Key, node.Value);
        }

        public TValue Search(TKey key)
        {
            var node = root;
            int compare = -1;
            while(node != sentinel)
            {
                compare = key.CompareTo(node.Key);
                if(compare == 0)
                {
                    break;
                }
                else if (compare < 0)
                {
                    node = node.left;
                }
                else {
                    node = node.right;
                }
            }

            return node.Value;
        }

        public Tuple<TKey, TValue> Max()
        {
            Node max = root;
            while(max.right != sentinel)
            {
                max = max.right;
            }

            return new Tuple<TKey, TValue>(max.Key, max.Value);
        }

        public Tuple<TKey, TValue> Min()
        {
            Node min = root;
            while (min.left != sentinel)
            {
                min = min.left;
            }

            return new Tuple<TKey, TValue>(min.Key, min.Value);
        }


        public bool Insert(TKey key, TValue value)
        {
            return Insert(ref root, key, value);
        }

        public bool Delete(TKey key)
        {
            return Delete(ref root, key);
        }


      
        private bool Insert(ref Node node, TKey key, TValue value)
        {
            //Case where there are no nodes
            if(node == sentinel)
            {
                node = new Node(key, value, sentinel);
                return true;
            }

            int compare = node.Key.CompareTo(key);

            if(compare == 0)
            {
                //Same key present
                return false;
            }
            else if(compare < 0)
            {
                if (!Insert(ref node.right, key, value))
                    return false;
            }
            else
            {
                if (!Insert(ref node.left, key, value))
                    return false;
            }

            Skew(ref node);
            Split(ref node);

            return true;
        }

        private bool Delete(ref Node node, TKey key)
        {
            if(node == sentinel)
            {
                return deleted != null;
            }

            int compare = key.CompareTo(node.Key);

            if(compare < 0)
            {
                if (!Delete(ref node.left, key))
                    return false;
            }
            else
            {
                if(compare == 0)
                {
                    deleted = node; //Set Delete and continue with right node
                }

                //This is to find the next value to be replaced for the deleted node
                if (!Delete(ref node.right, key))
                    return false;
            }

            if(deleted != null)
            {
                //This section is entered only once by the last node that holds the value immediately above the node to be deleted.
                
                //Copy the replacement nodes details
                deleted.Key = node.Key;
                deleted.Value = node.Value;

                //Severe the reference to avoid re-entering this section
                deleted = null;

                //Becasue we were moving right and finding the next smallest value, we can replace the swapped node with its right child
                node = node.right;
            }
            // Level above check for inconsistencies
            else if (node.left.level < node.level - 1
                    || node.right.level < node.level - 1)
            {
                node.level--;

                if (node.right.level > node.level)
                {
                    node.right.level = node.level;
                }

                Skew(ref node);
                Skew(ref node.right);
                Skew(ref node.right.right);

                Split(ref node);
                Split(ref node.right);
            }
            return true;
        }

        private void Skew(ref Node node)
        {
            if(node.level == node.left.level)
            {
                var left = node.left;
                node.left = left.right;
                left.right = node;
                node = left;
            }
        }

        private void Split(ref Node node)
        {
            if(node.level == node.right.right.level)    //Dont have to worry about sentinels as their level is zero
            {
                var right = node.right;
                node.right = right.left;
                right.left = node;
                node = right;

                //Raise the parent level
                node.level++;
            }
        }

        #region Nested class

        // Class is private and its properties are internal
        private class Node
        {
            internal Node left;
            internal Node right;
            internal TKey Key;
            internal TValue Value;

            internal int level;

            internal Node()
            {
                this.level = 0; // Sentinels are below the leaf nodes
                this.left = this;
                this.right = this;
            }

            // Sentinel is supplied from the calling class
            internal Node(TKey key, TValue value, Node sentinel)
            {
                this.left = sentinel;
                this.right = sentinel;
                this.level = 1; //New nodes start with the level of leaf nodes
                this.Key = key;
                this.Value = value;
            }


        }
        #endregion

    }
}
