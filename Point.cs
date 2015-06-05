using System;

namespace ifElse {
	public class Point {
		public int x;
		public int y;

		public Point northPoint { get { return new Point (x, y - 1); } }
		public Point eastPoint { get { return new Point (x + 1, y); } }
		public Point southPoint { get { return new Point (x, y + 1); } }
		public Point westPoint { get { return new Point (x - 1, y); } }

		public Point (int X, int Y) {
			x = X;
			y = Y;
		}

		public override string ToString ()
		{
			return string.Format ("({0}, {1})", x, y);
		}

		public int distanceFrom (Point pt) {
			double dx = (x - pt.x) * (x - pt.x);
			double dy = (y - pt.y) * (y - pt.y);
			return Convert.ToInt32 (Math.Sqrt (dx + dy));
		}
		public Point midPointBetween (Point min, Point max) {
			return new Point (max.x - min.x, max.y - min.y);
		}
	}
}

