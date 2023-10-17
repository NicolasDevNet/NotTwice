using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Events;
using NUnit.Framework;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

namespace Assets.NotTwice.Tools.PlayModeTests.Runtime.Components.Events
{
	public class GameEventListenerTests
	{
		[UnityTest]
		public IEnumerator OnEnableTest()
		{
			//Arrange
			FakeGameEventListener sut = FormatterServices.GetUninitializedObject(typeof(FakeGameEventListener)) as FakeGameEventListener;

			sut.Event = ScriptableObject.CreateInstance<GameEvent>();

			//Act
			sut.OnEnable();

			//Assert
			Assert.AreEqual(1, sut.Event.GetGameEventListenerCount());
			yield return null;
		}

		[UnityTest]
		public IEnumerator OnDisableTest()
		{
			//Arrange
			FakeGameEventListener sut = FormatterServices.GetUninitializedObject(typeof(FakeGameEventListener)) as FakeGameEventListener;

			sut.Event = ScriptableObject.CreateInstance<GameEvent>();

			sut.OnEnable();

			//Act
			sut.OnDisable();

			//Assert
			Assert.AreEqual(0, sut.Event.GetGameEventListenerCount());
			yield return null;
		}

		[UnityTest]
		public IEnumerator OnEventRaisedTest()
		{
			//Arrange
			FakeGameEventListener sut = FormatterServices.GetUninitializedObject(typeof(FakeGameEventListener)) as FakeGameEventListener;

			sut.Response = new UnityEvent();

			bool wasCalled = false;

			sut.Response.AddListener(() => wasCalled = true);

			//Act
			sut.OnEventRaised();

			//Assert
			Assert.IsTrue(wasCalled);

			yield return null;
		}
	}
}
