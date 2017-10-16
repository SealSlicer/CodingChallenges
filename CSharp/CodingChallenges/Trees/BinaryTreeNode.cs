namespace CodingChallenges.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;

    using CodingChallenges.Utilities;

    public class BinaryTreeNode<TValue>
        where TValue : IComparable
    {
        public BinaryTreeNode<TValue> Left { get; set; }

        public BinaryTreeNode<TValue> Right { get; set; }

        public TValue Value { get; set; }

        public BinaryTreeNode(TValue value)
        {
            this.Value = value;
        }

        public bool InsertStandardBst(TValue valueToAdd)
        {
            var result = this.InsertValueCustom(valueToAdd, NextNodeOrInsertStandardBst);

            return result;
        }
        
        public bool InsertValueCustom(TValue valueToAdd, Func<TValue, BinaryTreeNode<TValue>, BinaryTreeNode<TValue>> nextNodeOrInsert)
        {
            var nextNode = nextNodeOrInsert(valueToAdd, this);

            if (nextNode == null)
            {
                if (this.Value.Equals(valueToAdd))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return nextNode.InsertValueCustom(valueToAdd, nextNodeOrInsert);
        }

        public BinaryTreeNode<TValue> FindValueBreadthFirst(TValue valueToFind)
        {
            var queue = new Queue<BinaryTreeNode<TValue>>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    continue;
                }

                if (node.Value.Equals(valueToFind))
                {
                    return node;
                }

                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }

            return null;
        }

        public BinaryTreeNode<TValue> FindValueDepthFirst(TValue valueToFind)
        {
           

            if (this.Value.Equals(valueToFind))
            {
                return this;
            }

            return this.Left?.FindValueDepthFirst(valueToFind) ?? this.Right?.FindValueDepthFirst(valueToFind);
        }

        public BinaryTreeNode<TValue> FindValueStandardBst(TValue valueToFind)
        {
            if (this.Value == null)
            {
                return null;
            }
            else if (this.Value.Equals(valueToFind))
            {
                return this;
            }

            var comparison = valueToFind.CompareTo(this.Value);

            if (comparison == (int)ComparisonResult.LessThan && this.Left != null)
            {
                return this.Left.FindValueStandardBst(valueToFind);
            }
            else if (this.Right != null)
            {

                return this.Right.FindValueStandardBst(valueToFind);
            }

            return null;
        }

        public void InOrderTraversal(Action<TValue> perNodeAction)
        {
            this.Left?.InOrderTraversal(perNodeAction);
            perNodeAction(this.Value);
            this.Right?.InOrderTraversal(perNodeAction);
        }

        public void PreOrderTraversal(Action<TValue> perNodeAction)
        {
            perNodeAction(this.Value);
            this.Left?.InOrderTraversal(perNodeAction);
            this.Right?.InOrderTraversal(perNodeAction);
        }

        public void PostOrderTraversal(Action<TValue> perNodeAction)
        {
            this.Left?.InOrderTraversal(perNodeAction);
            this.Right?.InOrderTraversal(perNodeAction);
            perNodeAction(this.Value);
        }

        public bool ValidateIsStandardBst()
        {
            return this.ValidateBstNode(default(TValue), default(TValue));
        }

        private static BinaryTreeNode<TValue> NextNodeOrInsertStandardBst(TValue valueToAdd, BinaryTreeNode<TValue> currentNode)
        {
            var comparison = valueToAdd.CompareTo(currentNode.Value);
            BinaryTreeNode<TValue> nextNode = null;
            if (comparison == (int)ComparisonResult.LessThan)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = new BinaryTreeNode<TValue>(valueToAdd);
                }
                else
                {
                    nextNode = currentNode.Left;
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = new BinaryTreeNode<TValue>(valueToAdd);
                }
                else
                {
                    nextNode = currentNode.Right;
                }
            }

            return nextNode;
        }

        private bool ValidateBstNode(TValue min, TValue max)
        {
            bool resultSelfMin = min.Equals(default(TValue)) || this.Value.CompareTo(min) != (int)ComparisonResult.LessThan;

            bool resultSelfMax = max.Equals(default(TValue)) || this.Value.CompareTo(max) != (int)ComparisonResult.GreaterThan;

            bool resultLeft = true;
            bool resultRight = true;
           
            if (this.Right != null)
            {
                resultRight = this.Right.ValidateBstNode(this.Value, max);
            }

            if (this.Left != null)
            {
                resultLeft = this.Left.ValidateBstNode(min, this.Value);
            }

            return resultSelfMin && resultSelfMax && resultRight && resultLeft;
        }
    }
}