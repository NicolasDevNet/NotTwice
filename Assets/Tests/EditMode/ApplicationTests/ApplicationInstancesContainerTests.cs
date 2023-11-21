using Assets.com.nottwice;
using Assets.com.nottwice.application.Runtime.Proxies;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.Tests.EditMode.ApplicationTests
{
	[ExcludeFromCoverage]
	public class ApplicationInstancesContainerTests
	{
		[Test]
		public void GetLogger_NotNull_Test()
		{
			//Act
			ILogger logger = ApplicationInstancesContainer.Logger;

			//Assert
			Assert.NotNull(logger);
		}

		[Test]
		public void GetApplication_NotNull_Test()
		{
			//Act
			IApplication application = ApplicationInstancesContainer.Application;

			//Assert
			Assert.NotNull(application);
		}
	}
}
