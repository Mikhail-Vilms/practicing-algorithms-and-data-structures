# "Binary Search Tree" category LeetCode problems overview

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

## Validate BST #Medium [№98]

### Approach: Recursion
 - Traverse all nodes in the tree and compare the node value with its upper and lower limits.
 - Update upper limit when moving to left child
 - Update lower limit when moving to right child
 - TC: O(n)
 - SC: O(log(n)) in average / O(n) in worst case

Code: "ValidateBST.cs"
Problem description: https://leetcode.com/problems/validate-binary-search-tree/

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