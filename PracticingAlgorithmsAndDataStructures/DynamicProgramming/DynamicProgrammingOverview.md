# "Dynamic Programming" LeetCode problems overview

Dynamic Programming is mainly an optimization over plain recursion. Wherever we see a recursive solution that has repeated calls for same inputs, we can optimize it using Dynamic Programming. The idea is to simply store the results of subproblems, so that we do not have to re-compute them when needed later. This simple optimization reduces time complexities from exponential to polynomial. For example, if we write simple recursive solution for Fibonacci Numbers, we get exponential time complexity and if we optimize it by storing solutions of subproblems, time complexity reduces to linear.

### Problem list:

- [Climbing Stairs](#climbing-stairs)
- [Maximum Subarray](#maximum-subarray)
- [Longest Common Subsequence](#longest-common-subsequence)
- [Longest Increasing Subsequence](#longest-increasing-subsequence) #must-have
- [Minimum Cost Tree From Leaf Values](#minimum-cost-tree-from-leaf-values)


## Climbing Stairs

#### #Easy; [№70]; Problem description: https://leetcode.com/problems/climbing-stairs/
#### Solution code:

- On every step we have two choices: climb one stair or two stairs
- Two base cases: when we need to climb 2 or 1 stairs

#### Approach 1: Plain Recursion:
```csharp
public int ClimbStairs(int n) {
    if (n == 1){
        return 1;
    }

    if (n == 2){
        return 2;
    }

    return ClimbStairs(n-1) + ClimbStairs(n-2);
}
```

#### Approach 2: Plain Recursion + Memoization:
```csharp
private int[] memo;			// + memoization

public int ClimbStairs(int n) {
	memo = new int[n];		// + memoization

    return OnNextStep(n);
}

private int OnNextStep(int n){
	if (n == 1){
	    return 1;
    }
	if (n == 2){
        return 2;
    }
    if (memo[n-1] != 0){	// + memoization
		return memo[n-1];
	}

	memo[n-1] = OnNextStep(n-1) + OnNextStep(n-2);
	
	return memo[n-1];
}
```

## Maximum Subarray 
#### #Easy; [№53]; Problem description: https://leetcode.com/problems/maximum-subarray/
#### Solution code: MaximumSubarraySolution.cs

### Approach 1: Plain Recursion
```csharp
private int[] A;
private int max;
    
public int MaxSubArray(int[] nums)
{
    A = nums;
    max = A[0];
        
    DP(nums.Length - 1);
        
    return max;
}

private int DP(int indx)
{
    if (indx == 0){ return A[0]; }

    int option1 = DP(indx - 1) + A[indx];
    int option2 = A[indx];
        
    int res = option1 > option2 ? option1 : option2;
        
    if (res > max){ max = res; }
        
    return option1 > option2 ? option1 : option2;
}
```

### Approach 2: Plain Recursion + Memoization
```csharp
private int[] A;
private int max;
private List<int> memo = new List<int>(); // + memo

public int MaxSubArray(int[] nums)
{
    A = nums;
    max = A[0];
        
    memo.Add(A[0]);  // + memo
    DP(nums.Length - 1);
        
    return max;
}

private int DP(int indx)
{
    if (indx < memo.Count){  // + memo
        return memo[indx];
    }
        
    int option1 = DP(indx - 1) + A[indx];
    int option2 = A[indx];
        
    int res = option1 > option2 ? option1 : option2;
        
    if (res > max){ max = res; }
        
    memo.Add(res);  // + memo
    return res;
}
```

### Approach 3: Bottom-Up Approach
```csharp
public class Solution {
    private int[] A;
	private int[] memo; // + memoization

	public int Rob(int[] nums) {
        this.A = nums;
		return DP(A.length - 1);
    }

	private int DP(int indx){
		if (indx == 0){
			return A[0];
		}
		
		int option1 = DP(indx - 1) + A[indx];
		int option2 = A[indx];

		return option1 > option2 ? option1 : option2; 
    }
}
```

## Longest Common Subsequence
#### #Medium; [№1143]; Problem description: https://leetcode.com/problems/longest-common-subsequence/
#### Soluiton code: LongestCommonSubsequence.cs
### Description:
```
Given two strings text1 and text2, return the length of their longest common subsequence.
A subsequence of a string is a new string generated from the original string with some characters(can be none) deleted without
changing the relative order of the remaining characters. (eg, "ace" is a subsequence of "abcde" while "aec" is not). 
A common subsequence of two strings is a subsequence that is common to both strings.
```

### Approach 1 - Plain Recursion:
```csharp
private string _text1;
private string _text2;
    
public int LongestCommonSubsequence(string text1, string text2) {
    _text1 = text1;
    _text2 = text2;
    return Rec(text1.Length - 1, text2.Length - 1);
}
    
private int Rec(int p1, int p2){
    if (p1 == 0 && p2 == 0){
        return _text1[p1] == _text2[p2] ? 1 : 0;
    }
        
    if (p1 == 0){
        return _text1[p1] == _text2[p2] ? 1 : Rec(p1, p2 - 1);
    }
        
    if (p2 == 0){
        return _text1[p1] == _text2[p2] ? 1 : Rec(p1 - 1, p2);
    }
        
    if (_text1[p1] == _text2[p2]){
        return Rec(p1 - 1, p2 - 1) + 1;
    }
        
    return Rec(p1 - 1, p2) > Rec(p1, p2 - 1) ? Rec(p1 - 1, p2) : Rec(p1, p2 - 1);
}
```

### Approach 2 - Plain Recursion + Memoization:
```csharp
private string _text1;
private string _text2;
private int[,] _memo; // + Memoization
    
public int LongestCommonSubsequence(string text1, string text2) {
    _text1 = text1;
    _text2 = text2;
        
    _memo = new int[text1.Length, text2.Length]; // + Memoization
    for (int p1 = 0; p1 < text1.Length; p1++){
        for (int p2 = 0; p2 < text2.Length; p2++){
            _memo[p1, p2] = -1;
        }
    }
        
    return Rec(text1.Length - 1, text2.Length - 1);
}
    
private int Rec(int p1, int p2){
    if (_memo[p1, p2] != -1) { // + Memoization
        return _memo[p1, p2];
    }
        
    if (p1 == 0 && p2 == 0){
        _memo[p1, p2] = _text1[p1] == _text2[p2] ? 1 : 0; 
        return _memo[p1, p2]; // + Memoization
    }
        
    if (p1 == 0){
        _memo[p1, p2] = _text1[p1] == _text2[p2] ? 1 : Rec(p1, p2 - 1); 
        return _memo[p1, p2]; // + Memoization
    }
        
    if (p2 == 0){
        _memo[p1, p2] = _text1[p1] == _text2[p2] ? 1 : Rec(p1 - 1, p2);
        return _memo[p1, p2]; // + Memoization
    }
        
    if (_text1[p1] == _text2[p2]){
        _memo[p1, p2] = Rec(p1 - 1, p2 - 1) + 1;
        return _memo[p1, p2]; // + Memoization
    }
        
    _memo[p1, p2] = Rec(p1 - 1, p2) > Rec(p1, p2 - 1) ? Rec(p1 - 1, p2) : Rec(p1, p2 - 1);
    return _memo[p1, p2]; // + Memoization
}
```
### Approach 3 - Bottom-up:
```csharp
public int LongestCommonSubsequence(string text1, string text2) {
    int[,] matrix = new int[text2.Length, text1.Length];

    for(int row = 0; row < text2.Length; row++){
        for(int col = 0; col < text1.Length; col++){
            if (row == 0 && col == 0){
                matrix[row, col] = text2[row] == text1[col] ? 1 : 0;
                continue;
            }

            if (row == 0){
                matrix[row, col] = text2[row] == text1[col] ? 1 : matrix[row, col - 1];
                continue;
            }

            if (col == 0){
                matrix[row, col] = text2[row] == text1[col] ? 1 : matrix[row - 1, col];
                continue;
            }

            if (text2[row] == text1[col]){
                matrix[row, col] = matrix[row - 1, col - 1] + 1;
                continue;
            }

            matrix[row, col] = matrix[row, col - 1] > matrix[row - 1, col] ? matrix[row, col - 1] : matrix[row - 1, col];
        }
    }

    return matrix[text2.Length - 1, text1.Length - 1];
}
```

## Longest Increasing Subsequence
#### #Medium; [№300]; Problem description: https://leetcode.com/problems/longest-common-subsequence/
#### [Solution code](https://github.com/Mikhail-Vilms/practicing-algorithms-and-data-structures/blob/master/PracticingAlgorithmsAndDataStructures/DynamicProgramming/LongestIncreasingSubsequenceSolution.cs) : LongestIncreasingSubsequenceSolution.cs

### Description:
```
Given an unsorted array of integers, find the length of longest increasing subsequence.
[10,9,2,5,3,7,101,18] -> 4 : [2,3,7,101]
```

### Solution:
```
Iterate array from right to left, on every step we have two options:
- Skip current element: moving next without including current element into subsequence
- Include current element, if possible; It is possible if current element is less than next element in subsequence
This means that we have to track: 1) index of current element and 2) index of next element in subsequence
```

### Approach 1 - Plain Recursion:
```csharp
private int[] _nums;
    
public int LengthOfLIS(int[] nums) {
    _nums = nums;
        
    return FindFor(nums.Length - 1, nums.Length);
}
    
private int FindFor(int curr, int next){           
    if (curr == 0){
        if (next == _nums.Length || _nums[curr] < _nums[next]){
            return 1;
        }
        else {
            return 0;
        }
    }
        
    // Skip current element: moving without including current element into subsequence
    int opt1 = FindFor(curr - 1, next);                 
                
    // include current element, if possible: if current is less that next element,
    // we can include it into subsequence - that means that from now current el is new "next"
    int opt2 = 0;                                       
    if (next == _nums.Length || _nums[curr] < _nums[next]){
        opt2 = 1 + FindFor(curr - 1, curr);
    }
        
    return Math.Max(opt1, opt2);
}
```

### Approach 2 - Plain Recursion + Memoization:
```csharp
private int[] _nums;
private int[,] _memo; // + MEMO
    
public int LengthOfLIS(int[] nums) {
    if (nums.Length == 0){
        return 0;
    }
    _nums = nums;
        
    _memo = new int[nums.Length, nums.Length + 1]; // + MEMO
    for (int i = 0; i < nums.Length; i++){
        for (int j = 0; j <= nums.Length; j++){
            _memo[i, j] = -1;
        }
    }
        
    return FindFor(nums.Length - 1, nums.Length);
}

private int FindFor(int curr, int next){           
    if (curr == 0){
        if (next == _nums.Length || _nums[curr] < _nums[next]){
            return 1;
        }
        else {
            return 0;
        }
    }
        
    if (_memo[curr, next] != -1){   // + MEMO
        return _memo[curr, next];
    }
        
    int opt1 = FindFor(curr - 1, next);                 
                
    int opt2 = 0;
    if (next == _nums.Length || _nums[curr] < _nums[next]){
        opt2 = 1 + FindFor(curr - 1, curr);
    }
        
    _memo[curr, next] = Math.Max(opt1, opt2); // + MEMO
        
    return _memo[curr, next];
}
```

## Minimum Cost Tree From Leaf Values
#### #Medium; [№1130]; Problem description: https://leetcode.com/problems/minimum-cost-tree-from-leaf-values/
#### Solution code: MaximumSubarraySolution.cs

### Description:
```
Given an array of positive integers, consider all binary trees such that:
- Each node has either 0 or 2 children;
- The values of arr correspond to the values of each leaf in an in-order traversal of the tree 
// (Recall that a node is a leaf if and only if it has 0 children.)
- The value of each non-leaf node is equal to the product of the largest leaf 
value in its left and right subtree respectively.

Among all possible binary trees considered, return the smallest possible sum of the values
of each non-leaf node.  It is guaranteed this sum fits into a 32-bit integer.
```

### Approach 1 - Plain Recursion:
```csharp
private int[] arr;
    
public int MctFromLeafValues(int[] arr) {
	this.arr = arr;
	return OnNextStep(0, arr.Length - 1).sum;
}
    
private (int sum, int max) OnNextStep(int i, int j){
	if (i == j){ // base case: if we have 1 element in array
		return (0, arr[i]);
	}
        
	int finalSum = 10000;
	int finalMax = 0;
        
	for(int mid = i; mid < j; mid++){ // all possible partitions of subarray [i..j]
		(int sum, int max) res1 = OnNextStep(i, mid);
		(int sum, int max) res2 = OnNextStep(mid + 1, j);
            
		int currSum = res1.sum + res2.sum + res1.max*res2.max;
            
		if (currSum < finalSum){
			finalSum = currSum;
			finalMax = (res1.max > res2.max) ? res1.max : res2.max;
		}
	}
        
	return (finalSum, finalMax);
}
```

### Approach 2 - Plain Recursion + Memoization:
```csharp
private int[] arr;
private int[,] sumMemo;  // + memoization
private int[,] maxMemo;  // + memoization

public int MctFromLeafValues(int[] arr) {
    this.arr = arr;
    sumMemo = new int[arr.Length, arr.Length];  // + memoization
    maxMemo = new int[arr.Length, arr.Length];  // + memoization

    return OnNextStep(0, arr.Length - 1).sum;
}

private (int sum, int max) OnNextStep(int i, int j){
    if (i == j){
        return (0, arr[i]);
    }
        
    if (sumMemo[i, j] > 0){  // + memoization
        return (sumMemo[i, j], maxMemo[i, j]);
    }
        
    int finalSum = 10000;
    int finalMax = 0;

    for(int mid = i; mid < j; mid++){
        (int sum, int max) res1 = OnNextStep(i, mid);
        (int sum, int max) res2 = OnNextStep(mid + 1, j);

        int currSum = res1.sum + res2.sum + res1.max*res2.max;

        if (currSum < finalSum){
            finalSum = currSum;
            finalMax = (res1.max > res2.max) ? res1.max : res2.max;
        }
    }

    sumMemo[i, j] = finalSum;  // + memoization
    maxMemo[i, j] = finalMax;  // + memoization
        
    return (finalSum, finalMax);
}
```

## House Robber #Medium [№198]

### Approach - 1 Step: Recursion; 
 - For every element we have two options: include one in final set or skip and move to next one.
 - In case we picked previous element we have only one option: skip current.
 - Base case of recursion: return 0 if there are no more elements available;

```csharp
public class Solution {
    private int[] nums;

	public int Rob(int[] nums) {
        this.nums = nums;
		return DP(0, false);
    }

	private int DP(int currIndx, bool needToSkip){
		if (currIndx == this.nums.Length){
			return 0;
		}
        
		// if we have picked last element, we shall skip current:
		if (needToSkip){
			return DP(currIndx + 1, false);
		}

		// First case: include current element to final set:
        int res1 = nums[currIndx] + DP(currIndx + 1, true);
        
        // Second case: skip current element and move forward:
        int res2 = DP(currIndx + 1, false);
        
        int res = res1 > res2 ? res1 : res2;

		return res;
    }
}
```

### Approach - 2 Step: Recursion + MEMOIZATION;

```csharp
public class Solution {
    private int[] nums;
    
    // + MEMOIZATION
    private int[] memo;
    
    public int Rob(int[] nums) {
        this.nums = nums;
        
        // + MEMOIZATION
        this.memo = new int[nums.Length];
        for(int i = 0; i < nums.Length; i++){
            this.memo[i] = -1;
        }
        
        return DP(0, false);
    }
    
    private int DP(int currIndx, bool needToSkip){
        if (currIndx == this.nums.Length){
            return 0;
        }
        
        // if we have pisked last element, we shall skip current:
        if (needToSkip){
            return DP(currIndx + 1, false);
        }
        
        // + MEMOIZATION
        if (this.memo[currIndx] != -1) {
            return this.memo[currIndx];
        }
        
        // First case: include current element to final set:
        int res1 = nums[currIndx] + DP(currIndx + 1, true);
        
        // Second case: skip current element and move forward:
        int res2 = DP(currIndx + 1, false);
        
        int res = res1 > res2 ? res1 : res2;
        
        // + MEMOIZATION
        memo[currIndx] = res; 
        
        return res;
    }
}
```

Code: “HouseRobber.cs”
Problem description: https://leetcode.com/problems/house-robber/

## Ones and Zeroes #Medium [№474]

### Approach - 1 Step: Recursion;
 - if we have only one string to consider, there are only two opitons - include or skip this string. This choice depends only on the fact whether or not we have enough ones and zeros.
 - if we don't have enough zeros and ones then skip current string and move to the next one
 - there are two choices: skip or include current string. And move to next one after that. 

```csharp
public int FindMaxForm(string[] strs, int m, int n, int strIndx = 0) {
    // retrieve number of 0s and 1s from current string; 
    int m0 = strs[strIndx].ToCharArray()
        .Count(x => x == '0');
    int n0 = strs[strIndx].Length - m0;
        
    // base case - last string in array
    // that means we consider set of only one string 
    if (strIndx == strs.Length - 1){
        if (n0 > n || m0 > m){
            return 0;
        }
        return 1;
    }
        
    // if number of 0s or 1s is more than number of availabe 0s and 1s - skip current string and move to next one
    if (n0 > n || m0 > m){
        return FindMaxForm(strs, m, n, strIndx + 1);
    }
        
    int countIfSkip, countIfAdd;
        
    // first case - include current string
    countIfAdd = 1 + FindMaxForm(strs, m-m0, n-n0, strIndx + 1);
        
    // second case - skip current string and move for the next one
    countIfSkip = FindMaxForm(strs, m, n, strIndx + 1); 
        
    // return result of the case with max result
    return countIfAdd > countIfSkip ? countIfAdd : countIfSkip;
}
```

### Approach - 2 Step: Recursion + MEMOIZATION;

```cs
public class Solution {
    private int[,] zerosAndOnes;
    private int lastIndx;
    
    private int[,,] memo; // +memoization
    
    public int FindMaxForm(string[] strs, int m, int n) {
        this.lastIndx = strs.Length - 1;
        this.zerosAndOnes = new int[2, strs.Length];
        
        // transform all strings to pairs of zeros and ones:
        for(int strIndx = 0; strIndx < strs.Length; strIndx++){
            int zeros = strs[strIndx].ToCharArray()
                .Count(x => x == '0');
            int ones = strs[strIndx].Length - zeros;
            
            this.zerosAndOnes[0, strIndx] = zeros;
            this.zerosAndOnes[1, strIndx] = ones;
        }
        
        this.memo = new int[m + 1, n + 1, strs.Length]; // +memoization
        
        return dp(m, n, 0);
    }
    
    private int dp(int zerosAvailable, int onesAvailable, int strIndx){
        // retrieve number of 0s and 1s from current string; 
        int zeros = this.zerosAndOnes[0, strIndx];
        int ones = this.zerosAndOnes[1, strIndx];
        
        // base case - last string in array
        // that means we consider set of only one string 
        if (strIndx == this.lastIndx){
            if (zeros > zerosAvailable || ones > onesAvailable){
                return 0;
            }
            return 1;
        }
        
        // +memoization
        if (this.memo[zerosAvailable, onesAvailable, strIndx] != 0){
            return this.memo[zerosAvailable, onesAvailable, strIndx];
        }
        
        // if number of 0s or 1s is more than number of availabe 0s and 1s - skip current string
        if (zeros > zerosAvailable || ones > onesAvailable){
            return dp(zerosAvailable, onesAvailable, strIndx + 1);
        }
        
        int countIfSkip, countIfAdd;
        
        // first case - include current string
        countIfAdd = 1 + dp(zerosAvailable - zeros, onesAvailable - ones, strIndx + 1);
        
        // second case - skip current string and move for the next one
        countIfSkip = dp(zerosAvailable, onesAvailable, strIndx + 1); 
        
        // return result of the case with max result
        int result = countIfAdd > countIfSkip ? countIfAdd : countIfSkip;
        
        this.memo[zerosAvailable, onesAvailable, strIndx] = result;  // +memoization
        
        return result;
    }
}
```

##### Code: "MaximumBinaryTree.cs"
##### Problem description: https://leetcode.com/problems/ones-and-zeroes/