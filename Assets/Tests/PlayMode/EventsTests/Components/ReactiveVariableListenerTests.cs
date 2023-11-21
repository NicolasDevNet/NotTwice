using Assets.com.nottwice.events.Runtime.Components;
using Assets.com.nottwice;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables;

namespace Assets.Tests.PlayMode.EventsTests.Components
{
	[ExcludeFromCoverage]
	public class ReactiveVariableListenerTests
	{
		private Mock<ILogger> _loggerStub;
		private ReactiveVariableListener _sut;

		[SetUp]
		public void SetUp()
		{
			_loggerStub = new Mock<ILogger>();

			ApplicationInstancesContainer.Logger = _loggerStub.Object;
		}

		[UnityTest]
		public IEnumerator OnEnable_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<ReactiveVariableListener>();

			ReactiveBoolVariableEvent fakeBoolEvent = ScriptableObject.CreateInstance<ReactiveBoolVariableEvent>();
			fakeBoolEvent.name = "testBool";
			ReactiveIntVariableEvent fakeIntEvent = ScriptableObject.CreateInstance<ReactiveIntVariableEvent>();
			fakeIntEvent.name = "testInt";

			_sut.ReactiveVariableEvents.Add(fakeBoolEvent);
			_sut.ReactiveVariableEvents.Add(fakeIntEvent);

			//Act
			_sut.OnEnable();

			//Assert
			_loggerStub.Verify(p => p.Log(LogType.Log, "Subscribe to testBool"), Times.Once);
			_loggerStub.Verify(p => p.Log(LogType.Log, "Subscribe to testInt"), Times.Once);

			yield return null;
		}

		[UnityTest]
		public IEnumerator OnDisable_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<ReactiveVariableListener>();

			ReactiveBoolVariableEvent fakeBoolEvent = ScriptableObject.CreateInstance<ReactiveBoolVariableEvent>();
			fakeBoolEvent.name = "testBool";
			ReactiveIntVariableEvent fakeIntEvent = ScriptableObject.CreateInstance<ReactiveIntVariableEvent>();
			fakeIntEvent.name = "testInt";

			_sut.ReactiveVariableEvents.Add(fakeBoolEvent);
			_sut.ReactiveVariableEvents.Add(fakeIntEvent);

			//Act
			_sut.OnDisable();

			//Assert
			_loggerStub.Verify(p => p.Log(LogType.Log, "UnSubscribe from testBool"), Times.Once);
			_loggerStub.Verify(p => p.Log(LogType.Log, "UnSubscribe from testInt"), Times.Once);

			yield return null;
		}
	}
}
