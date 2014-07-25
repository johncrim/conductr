// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwinConfig.cs">
// Copyright (c) 2013-2014 https://github.com/johncrim/conductr.  
// </copyright>
// Licensed under the <a href="https://github.com/johncrim/conductr/blob/master/LICENSE">MIT License</a>;
// you may not use this file except in compliance with the License.
// --------------------------------------------------------------------------------------------------------------------

namespace Conductr.Service.Startup
{
	using System.IO;
	using System.Web.Http;

	using Microsoft.Owin;
	using Microsoft.Owin.Diagnostics;
	using Microsoft.Owin.FileSystems;
	using Microsoft.Owin.StaticFiles;

	using Owin;


	/// <summary>
	/// Configures Owin/Katana web server.
	/// </summary>
	public sealed class OwinConfig
	{

		public void Configuration(IAppBuilder appBuilder)
		{
			appBuilder.UseTracerLogging();
			if (!App.IsRunningInMono ()) 
			{
				appBuilder.TraceExceptions (false, true);
			}
			appBuilder.LogHttpRequests(true, false);

			appBuilder.UseStaticFiles(new StaticFileOptions()
			                          {
				                          RequestPath = new PathString(""),
										  FileSystem = new PhysicalFileSystem(Path.Combine(App.ApplicationDirectory.FullName, "web"))
			                          });

			// Configure Web API for self-host. 
			HttpConfiguration config = new HttpConfiguration();
			config.MapHttpAttributeRoutes();
			appBuilder.UseWebApi(config);

			appBuilder.UseErrorPage(ErrorPageOptions.ShowAll);
		}

	}

}
