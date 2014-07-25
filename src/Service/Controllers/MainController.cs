// // --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainController.cs">
// Copyright (c) 2013-2014 https://github.com/johncrim/conductr.  
// </copyright>
// Licensed under the <a href="https://github.com/johncrim/conductr/blob/master/LICENSE">MIT License</a>;
// you may not use this file except in compliance with the License.
// --------------------------------------------------------------------------------------------------------------------


namespace Conductr.Service.Controllers
{
	using System.Web.Http;


	/// <summary>
	/// Main Web API (REST) Controller.
	/// </summary>
	[RoutePrefix("api")]
	public sealed class MainController : ApiController
	{
		public MainController()
		{}

		[Route(""), HttpGet]
		public string Default()
		{
			return "default API response";
		}
	}

}