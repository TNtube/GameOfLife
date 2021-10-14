using System;
using System.Collections.Generic;
using System.Threading;

namespace Core {

	public class Game {

		private int n;
		private int iter;
		private readonly List<Coords> AliveCellsCoords;
		public Grid grid;

		public Game(int nbCells, int nbIterations) {
			AliveCellsCoords = new List<Coords> {
				new(0, 2), new (1, 2), new (2, 2),
				new (2, 1), new (1, 0)
			};
			n = nbCells;
			iter = nbIterations;
			grid = new Grid(nbCells, AliveCellsCoords);
			
		}

		public void RunGameConsole() {
			for (int i = 0; i < iter; i++) {
				grid.UpdateGrid();
				grid.DisplayGrid();
				Thread.Sleep(1000);
			}
		}
	}
}