
using System.Reflection.Metadata.Ecma335;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers.Length == 0)
        {
            return 0;
        }
        else
        {
            int result = 0;
            string[] x = numbers.Split( ',', '\n');
            foreach (string n in x) 
            {
                result += int.Parse(n);
            }
            return result;
        }
    }   
}
