using Assets.com.nottwice.events.Runtime.Components;
using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice;
using Moq;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;

namespace Assets.Tests.PlayMode.EventsTests.Components
{
	[ExcludeFromCoverage]
	public class OnPointerExitEventTests
	{
		private Mock<ILogger> _loggerStub;
		private OnPointerExitEvent _sut;

		[SetUp]
		public void SetUp()
		{
			_loggerStub = new Mock<ILogger>();

			ApplicationInstancesContainer.Logger = _loggerStub.Object;
		}

		[UnityTest]
		public IEnumerator OnPointerEnter_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<OnPointerExitEvent>();

			GameEvent gameEvent = ScriptableObject.CreateInstance<GameEvent>();
			_sut.Event = gameEvent;

			_sut.gameObject.name = "test";

			//Act
			_sut.OnPointerExit(null);

			//Assert
			_loggerStub.Verify(p => p.Log(LogType.Log, "Pointer exit from test"), Times.Once);

			yield return null;
		}
	}
}
