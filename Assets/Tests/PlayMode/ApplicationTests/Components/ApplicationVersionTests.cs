using Assets.com.nottwice;
using Assets.com.nottwice.application.Runtime.Components;
using Assets.com.nottwice.application.Runtime.Proxies;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.Tests.PlayMode.ApplicationTests.Components
{
	[ExcludeFromCoverage]
	public class ApplicationVersionTests
	{
		private Mock<ILogger> _loggerStub;
		private Mock<IApplication> _applicationStub;
		private ApplicationVersion _sut;

		[SetUp]
		public void SetUp()
		{
			_loggerStub = new Mock<ILogger>();
			_applicationStub = new Mock<IApplication>();

			ApplicationInstancesContainer.Logger = _loggerStub.Object;
			ApplicationInstancesContainer.Application = _applicationStub.Object;
		}

		[UnityTest]
		public IEnumerator OnEnable_MissingComponent_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<ApplicationVersion>();

			//Act
			_sut.gameObject.SetActive(true);

			//Assert
			LogAssert.Expect(LogType.Exception, "MissingComponentException: The TMPro.TextMeshProUGUI component is missing from the GameObject of the Assets.com.nottwice.application.Runtime.Components.ApplicationVersion component.");

			yield return null;
		}

		[UnityTest]
		public IEnumerator OnEnable_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<ApplicationVersion>();

			var textComponent = _sut.gameObject.AddComponent<TextMeshProUGUI>();

			textComponent.text = "v";

			_applicationStub.Setup(p => p.GetApplicationVersion())
				.Returns("1.0");

			//Act
			_sut.gameObject.SetActive(true);

			//Assert
			Assert.AreEqual("v1.0", textComponent.text);

			_applicationStub.Verify(p => p.GetApplicationVersion(), Times.Once);
			_loggerStub.Verify(p => p.Log(LogType.Log, "The application version is displayed"), Times.Once);

			yield return null;
		}
	}
}
