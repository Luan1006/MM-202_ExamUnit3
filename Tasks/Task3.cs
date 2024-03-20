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
    }
}