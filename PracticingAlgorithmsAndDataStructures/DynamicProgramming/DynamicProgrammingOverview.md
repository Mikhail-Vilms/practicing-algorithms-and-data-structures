# "Dynamic Programming" LeetCode problems overview

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