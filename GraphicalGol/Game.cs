using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using Core;

namespace GraphicalGol {
	public class Game {
		private int n;
		private int iter;
		
		// Glider Coordinates
		private readonly List<Coords> AliveCellsCoords = new List<Coords> {
				new Coords(0, 2), new Coords(1, 2), new Coords(2, 2),
				new Coords(2, 1), new Coords(1, 0)
			};

		private Random _random;
		
		public Grid grid;

		public Game(int nbCells, int nbIterations, bool random = false) {
			_random = new Random();
			n = nbCells;
			iter = nbIterations;
			if (random) {
				for (int i = 0; i < n; i++) {
					for (int j = 0; j < n; j++) {
						if (_random.Next(0, 100) > 49)
							AliveCellsCoords.Add(new Coords(i, j));
					}
				}
			}
			
			grid = new Grid(nbCells, AliveCellsCoords);
		}
		public Game(int nbCells, bool random = false) {
			_random = new Random();
			n = nbCells;
			
			if (random) {
				for (int i = 0; i < n; i++) {
					for (int j = 0; j < n; j++) {
						if (_random.Next(0, 100) > 70)
							AliveCellsCoords.Add(new Coords(i, j));
					}
				}
			}

			int foo = AliveCellsCoords.Count;
			grid = new Grid(nbCells, AliveCellsCoords);
		}

		public void Paint(Graphics g, int squareSize) {
			SolidBrush grayBrush = new SolidBrush(Color.Gray);
			g.FillRectangle(grayBrush, squareSize * n, 0, 100, squareSize* n);
			SolidBrush whiteBrush = new SolidBrush(Color.White);
			foreach (var coord in grid.GetCoordsCellsAlive()) {
				if (grid.TabCells[coord.x, coord.y].isAlive) {
					g.FillRectangle(whiteBrush, coord.y * squareSize, coord.x * squareSize, squareSize, squareSize);
				}
			}
		}
	}
}