using System;
using System.Collections.Generic;
using System.Threading;
using Core;

namespace ConsoleGol {

	public class Game {

		private int n;
		private int iter;
		private readonly List<Coords> AliveCellsCoords;
		public Grid grid;

		public Game(int nbCells, int nbIterations) {
			AliveCellsCoords = new List<Coords> {
				new Coords(0, 2), new Coords(1, 2), new Coords(2, 2),
				new Coords(2, 1), new Coords(1, 0)
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