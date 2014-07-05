// // -----------------------------------------------------------------------
// <copyright file="TestClass.cs" company="PrecisionDemand">
// Copyright (c) 2014 PrecisionDemand.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System;
using System.Diagnostics.Contracts;

namespace Yobby.JobApi
{

	/// <summary>
	/// TODO: Delete me
	/// </summary>
	public sealed class TestClass
	{
		public void Method(string value)
		{
			Contract.Requires<ArgumentNullException>(value != null);
		}
	}

}