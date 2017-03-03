using System;
using System.Collections;
using System.Diagnostics;

namespace NoMansGame
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Random random = new Random();
			Stopwatch watch = new Stopwatch();
			watch.Start();
			bool load = false;

			string bloc = "O";
			string perso = "I";

			ConsoleKey lastKey = ConsoleKey.NoName;
			bool fly = false;

			int walk = 0;

			Console.WriteLine("press a key to start");
			Console.ReadKey();

			Queue l1 = new Queue();
			Queue l2 = new Queue();

			for (int i = 0; i < Console.BufferWidth; i++)
			{
				l1.Enqueue(" ");
				if (i >= (Console.BufferWidth / 6))
				{
					if (random.Next(100) <= 10)
					{
						l2.Enqueue(bloc);
						//Console.WriteLine("more");
					}
					else
					{
						l2.Enqueue("_");
					}
				}
				else
				{
					l2.Enqueue("_");
				}
			}

			//Console.ReadKey();

			bool ok = true;
			int score = 0;

			while (ok)
			{
				if (load || watch.Elapsed.Milliseconds >= 100)
				{
					Console.Clear();

					if (lastKey == ConsoleKey.UpArrow)
					{
						fly = true;
						walk = 0;
					}
					else
					{
						if (walk >= 3)
						{
							fly = false;
						}

						walk++;
					}

					lastKey = ConsoleKey.NoName;

					l2.Dequeue();
					if (random.Next(100) <= 10)
						l2.Enqueue(bloc);
					else
						l2.Enqueue("_");


					for (int i = 0; i < l1.Count; i++)
					{
						if (i == 2 && fly)
							Console.Write(perso);
						else
							Console.Write(l1.ToArray()[i]);
					}
					for (int i = 0; i < l2.Count; i++)
					{
						if (i == 2 && !fly)
						{
							if (l2.ToArray()[i] == bloc)
								ok = false;
							else 
								Console.Write(perso);
						}
						else
							Console.Write(l2.ToArray()[i]);
					}

					score++;

					watch.Restart();
					load = false;
					continue;
				}

				if (Console.KeyAvailable)
				{
					lastKey = Console.ReadKey(true).Key;
					if (fly)
					{
						lastKey = ConsoleKey.NoName;
					}
					else
					{
						load = true;
					}
				}
			}

			Console.Clear();
			Console.WriteLine("GAME OVER ");
			Console.WriteLine("score : " + score);
			       
		}
	}
}
