using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Out.WriteLine("Starting Yobby in {0}", Environment.CurrentDirectory);
			Console.Out.WriteLine("(Press any key to exit)");
			Console.In.Read();
		}
	}
}
