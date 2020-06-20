# Sorting Algorithms

## Quick Sort:

- Run partition operation on array
   - Pick pivot
   - Reorder array so all values less than the pivot move before pivot, all greater ones move after pivot
- Sort first part of partition operation result
- Sort second part
- Time Complexity: O(n*log(n)); O(n^2) in worst case - depends on how we chose pivot for partition operation
- Space Complexity: O(n)

## Merge Sort:

- Divide array to two parts
- Sort first part
- Sort second part
- Merge two parts to result sorted array
- Base case: if we have 0 or 1 element in array just return it
- Time Complexity: O(n*log(n)); O(n*log(n)) in worst case
- Space Complexity: O(n) - during merging routine we have to have temporary arrays

## Heap Sort:
#TODO

## External Sort:
#TODO