using Programming_Methods;

class Program
{
    static void Main()
    {
        Random rand = new Random();

        int[] arr = new int[10];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next() % 100;
        }

        Console.WriteLine(string.Join(" ", Sort.BubbleSort<int>(arr)));

        Console.WriteLine(string.Join(" ", Sort.QuickSort<int>(arr)));

        Console.WriteLine(string.Join(" ", Sort.MergeSort<int>(arr)));
    }
}
