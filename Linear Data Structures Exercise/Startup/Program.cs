//Problem 5
//int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

//Stack<int> stack = new Stack<int>(input);

//Console.WriteLine(string.Join(" ", stack));

//Problem 6

int input = int.Parse(Console.ReadLine());

Queue<long> queue = new Queue<long>();
queue.Enqueue(input);
const int times = 50;

List<long> result = new List<long> () { input};

for (int i = 0; i < times; i++)
{
    long currentNumber = queue.Dequeue();

    queue.Enqueue(currentNumber + 1);
    result.Add (currentNumber + 1);

    queue.Enqueue(2 * currentNumber + 1);
    result.Add(2 * currentNumber + 1);

    queue.Enqueue(currentNumber + 2);
    result.Add(currentNumber + 2);
}
Console.WriteLine("----");

Console.WriteLine(string.Join(", ", result));
