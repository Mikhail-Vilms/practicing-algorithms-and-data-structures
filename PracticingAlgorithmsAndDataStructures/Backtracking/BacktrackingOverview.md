# Backtracking Technique Overview

Backtracking is an algorithmic-technique for solving problems recursively by trying to build a solution incrementally, one piece at a time, removing those solutions that fail to satisfy the constraints of the problem at any point of time (by time, here, is referred to the time elapsed till reaching any level of the search tree).

### Problem list:

- [Subsets](#subsets)
- [Subsets II](#subsets-ii)
- [Combination Sum](#combination-sum)
- [Combination Sum II](#combination-sum-ii)
- [Combination Sum III](#combination-sum-iii)
- [Premutations](#premutations)
- [Premutations II](#premutations-ii)
- 
- [N Queens](#n-queens)

## "Subsets"

#### #Medium; [№78]; Problem description: https://leetcode.com/problems/subsets/
#### Sulotion code: SubsetsSolution.cs

- For every element in initial set we need to investigate two options: adding element to set or skipping one
- After making first decision we have to move to next element if we are not at the end of initial set
- When we are done with one option(adding element to the set) we need to return("backtack") to the point when we made decision
- Delete this element and investigate second path: moving to next element whithout current element being added to the set
- Time Complexity: O(2^N) - For every element we have two recursive cases to investigate
- Space Complexity: O(N) - Using stack to keep all added element from initial set

```csharp
private IList<IList<int>> res = new List<IList<int>>();
private Stack<int> stack = new Stack<int>();
private int[] nums;
private int length;

public IList<IList<int>> FindAllSubsets(int[] nums)
{
    this.nums = nums;
    length = nums.Length;
    Backtracking(0);
    return res;
}

private void Backtracking(int indx)
{
    res.Add(stack.ToList());
    for (int i = indx; i < length; i++)
    {
        stack.Push(nums[i]);
        Backtracking(i + 1);
        stack.Pop();
    }
}
```


## "Subsets II" 

#### #Medium; [№90]; Problem description: https://leetcode.com/problems/subsets-ii/
#### Sulotion code: SubsetIISolution.cs

 - The only differences between this problem and [Subsets](#subsets) are:
   - We need to sort elements first
   - Also we have to avoid adding duplicated subsets - this could be achieved by skipping similar element if this element is not firstn one we are considering for current recursion call

```csharp
private IList<IList<int>> res = new List<IList<int>>();
private Stack<int> stack = new Stack<int>();
private int[] nums;
private int length;

public IList<IList<int>> SubsetsWithDup(int[] nums)
{
    Array.Sort(nums); // + Sorting initial array
    this.nums = nums;
    length = nums.Length;
    PlaceElement(0);
    return res;
}

private void PlaceElement(int indx)
{
    res.Add(stack.ToList());
    for (int i = indx; i < length; i++)
    {
        if (i != indx && nums[i] == nums[i - 1]) // Excluding duplicated subsets
        {
            continue;
        }
        stack.Push(nums[i]);
        PlaceElement(i + 1);
        stack.Pop();
    }
}
```

## Combination Sum

#### #Medium; [№39]; Problem description: https://leetcode.com/problems/combination-sum/
#### Sulotion code: CombinationSumSoluiton.cs

- On every step we trying to add one of the elements from array that are available
- We have to try every option
- "available" means elements of array that we have not considered for adding to combination yet

```csharp
private IList<IList<int>> res = new List<IList<int>>();
private Stack<int> stack = new Stack<int>();
private int[] arr;
private int length;

public IList<IList<int>> FindAllCombinations(int[] candidates, int target)
{
    arr = candidates;
    length = candidates.Length;
    OnNextStep(target, 0);
    return res;
}

private void OnNextStep(int sum, int indx)
{
    if (sum < 0) { return; }
	if (sum == 0) { res.Add(stack.ToList()); }

    for (int i = indx; i < length; i++)
    {
        stack.Push(arr[i]);
        OnNextStep(sum - arr[i], i);
        stack.Pop();
    }
}
```


## Combination Sum II

#### #Medium; [№40]; Problem description: https://leetcode.com/problems/combination-sum-ii/
#### Sulotion code: CombinationSumSoluitonII.cs

- On every step we trying to add one of the elements from array that are available
- We have to try every option
- "available" means elements of array that we have not considered for adding to combination yet 
- We need to be sure that same element will not be considered twice

```csharp
private IList<IList<int>> res = new List<IList<int>>();
private int[] arr;
private int length;
private Stack<int> stack = new Stack<int>();

public IList<IList<int>> FindAllCombinations(int[] candidates, int target)
{
    Array.Sort(candidates); // + Sorting initial array
    this.arr = candidates;
    this.length = candidates.Length;

    OnNextStep(0, target);
    return this.res;
}

private void OnNextStep(int indx, int sum)
{
	if (sum < 0) { return; }
	if (sum == 0) { res.Add(stack.ToList()); }

    for (int i = indx; i < length; i++)
    {
        if (i != indx && arr[i] == arr[i - 1]) // Excluding similar combinaitons(subsets) that will cause duplicated sums
        {
            continue;
        }

        this.stack.Push(this.arr[i]);
        this.OnNextStep(i + 1, sum - arr[i]);
        this.stack.Pop();
    }
}
```

## "Permutations" #Medium [№46]

## "Permutations II" #Medium [№47]


## "Palindrome Partitioning" #Medium [№131]	


## Links

- https://www.geeksforgeeks.org/backtracking-algorithms/
- 