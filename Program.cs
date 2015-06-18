using System;

namespace ifElse {
	class Program {
		public static void Main (string[] args) {
			World.generate ();

			World.printElevationMapAboutPoint (new Point (0, 0));
			Console.WriteLine ();
			World.printWaterMapAboutPoint (new Point (0, 0));
			Console.WriteLine ();
		}
	}
}