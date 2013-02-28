using System;
class Program
{
    static void Main()
    {
        long hand = 0;
        long ones = 0x1111111111111;//13 ones
        for (int i = 0; i < 5; i++)
        {
            string cardString = Console.ReadLine();
            switch (cardString)
            {
                case "J": hand += 1L << 4 * 10; break;
                case "Q": hand += 1L << 4 * 11; break;
                case "K": hand += 1L << 4 * 12; break;
                case "A": hand += 1L; break;
                default: hand += 1L << 4 * (int.Parse(cardString) - 1); break;
            }
        }
       while ((hand & 7L) == 0)
        {
            hand >>= 4;
        }
        if ((hand == 0x1111000000001) || (hand == 0x11111))         {
            Console.WriteLine("Straight");
        }
        else
        {
            hand += (hand & (ones<<2)) >>1;// 4-->6 and 5-->7 
            hand -= ones & (hand ^ (hand >> 1)); //6-->5 2-->1 1-->0  
            switch (hand % 15)
            {
                case 7: Console.WriteLine("Impossible"); break;//7
                case 5: Console.WriteLine("Four of a Kind"); break;//5
                case 4: Console.WriteLine("Full House"); break;//3+1
                case 3: Console.WriteLine("Three of a Kind"); break;//3
                case 2: Console.WriteLine("Two Pairs"); break;//1+1
                case 1: Console.WriteLine("One Pair"); break;//1
                default: Console.WriteLine("Nothing"); break;
            }
        }
    }
}
