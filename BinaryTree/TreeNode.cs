namespace BinaryTree;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right; 
    
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
    { 
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static bool IsSameTree(TreeNode a, TreeNode b)
    {
        if (a is null && b is null) {
            return true;
        }
        else if (a is null && b is not null || a is not null && b is null) {
            return false;
        }

        var result0 = a.val == b.val;
        var result1 = (a.left, b.left) switch
        {
            (null, null) => true,
            (null, TreeNode bl) => false,
            (TreeNode left, null) => false,
            (TreeNode al, TreeNode bl) => IsSameTree(al, bl)
        };

        var result2 = (a.right, b.right) switch
        {
            (null, null) => true,
            (null, TreeNode br) => false,
            (TreeNode right, null) => false,
            (TreeNode ar, TreeNode br) => IsSameTree(ar, br)
        };
        
        return result0 && result1 && result2;
    }
}