// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.cs">
// Copyright (c) 2013-2014 https://github.com/johncrim/conductr.  
// </copyright>
// Licensed under the <a href="https://github.com/johncrim/conductr/blob/master/LICENSE">MIT License</a>;
// you may not use this file except in compliance with the License.
// --------------------------------------------------------------------------------------------------------------------

namespace Conductr.Service.Startup
{
	using System;
	using System.Diagnostics.Contracts;
	using System.IO;
	using System.Linq;
	using System.Threading;

	using Microsoft.Owin.Hosting;


	internal class App
	{
		public const string DefaultServerUrl = "http://+:7063/";

		private static readonly ManualResetEvent s_exitEvent = new ManualResetEvent(false);

		private static DirectoryInfo s_appDirectory;
 
		public static DirectoryInfo ApplicationDirectory
		{
			get { return s_appDirectory ?? (s_appDirectory = FindWebAppDirectory()); }
			set
			{
				Contract.Requires<ArgumentNullException>(value != null);
				Contract.Requires<FileNotFoundException>(value.Exists);

				s_appDirectory = value;
			}
		}

		private static bool IsValidWebAppDirectory(DirectoryInfo dir)
		{
			return dir.GetDirectories("web").SingleOrDefault() != null;
		}

		private static DirectoryInfo FindWebAppDirectory()
		{
			var dir = new DirectoryInfo(Environment.CurrentDirectory);
			while (dir != null)
			{
				if (IsValidWebAppDirectory(dir))
				{
					return dir;
				}
				dir = dir.Parent;
			}

			throw new InvalidOperationException("Could not find ./web directory by walking up from " + Environment.CurrentDirectory);
		}

		private static bool Initialize(string[] args)
		{
			// Default exit code: an error occurred
			Environment.ExitCode = -1;

			// Handling of Ctrl+C
			s_exitEvent.Reset();
			Console.CancelKeyPress += (sender, eventArgs) =>
			{
				eventArgs.Cancel = true;
				s_exitEvent.Set();
				Console.Out.WriteLine("  Ctrl+C pressed");
				Environment.ExitCode = 0; // Healthy exit
			};

			// TODO: Parse args, set app directory, etc.

			return true;
		}

		internal static void Main(string[] args)
		{
			if (! Initialize(args))
			{
				return;
			}

			Console.Out.WriteLine("Starting Yobby in {0}...", Environment.CurrentDirectory);
			Console.Out.WriteLine("(Press Ctrl+C to exit)");

			// TODO: Read from config?
			string serverUrl = DefaultServerUrl;

			// Start OWIN host 
			using (WebApp.Start<OwinConfig>(serverUrl))
			{
				Console.Out.WriteLine("Web server started: {0}", serverUrl);

				s_exitEvent.WaitOne();
			}

			Console.Out.WriteLine("Exiting Conductr...");
		}

	}
}
