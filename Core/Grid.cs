using System;
using System.Collections.Generic;
using System.Linq;

namespace Core {
	public class Grid {
		private int _n;

		public int n {
			get => _n;
			set => _n = value;
		}
		
		Cell[,] TabCells ;


		public Grid(int nbCells, List<Coords> aliveCellsCoords) {
			n = nbCells;
			TabCells = new Cell[n, n];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++) {
					Coords coords = new Coords(i, j);
					bool state = aliveCellsCoords.Any(x => x.Equals(coords));
					TabCells[i, j] = new Cell(state);
				}
			}
			DisplayGrid();
		}

		public int GetNbAliveNeighboor(int i, int j) {
			int result = 0;
			var coordList = GetCoordsNeighboors(i, j);
			foreach (var coord in coordList) {
				if (TabCells[coord.x, coord.y].isAlive) {
					result++;
				}
			}
			return result;
		}

		public List<Coords> GetCoordsNeighboors(int x, int y) {
			var coordsList = new List<Coords>();
			for (int i = Math.Max(0, x-1); i < Math.Min(x+1, _n); i++) {
				for (int j = Math.Max(0, y-1); j < Math.Min(y+1, _n); j++) {
					coordsList.Add(new Coords(x, y));
				}
			}
			return coordsList;
		}

		public List<Coords> GetCoordsCellsAlive() {
			var coordsList = new List<Coords>();
			for (int i = 0; i < _n; i++) {
				for (int j = 0; j < _n; j++) {
					if(TabCells[i, j].isAlive)
						coordsList.Add(new Coords(i, j));
				}
			}
			return coordsList;
		}
		public void DisplayGrid() {
			string line = string.Join("", Enumerable.Repeat("+---", _n)) + "+";

			for (int i = 0; i < _n; i++) {
				Console.WriteLine(line);
				for (int j = 0; j < _n; j++) {
					Console.Write("| ");
					Console.Write(TabCells[i, j].isAlive ? "X" : " ");
					Console.Write(" ");
				}
				Console.WriteLine("|");
			}
			Console.WriteLine(line);
		}

		public void UpdateGrid() {
			for (int i = 0; i < _n; i++) {
				for (int j = 0; j < _n; j++) {
					bool state = TabCells[i, j].isAlive;
					bool result = false;
					int nbAlive = GetNbAliveNeighboor(i, j);
					if (nbAlive == 3) {
						result = true;
					}
					else if (nbAlive == 2) {
						result = state;
					}

					TabCells[i, j].nextState = result;
				}
			}

			foreach (var cell in TabCells) {
				cell.Update();
			}
		}
	}
}