using System;
using System.Collections.Generic;

namespace ifElse {
	public class World {
		public static int seed = 0;
		public static Random random;
		public static Dictionary<Point, int> elevationMap = new Dictionary<Point, int> ();

		public static void generate () {
			random = new Random (seed);
			for (int elv = 0; elv < random.Next (10, 16); elv++) {
				getElevationAt (new Point (random.Next (-100, 101), random.Next (-100, 101)));
			}
		}

		public static int getElevationAt (Point pt) {
			if (!elevationMap.ContainsKey (pt)) {
				Point neighbour = pt.closestNeighbour ();
				int distance = pt.distanceFrom (neighbour );
				int elevation = random.Next (elevationMap [neighbour] - distance, elevationMap [neighbour] + distance);
				elevationMap.Add (pt, elevation);
			}
			return elevationMap [pt];
		}
		public static bool waterIsAt (Point pt) {
			return false;
		}
	}
}

