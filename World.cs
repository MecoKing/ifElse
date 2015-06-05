﻿using System;
using System.Collections.Generic;

namespace ifElse {
	public class World {
		public static int seed = 1234567890;
		public static Random random;
		public static Dictionary<Point, int> elevationMap = new Dictionary<Point, int> ();

		public static void generate () {
			random = new Random (seed);
			elevationMap.Add (new Point (0, 0), random.Next (-5, 6));
			for (int y = -5; y < 6; y++) {
				for (int x = -5; x < 6; x++) {
					int localElevation = getElevationAt (new Point (x, y));
					if (localElevation < 0)
						Console.Write ("{0} ", localElevation);
					else
						Console.Write (" {0} ", localElevation);
				}
				Console.WriteLine ();
			}
		}

		public static int getElevationAt (Point pt) {
			if (!elevationMap.ContainsKey (pt)) {
				int totalWeight = 0;
				int totalElevation = 0;
				foreach (Point neighbour in elevationMap.Keys) {
					totalWeight += pt.distanceFrom (neighbour);
					totalElevation += elevationMap [neighbour] * pt.distanceFrom (neighbour);
				}
				int[] modFactor = new int[] { 0, 0, 1, 1, 1, 2, -1, -1, -1, -2 };
				elevationMap.Add (pt, (totalElevation / totalWeight) + modFactor [random.Next (modFactor.Length)]);
			}
			return elevationMap [pt];
		}
		public static bool waterIsAt (Point pt) {
			return false;
		}
	}
}

