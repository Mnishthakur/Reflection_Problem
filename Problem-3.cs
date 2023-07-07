using System;
using System.Reflection;

public class Program
{
    public int MyProperty { get; set; }

    public Program()
    {
        // Default constructor
    }

    public Program(int value)
    {
        MyProperty = value;
    }

    public static int FindClosestEvenNumber(int N)
    {
        string N_str = N.ToString();

        // Check if all digits in N are already even
        bool allEven = true;
        foreach (char digit in N_str)
        {
            if ((digit - '0') % 2 != 0)
            {
                allEven = false;
                break;
            }
        }

        if (allEven)
        {
            return N;
        }

        // Find the next smallest even number
        int evenNumber = N - 1;
        while (!IsAllDigitsEven(evenNumber))
        {
            evenNumber--;
        }

        // Find the next largest even number
        int oddNumber = N + 1;
        while (!IsAllDigitsEven(oddNumber))
        {
            oddNumber++;
        }

        // Determine which even number is closest to N
        if (N - evenNumber < oddNumber - N)
        {
            return evenNumber;
        }
        else
        {
            return oddNumber;
        }
    }

    public static bool IsAllDigitsEven(int number)
    {
        string numStr = number.ToString();
        foreach (char digit in numStr)
        {
            if ((digit - '0') % 2 != 0)
            {
                return false;
            }
        }
        return true;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the number: ");
        int N = int.Parse(Console.ReadLine());

        int closestEvenNumber = FindClosestEvenNumber(N);
        Console.WriteLine("Closest even number: " + closestEvenNumber);

        // Fetch all class members using reflection
        Type programType = typeof(Program);
        MemberInfo[] members = programType.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        Console.WriteLine("\nClass Members:");
        foreach (MemberInfo member in members)
        {
            Console.WriteLine(member.Name + " - " + member.MemberType);
        }

        // Create an empty object using reflection
        Program emptyObject = (Program)Activator.CreateInstance(programType);

        Console.WriteLine("\nEmpty Object created using reflection: " + emptyObject.GetType().Name);
    }
}
