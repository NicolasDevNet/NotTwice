using Assets.com.nottwice;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.TestTools;
using UnityEngine;
using Assets.com.nottwice.events.Runtime.Components;
using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using UnityEngine.Events;

namespace Assets.Tests.PlayMode.EventsTests.Components
{
	[ExcludeFromCodeCoverage]
	public class GameEventListenerTests
	{
		private Mock<ILogger> _loggerStub;
		private GameEventListener _sut;

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
			_sut = DisabledComponentsFactory.Create<GameEventListener>();

			GameEvent gameEvent = ScriptableObject.CreateInstance<GameEvent>();

			_sut.Event = gameEvent;

			//Act
			_sut.gameObject.SetActive(true);

			//Assert
			Assert.AreEqual(1, gameEvent.GetGameEventListenerCount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator OnDisable_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<GameEventListener>();

			GameEvent gameEvent = ScriptableObject.CreateInstance<GameEvent>();

			_sut.Event = gameEvent;

			//Act
			_sut.gameObject.SetActive(true);
			_sut.gameObject.SetActive(false);

			//Assert
			Assert.AreEqual(0, gameEvent.GetGameEventListenerCount());

			yield return null;
		}

		[UnityTest]
		public IEnumerator OnEventRaised_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<GameEventListener>();

			GameEvent gameEvent = ScriptableObject.CreateInstance<GameEvent>();
			gameEvent.name = "test";

			_sut.Event = gameEvent;

			bool expectedResponse = false;

			UnityEvent response = new UnityEvent();
			response.AddListener(() => expectedResponse = true);

			_sut.Response = response;

			//Act
			_sut.OnEventRaised();

			//Assert
			Assert.True(expectedResponse);

			_loggerStub.Verify(p => p.Log(LogType.Log, "Event raise: test"), Times.Once);

			yield return null;
		}
	}
}
