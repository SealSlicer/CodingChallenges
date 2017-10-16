namespace CodingChallenges.Trees
{
    using System;

    public class TreeTests
    {
        public void TestBst()
        {
            var random = new Random();
            var standardBst = new BinaryTreeNode<int>(random.Next(-1000000, 1000000));
            for (int i = 0; i < 10000; ++i)
            {
                standardBst.InsertStandardBst(random.Next(-1000000, 1000000));
            }

            Console.WriteLine("Is Valid? " + standardBst.ValidateIsStandardBst());

            Console.WriteLine("\nInOrderTraversal: ");
            standardBst.InOrderTraversal(WriteWithComma);

            Console.WriteLine("\nPreOrderTraversal: ");
            standardBst.PreOrderTraversal(WriteWithComma);

            Console.WriteLine("\nPostOrderTraversal: ");
            standardBst.PostOrderTraversal(WriteWithComma);


        }

        static void WriteWithComma(int value)
        {
            Console.Write(value.ToString() + ',');
        }
    }
}