using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("Zadejte kladné celé číslo:");
		if (UInt64.TryParse(Console.ReadLine(), out UInt64 number))
		{
			int numberOfOnes = CountOnesInBinaryRepresentation(number);
			Console.WriteLine($"{number} => {numberOfOnes} ({Convert.ToString((long)number, 2)})");
		}
		else
		{
			Console.WriteLine("Neplatný vstup. Zadejte prosím kladné celé číslo.");
		}
	}

	static int CountOnesInBinaryRepresentation(UInt64 number)
	{
		int count = 0;
		while (number != 0)
		{
			count += (int)(number & 1);
			number >>= 1;
		}
		return count;
	}
}
