// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using SortingAlgorithms;

int[] nums;
int[] testedNums;

Console.WriteLine("Welcome to AlgoSort, a console app to test sorting algorithms.");

int main_menu_selection = 0;

while (main_menu_selection < 1 || main_menu_selection > 2)
{
    Console.WriteLine();
    Console.WriteLine("Please select from the following: ");
    Console.WriteLine("1.) Test an Algorithm\n2.) Compare Algorithms");
    Console.WriteLine();

    int.TryParse(Console.ReadLine(), out main_menu_selection);

    if (main_menu_selection < 1 || main_menu_selection > 2)
        Console.WriteLine("Invalid input detected. Please try again.");
}

int input_selection = 0;

while (input_selection < 1 || input_selection > 4)
{
    Console.WriteLine();
    Console.WriteLine("Please select from the following: ");
    Console.WriteLine("1.) Sorted Input\n2.) Reversed Input\n3.) Random Input\n4.) Custom Input");
    Console.WriteLine();

    int.TryParse(Console.ReadLine(), out input_selection);
    Console.WriteLine();

    if (input_selection < 1 || input_selection > 4)
        Console.WriteLine("Invalid input detected. Please try again.");
}

switch (input_selection)
{
    default:
        {
            Console.WriteLine("Please enter a collection of numbers seperated by spaces:\n(Invalid numbers will default to zeros)");

            string[] arrayInput = Console.ReadLine().Split(' ');

            nums = new int[arrayInput.Length];

            for (int i = 0; i < arrayInput.Length; i++)
                int.TryParse(arrayInput[i], out nums[i]);

            break;
        }

    case 1:
        {
            Console.WriteLine("Please enter the number of elements to generate:");
            int.TryParse(Console.ReadLine(), out int element_count);

            nums = new int[element_count];

            for(int i = 0; i < element_count; i++)
                nums[i] = i;

            break;
        }

    case 2:
        {
            Console.WriteLine("Please enter the number of elements to generate:");
            int.TryParse(Console.ReadLine(), out int element_count);

            nums = new int[element_count];

            for (int i = 0; i < element_count; i++)
                nums[i] = element_count - i;

            break;
        }

    case 3:
        {
            Console.WriteLine("Please enter the number of elements to generate:");
            int.TryParse(Console.ReadLine(), out int element_count);

            nums = new int[element_count];

            Random r = new Random();

            for (int i = 0; i < element_count; i++)
                nums[i] = r.Next(100);

            break;
        }
}

if (main_menu_selection == 2)
{
    testedNums = new int[nums.Length];
    Array.Copy(nums, testedNums, nums.Length);
}

if (main_menu_selection == 1)
{
    int algorithm_selection = 0;

    while (algorithm_selection < 1 || algorithm_selection > 4)
    {
        Console.WriteLine("\nPlease select the type of sort you would like to perform:");
        Console.WriteLine("1.) Bubble Sort\n2.) Insertion Sort\n3.) Selection Sort\n4.) Merge Sort\n");

        int.TryParse(Console.ReadLine(), out algorithm_selection);
        Console.WriteLine();

        if (algorithm_selection < 1 || algorithm_selection > 4)
            Console.WriteLine("Invalid input detected. Please try again.");
    }

    Stopwatch sw = new Stopwatch();

    switch (algorithm_selection)
    {
        default:
            {
                sw.Start();
                Sorting.BubbleSort(nums);
                sw.Stop();
                break;
            }

        case 2:
            {
                sw.Start();
                Sorting.InsertionSort(nums);
                sw.Stop();
                break;
            }

        case 3:
            {
                sw.Start();
                Sorting.SelectionSort(nums);
                sw.Stop();
                break;
            }

        case 4:
            {
                sw.Start();
                Sorting.MergeSort(nums);
                sw.Stop();
                break;
            }
    }

    Console.Write("The array has been sorted.\n");

    if (nums.Length <= 20)
    {
        Console.Write("[");

        for (int i = 0; i < nums.Length - 1; i++)
            Console.Write(nums[i] + ", ");

        Console.WriteLine(nums[nums.Length - 1] + "]");
    }
    else
        Console.WriteLine($"[{nums[0]}, {nums[1]}, {nums[2]}...{nums[nums.Length - 3]}, {nums[nums.Length - 2]}, {nums[nums.Length - 1]}]");

    Console.WriteLine("Operation Time: " + sw.ElapsedMilliseconds + "ms.");
}
else
{
    testedNums = new int[nums.Length];
    Stopwatch sw = new Stopwatch();

    long[] times = new long[4];

    Array.Copy(nums, testedNums, nums.Length);
    sw.Start();
    Sorting.BubbleSort(testedNums);
    sw.Stop();
    times[0] = sw.ElapsedMilliseconds;

    Array.Copy(nums, testedNums, nums.Length);
    sw.Restart();
    Sorting.InsertionSort(testedNums);
    sw.Stop();
    times[1] = sw.ElapsedMilliseconds;

    Array.Copy(nums, testedNums, nums.Length);
    sw.Restart();
    Sorting.SelectionSort(testedNums);
    sw.Stop();
    times[2] = sw.ElapsedMilliseconds;

    Array.Copy(nums, testedNums, nums.Length);
    sw.Restart();
    Sorting.MergeSort(testedNums);
    sw.Stop();
    times[3] = sw.ElapsedMilliseconds;

    Console.WriteLine($"\nSorting has been completed. Execution times with {nums.Length} elements:");
    Console.WriteLine($"Bubble Sort:    {times[0]}ms");
    Console.WriteLine($"Insertion Sort: {times[1]}ms");
    Console.WriteLine($"Selection Sort: {times[2]}ms");
    Console.WriteLine($"Merge Sort:     {times[3]}ms");

    Console.WriteLine("\n------------------------------------------------------------------------------------");
}