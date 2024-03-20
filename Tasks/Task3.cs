using System.Text.Json;

namespace MM202ExamUnit3
{
    public class Task3
    {

        // setting it up as a binary tree
        public class Node
        {
            public int value { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
        }

        public class TreeInfo
        {
            public int Sum { get; set; }
            public int Depth { get; set; }
            public int Count { get; set; }
        }
        public TreeInfo Traverse(Node node)
        {
            if (node == null)
            {
                return new TreeInfo { Sum = 0, Depth = 0, Count = 0 };
            }

            TreeInfo LeftNode = Traverse(node.left);
            TreeInfo RightNode = Traverse(node.right);

            int sum = node.value + LeftNode.Sum + RightNode.Sum;
            int depth = Math.Max(LeftNode.Depth, RightNode.Depth) + 1;
            int count = LeftNode.Count + RightNode.Count + 1;

            return new TreeInfo { Sum = sum, Depth = depth, Count = count };
        }
    }
}