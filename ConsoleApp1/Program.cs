using System.Runtime.Intrinsics.X86;
using System.Text.Encodings.Web;
using System.Text.Json;

internal class Program
{
    //public static int[] arr = new int[] { };
    //public static int[] arr2 = new int[] { };
    //public static int[] arr3 = new int[] { };
    //public static int[] arr4 = new int[] { };
    //public static int[] arr5 = new int[] { };
    //public static int[] arr6 = new int[] { };
    //public static int[] arr7 = new int[] { };
    //public static int[] arr8 = new int[] { };

    public static void Main(string[] args)
    {
        //    arr = FullArray(arr, 1000000);

        //    int partSize = arr.Length / 8;

        //    arr2 = new int[partSize];
        //    arr3 = new int[partSize];
        //    arr4 = new int[partSize];
        //    arr5 = new int[partSize];
        //    arr6 = new int[partSize];
        //    arr7 = new int[partSize];
        //    arr8 = new int[partSize];

        //    for (int i = 0; i < partSize; i++)
        //    {
        //        arr2[i] = arr[i + 0 * partSize];
        //        arr3[i] = arr[i + 1 * partSize];
        //        arr4[i] = arr[i + 2 * partSize];
        //        arr5[i] = arr[i + 3 * partSize];
        //        arr6[i] = arr[i + 4 * partSize];
        //        arr7[i] = arr[i + 5 * partSize];
        //        arr8[i] = arr[i + 6 * partSize];
        //    }

        //    Console.WriteLine(arr2.Length);
        //    Console.WriteLine(arr8[arr8.Length - 1]);
        //    var threadArr = new Thread[8];
        //    for (int i = 0;i < 8 ; i++)
        //    {

        //    }
        //}
        //public static int FindMax(int[] arr)
        //{
        //    return arr.Max(x => x);
        //}
        //public static int[] FullArray(int[] arr, int count)
        //{
        //    return Enumerable.Range(0, count).ToArray();
        //}

        //public static int[] FullSmallArrayFromOriginal(int[] smallarr, int[] original, int X, int Start)
        //{
        //    int j = 0;

        //    for (int i = Start; i < original.Length / X; i++, j++)
        //    {
        //        if (j >= smallarr.Length) break;
        //        smallarr[j] = original[i * X];
        //    }

        //    return smallarr;
        //}
        var t1 = new Thread(() => FindMinMaxAvgGrade(students[1]));
        var t2 = new Thread(() => FindMinMaxAvgGrade(students[2]));
        var t3 = new Thread(() => FindMinMaxAvgGrade(students[3]));
        var t4 = new Thread(() => FindMinMaxAvgGrade(students[4]));
        var t5 = new Thread(() => FindMinMaxAvgGrade(students[5]));
        var t6 = new Thread(() => FindMinMaxAvgGrade(students[6]));
        var t7 = new Thread(() => FindMinMaxAvgGrade(students[7]));
        var t8 = new Thread(() => FindMinMaxAvgGrade(students[8]));
        var t9 = new Thread(() => FindMinMaxAvgGrade(students[9]));
        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();
        t6.Start();
        t7.Start();
        t8.Start();
        t9.Start();
        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();
        t5.Join();
        t6.Join();
        t7.Join();
        t8.Join();
        t9.Join();



    }

    public static List<Student> students = new List<Student>()
    {
        new Student("Alex", new int[] { 5, 4, 3, 5 }),
        new Student("Maria", new int[] { 4, 4, 5, 5 }),
        new Student("John", new int[] { 3, 4, 4, 3 }),
        new Student("Anna", new int[] { 5, 5, 5, 4 }),
        new Student("David", new int[] { 2, 3, 3, 4 }),
        new Student("Sophie", new int[] { 4, 5, 4, 5 }),
        new Student("Michael", new int[] { 3, 3, 4, 4 }),
        new Student("Emma", new int[] { 5, 4, 5, 5 }),
        new Student("Daniel", new int[] { 4, 3, 4, 3 }),
        new Student("Olivia", new int[] { 5, 5, 4, 5 })
    };
    public static List<Tranksation> tranksations = new List<Tranksation>()
    {
        new Tranksation("Alice", "Bob", 120.50m),
        new Tranksation("John", "Maria", 75.00m),
        new Tranksation("David", "Emma", 300.25m),
        new Tranksation("Sophia", "Michael", 50.75m),
        new Tranksation("Daniel", "Olivia", 220.10m)
    };
    public static void ProcessingTranksation(Tranksation tranksation)
    {
        var rand = new Random();
        for (int i = 0; i < rand.Next(0,300); i++)
        {
            Thread.Sleep(200);
            Console.WriteLine($"");
        }
    }


    public static void FindMinMaxAvgGrade(Student student)
    {
        int max = student.grades.Max();
        int min = student.grades.Min();
        int sum = student.grades.Sum();
        int count = student.grades.Count();
        int avg = sum / count;
        int[] res = { max, min, sum, avg };
        string directory = Directory.GetCurrentDirectory();
        Console.WriteLine(directory);
        string path = Path.Combine(directory, $"Grades-{student.Name}.json");
        string json = JsonSerializer.Serialize(res, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
        File.WriteAllText(path, json);
    }
}

public sealed record Student(string Name, int[] grades) { };
public sealed record Tranksation(string Recipient,string Sender,decimal Sum);