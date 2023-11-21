using Assets.com.nottwice.application.Runtime.Components;
using Assets.com.nottwice.application.Runtime.Proxies;
using Assets.com.nottwice;
using Moq;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using Assets.com.nottwice.audio.Runtime.Components;

namespace Assets.Tests.PlayMode.AudioTests.Components
{
	[ExcludeFromCoverage]
	public class NotDestroyableAudioTests
	{
		private Mock<ILogger> _loggerStub;
		private NotDestroyableAudio _sut;

		[SetUp]
		public void SetUp()
		{
			_loggerStub = new Mock<ILogger>();

			ApplicationInstancesContainer.Logger = _loggerStub.Object;
		}

		[UnityTest]
		public IEnumerator OnEnable_MissingComponent_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<NotDestroyableAudio>();

			//Act
			_sut.gameObject.SetActive(true);

			//Assert
			LogAssert.Expect(LogType.Exception, "MissingComponentException: The AudioSource component is missing from the gameobject.");

			yield return null;
		}

		[UnityTest]
		public IEnumerator OnEnable_FirstInstanceRetained_Test()
		{
			//Arrange
			_sut = DisabledComponentsFactory.Create<NotDestroyableAudio>();

			_sut.gameObject.AddComponent<AudioSource>();

			//Act
			_sut.gameObject.SetActive(true);

			//Assert
			_loggerStub.Verify(p => p.Log(LogType.Log, "The first Audio instance is retained."), Times.Once);

			Assert.NotNull(_sut.AudioSource);

			yield return null;
		}

		[UnityTest]
		public IEnumerator OnEnable_OldInstanceReplaced_Test()
		{
			//Arrange
			//Arrange old AudioSource
			GameObject oldInstanceParent = new GameObject();
			oldInstanceParent.SetActive(false);
			oldInstanceParent.AddComponent<NotDestroyableAudio>();

			AudioSource oldAudioSource = oldInstanceParent.AddComponent<AudioSource>();
			oldAudioSource.clip = AudioClip.Create("test1", 1, 1, 1000, false);

			oldInstanceParent.SetActive(true);

			//Arrange Sut
			_sut = DisabledComponentsFactory.Create<NotDestroyableAudio>();

			AudioSource newAudioSource = _sut.gameObject.AddComponent<AudioSource>();
			newAudioSource.clip = AudioClip.Create("test2", 1, 1, 1000, false);

			//Act
			_sut.gameObject.SetActive(true);

			//Assert
			_loggerStub.Verify(p => p.Log(LogType.Log, "The old Audio instance is replaced."), Times.Once);

			Assert.NotNull(_sut.AudioSource);

			yield return null;
		}

		[UnityTest]
		public IEnumerator OnEnable_OldInstanceRetained_Test()
		{
			//Arrange
			//Arrange old AudioSource
			GameObject oldInstanceParent = new GameObject();
			oldInstanceParent.SetActive(false);
			oldInstanceParent.AddComponent<NotDestroyableAudio>();

			AudioSource oldAudioSource = oldInstanceParent.AddComponent<AudioSource>();
			oldAudioSource.clip = AudioClip.Create("test1", 1, 1, 1000, false);

			oldInstanceParent.SetActive(true);

			//Arrange Sut
			_sut = DisabledComponentsFactory.Create<NotDestroyableAudio>();

			AudioSource newAudioSource = _sut.gameObject.AddComponent<AudioSource>();
			newAudioSource.clip = AudioClip.Create("test1", 1, 1, 1000, false);

			//Act
			_sut.gameObject.SetActive(true);

			//Assert
			_loggerStub.Verify(p => p.Log(LogType.Log, "The old Audio instance is retained."), Times.Once);

			yield return null;
		}
	}
}
