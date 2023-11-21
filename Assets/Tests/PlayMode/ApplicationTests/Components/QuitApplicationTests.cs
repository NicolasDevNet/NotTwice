using Assets.com.nottwice.application.Runtime.Components;
using Assets.com.nottwice.application.Runtime.Proxies;
using Assets.com.nottwice;
using Moq;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;
using System.Collections;

namespace Assets.Tests.PlayMode.ApplicationTests.Components
{
	[ExcludeFromCoverage]
	public class QuitApplicationTests
	{
		private Mock<ILogger> _loggerStub;
		private Mock<IApplication> _applicationStub;
		private QuitApplication _sut;

		[SetUp]
		public void SetUp()
		{
			_loggerStub = new Mock<ILogger>();
			_applicationStub = new Mock<IApplication>();

			ApplicationInstancesContainer.Logger = _loggerStub.Object;
			ApplicationInstancesContainer.Application = _applicationStub.Object;
		}

		[UnityTest]
		public IEnumerator ExecuteQuitApplication_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<QuitApplication>();

			//Act
			_sut.ExecuteQuitApplication();

			//Assert
			_loggerStub.Verify(p => p.Log(LogType.Log, "Try to quit application"), Times.Once);
			_applicationStub.Verify(p => p.Quit(), Times.Once);

			yield return null;
		}
	}
}
