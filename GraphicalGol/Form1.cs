using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalGol {
	public partial class Form1 : Form {
		private Game _game;
		public Form1(int n = 5) {

			_game = new Game(n);
			
			InitializeComponent(n);
			
			Timer myTimer = new Timer();
			myTimer.Interval = 60;
			Paint += pictureBox1_Paint;
			myTimer.Tick += MyTimer_Tick;

			CreateButton("Start", n, new Point(n * squareSize, 0), (sender, args) => myTimer.Start());
			CreateButton("Stop", n, new Point(n * squareSize, 80), (sender, args) => myTimer.Stop());
			CreateButton("Random Pattern", n, new Point(n * squareSize, 160), (sender, args) =>{
				_game = new Game(n, true);
				myTimer.Stop();
				Refresh();
			});
			
			CreateButton("Reset", n, new Point(n * squareSize, 240), (sender, args) => {
				_game = new Game(n);
				myTimer.Stop();
				Refresh();
			});
		}

		private void CreateButton(string name, int n, Point location, EventHandler function) {
			Button button = new Button();
			button.Location = location;
			button.BackColor = Color.Beige;
			button.Size = new Size(100, 70);
			button.Text = name;
			button.Click += function;
			Controls.Add(button);
		}
		private void MyTimer_Tick(object sender, EventArgs e) {
			_game.grid.UpdateGrid();
			Refresh();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e) {
			_game.Paint(e.Graphics, squareSize);
		}
		
	}
}