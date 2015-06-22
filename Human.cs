using System;

namespace ifElse
{
	public class Human
	{
		public Point position;
		public string gender;
		public Human () {
			position = World.map [World.random.Next (World.map.Count)].position;
			gender = (World.random.Next (2) == 0) ? "Male" : "Female";
		}
	}
}

