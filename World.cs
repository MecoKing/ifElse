using System;
using System.Collections.Generic;

namespace ifElse {
	public class World {
		public static int seed = 1234567890;
		public static int size = 5;
		public static Random random;
		public static Dictionary<Point, int> elevationMap = new Dictionary<Point, int> ();
		public static List<Point> waterSprings = new List<Point> ();

		//Generates a random world from the given seed
		public static void generate () {
			random = new Random (seed);
			for (int i = 0; i < random.Next (4, 9); i++) {
				waterSprings.Add (new Point (random.Next (-size, size+1), random.Next (-size, size+1)));
			}
			elevationMap.Add (new Point (0, 0), random.Next (-5, 6));
			for (int y = -size; y < size+1; y++) {
				for (int x = -size; x < size+1; x++) {
					int localElevation = getElevationAt (new Point (x, y));

					if (localElevation < 0)
						Console.Write ("{0} ", localElevation);
					else
						Console.Write (" {0} ", localElevation);
				}
				Console.WriteLine ();
			}
		}

		//Returns the elevation value at a certain point.
		//If no elevation point exists yet, it generates a new one.
		public static int getElevationAt (Point pt) {
			if (!elevationMap.ContainsKey (pt)) {
				int totalWeight = 0;
				int totalElevation = 0;
				foreach (Point neighbour in elevationMap.Keys) {
					totalWeight += pt.distanceFrom (neighbour);
					totalElevation += elevationMap [neighbour] * pt.distanceFrom (neighbour);
				}
				int[] modFactor = new int[] { 0, 0, 1, 1, 1, 2, -1, -1, -1, -2 };
				//Add a new terrain point with the weighted average elevation + a random factor.
				elevationMap.Add (pt, (totalElevation / totalWeight) + modFactor [random.Next (modFactor.Length)]);
			}
			return elevationMap [pt];
		}

		public static bool waterIsAt (Point pt) {
			if (waterSprings.Contains (pt))
				return true;
			else
				return false;
		}
	}
}

