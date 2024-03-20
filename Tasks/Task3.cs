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

            var left = Traverse(node.Left);
            var right = Traverse(node.Right);

            var sum = node.Value + left.Sum + right.Sum;
            var depth = Math.Max(left.Depth, right.Depth) + 1;
            var count = left.Count + right.Count + 1;

            return new TreeInfo { Sum = sum, Depth = depth, Count = count };
        }
    }
}