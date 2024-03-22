using System.Text.Json;
using MM202ExamUnit3.Utils;
using static MM202ExamUnit3.Utils.Constants;
using static MM202ExamUnit3.Utils.Print;

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

        public static async Task FindTreeInfoWithJsonFile(string jsonFilePath)
        {
            try
            {
                Console.WriteLine(ReadJSON);

                jsonFilePath = Path.Combine(ExampleFilesDirectory, NodesJsonExampleFile);
                string jsonContent = await File.ReadAllTextAsync(jsonFilePath);

                Task3 task3 = new Task3();

                Console.WriteLine(BinaryTree, jsonContent);

                Task3.Node root = JsonSerializer.Deserialize<Task3.Node>(jsonContent);

                Task3.TreeInfo treeInfo = task3.Traverse(root);

                Console.WriteLine(Sum, treeInfo.Sum);
                Console.WriteLine(DeepestLevel, treeInfo.Depth);
                Console.WriteLine(Nodes, treeInfo.Count);
            }
            catch (Exception e)
            {
                PrintErrorMessage(e.Message);
            }
        }

        public static async Task FindTreeInfoWithAPICall(string BSTAPIURL)
        {
            ApiService apiService = new ApiService(new HttpClient());
            try
            {
                Console.WriteLine(CallAPI);

                HttpResponseMessage response = await apiService.GetApiResponse(BSTAPIURL);
                string responseBody = await response.Content.ReadAsStringAsync();

                Task3 task3 = new Task3();

                Console.WriteLine(BinaryTree, responseBody);

                Task3.Node root = JsonSerializer.Deserialize<Task3.Node>(responseBody);

                Task3.TreeInfo treeInfo = task3.Traverse(root);

                Console.WriteLine(Sum, treeInfo.Sum);
                Console.WriteLine(DeepestLevel, treeInfo.Depth);
                Console.WriteLine(Nodes, treeInfo.Count);
            }
            catch (HttpRequestException e)
            {
                PrintErrorMessage(e.Message);
            }
        }
    }
}