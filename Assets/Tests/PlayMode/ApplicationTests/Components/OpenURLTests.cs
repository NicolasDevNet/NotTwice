using Assets.com.nottwice.application.Runtime.Components;
using Assets.com.nottwice.application.Runtime.Proxies;
using Assets.com.nottwice;
using Moq;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;

namespace Assets.Tests.PlayMode.ApplicationTests.Components
{
	[ExcludeFromCoverage]
	public class OpenURLTests
	{
		private Mock<ILogger> _loggerStub;
		private Mock<IApplication> _applicationStub;
		private OpenURL _sut;

		[SetUp]
		public void SetUp()
		{
			_loggerStub = new Mock<ILogger>();
			_applicationStub = new Mock<IApplication>();

			ApplicationInstancesContainer.Logger = _loggerStub.Object;
			ApplicationInstancesContainer.Application = _applicationStub.Object;
		}

		[UnityTest]
		public IEnumerator ExecuteOpeningURL_Without_Parameter_MissingComponentException_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<OpenURL>();

			//Act
			MissingComponentException exception = Assert.Throws<MissingComponentException>(() => _sut.ExecuteOpeningURL());

			//Assert
			Assert.AreEqual("A StringVariable is needed to use this method.", exception.Message);

			yield return null;
		}

		[UnityTest]
		public IEnumerator ExecuteOpeningURL_Without_Parameter_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<OpenURL>();

			StringVariable stringVariable = ScriptableObject.CreateInstance<StringVariable>();

			stringVariable.Value = "testUrl";

			_sut.UrlToRedirect = stringVariable;

			//Act
			_sut.ExecuteOpeningURL();

			//Assert
			_applicationStub.Verify(p => p.OpenURL("testUrl"), Times.Once);
			_loggerStub.Verify(p => p.Log(LogType.Log, "Redirect to testUrl"), Times.Once);

			yield return null;
		}

		[UnityTest]
		public IEnumerator ExecuteOpeningURL_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<OpenURL>();

			StringVariable stringVariable = ScriptableObject.CreateInstance<StringVariable>();

			stringVariable.Value = "testUrl";

			//Act
			_sut.ExecuteOpeningURL(stringVariable);

			//Assert
			_applicationStub.Verify(p => p.OpenURL("testUrl"), Times.Once);
			_loggerStub.Verify(p => p.Log(LogType.Log, "Redirect to testUrl"), Times.Once);

			yield return null;
		}
	}
}
