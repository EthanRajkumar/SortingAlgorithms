# Sorting Algorithms
This is a simple console app built to reinforce and demonstrate my learning of sorting algorithms. This program currently contains the following algorithms:
- Bubble Sort
- Insertion Sort
- Selection Sort
- Merge Sort

More algorithms are planned in the future.

## Testing Options
Users can select whether they want to test an individual sorting algorithm, or do a benchmark of them all with the same dataset.

## Collection Input Method
Users can choose from a variety of input presets, including sorted ascending (tests best case performance), sorted descending (tests worst case performance), and randomly generated (tests average performance). Each of these sks for a length of the collection to generate.

Users can also opt to enter custom input, which will create an array from space-seperated characters (invalid chracter sequences will default to 0).

## Testing Results
When testing an individual algorithm, the console will output the newly sorted array (truncated to the first and last 3 values if too large), as well as the execution time in milliseconds.

When testing all algorithms, the console will not output the sorted array, but instead output the execution times for each algorithm in milliseconds.
