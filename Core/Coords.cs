using System;

namespace Core {
	public struct Coords {
		private int _x;
		private int _y;
		
		public int x   { get => _x; set => _x = value; }
		public int y { get => _y; set => _y = value; }

		public Coords(int x, int y) {
			_x = x;
			_y = y;
		}
		
		public override string ToString() {
			return $"({_x}, {_y})";
		}
		
		public bool Equals(Coords other) {
			return _x == other._x && _y == other._y;
		}
		
	}
}