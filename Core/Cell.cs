namespace Core {
	public class Cell {
		private bool _isAlive;
		
		public bool isAlive { 
			get => _isAlive;
			set => _isAlive = value;
		}
		
		private bool _nextState;

		public bool nextState { 
			get => _nextState;
			set => _nextState = value;
		}

		public Cell(bool state) {
			isAlive = state;
		}

		public void ComeAlive() {
			nextState = true;
		}

		public void PassAway() {
			nextState = false;
		}
		
		public void Update() {
			isAlive = nextState;
		}
	}
}