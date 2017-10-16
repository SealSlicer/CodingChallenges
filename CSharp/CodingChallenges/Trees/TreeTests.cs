namespace CodingChallenges.Trees
{
    using System;

    public class TreeTests
    {
        public void TestRandomBst()
        {
            var random = new Random();
            var standardBst = new BinaryTreeNode<int>(random.Next(-1000000, 1000000));
            for (int i = 0; i < 5; ++i)
            {
                standardBst.InsertStandardBst(random.Next(-1000000, 1000000));
            }

            Console.WriteLine("Is Valid? " + standardBst.ValidateIsStandardBst(int.MinValue, int.MaxValue));

            Console.WriteLine("\nInOrderTraversal: ");
            standardBst.InOrderTraversal(WriteWithComma);

            Console.WriteLine("\nPreOrderTraversal: ");
            standardBst.PreOrderTraversal(WriteWithComma);

            Console.WriteLine("\nPostOrderTraversal: ");
            standardBst.PostOrderTraversal(WriteWithComma);
        }

        public void TestBst()
        {
            var notABst= new BinaryTreeNode<int>(0);
            notABst.InsertToFillTree(1);
            notABst.InsertToFillTree(-1);

            Console.WriteLine("Not A Bst Is Valid BST? " + notABst.ValidateIsStandardBst(int.MinValue, int.MaxValue));

            var actualBst = new BinaryTreeNode<int>(0);
            actualBst.InsertStandardBst(-5);
            actualBst.InsertStandardBst(5);
            actualBst.InsertStandardBst(-1);
            actualBst.InsertStandardBst(6);
            actualBst.InsertStandardBst(-6);
            actualBst.InsertStandardBst(4);

            Console.WriteLine("Actual BST Is Valid Bst? " + actualBst.ValidateIsStandardBst(int.MinValue, int.MaxValue));

            Console.WriteLine("Found 10? " + (actualBst.FindValueStandardBst(10) != null).ToString());
            Console.WriteLine("Found -1? " + (actualBst.FindValueStandardBst(-1) != null).ToString());

        }

        static void WriteWithComma(int value)
        {
            Console.Write(value.ToString() + ',');
        }
    }
}