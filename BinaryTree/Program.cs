namespace BinaryTree;

// Binary trees are commonly used in computer science for efficient storage and retrieval of data
public class Program
{
    public static void Main(string[] args)
    {
        SolveSameTree();
    }

    public static void SolveSameTree()
    {
        TreeNode root1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode root2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        
        var result1 = TreeNode.IsSameTree(root1, root2);
        Console.WriteLine($"First: {result1}");

        TreeNode root3 = new TreeNode(1, new TreeNode(2), null);
        TreeNode root4 = new TreeNode(1, null, new TreeNode(3));

        var result2 = TreeNode.IsSameTree(root3, root4);
        Console.WriteLine($"Second: {result2}");
        
        TreeNode root5 = new TreeNode(1, new TreeNode(2), new TreeNode(1));
        TreeNode root6 = new TreeNode(1, new TreeNode(1), new TreeNode(2));

        var result3 = TreeNode.IsSameTree(root5, root6);
        Console.WriteLine($"Third: {result3}");
    }
    
    public static void SolveInorderTraversal()
    {
        TreeNode node1 = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));

        var result1 = InorderTraversal(node1);
        foreach (var item in result1)
        {
            Console.Write($"{item},");
        }
        
        Console.WriteLine();
        
        TreeNode node2 = new TreeNode(1, 
            new TreeNode(2, new TreeNode(4), new TreeNode(5, new TreeNode(6), new TreeNode(7))),
            new TreeNode(3, null, new TreeNode(8, new TreeNode(9))));

        var result2 = InorderTraversal(node2);
        foreach (var item in result2)
        {
            Console.Write($"{item},");
        }
        
        Console.WriteLine();
        
        var result3 = InorderTraversal(null);
        Console.WriteLine(result3.Count == 0);
        
        var result4 = InorderTraversal(new TreeNode(1));
        foreach (var item in result4)
        {
            Console.Write($"{item},");
        }

    }

    // todo: improve performance of this algorithm 
    /// <summary>
    /// Inorder traversal is an algorithm where first the left node is traversed followed by the root node and
    /// then at last the right node 
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<int> InorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>();
        }

        IList<int> left = new List<int>();
        IList<int> right = new List<int>();
        
        if (root.left is not null)
        {
            left = InorderTraversal(root.left);
        }

        if (root.right is not null)
        {
            right = InorderTraversal(root.right);
        }

        return [..left, root.val, ..right];
    }
}