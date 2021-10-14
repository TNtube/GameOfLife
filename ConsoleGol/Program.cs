using System;
using Core;

namespace ConsoleGol {
	class Program {
		static void Main()
		{
			Game game = new Game(4, 10);
			game.RunGameConsole();
		}
	}
}