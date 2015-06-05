using System;

namespace ifElse {
	public class Point {
		public int x;
		public int y;

		public Point (int X, int Y) {
			x = X;
			y = Y;
		}

		public int distanceFrom (Point pt) {
			double dx = (x - pt.x) * (x - pt.x);
			double dy = (y - pt.y) * (y - pt.y);
			return Convert.ToInt32 (Math.Sqrt (dx + dy));
		}
		public Point midPointBetween (Point min, Point max) {
			return new Point (max.x - min.x, max.y - min.y);
		}

		public Point closestNeighbour () {
			int closestDistance = 100000;
			Point closestPoint = this;
			foreach (Point pt in World.elevationMap.Keys) {
				if (distanceFrom (pt) < closestDistance && pt != this) {
					closestDistance = distanceFrom (pt);
					closestPoint = pt;
				}
			}
			return closestPoint;
		}
	}
}

