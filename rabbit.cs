using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
class Program02
{
    static void Main()
    {
        string[] Input = Console.ReadLine().Split(',');
        int[] terrain = new int[Input.Length];
        for (int i = 0; i < Input.Length; i++)
        {
            terrain[i] = int.Parse(Input[i]);
        }
        int maxOffset = Math.Min(1000, Input.Length /2);
        int bestResult = 1;
        for (int i = 0; i < terrain.Length; i++)
        {
            for (int j = -maxOffset; j < maxOffset; j++)
            {
                int result = Check(i, j,terrain);
                if (result>bestResult)
                {
                    bestResult = result;
                }
            }
        }
        Console.WriteLine(bestResult);
    }
 
    private static int Check(int startPosition, int step, int[] terrain)
    {
        int result = 0;
        int lastPositionNumber = int.MinValue;
        int currentPosition = startPosition;
        do
        {
            lastPositionNumber = terrain[currentPosition];
            result++;
            currentPosition += step;
            if (currentPosition >= terrain.Length)
            {
                currentPosition -= terrain.Length;
            }
            if (currentPosition<0)
            {
                currentPosition += terrain.Length;
            }
        } while (terrain[currentPosition]>lastPositionNumber);
        return result;
    }
}
