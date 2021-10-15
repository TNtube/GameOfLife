using System;

namespace ConsoleGol {
	class Program {
		static void Main()
		{
			Game game = new Game(10, 15);
			game.RunGameConsole();
			Console.ReadLine();
		}
	}
}