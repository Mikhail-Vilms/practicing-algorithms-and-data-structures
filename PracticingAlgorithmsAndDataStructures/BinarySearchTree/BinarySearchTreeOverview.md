# "Binary Search Tree" category LeetCode problems overview

Binary Search Tree is a node-based binary tree data structure which has the following properties:
- The left subtree of a node contains only nodes with keys lesser than the node’s key.
- The right subtree of a node contains only nodes with keys greater than the node’s key.
- The left and right subtree each must also be a binary search tree.

### Problem list:
- [Validate BST](#validate-bst)
- [Construct BST from Preorder Traversal](#construct-bst-from-preorder-traversal)

## Validate BST
#### #Medium; [№98]; Problem description: https://leetcode.com/problems/validate-binary-search-tree/
#### Solution code: ValidateBinarySearchTreeSolution.cs

### Approach: Recursion
 - Traverse all nodes in the tree and compare the node value with its upper and lower limits.
 - Update upper limit when moving to left child
 - Update lower limit when moving to right child
 - TC: O(n)
 - SC: O(log(n)) in average / O(n) in worst case

Code: "ValidateBST.cs"
Problem description: https://leetcode.com/problems/validate-binary-search-tree/

## Construct BST from Preorder Traversal
#### #Medium; [№1008]; Construct Binary Search Tree from Preorder Traversal
#### Solution code: ConstructBstFromPreordalTraversalSolution.cs
### Approach 1 - Iterations + Stack:
```csharp
public TreeNode BstFromPreorder(int[] preorder) {
    Stack<TreeNode> stack = new Stack<TreeNode>();
    TreeNode root = null;
        
    for(int i = 0; i < preorder.Length; i++){           // iterate from left -> right
        TreeNode node = new TreeNode(){
            val = preorder[i]
        };
            
        if (stack.Count == 0 || root == null){          // if there is no root - create
            root = node;
            stack.Push(node);
            continue;
        }
            
        if (node.val < stack.Peek().val){               // if element is less than "head" val - build left subtree
            stack.Peek().left = node;
            stack.Push(node);
            continue;
        }
            
        TreeNode parent = null;                         // find parent node - extract from stack
        while (stack.Count != 0 && node.val > stack.Peek().val){
            parent = stack.Pop();
        }
        parent.right = node;
        stack.Push(node);                               // build right node and add it to stack
    }
        
    return root;
}
```

## Insert Node #Medium [№701]

### Approach: #TODO
 - TC: O(log(n)); O(n) - worst case
 - SC: O(log(n)); O(n) - worst case

 Code: "InsertIntoBST.cs"
 Problem description: https://leetcode.com/problems/insert-into-a-binary-search-tree/submissions/

## Delete Node #Medium [№450]

#### Approach: #TODO
 Code: "DeleteNodeInBST.cs"
 Problem description: https://leetcode.com/problems/delete-node-in-a-bst/

## Binary Search Tree Iterator #Medium [№173]

### Approach: Traverse iteratively using stack
 - Traverse all tree to very left bottom node and add all nodes to stack. We need to do this when instantiating new iterator.
 - To return next element we have to retrieve element from stack, return it's data, and push right child of this node to stack as well as every node all the way down to bottom left one
 - TC: O(1)
 - SC: O(log(N)) / O(N) in worst case - skew tree

Code: "BSTIterator.cs"
Problem decription (good one): https://leetcode.com/problems/binary-search-tree-iterator/ 

#### Find Kth Smallest Element #Medium [№230]

Approach: Use stack to traverse BST until Kth node is reached. 

Code: 