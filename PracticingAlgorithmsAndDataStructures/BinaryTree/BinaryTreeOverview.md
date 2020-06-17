# "Binary Tree" category LeetCode problems overview

## Level Order Traversal #Medium [№102]

### Approach: Iterations / Stack(List) / BFS;
 - Use list of nodes to save all tree nodes for every level.
 - On each iteration based on previous level build new level(list) of nodes.
 - At the same time save all values from each node that we need to return
 - Continue until there is no nodes for next level to iterate.

##### Code: "LevelOrderTraversal.cs"

## Inorder Traversal #Medium [№92]

### Approach 1: Recursion
 - #TODO
 - TC: O(n)
 - SC: O(log(n)) in average / O(n) in worst case

### Approach 2: Iterations / Stack
 - #TODO
 - TC: O(n)
 - SC: O(log(n)) in average / O(n) in worst case

##### Code: "InorderTraversal.cs"

## Delete Leaves With a Given Value #Medium [№1325]
 - Use postorder traversal to traverse tree
 - For each node check children and delete if needed
 - TC: O(n)
 - SC: O(log(n)) in average / O(n) in worst case

##### Code: "DeleteLeavesWithGivenValue.cs"
##### Problem description: https://leetcode.com/problems/delete-leaves-with-a-given-value/

## Maximum Binary Tree. #Medium [№654]
#### Approach: Recursion
 - Find max value in array
 - Create new node and assign max value to it	
 - Construct tree for left and right parts of array in similar fashion
 - Use start and end pointers to define available range of array for every step
 - Pass these pointers through recursion calls
 - TC: on each level we need to traverse whole array - n elements. In worst case number of cases levels is n, if tree is balanced - log(n). Result: O(n^2) in worst case, O(n*log(n))
 - SC: worst case - O(n) - if tree of n elements has n levels; O(log(n)) - if tree is balanced(average case)

##### Code: "MaximumBinaryTree.cs"
##### Problem description: https://leetcode.com/problems/maximum-binary-tree