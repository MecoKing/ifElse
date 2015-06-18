using System;

namespace ifElse {
	public class Tile {
		
		public Point position;
		public int elevation;
		public bool isWaterSpring;

		public Tile (Point location, int height) {
			position = location;
			elevation = height;
			isWaterSpring = (World.random.Next (20) == 0);
		}

		public bool hasWater () {
			if (isWaterSpring)
				return true;
			else {
				if (World.tileExistsAtPoint (position.northPoint)) {
					Tile northTile = World.tileAtPoint (position.northPoint);
					if (northTile.elevation > elevation && northTile.hasWater ())
						return true;
				}
				if (World.tileExistsAtPoint (position.eastPoint)) {
					Tile eastTile = World.tileAtPoint (position.eastPoint);
					if (eastTile.elevation > elevation && eastTile.hasWater ())
						return true;
				}
				if (World.tileExistsAtPoint (position.southPoint)) {
					Tile southTile = World.tileAtPoint (position.southPoint);
					if (southTile.elevation > elevation && southTile.hasWater ())
						return true;
				}
				if (World.tileExistsAtPoint (position.westPoint)) {
					Tile westTile = World.tileAtPoint (position.westPoint);
					if (westTile.elevation > elevation && westTile.hasWater ())
						return true;
				}
				return false;
			}
		}
	}
}

