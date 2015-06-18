using System;
using System.Collections.Generic;

namespace ifElse {
	public class World {
		public static int seed = 1234567890;
		public static int size = 5;
		public static Random random;
		public static List<Tile> map = new List<Tile> ();

		//Generates a random world from the given seed
		public static void generate () {
			random = new Random (seed);
			//Add a starting elevation point at (0, 0) with a randomized height
			map.Add (new Tile (new Point (0, 0), random.Next (-5, 6)));
			//for all coordinates in the giving size
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
		public static int getElevationAt (Point location) {
			if (!tileExistsAtPoint (location)) {
				int totalWeight = 0;
				int totalElevation = 0;
				foreach (Tile neighbour in map) {
					int distance = location.distanceFrom (neighbour.position);
					totalWeight += distance;
					totalElevation += neighbour.elevation * distance;
				}
				int[] modFactor = new int[] { 0, 0, 1, 1, 1, 2, -1, -1, -1, -2 };
				//Add a new terrain point with the weighted average elevation + a random factor.
				map.Add (new Tile(location, (totalElevation / totalWeight) + modFactor [random.Next (modFactor.Length)]));
			}
			return tileAtPoint (location).elevation;
		}

		public static Tile tileAtPoint (Point pt) {
			foreach (Tile tl in map) {
				if (tl.position.x == pt.x && tl.position.y == pt.y)
					return tl;
			}
			return null;
		}
		public static bool tileExistsAtPoint (Point pt) {
			if (tileAtPoint (pt) != null)
				return true;
			else
				return false;
		}
