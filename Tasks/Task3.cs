using System.Text.Json;

namespace MM202ExamUnit3
{
    public class Task3
    {

        // setting it up as a binary tree
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
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

            TreeInfo left = Traverse(node.Left);
            TreeInfo right = Traverse(node.Right);

            int sum = node.Value + left.Sum + right.Sum;
            int depth = Math.Max(left.Depth, right.Depth) + 1;
            int count = left.Count + right.Count + 1;

            return new TreeInfo { Sum = sum, Depth = depth, Count = count };
        }

        public TreeInfo ProcessTree(string json)
        {
            Node root = JsonSerializer.Deserialize<Node>(json);

            TreeInfo result = Traverse(root);
            Console.WriteLine($"Sum = {result.Sum}");
            Console.WriteLine($"Deepest level = {result.Depth}");
            Console.WriteLine($"Nodes = {result.Count}");

            return result;
        }
    }
}