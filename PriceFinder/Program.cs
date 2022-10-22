// See https://aka.ms/new-console-template for more information

using System.Collections;

class PriceFinder
{
    public static void Main(String[] args)
    {
        while (true)
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
            double searchValue = Double.Parse(Console.ReadLine()); 
            multipleInput.Sort();
            multipleInput.Reverse();
            Console.WriteLine($"Find one (1)");
            Console.WriteLine($"Find all (2)");
            int method = Int16.Parse(Console.ReadLine());
            if (method == 1)
            {
                ArrayList sum = findSum(searchValue, multipleInput, new ArrayList());
                Console.Write("[");
                for (int i = 0; i < sum.Count; i++)
                {
                    Console.Write($"{sum[i]}{(i != sum.Count-1 ? seperator : end)}");
                }
                Console.Write("]\n");
            } else if (method == 2)
            {
                ArrayList sums = findAllSums(searchValue, multipleInput, new ArrayList(), new ArrayList());
                foreach (ArrayList sum in sums)
                {
                    Console.Write("[");
                    for (int i = 0; i < sum.Count; i++)
                    {
                        Console.Write($"{sum[i]}{(i != sum.Count-1 ? seperator : end)}");
                    }
                    Console.Write("]\n");
                }
            }
            
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
    static ArrayList findSum(double sum, ArrayList doubles, ArrayList combined)
    {
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

    public static ArrayList findAllSums(double sum, ArrayList doubles, ArrayList combined, ArrayList standard)
    {
        double i = 0;
        foreach (double m in combined)
        {
            i += m;
        }

        if (i > sum)
        {
            return standard;
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
                standard.Add(new ArrayList(combined));
            }
            standard = findAllSums(sum, newDoubles, combined, standard);
            combined.Remove(n);
        }

        return standard;
    }
}

