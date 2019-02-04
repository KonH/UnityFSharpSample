using System;
using GameLogics;

namespace ConsoleRunner {
	class Program {
		static void Main(string[] args) {
			var state = new Logics.GameState(0);
			Console.WriteLine(state);
			var result1 = Logics.addScore(state, 100);
			Console.WriteLine((result1 != null) ? result1.Value.ToString() : "can't perform");
			var result2 = Logics.addScore(state, -100);
			Console.WriteLine((result2 != null) ? result2.Value.ToString() : "can't perform");
			Console.ReadKey();
		}
	}
}
