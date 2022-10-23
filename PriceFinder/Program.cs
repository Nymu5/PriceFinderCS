// See https://aka.ms/new-console-template for more information

using System.Collections;

class PriceFinder
{
    public static void Main(String[] args)
    {
        String seperator = " | ";
        String end = "";
        Console.WriteLine("Enter Values: ");
        ArrayList multipleInput = new ArrayList();
        do
        {
            String input = Console.ReadLine();
            if (input == "") break; 
            multipleInput.Add(Double.Parse(input));
        } while (true);
        Console.Write("[");
        for (int i = 0; i < multipleInput.Count; i++)
        {
            Console.Write($"{multipleInput[i]}{(i != multipleInput.Count-1 ? seperator : end)}");
        }
        Console.Write("]");
        Console.WriteLine("\nEnter Value: ");
        multipleInput.Sort();
        multipleInput.Reverse();
        ArrayList sum = findSum(Double.Parse(Console.ReadLine()), multipleInput, new ArrayList());
        Console.Write("[");
        for (int i = 0; i < sum.Count; i++)
        {
            Console.Write($"{sum[i]}{(i != sum.Count-1 ? seperator : end)}");
        }
        Console.Write("]\n");
        Console.WriteLine("Press enter to finish...");
        Console.ReadLine();
    }
    static ArrayList findSum(double sum, ArrayList doubles, ArrayList combined)
    {
        Console.Write("[");
        for (int x = 0; x < combined.Count; x++)
        {
            Console.Write($"{combined[x]} + {(x != combined.Count-1 ? " | " : "")}");
        }
        Console.Write("]\n");
        double i = 0;
        foreach (double m in combined)
        {
            i += m;
        }

        if (i > sum)
        {
            return new ArrayList();
        }

        foreach (double n in doubles)
        {
            ArrayList newDoubles = new ArrayList(doubles);
            newDoubles.Remove(n);
            combined.Add(n);
            double combined_sum = 0;
            foreach (double m in combined)
            {
                combined_sum += m;
            }

            if (combined_sum == sum)
            {
                return combined;
            }

            ArrayList res = findSum(sum, newDoubles, combined);
            if (res.Count > 0)
            {
                return res; 
            }
            combined.Remove(n);
        }

        return new ArrayList();
    }
}

