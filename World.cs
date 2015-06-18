﻿using System;
using System.Collections.Generic;

namespace ifElse {
	public class World {
		public static int seed = 1234567890;
		public static int size = 5;
		public static Random random;
		public static List<Tile> map = new List<Tile> ();

		//Generates a random world from the given seed
		public static void generate () {
			//create a new random object with the world's seed
			random = new Random (seed);
			//Add a starting elevation point at (0, 0) with a randomized height
			map.Add (new Tile (new Point (0, 0), random.Next (-5, 6)));
			//for all coordinates in the giving size
			for (int y = -size; y < size+1; y++) {
				for (int x = -size; x < size+1; x++) {
					Point localPoint = new Point (x, y);
					getElevationAt (localPoint);
				}
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

		public static void printElevationMapAboutPoint (Point origin) {
			for (int y = origin.y-size; y < origin.y+size + 1; y++) {
				for (int x = origin.x-size; x < origin.x+size + 1; x++) {
					Point localPoint = new Point (x, y);
					if (tileExistsAtPoint (localPoint)) {
						int localElevation = tileAtPoint (localPoint).elevation;
						if (localElevation < -1)
							Console.ForegroundColor = ConsoleColor.Blue;
						else if (localElevation < 0)
							Console.ForegroundColor = ConsoleColor.Cyan;
						else if (localElevation < 2)
							Console.ForegroundColor = ConsoleColor.Green;
						else if (localElevation < 4)
							Console.ForegroundColor = ConsoleColor.Yellow;
						else
							Console.ForegroundColor = ConsoleColor.Red;

						Console.Write ("# ");
					} else
						Console.Write ("  ");
				}
				Console.WriteLine ();
			}
		}
		public static void printWaterMapAboutPoint (Point origin) {
			for (int y = origin.y-size; y < origin.y+size + 1; y++) {
				for (int x = origin.x-size; x < origin.x+size + 1; x++) {
					Point localPoint = new Point (x, y);
					if (tileExistsAtPoint (localPoint)) {
						Tile localTile = tileAtPoint (localPoint);
						if (localTile.isWaterSpring) {
							Console.ForegroundColor = ConsoleColor.Blue;
							Console.Write ("o ");
						} else if (localTile.hasWater ()) {
							Console.ForegroundColor = ConsoleColor.Blue;
							Console.Write ("~ ");
						} else {
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write ("# ");
						}
					} else
						Console.Write ("  ");
				}
				Console.WriteLine ();
			}
		}
	}
}